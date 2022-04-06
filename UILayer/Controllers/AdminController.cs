using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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

        private readonly ServicePackageManager _servicePackageManager =
            new ServicePackageManager(new EfServicePackageRepository());

        private readonly CustomerServiceManager _customerServiceManager =
            new CustomerServiceManager(new EfCustomerServiceRepository());


        public AdminController(INotyfService notyf, IMapper mapper, UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager, Context context)
        {
            _notyf = notyf;
            _mapper = mapper;
            _userManager = userManager;
            _roleManager = roleManager;
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> DefineEmployee()
        {
            EmployeeList employeeList = new EmployeeList(_context, _userManager);
            EmployeeDefineAndListDTO employeModel = new EmployeeDefineAndListDTO();
            List<RoleListClass> roleList = new List<RoleListClass>();
            employeModel.EmployeeList = employeeList.GetAllEmployee().Result;
            var roles = _context.Roles.Where(x=> x.Name == "designer" || x.Name == "marketing" || x.Name == "ops").ToList();
            foreach (var item in roles)
            {
                roleList.Add(new RoleListClass
                {
                    
                    RoleName = item.Name,
                });
            }

            employeModel.RoleList = roleList;
            return View(employeModel);
        }

        [HttpPost]
        public async Task<IActionResult> DefineEmployee(EmployeeDefineAndListDTO employeeData)
        {
            MailService SendMail = new MailService();
            if (ModelState.IsValid)
            {
                if (employeeData.Password == employeeData.ConfirmPassword)
                {
                    var EmployeeUser = _mapper.Map<ApplicationUser>(employeeData);
                    EmployeeUser.Status = true;
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
            }
            else
            {
                _notyf.Error("Beklenmeyen bir hata oluştu");
            }

            EmployeeDefineAndListDTO employeModel = new EmployeeDefineAndListDTO();
            EmployeeList employeeList = new EmployeeList(_context, _userManager);
            employeModel.EmployeeList = employeeList.GetAllEmployee().Result;
            return View(employeModel);
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployee(string employeeID)
        {
            EditEmployeeDTO selectedEmployee = new EditEmployeeDTO();
            var user = await _userManager.FindByIdAsync(employeeID);
            var userRole = await _userManager.GetRolesAsync(user);
            selectedEmployee.Name = user.NameSurname;
            selectedEmployee.Email = user.Email;
            selectedEmployee.Role = userRole[0];
            return PartialView("_EmployeeModelPartial", selectedEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> EditEmployee(EditEmployeeDTO employeeData)
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

            EditEmployeeDTO selectedEmployee = new EditEmployeeDTO();
            var employeeRole = await _userManager.GetRolesAsync(user);
            selectedEmployee.Name = user.NameSurname;
            selectedEmployee.Email = user.Email;
            selectedEmployee.Role = employeeRole[0];
            return PartialView("_EmployeeModelPartial", selectedEmployee);
        }

        public async Task<IActionResult> DeleteEmployee(string EmployeeID)
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
            return RedirectToAction("DefineEmployee", "Admin");
        }

        [HttpGet]
        public IActionResult Services()
        {
            ServicePackageandServiceListDTO ServicePackageandServiceList = new ServicePackageandServiceListDTO();
            List<ServiceListViewModel> serviceViewModelList = new List<ServiceListViewModel>();
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
            return View(ServicePackageandServiceList);
        }

        [HttpPost]
        public IActionResult Services(ServicePackageandServiceListDTO data,
            IFormCollection selectedServicesIDforPackages)
        {
            ServicePackageandServiceListDTO ServicePackageandServiceList = new ServicePackageandServiceListDTO();
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
            
            return View(ServicePackageandServiceList);
        }

        public IActionResult DeleteService(int ServiceID)
        {
            var selectedService = _serviceManager.GetById(ServiceID);
            selectedService.Status = false;
            _serviceManager.Update(selectedService);
            _notyf.Success("Hizmet başarıyla silindi");
            return RedirectToAction("Services", "Admin");
        }

        [HttpGet]
        public IActionResult EditService(int ServiceID)
        {
            var selectedService = _serviceManager.GetById(ServiceID);
            EditServiceDTO editServiceModel = new EditServiceDTO();
            editServiceModel.ServiceName = selectedService.Name;
            editServiceModel.ServiceDescription = selectedService.Description;
            return PartialView("_EditServicePartial", editServiceModel);
        }

        [HttpPost]
        public IActionResult EditService(EditServiceDTO data)
        {
            var service = _mapper.Map<Services>(data);
            service.Status = true;
            _serviceManager.Update(service);
            _notyf.Success("Hizmet başarıyla güncellendi");
            return PartialView("_EditServicePartial");
        }

        [HttpGet]
        public async Task<IActionResult> CreateCustomer()
        {
            CustomerCreateAndListDTO customerViewModel = new CustomerCreateAndListDTO();
            List<CustomerListClass> customerList = new List<CustomerListClass>();
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
            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer(CustomerCreateAndListDTO customerData)
        {
            MailService SendMail = new MailService();
            if (ModelState.IsValid)
            {
                if (customerData.Password == customerData.ConfirmPassword)
                {
                    var CustomerUser = _mapper.Map<ApplicationUser>(customerData);
                    CustomerUser.Status = true;
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
            }
            else
            {
                _notyf.Error("Beklenmeyen bir hata oluştu");
            }

            return View();
        }

        public async Task<IActionResult> DeleteCustomer(string CustomerID)
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

            return RedirectToAction("CreateCustomer", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> EditCustomer(string CustomerID)
        {
            EditCustomerDTO customerEditViewModel = new EditCustomerDTO();
            var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
            customerEditViewModel.Name = selectedCustomer.NameSurname;
            return PartialView("_EditCustomerPartial", customerEditViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditCustomer(EditCustomerDTO customerNewData)
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

            return PartialView("_EditCustomerPartial");
        }

        [HttpGet]
        public async Task<IActionResult> CustomerDefineServices()
        {
            CustomerDefineServiceDTO customerViewModel = new CustomerDefineServiceDTO();
            List<CustomerListClassForDefineService> customerList = new List<CustomerListClassForDefineService>();
            List<CustomerDefinedServiceListClass> customerServiceList = new List<CustomerDefinedServiceListClass>();
            string ServiceNamesForCustomer = "";
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
                    {CustomerID = customer.Id, CustomerName = customer.NameSurname, CustomerMail = customer.Email});
                var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(customer.Id);
                ServiceNamesForCustomer = "";
                foreach (var customerServices in customerService)
                {
                    var selectedService = _serviceManager.GetById(customerServices.ServiceID);
                    ServiceNamesForCustomer = selectedService.Name + ", " + ServiceNamesForCustomer;
                }

                customerServiceList.Add(new CustomerDefinedServiceListClass
                {
                    CustomerID = customer.Id, CustomerName = customer.NameSurname, CustomerMail = customer.Email,
                    ServiceNames = ServiceNamesForCustomer
                });
            }


            customerViewModel.PackageList = _packageManager.GetList();
            customerViewModel.ServiceList = _serviceManager.GetList();
            customerViewModel.CustomerList = customerList;
            customerViewModel.CustomerDefinedServiceList = customerServiceList;
            return View(customerViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CustomerDefineServices(CustomerDefineServiceDTO customerDefineServiceData,
            IFormCollection selectedServicesIDandSelectedPackagesIDforPackages)
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
                _customerServiceManager.GetCustomerServiceByCustomerID(customerDefineServiceData.selectedCustomerID);
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
                newCustomerService.StartDate = DateTime.Now;;
                newCustomerService.ServiceID = serviceID;
                _customerServiceManager.Add(newCustomerService);
            }
                _notyf.Success("Müşteri hizmeti başarıyla tanımlandı");
            }
            else
            {
                _notyf.Error("Müşteri hizmet tanımlanırken bir hata oluştu");
            }

            

            return RedirectToAction("CustomerDefineServices", "Admin");
        }

        public async Task<IActionResult> CustomerCard(string CustomerID)
        {
            List<CustomerCardServiceListClass> serviceListForCustomer = new List<CustomerCardServiceListClass>();
            var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
            var customerCardModel = _mapper.Map<CustomerCardDTO>(selectedCustomer);
            var selectedCustomerDefinedServiceList = _customerServiceManager.GetCustomerServiceByCustomerID(CustomerID);
            foreach (var service in selectedCustomerDefinedServiceList)
            {
                var selectedService = _serviceManager.GetById(service.ServiceID);
                serviceListForCustomer.Add(new CustomerCardServiceListClass
                {
                    ServiceId = service.ID, ServiceStartDate = service.StartDate, ServiceEndDate = service.EndDate,
                    ServiceName = selectedService.Name, ServiceDescription = selectedService.Description
                });
            }

            customerCardModel.CustomerDefinedServiceList = serviceListForCustomer;
            return View(customerCardModel);
        }
        
        
        
    }
}