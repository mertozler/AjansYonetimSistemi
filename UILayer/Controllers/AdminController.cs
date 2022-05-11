using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Concrete;
using BusinessLayer.Utils;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SmsApiNode;
using SmsApiNode.Operations;

namespace Project.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly Context _context;
        private readonly ServiceManager _serviceManager = new ServiceManager(new EfServicesRepository());
        private readonly PackageManager _packageManager = new PackageManager(new EfPackageRepository());

        private CustomerPaymentsManager _customerPaymentsManager =
            new CustomerPaymentsManager(new EfCustomerPaymentsRepository());

        private readonly ServicePackageManager _servicePackageManager =
            new ServicePackageManager(new EfServicePackageRepository());

        private readonly CustomerServiceManager _customerServiceManager =
            new CustomerServiceManager(new EfCustomerServiceRepository());

        private CustomerEmployeeManager _customerEmployeeManager =
            new CustomerEmployeeManager(new EfCustomerEmployeeRepository());

        private PaymentRoutineTypesManager _paymentRoutineTypesManager =
            new PaymentRoutineTypesManager(new EfPaymentRouteTypesRepository());

        CustomerProdutcsManager _customerProductsManager =
            new CustomerProdutcsManager(new EfCustomerProductsRepository());

        private DemandManager _demandManager = new DemandManager(new EfDemandRepository());

        private CustomerProductsFileManager _customerProductsFileManager =
            new CustomerProductsFileManager(new EfCustomerProductsFileRepository());
        SettingsManager _settingsManager = new SettingsManager(new EfSettingsRepository());

        private MailSettingsManager _mailSettingsManager = new MailSettingsManager(new EfMailSettingsRepository());

        private DemandAnswerManager _demandAnswerManager = new DemandAnswerManager(new EfDemandAnswersRepository());
        private readonly ILogger<AdminController> _logger;
        private AnnouncementManager _announcementManager = new AnnouncementManager(new EfAnnouncementRepository());
        DigicellSMSSettingsManager _digicellSmsSettingsManager = new DigicellSMSSettingsManager(new EfDigicellSMSSettingsRepository());
        PeakcellSMSSettingsManager _peakcellSmsSettingsManager = new PeakcellSMSSettingsManager(new EfPeakcellSMSSettingsRepository());

        public AdminController(INotyfService notyf, IMapper mapper, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, Context context, ILogger<AdminController> logger)
        {
            _notyf = notyf;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
            _logger = logger;
        }


        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Admin Index test yapıyom");
            AdminIndexDTO model = new AdminIndexDTO();
            try
            {
                model.DemandCounter = _demandManager.GetList().Count;
                model.CustomerProductCounter = _customerProductsManager.GetList().Count;
                double totalIncome = 0;
                var customerPayments = _customerPaymentsManager.GetList();
                foreach (var item in customerPayments)
                {
                    totalIncome += item.PaymentPrice;
                }

                model.TotalIncome = totalIncome;
                var customerList = await (from user in _context.Users
                    join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    where (role.Name == "customer")
                    select user).ToListAsync();
                model.CustomerCounter = customerList.Count;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> DefineEmployee()
        {
            EmployeeList employeeList = new EmployeeList(_context, _userManager);
            EmployeeDefineAndListDTO employeModel = new EmployeeDefineAndListDTO();
            List<RoleListClass> roleList = new List<RoleListClass>();
            try
            {
                employeModel.EmployeeList = employeeList.GetAllEmployee().Result;
                var roles = _context.Roles.Where(x => x.Name == "designer" || x.Name == "marketing" || x.Name == "ops")
                    .ToList();
                foreach (var item in roles)
                {
                    roleList.Add(new RoleListClass
                    {
                        RoleName = item.Name,
                    });
                }

                employeModel.RoleList = roleList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(employeModel);
        }

        [HttpPost]
        public async Task<IActionResult> DefineEmployee(EmployeeDefineAndListDTO employeeData)
        {
            EmployeeDefineAndListDTO employeModel = new EmployeeDefineAndListDTO();
            MailService SendMail = new MailService();
            try
            {
                if (ModelState.IsValid)
                {
                    if (employeeData.Password == employeeData.ConfirmPassword)
                    {
                        var EmployeeUser = _mapper.Map<ApplicationUser>(employeeData);
                        EmployeeUser.Status = true;
                        EmployeeUser.PhoneNumber = "90" + employeeData.PhoneNumber;
                        EmployeeUser.Id = Guid.NewGuid().ToString();
                        var result = await _userManager.CreateAsync(EmployeeUser, employeeData.Password);
                        if (result.Succeeded)
                        {
                            var roleResult = await _userManager.AddToRoleAsync(EmployeeUser, employeeData.Role);
                            if (roleResult.Succeeded)
                            {
                                var token = await _userManager.GenerateEmailConfirmationTokenAsync(EmployeeUser);
                                var confirmationLink = Url.ActionLink("ConfirmMail", "Account",
                                    new {token, email = EmployeeUser.Email}, Request.Scheme);
                                string mailContext =
                                    "Üyeliğiniz başarıyla oluşturulmuştur, lütfen kaydınızı tamamlamak için <a href=" +
                                    confirmationLink + ">tıklayınız</a>";
                                SendMail.SendMailWithReceiverMailContextAndSubject(EmployeeUser.Email, mailContext,
                                    "Ajans Yönetim Sistemi: Üyeliğinizi Aktif Ediniz.");
                                _notyf.Success("Personel başarıyla kaydedildi!");
                                return RedirectToAction("DefineEmployee", "Admin");
                            }

                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                        }
                    }
                    else
                    {
                        _notyf.Error("Şifreler eşleşmiyor, lütfen tekrar deneyiniz.");
                    }
                }
                else
                {
                    _notyf.Error("Beklenmeyen bir hata oluştu");
                }

                EmployeeList employeeList = new EmployeeList(_context, _userManager);
                List<RoleListClass> roleList = new List<RoleListClass>();
                var roles = _context.Roles
                    .Where(x => x.Name == "designer" || x.Name == "marketing" || x.Name == "ops")
                    .ToList();
                foreach (var item in roles)
                {
                    roleList.Add(new RoleListClass
                    {

                        RoleName = item.Name,
                    });
                }

                employeModel.RoleList = roleList;
                employeModel.EmployeeList = employeeList.GetAllEmployee().Result;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(employeModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(string employeeID)
        {
            EditEmployeeDTO selectedEmployee = new EditEmployeeDTO();
            try
            {
                var user = await _userManager.FindByIdAsync(employeeID);
                var userRole = await _userManager.GetRolesAsync(user);
                selectedEmployee.Name = user.NameSurname;
                selectedEmployee.Email = user.Email;
                selectedEmployee.Role = userRole[0];
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return PartialView("_EmployeeModelPartial", selectedEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeDTO employeeData)
        {
            EditEmployeeDTO selectedEmployee = new EditEmployeeDTO();
            try
            {
                var user = await _userManager.FindByIdAsync(employeeData.EmployeeID);
                if (ModelState.IsValid)
                {
                    var userRole = await _userManager.GetRolesAsync(user);
                    user.NameSurname = employeeData.Name;
                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await _userManager.RemoveFromRoleAsync(user, userRole[0]);
                        var roleResult = await _userManager.AddToRoleAsync(user, employeeData.Role);
                        if (roleResult.Succeeded)
                        {
                            _notyf.Success("Personel başarıyla güncellendi");
                        }
                        else
                        {
                            _notyf.Error("Personel Güncellenirken bir hata oluştu");
                        }
                    }
                    else
                    {
                        _notyf.Error("Personel Güncellenirken bir hata oluştu");
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, item.Description);
                        }
                    }
                }
                else
                {
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        _notyf.Error("Personel güncellenirken bir hata oluştu. Hata mesajı: " + error.ErrorMessage);
                    }
                }

                var employeeRole = await _userManager.GetRolesAsync(user);
                selectedEmployee.Name = user.NameSurname;
                selectedEmployee.Email = user.Email;
                selectedEmployee.Role = employeeRole[0];
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return PartialView("_EmployeeModelPartial", selectedEmployee);
        }

        public async Task<IActionResult> DeleteEmployee(string EmployeeID)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(EmployeeID);
                user.Status = false;
                var result = await _userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    _notyf.Success("Personel başarıyla silindi");
                    return RedirectToAction("DefineEmployee", "Admin");
                }

                _notyf.Error("Personel silinirken bir hata oluştu.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return RedirectToAction("DefineEmployee", "Admin");
        }

        [HttpGet]
        public IActionResult Services()
        {
            ServicePackageandServiceListDTO ServicePackageandServiceList = new ServicePackageandServiceListDTO();
            List<ServiceListViewModel> serviceViewModelList = new List<ServiceListViewModel>();
            try
            {
                var allServices = _serviceManager.GetList();
                foreach (var service in allServices)
                {
                    if (service.Status == true)
                    {
                        ServiceListViewModel newServiceListViewModel = new ServiceListViewModel();
                        newServiceListViewModel.ServiceName = service.Name;
                        newServiceListViewModel.ServiceDescription = service.Description;
                        newServiceListViewModel.ServiceId = service.ID;
                        var servicePackageID = _servicePackageManager.GetPackageIDListByServiceId(service.ID);
                        string packageNames = "";
                        foreach (var packageID in servicePackageID)
                        {
                            var package = _packageManager.GetById(packageID.PackageID);
                            if (package != null)
                            {
                                packageNames = package.Name + ", " + packageNames;
                            }
                        }

                        newServiceListViewModel.ServicePackageName = packageNames;
                        serviceViewModelList.Add(newServiceListViewModel);
                    }
                }

                ServicePackageandServiceList.ServiceList = allServices;
                ServicePackageandServiceList.ServiceListViewModel = serviceViewModelList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(ServicePackageandServiceList);
        }

        [HttpPost]
        public IActionResult Services(ServicePackageandServiceListDTO data,
            IFormCollection selectedServicesIDforPackages)
        {
            ServicePackageandServiceListDTO ServicePackageandServiceList = new ServicePackageandServiceListDTO();
            try
            {
                var allServices = _serviceManager.GetList();
                ServicePackageandServiceList.ServiceList = allServices;
                if (ModelState.IsValid)
                {
                    if (data.selectedButtonId == 1)
                    {
                        ServicesValidator servicesValidator = new ServicesValidator();
                        var newService = _mapper.Map<Services>(data);
                        newService.Status = true;
                        ValidationResult results = servicesValidator.Validate(newService);
                        if (results.IsValid)
                        {
                            _serviceManager.Add(newService);
                            _notyf.Success("Hizmet başarıyla oluşturuldu");
                            return RedirectToAction("Services", "Admin");
                        }
                        else
                        {
                            foreach (var item in results.Errors)
                            {
                                if (item.PropertyName == "Name")
                                {
                                    ModelState.AddModelError("ServiceName", item.ErrorMessage);
                                }
                                else if (item.PropertyName == "Description")
                                {
                                    ModelState.AddModelError("ServiceDescription", item.ErrorMessage);
                                }

                            }

                            _notyf.Error("Hizmet oluşturulurken bir hata oldu");
                        }

                    }
                    else if (data.selectedButtonId == 2)
                    {
                        List<int> serviceIdArray = new List<int>();
                        foreach (var item in selectedServicesIDforPackages["ServiceId"])
                        {
                            serviceIdArray.Add(Convert.ToInt32(item));
                        }

                        PackageValidator packageValidator = new PackageValidator();
                        var newPackage = _mapper.Map<Package>(data);
                        newPackage.Status = true;
                        ValidationResult results = packageValidator.Validate(newPackage);
                        if (results.IsValid)
                        {
                            _packageManager.Add(newPackage);
                            foreach (var item in serviceIdArray)
                            {
                                ServicePackage newServicePackage = new ServicePackage();
                                newServicePackage.PackageID = newPackage.ID;
                                newServicePackage.ServiceID = item;
                                _servicePackageManager.Add(newServicePackage);
                            }

                            _notyf.Success("Paket başarıyla oluşturuldu");
                            return RedirectToAction("Services", "Admin");
                        }
                        else
                        {
                            foreach (var item in results.Errors)
                            {
                                if (item.PropertyName == "Name")
                                {
                                    ModelState.AddModelError("PackageName", item.ErrorMessage);
                                }
                                else if (item.PropertyName == "Description")
                                {
                                    ModelState.AddModelError("PackageDescription", item.ErrorMessage);
                                }

                            }

                            _notyf.Error("Paket oluşturulurken bir hata oldu");
                        }

                    }
                }
                else
                {
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        _notyf.Error("Bir hata oluştu. Hata mesajı: " + error.ErrorMessage);
                    }
                }

                List<ServiceListViewModel> serviceViewModelList = new List<ServiceListViewModel>();
                foreach (var service in allServices)
                {
                    if (service.Status == true)
                    {
                        ServiceListViewModel newServiceListViewModel = new ServiceListViewModel();
                        newServiceListViewModel.ServiceName = service.Name;
                        newServiceListViewModel.ServiceDescription = service.Description;
                        newServiceListViewModel.ServiceId = service.ID;
                        var servicePackageID = _servicePackageManager.GetPackageIDListByServiceId(service.ID);
                        string packageNames = "";
                        foreach (var packageID in servicePackageID)
                        {
                            var package = _packageManager.GetById(packageID.PackageID);
                            if (package != null)
                            {
                                packageNames = package.Name + ", " + packageNames;
                            }
                        }

                        newServiceListViewModel.ServicePackageName = packageNames;
                        serviceViewModelList.Add(newServiceListViewModel);
                    }
                }

                ServicePackageandServiceList.ServiceList = allServices;
                ServicePackageandServiceList.ServiceListViewModel = serviceViewModelList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }


            return View(ServicePackageandServiceList);
        }

        public IActionResult DeleteService(int ServiceID)
        {
            try
            {
                var selectedService = _serviceManager.GetById(ServiceID);
                selectedService.Status = false;
                _serviceManager.Update(selectedService);
                _notyf.Success("Hizmet başarıyla silindi");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return RedirectToAction("Services", "Admin");
        }

        [HttpGet]
        public IActionResult EditService(int ServiceID)
        {
            EditServiceDTO editServiceModel = new EditServiceDTO();
            try
            {
                var selectedService = _serviceManager.GetById(ServiceID);

                editServiceModel.ServiceName = selectedService.Name;
                editServiceModel.ServiceDescription = selectedService.Description;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return PartialView("_EditServicePartial", editServiceModel);
        }

        [HttpPost]
        public IActionResult EditService(EditServiceDTO data)
        {
            try
            {
                var service = _mapper.Map<Services>(data);
                service.Status = true;
                _serviceManager.Update(service);
                _notyf.Success("Hizmet başarıyla güncellendi");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return PartialView("_EditServicePartial");
        }

        [HttpGet]
        public async Task<IActionResult> CreateCustomer()
        {
            CustomerCreateAndListDTO customerViewModel = new CustomerCreateAndListDTO();
            List<CustomerListClass> customerList = new List<CustomerListClass>();
            try
            {
                var allCustomers = await (from user in _context.Users
                    join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    where ((role.Name == "customer") && user.Status == true)
                    select user).ToListAsync();
                foreach (var customer in allCustomers)
                {
                    customerList.Add(new CustomerListClass
                        {CustomerID = customer.Id, CustomerName = customer.NameSurname, CustomerMail = customer.Email});
                }

                customerViewModel.CustomerList = customerList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerCreateAndListDTO customerData)
        {
            CustomerCreateAndListDTO customerViewModel = new CustomerCreateAndListDTO();
            List<CustomerListClass> customerList = new List<CustomerListClass>();
            MailService SendMail = new MailService();
            try
            {
                if (ModelState.IsValid)
                {
                    if (customerData.Password == customerData.ConfirmPassword)
                    {
                        var CustomerUser = _mapper.Map<ApplicationUser>(customerData);
                        CustomerUser.Status = true;
                        CustomerUser.PhoneNumber = "90" + customerData.PhoneNumber;
                        CustomerUser.Id = Guid.NewGuid().ToString();
                        var result = await _userManager.CreateAsync(CustomerUser, customerData.Password);
                        if (result.Succeeded)
                        {
                            var roleResult = await _userManager.AddToRoleAsync(CustomerUser, "customer");
                            if (roleResult.Succeeded)
                            {
                                var token = await _userManager.GenerateEmailConfirmationTokenAsync(CustomerUser);
                                var confirmationLink = Url.ActionLink("ConfirmMail", "Account",
                                    new {token, email = CustomerUser.Email}, Request.Scheme);
                                string mailContext =
                                    "Üyeliğiniz başarıyla oluşturulmuştur, lütfen kaydınızı tamamlamak için <a href=" +
                                    confirmationLink + ">tıklayınız</a>";
                                SendMail.SendMailWithReceiverMailContextAndSubject(CustomerUser.Email, mailContext,
                                    "Ajans Yönetim Sistemi: Üyeliğinizi Aktif Ediniz.");
                                _notyf.Success("Müşteri başarıyla kaydedildi!");
                                return RedirectToAction("CreateCustomer", "Admin");
                            }

                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                        }
                        else
                        {
                            foreach (var item in result.Errors)
                            {
                                ModelState.AddModelError(string.Empty, item.Description);
                            }
                        }
                    }
                    else
                    {
                        _notyf.Error("Şifreler uyuşmuyor!");
                    }
                }
                else
                {
                    _notyf.Error("Beklenmeyen bir hata oluştu");
                }

                var allCustomers = await (from user in _context.Users
                    join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    where ((role.Name == "customer") && user.Status == true)
                    select user).ToListAsync();
                foreach (var customer in allCustomers)
                {
                    customerList.Add(new CustomerListClass
                        {CustomerID = customer.Id, CustomerName = customer.NameSurname, CustomerMail = customer.Email});
                }

                customerViewModel.CustomerList = customerList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }


            return View(customerViewModel);
        }

        public async Task<IActionResult> DeleteCustomer(string CustomerID)
        {
            try
            {
                var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
                selectedCustomer.Status = false;
                var result = await _userManager.UpdateAsync(selectedCustomer);
                if (result.Succeeded)
                {
                    _notyf.Success("Müşteri başarıyla silindi!");
                }
                else
                {
                    _notyf.Error("Müşteri silinirken bir hata oluştu!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }


            return RedirectToAction("CreateCustomer", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomer(string CustomerID)
        {
            EditCustomerDTO customerEditViewModel = new EditCustomerDTO();
            try
            {
                var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
                customerEditViewModel.Name = selectedCustomer.NameSurname;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return PartialView("_EditCustomerPartial", customerEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(EditCustomerDTO customerNewData)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedCustomer = await _userManager.FindByIdAsync(customerNewData.CustomerID);
                    selectedCustomer.NameSurname = customerNewData.Name;
                    var result = await _userManager.UpdateAsync(selectedCustomer);
                    if (result.Succeeded)
                    {
                        _notyf.Success("Müşteri başarıyla güncellendi!");
                    }
                    else
                    {
                        _notyf.Error("Müşteri güncellenirken bir hata oluştu!");
                    }
                }
                else
                {
                    foreach (var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors))
                    {
                        _notyf.Error("Personel güncellenirken bir hata oluştu. Hata mesajı: " + error.ErrorMessage);
                    }
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return PartialView("_EditCustomerPartial");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDefineServices(string CustomerID)
        {
            CustomerDefineServiceDTO customerViewModel = new CustomerDefineServiceDTO();
            List<CustomerListClassForDefineService> customerList = new List<CustomerListClassForDefineService>();
            List<CustomerDefinedServiceListClass> customerServiceList = new List<CustomerDefinedServiceListClass>();
            List<PaymentRoutineTypesClass> paymentRoutineTypeList = new List<PaymentRoutineTypesClass>();
            try
            {
                string ServiceNamesForCustomer = "";
                if (CustomerID == null)
                {
                    var allCustomers = await (from user in _context.Users
                        join userRole in _context.UserRoles
                            on user.Id equals userRole.UserId
                        join role in _context.Roles
                            on userRole.RoleId equals role.Id
                        where ((role.Name == "customer") && user.Status == true)
                        select user).ToListAsync();
                    foreach (var customer in allCustomers)
                    {
                        customerList.Add(new CustomerListClassForDefineService
                        {
                            CustomerID = customer.Id, CustomerName = customer.NameSurname, CustomerMail = customer.Email
                        });
                        var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(customer.Id);
                        ServiceNamesForCustomer = "";
                        PaymentRoutineType selectedPaymentRoutine = new PaymentRoutineType();
                        foreach (var customerServices in customerService)
                        {
                            selectedPaymentRoutine =
                                _paymentRoutineTypesManager.GetById(customerServices.PaymentRoutineTypeID);
                            var selectedService = _serviceManager.GetById(customerServices.ServiceID);
                            ServiceNamesForCustomer = selectedService.Name + ", " + ServiceNamesForCustomer;
                        }

                        customerServiceList.Add(new CustomerDefinedServiceListClass
                        {
                            CustomerID = customer.Id, CustomerName = customer.NameSurname,
                            CustomerMail = customer.Email,
                            ServiceNames = ServiceNamesForCustomer, PaymentRoutineTypeName = selectedPaymentRoutine.Name
                        });
                    }

                    var allPaymentRoutineTypes = _paymentRoutineTypesManager.GetList();
                    foreach (var onePaymentRoutineType in allPaymentRoutineTypes)
                    {
                        paymentRoutineTypeList.Add(new PaymentRoutineTypesClass
                        {
                            PaymentRoutineID = onePaymentRoutineType.ID,
                            PaymentRoutineName = onePaymentRoutineType.Name,
                        });
                    }
                }
                else
                {
                    customerViewModel.isCustomerIDComingfromCustomerCard = CustomerID;
                    customerViewModel.selectedCustomerID = CustomerID;


                    var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
                    customerList.Add(new CustomerListClassForDefineService
                    {
                        CustomerID = selectedCustomer.Id, CustomerName = selectedCustomer.NameSurname,
                        CustomerMail = selectedCustomer.Email
                    });
                    var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(selectedCustomer.Id);
                    ServiceNamesForCustomer = "";
                    PaymentRoutineType selectedPaymentRoutine = new PaymentRoutineType();
                    foreach (var customerServices in customerService)
                    {
                        selectedPaymentRoutine =
                            _paymentRoutineTypesManager.GetById(customerServices.PaymentRoutineTypeID);
                        var selectedService = _serviceManager.GetById(customerServices.ServiceID);
                        ServiceNamesForCustomer = selectedService.Name + ", " + ServiceNamesForCustomer;
                    }

                    customerServiceList.Add(new CustomerDefinedServiceListClass
                    {
                        CustomerID = selectedCustomer.Id, CustomerName = selectedCustomer.NameSurname,
                        CustomerMail = selectedCustomer.Email,
                        ServiceNames = ServiceNamesForCustomer, PaymentRoutineTypeName = selectedPaymentRoutine.Name
                    });
                    var allPaymentRoutineTypes = _paymentRoutineTypesManager.GetList();
                    foreach (var onePaymentRoutineType in allPaymentRoutineTypes)
                    {
                        paymentRoutineTypeList.Add(new PaymentRoutineTypesClass
                        {
                            PaymentRoutineID = onePaymentRoutineType.ID,
                            PaymentRoutineName = onePaymentRoutineType.Name,
                        });
                    }
                }

                customerViewModel.PackageList = _packageManager.GetList();
                customerViewModel.ServiceList = _serviceManager.GetList();
                customerViewModel.CustomerList = customerList;
                customerViewModel.CustomerDefinedServiceList = customerServiceList;
                customerViewModel.PaymentRoutineTypesList = paymentRoutineTypeList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerDefineServices(CustomerDefineServiceDTO customerDefineServiceData,
            IFormCollection selectedServicesIDandSelectedPackagesIDforPackages)
        {
            try
            {
                if (customerDefineServiceData.selectedCustomerID == null)
                {
                    _notyf.Error("Lütfen işlem yapabilmek için bir müşteri seçiniz");
                    return RedirectToAction("CustomerDefineServices", "Admin");
                }

                List<int> serviceIdList = new List<int>();
                foreach (var item in selectedServicesIDandSelectedPackagesIDforPackages["ServiceId"])
                {
                    serviceIdList.Add(Convert.ToInt32(item));
                }

                List<int> packageIdList = new List<int>();
                foreach (var item in selectedServicesIDandSelectedPackagesIDforPackages["PackageId"])
                {
                    packageIdList.Add(Convert.ToInt32(item));
                }

                foreach (var packageID in packageIdList)
                {
                    var package = _packageManager.GetById(packageID);
                    var packageService = _servicePackageManager.GetServiceIDListByPackageId(packageID);
                    foreach (var service in packageService)
                    {
                        if (!serviceIdList.Contains(service.ServiceID))
                        {
                            serviceIdList.Add(Convert.ToInt32(service.ServiceID));
                        }
                    }
                }

                if (serviceIdList.Count == 0)
                {
                    _notyf.Error("Lütfen işlem yapabilmek için bir hizmet seçiniz!");
                    return RedirectToAction("CustomerDefineServices", "Admin");
                }

                var selectedCustomerAldreadyDefinedServices =
                    _customerServiceManager.GetCustomerServiceByCustomerID(customerDefineServiceData
                        .selectedCustomerID);
                List<int> CustomerAldreadyDefinedServicesIDList = new List<int>();
                foreach (var item in selectedCustomerAldreadyDefinedServices)
                {
                    CustomerAldreadyDefinedServicesIDList.Add(item.ServiceID);
                }

                var serviceIDListClean = serviceIdList.Except(CustomerAldreadyDefinedServicesIDList).ToList();
                if (serviceIDListClean.Count != 0)
                {
                    foreach (var serviceID in serviceIDListClean)
                    {
                        CustomerService newCustomerService = new CustomerService();
                        newCustomerService.Status = true;
                        newCustomerService.EndDate = customerDefineServiceData.DateRange;
                        newCustomerService.CustomerID = customerDefineServiceData.selectedCustomerID;
                        newCustomerService.StartDate = DateTime.Now;
                        ;
                        newCustomerService.ServiceID = serviceID;
                        newCustomerService.PaymentRoutineTypeID =
                            customerDefineServiceData.SelectedPaymentRoutineTypeID;
                        _customerServiceManager.Add(newCustomerService);
                    }

                    _notyf.Success("Müşteri hizmeti başarıyla tanımlandı");
                }
                else
                {
                    _notyf.Error("Müşteri hizmet tanımlanırken bir hata oluştu");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return RedirectToAction("CustomerDefineServices", "Admin");
        }

        public async Task<IActionResult> CustomerCard(string CustomerID)
        {
            CustomerCardDTO customerCardModel = new CustomerCardDTO();
            List<ReportListClass> reportList = new List<ReportListClass>();
            List<CustomerCardServiceListClass> serviceListForCustomer = new List<CustomerCardServiceListClass>();
            List<CustomerEmployeeListClass> customerEmployeeList = new List<CustomerEmployeeListClass>();
            List<PaymentHistoryClassForAdmin> paymentHistoryList = new List<PaymentHistoryClassForAdmin>();
            try
            {
                double PaymentPriceSum = 0;
                var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
                if (selectedCustomer != null)
                {
                    customerCardModel = _mapper.Map<CustomerCardDTO>(selectedCustomer);
                    var selectedCustomerDefinedServiceList =
                        _customerServiceManager.GetCustomerServiceByCustomerID(CustomerID);
                    foreach (var service in selectedCustomerDefinedServiceList)
                    {
                        var selectedService = _serviceManager.GetById(service.ServiceID);
                        serviceListForCustomer.Add(new CustomerCardServiceListClass
                        {
                            ServiceId = service.ID, ServiceStartDate = service.StartDate,
                            ServiceEndDate = service.EndDate,
                            ServiceName = selectedService.Name, ServiceDescription = selectedService.Description
                        });
                    }

                    var selectedCustomerEmployee = _customerEmployeeManager.GetEmployeeListByCustomerID(CustomerID);
                    foreach (var oneCustomerEmployee in selectedCustomerEmployee)
                    {
                        var selectedEmployee = await _userManager.FindByIdAsync(oneCustomerEmployee.EmployeeID);
                        var selectedEmployeeRole = await _userManager.GetRolesAsync(selectedEmployee);
                        customerEmployeeList.Add(new CustomerEmployeeListClass
                        {
                            EmployeeID = oneCustomerEmployee.EmployeeID, EmployeeName = selectedEmployee.NameSurname,
                            EmployeeRole = selectedEmployeeRole[0].ToUpper(),
                            CustomerEmployeeID = oneCustomerEmployee.ID,
                        });
                    }

                    var selectedCustomerPaymentHistory =
                        _customerPaymentsManager.GetPaymentListByCustomerID(CustomerID);
                    foreach (var payment in selectedCustomerPaymentHistory)
                    {
                        PaymentPriceSum += payment.PaymentPrice;
                        paymentHistoryList.Add(new PaymentHistoryClassForAdmin
                        {
                            PaymentDate = payment.PaymentDate,
                            PaymentPrice = payment.PaymentPrice,
                        });
                    }

                    CustomerReportsDTO model = new CustomerReportsDTO();

                    var customerProductList =
                        _customerProductsManager.GetCustomerProductsListByCustomerID(selectedCustomer.Id);
                    foreach (var product in customerProductList)
                    {
                        var selectedProductFile = _customerProductsFileManager.GetByProductId(product.id);
                        if (selectedProductFile != null)
                        {
                            FileInfo fileInfo = new FileInfo(selectedProductFile.FilePath);
                            string fileExt = fileInfo.Extension;
                            if (fileExt == ".docx" || fileExt == ".doc" || fileExt == ".pdf" || fileExt == ".xls" ||
                                fileExt == ".xlsx" || fileExt == ".ppt" || fileExt == ".pptx" || fileExt == ".txt")
                            {
                                var newProduct = _mapper.Map<ReportListClass>(product);
                                var checkDemandisExist = _demandManager.GetByProductID(product.id);
                                if (checkDemandisExist != null)
                                {
                                    newProduct.ReportName = newProduct.ProductTitle + "rapor.v1";
                                    newProduct.ReportPath = "CustomerProductsFile/" + selectedProductFile.FilePath;
                                    int versionCounter = 2;
                                    reportList.Add(newProduct);
                                    var checkDemandAnswers = _demandAnswerManager.GetByDemandId(checkDemandisExist.ID);
                                    if (checkDemandAnswers != null)
                                    {
                                        foreach (var item in checkDemandAnswers)
                                        {
                                            if (item.AnswerFilePath != null)
                                            {
                                                FileInfo fileInfoForAnswer = new FileInfo(item.AnswerFilePath);
                                                string fileExtension = fileInfoForAnswer.Extension;
                                                if (fileExtension == ".docx" || fileExtension == ".doc" ||
                                                    fileExtension == ".pdf" || fileExtension == ".xls" ||
                                                    fileExtension == ".xlsx" || fileExtension == ".ppt" ||
                                                    fileExtension == ".pptx" || fileExtension == ".txt")
                                                {
                                                    var newProductWithDemand = _mapper.Map<ReportListClass>(product);
                                                    newProductWithDemand.DemandStatus = checkDemandisExist.Status;
                                                    newProductWithDemand.DemandID = checkDemandisExist.ID;
                                                    newProductWithDemand.ReportPath =
                                                        "DemandFiles/" + item.AnswerFilePath;
                                                    newProductWithDemand.ReportName =
                                                        newProductWithDemand.ProductTitle +
                                                        "-Rapor.v" + versionCounter;
                                                    newProductWithDemand.CustomerName = selectedCustomer.NameSurname;
                                                    versionCounter++;
                                                    reportList.Add(newProductWithDemand);
                                                }
                                            }


                                        }

                                    }
                                }
                                else
                                {
                                    newProduct.ReportPath = "CustomerProductsFile/" + selectedProductFile.FilePath;
                                    newProduct.CustomerName = selectedCustomer.NameSurname;
                                    newProduct.ReportName = newProduct.ProductTitle + "-Rapor.v1";
                                    reportList.Add(newProduct);

                                }
                            }
                            else
                            {
                                var checkDemandisExist = _demandManager.GetByProductID(product.id);
                                if (checkDemandisExist != null)
                                {
                                    int versionCounterForAnswers = 1;
                                    var checkDemandAnswers = _demandAnswerManager.GetByDemandId(checkDemandisExist.ID);
                                    if (checkDemandAnswers != null)
                                    {
                                        foreach (var item in checkDemandAnswers)
                                        {
                                            if (item.AnswerFilePath != null)
                                            {
                                                FileInfo fileInfoForAnswer = new FileInfo(item.AnswerFilePath);
                                                string fileExtension = fileInfoForAnswer.Extension;
                                                if (fileExtension == ".docx" || fileExtension == ".doc" ||
                                                    fileExtension == ".pdf" || fileExtension == ".xls" ||
                                                    fileExtension == ".xlsx" || fileExtension == ".ppt" ||
                                                    fileExtension == ".pptx" || fileExtension == ".txt")
                                                {
                                                    var newProductWithDemand = _mapper.Map<ReportListClass>(product);
                                                    newProductWithDemand.DemandStatus = checkDemandisExist.Status;
                                                    newProductWithDemand.DemandID = checkDemandisExist.ID;
                                                    newProductWithDemand.ReportPath =
                                                        "DemandFiles/" + item.AnswerFilePath;
                                                    newProductWithDemand.ReportName =
                                                        newProductWithDemand.ProductTitle +
                                                        "-Rapor.v" + versionCounterForAnswers;
                                                    newProductWithDemand.CustomerName = selectedCustomer.NameSurname;
                                                    versionCounterForAnswers++;
                                                    reportList.Add(newProductWithDemand);
                                                }
                                            }


                                        }

                                    }
                                }
                            }
                        }

                    }
                }
                else
                {
                    _notyf.Error(
                        "Müşteri bilgileri getirilirken bir hata oluştu, lütfen müşteri seçtiğinizden emin olun");
                    return RedirectToAction("CreateCustomer", "Admin");
                }

                customerCardModel.ReportList = reportList;
                customerCardModel.PaymentPriceSum = PaymentPriceSum;
                customerCardModel.CustomerEmployeeList = customerEmployeeList;
                customerCardModel.CustomerDefinedServiceList = serviceListForCustomer;
                customerCardModel.PaymentHistoryList = paymentHistoryList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(customerCardModel);
        }

        public IActionResult DeleteCustomerEmployee(int CustomerEmployeeID)
        {
            try
            {
                var selectedCustomerEmployee = _customerEmployeeManager.GetById(CustomerEmployeeID);
                selectedCustomerEmployee.Status = false;
                _customerEmployeeManager.Update(selectedCustomerEmployee);
                _notyf.Success("Müşteri çalışanı başarıyla silindi");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return RedirectToAction("CustomerCard", "Admin",
                new {CustomerID = _customerEmployeeManager.GetById(CustomerEmployeeID).CustomerID});
        }

        [HttpGet]
        public async Task<IActionResult> DefineCustomerEmployee(string CustomerID)
        {
            DefineCustomerEmployeeDTO defineCustomerEmployeeDTO = new DefineCustomerEmployeeDTO();
            try
            {
                var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);

                List<EmployeeListDefineEmployee> employeeListForSelectedItem = new List<EmployeeListDefineEmployee>();

                if (selectedCustomer != null)
                {
                    defineCustomerEmployeeDTO.CustomerName = selectedCustomer.NameSurname;
                    var employeeList = await (from user in _context.Users
                        join userRole in _context.UserRoles
                            on user.Id equals userRole.UserId
                        join role in _context.Roles
                            on userRole.RoleId equals role.Id
                        where ((role.Name == "designer" || role.Name == "ops" || role.Name == "marketing") &&
                               user.Status == true)
                        select user).ToListAsync();
                    foreach (var oneEmployee in employeeList)
                    {
                        var selectedEmployeeRole = await _userManager.GetRolesAsync(oneEmployee);
                        StringBuilder employeeName = new StringBuilder();
                        employeeName.Append("[" + selectedEmployeeRole[0].ToUpper() + "]");
                        employeeName.Append(" " + oneEmployee.NameSurname);
                        employeeListForSelectedItem.Add(new EmployeeListDefineEmployee
                        {
                            EmployeeID = oneEmployee.Id,
                            EmployeeName = employeeName.ToString(),
                        });

                    }
                }
                else
                {
                    _notyf.Error(
                        "Müşteri bilgileri getirilirken bir hata oluştu, lütfen müşteri seçtiğinizden emin olun");
                    return RedirectToAction("CreateCustomer", "Admin");
                }

                defineCustomerEmployeeDTO.SelectedCustomerID = CustomerID;
                defineCustomerEmployeeDTO.EmployeeList = employeeListForSelectedItem;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(defineCustomerEmployeeDTO);
        }

        [HttpPost]
        public async Task<IActionResult> DefineCustomerEmployee(DefineCustomerEmployeeDTO data)
        {

            DefineCustomerEmployeeDTO defineCustomerEmployeeDTO = new DefineCustomerEmployeeDTO();
            try
            {
                if (ModelState.IsValid)
                {
                    var selectedCustomerEmployeeList =
                        _customerEmployeeManager.GetEmployeeListByCustomerID(data.SelectedCustomerID);
                    if (selectedCustomerEmployeeList.Count > 0)
                    {
                        var isThereAnyCustomerEmployeeData = selectedCustomerEmployeeList
                            .Where(x => x.EmployeeID == data.SelectedEmployeeID).ToList();
                        if (isThereAnyCustomerEmployeeData.Count >= 1)
                        {
                            _notyf.Error("Bu personel müşteriye hali hazırda tanımlanmıştır");
                            return  RedirectToAction("DefineCustomerEmployee","Admin", new {CustomerID = data.SelectedCustomerID});
                        }
                    }
                    CustomerEmployee newCustomerEmployee = new CustomerEmployee();
                    newCustomerEmployee.Status = true;
                    newCustomerEmployee.CustomerID = data.SelectedCustomerID;
                    newCustomerEmployee.EmployeeID = data.SelectedEmployeeID;
                    _customerEmployeeManager.Add(newCustomerEmployee);
                    _notyf.Success("Müşteriye başarıyla personel tanımlandı!");
                    return RedirectToAction("CustomerCard", "Admin", new {CustomerID = data.SelectedCustomerID});
                }

                _notyf.Error("Personel tanımlanamadı!");
                var selectedCustomer = await _userManager.FindByIdAsync(data.SelectedCustomerID);
                List<EmployeeListDefineEmployee> employeeListForSelectedItem = new List<EmployeeListDefineEmployee>();
                defineCustomerEmployeeDTO.CustomerName = selectedCustomer.NameSurname;
                var employeeList = await (from user in _context.Users
                    join userRole in _context.UserRoles
                        on user.Id equals userRole.UserId
                    join role in _context.Roles
                        on userRole.RoleId equals role.Id
                    where ((role.Name == "designer" || role.Name == "ops" || role.Name == "marketing") &&
                           user.Status == true)
                    select user).ToListAsync();
                foreach (var oneEmployee in employeeList)
                {
                    var selectedEmployeeRole = await _userManager.GetRolesAsync(oneEmployee);
                    StringBuilder employeeName = new StringBuilder();
                    employeeName.Append("[" + selectedEmployeeRole[0].ToUpper() + "]");
                    employeeName.Append(" " + oneEmployee.NameSurname);
                    employeeListForSelectedItem.Add(new EmployeeListDefineEmployee
                    {
                        EmployeeID = oneEmployee.Id,
                        EmployeeName = employeeName.ToString(),
                    });

                }

                defineCustomerEmployeeDTO.SelectedCustomerID = data.SelectedCustomerID;
                defineCustomerEmployeeDTO.EmployeeList = employeeListForSelectedItem;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(defineCustomerEmployeeDTO);

        }

        public IActionResult Settings()
        {
            MailSettingsDTO model = new MailSettingsDTO();
            try
            {
                var defaultSettings = _mailSettingsManager.GetList().FirstOrDefault();
                model.Mail = defaultSettings.Mail;
                model.Password = defaultSettings.Password;
                model.Port = defaultSettings.Port;
                model.SmtpServer = defaultSettings.SMTPServer;
                model.ID = defaultSettings.ID;
                var defaultPeakcellSMSSettigns = _peakcellSmsSettingsManager.GetSettings();
                model.PeakcellHeader = defaultPeakcellSMSSettigns.Header;
                model.PeakcellUserName = defaultPeakcellSMSSettigns.Username;
                model.PeakcellPassword = defaultPeakcellSMSSettigns.Password;
                var defaultDigicellSMSSettings = _digicellSmsSettingsManager.GetSettings();
                model.DigicellUserName = defaultDigicellSMSSettings.Username;
                model.DigicellHeader = defaultDigicellSMSSettings.Header;
                model.DigicellPassword = defaultDigicellSMSSettings.Password;
                var defaultShouldCustomerBeAbleToSeePaymentHistorySettings = _settingsManager
                    .GetBySettingField("ShouldCustomerBeAbleToSeePaymentHistory");
                model.ShouldCustomerBeAbleTooSeePaymentHistoryIsActive =
                    defaultShouldCustomerBeAbleToSeePaymentHistorySettings.SettingIsActive;
                var defaultShouldCustomerBeAbleToSeeRelevantPersonelSettings = _settingsManager
                    .GetBySettingField("ShouldCustomerBeAbleToSeeRelevantPersonel");
                model.ShouldCustomerBeAbleTooSeeRelevantPersonelIsActive =
                    defaultShouldCustomerBeAbleToSeeRelevantPersonelSettings.SettingIsActive;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(model);
        }

        [HttpPost]
        public IActionResult ShouldCustomerBeAbleToSeePaymentHistorySettings(MailSettingsDTO data)
        {
            try
            {
                var selectedSettings = _settingsManager.GetBySettingField("ShouldCustomerBeAbleToSeePaymentHistory");
                selectedSettings.SettingIsActive = data.ShouldCustomerBeAbleTooSeePaymentHistoryIsActive;
                _settingsManager.Update(selectedSettings);
                _notyf.Success("Ayar başarıyla değiştirildi.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return RedirectToAction("Settings", "Admin");
        }
        
        public IActionResult ShouldCustomerBeAbleTooSeeRelevantPersonelIsActiveSettings(MailSettingsDTO data)
        {
            try
            {
                var selectedSettings = _settingsManager.GetBySettingField("ShouldCustomerBeAbleToSeeRelevantPersonel");
                selectedSettings.SettingIsActive = data.ShouldCustomerBeAbleTooSeeRelevantPersonelIsActive;
                _settingsManager.Update(selectedSettings);
                _notyf.Success("Ayar başarıyla değiştirildi.");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return RedirectToAction("Settings", "Admin");
        }


        public IActionResult MailSettings(MailSettingsDTO data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var getSelectedData = _mailSettingsManager.GetById(data.ID);
                    getSelectedData.SMTPServer = data.SmtpServer;
                    getSelectedData.Mail = data.Mail;
                    getSelectedData.Password = data.Password;
                    getSelectedData.Port = data.Port;
                    _mailSettingsManager.Update(getSelectedData);
                    _notyf.Success("Mail ayarlarınız başarıyla değiştirilmiştir.");
                }
                else
                {
                    _notyf.Error("Mail ayarlarınız değiştirilirken hata oluştu. Lütfen kontrol edip tekrar deneyiniz.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return RedirectToAction("Settings");
        }

        [HttpPost]
        public IActionResult PeakcellSettings(MailSettingsDTO data)
        {
            try
            {
                var isThereAnyPeakcellSettings = _peakcellSmsSettingsManager.GetSettings();
                if (isThereAnyPeakcellSettings != null)
                {
                    isThereAnyPeakcellSettings.Username = data.PeakcellUserName;
                    isThereAnyPeakcellSettings.Password = data.PeakcellPassword;
                    isThereAnyPeakcellSettings.Header = data.PeakcellHeader;
                    isThereAnyPeakcellSettings.isActive = true;
                    _peakcellSmsSettingsManager.Update(isThereAnyPeakcellSettings);
                }
                else
                {
                    PeakcellSMSSettings newPeakcellSettings = new PeakcellSMSSettings();
                    newPeakcellSettings.Username = data.PeakcellUserName;
                    newPeakcellSettings.Password = data.PeakcellPassword;
                    newPeakcellSettings.Header = data.PeakcellHeader;
                    newPeakcellSettings.isActive = true;
                    _peakcellSmsSettingsManager.Add(newPeakcellSettings);
                    _notyf.Success("Ayarlarınız başarıyla güncellenmiştir.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return RedirectToAction("Settings");
        }
        
        [HttpPost]
        public IActionResult DigicellSettings(MailSettingsDTO data)
        {
            try
            {
                var isThereAnyDigicellSmsSettingsSettings = _digicellSmsSettingsManager.GetSettings();
                if (isThereAnyDigicellSmsSettingsSettings != null)
                {
                    isThereAnyDigicellSmsSettingsSettings.Username = data.DigicellUserName;
                    isThereAnyDigicellSmsSettingsSettings.Password = data.DigicellPassword;
                    isThereAnyDigicellSmsSettingsSettings.Header = data.DigicellHeader;
                    isThereAnyDigicellSmsSettingsSettings.isActive = true;
                    _digicellSmsSettingsManager.Update(isThereAnyDigicellSmsSettingsSettings);
                }
                else
                {
                    DigicellSMSSettings newDigicellSMSSettings = new DigicellSMSSettings();
                    newDigicellSMSSettings.Username = data.DigicellUserName;
                    newDigicellSMSSettings.Password = data.DigicellPassword;
                    newDigicellSMSSettings.Header = data.DigicellHeader;
                    newDigicellSMSSettings.isActive = true;
                    _digicellSmsSettingsManager.Add(newDigicellSMSSettings);
                    _notyf.Success("Ayarlarınız başarıyla güncellenmiştir.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            return RedirectToAction("Settings");
        }
        

        [HttpGet]
        public IActionResult Profile()
        {
            UserProfileDTO model = new UserProfileDTO();
            try
            {
                var currentUser = _userManager.GetUserAsync(HttpContext.User);
                model.Mail = currentUser.Result.Email;
                model.Name = currentUser.Result.NameSurname;
                model.UserId = currentUser.Result.Id;
                var selectedUserRole = _userManager.GetRolesAsync(currentUser.Result).Result;
                model.RoleName = selectedUserRole[0].ToUpper();
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(UserProfileDTO data)
        {
            try
            {
                if (data.Password == data.PasswordConfirm)
                {
                    var selectedUser = await _userManager.FindByIdAsync(data.UserId);
                    var token = await _userManager.GeneratePasswordResetTokenAsync(selectedUser);
                    var result = await _userManager.ResetPasswordAsync(selectedUser, token, data.Password);
                    if (result.Succeeded)
                    {
                        MailService mailService = new MailService();
                        mailService.SendMailWithReceiverMailContextAndSubject(selectedUser.Email, "Şifre Güncelleme",
                            "Şifreniz başarıyla değiştirilmiştir.");
                        _notyf.Success("Şifreniz başarıyla değiştirilmiştir.");
                    }

                    foreach (var item in result.Errors)
                    {
                        _notyf.Error("Şifre Değiştirilirken Hata Oluştu: " + item.Description);
                    }
                }
                else
                {
                    _notyf.Error("Şifreleriniz uyuşmuyor. Lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

            return RedirectToAction("Profile", "Admin");
        }

        [HttpGet]
        public IActionResult MakeAnAnnouncement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MakeAnAnnouncement(AnnouncementDTO data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Announcement newAnnouncement = new Announcement();
                    newAnnouncement.Header = data.Header;
                    newAnnouncement.Content = data.Content;
                    newAnnouncement.Date = DateTime.Now;
                    _announcementManager.Add(newAnnouncement);
                    _notyf.Success("Duyuru başarıyla iletildi.");
                    return RedirectToAction("MakeAnAnnouncement", "Admin");
                }
                else
                {
                    _notyf.Error("Duyuru oluşturulurken bir hata oluştu, lütfen tekrar deneyiniz.");
                }
            }
            catch (Exception e)
            {
                _notyf.Error("Duyuru yapılıarken bir hata oluştu.");
                _logger.LogError(e, e.Message);
            }
            return View();
        }
    }
    
}