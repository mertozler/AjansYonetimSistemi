using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BackgroundJobs.Schedules;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Project.Models;
using Notification = EntityLayer.Concrete.Notification;

namespace Project.Controllers
{
    public class OpsController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ServiceManager _serviceManager = new ServiceManager(new EfServicesRepository());
        private readonly PackageManager _packageManager = new PackageManager(new EfPackageRepository());
        private readonly ServicePackageManager _servicePackageManager =
            new ServicePackageManager(new EfServicePackageRepository());
        private readonly CustomerServiceManager _customerServiceManager =
            new CustomerServiceManager(new EfCustomerServiceRepository());
        CustomerProdutcsManager _customerProductsManager = new CustomerProdutcsManager(new EfCustomerProductsRepository());
        CustomerProductsFileManager _customerProductsFileManager = new CustomerProductsFileManager(new EfCustomerProductsFileRepository());
        DemandManager _demandManager = new DemandManager(new EfDemandRepository());
        DemandFilesManager _demandFileManager = new DemandFilesManager(new EfDemandFilesRepository());
        PaymentRoutineTypesManager _paymentRoutineTypeManager = new PaymentRoutineTypesManager(new EfPaymentRouteTypesRepository());
        private CustomerPaymentsManager _customerPaymentsManager =
            new CustomerPaymentsManager(new EfCustomerPaymentsRepository());
        private EmployeeCalendarManager _employeeCalendarManager =
            new EmployeeCalendarManager(new EfEmployeeCalendarRepository());
        private DemandAnswerManager _demandAnswerManager = new DemandAnswerManager(new EfDemandAnswersRepository());
        private CustomerEmployeeManager _customerEmployeeManager =
            new CustomerEmployeeManager(new EfCustomerEmployeeRepository());
        NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public OpsController(INotyfService notyf,Context context,IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _notyf = notyf;
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
         public async Task<IActionResult> CustomerServicePlanning()
        {
            List<CustomerListWithServiceName> customerServiceList = new List<CustomerListWithServiceName>();
            string ServiceNamesForCustomer = "";
            var currentUser = await _userManager.GetUserAsync(User);;
            var customerIDsForEmployee = _customerEmployeeManager.GetEmployeeListByEmployeeID(currentUser.Id);
            foreach (var oneCustomerEmployee in customerIDsForEmployee)
            {
                var selectedCustomer = await _userManager.FindByIdAsync(oneCustomerEmployee.CustomerID);
                var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(selectedCustomer.Id);
                ServiceNamesForCustomer = "";
                foreach (var customerServices in customerService)
                {
                    var selectedService = _serviceManager.GetById(customerServices.ServiceID);
                    ServiceNamesForCustomer = selectedService.Name + ", " + ServiceNamesForCustomer;
                }

                customerServiceList.Add(new CustomerListWithServiceName
                {
                    CustomerID = selectedCustomer.Id, CustomerName = selectedCustomer.NameSurname, CustomerMail = selectedCustomer.Email,
                    ServiceNames = ServiceNamesForCustomer
                });
            }


            return View(customerServiceList);
        }
        public IActionResult CustomerServicePlanningDates(string CustomerID)
        {
            var selectedCustomerServiceCheck = _customerServiceManager.GetCustomerServiceByCustomerID(CustomerID);
            if (selectedCustomerServiceCheck.Count == 0)
            {
                _notyf.Error("Müşteriye henüz bir hizmet tanımlaması olmadığından hizmet planlaması yapılamamaktadır.");
                return RedirectToAction("CustomerServicePlanning", "Ops");
            }
            ViewBag.CustomerID = CustomerID;
            return View();
        }
        public IActionResult GetAllEvents(string CustomerID)
        {
            List<Event> eventList = new List<Event>();
            var events = _customerProductsManager.GetCustomerProductsListByCustomerID(CustomerID);
            foreach (var item in events)
            {
                    Event newEvent = new Event();
                    newEvent.id = item.id;
                    newEvent.start = item.start;
                    newEvent.color = item.color;
                    newEvent.title = item.title;
                    newEvent.textColor = item.textColor;
                    newEvent.description = item.description;
                    newEvent.end = item.end;
                    eventList.Add(newEvent);
            }
            return new JsonResult(eventList);
        }
        public IActionResult GetAllEventsForEmployee(string EmployeeID)
        {
            List<EmployeeEvent> eventList = new List<EmployeeEvent>();
            var events = _employeeCalendarManager.GetListbyEmployeeID(EmployeeID);
            foreach (var item in events)
            {
                if (item.Status == true)
                {
                    EmployeeEvent newEvent = new EmployeeEvent();
                    newEvent.id = item.id;
                    newEvent.start = item.start;
                    newEvent.color = item.color;
                    newEvent.title = item.title;
                    newEvent.textColor = item.textColor;
                    newEvent.description = item.description;
                    newEvent.end = item.end;
                    eventList.Add(newEvent);
                }
            }
            return new JsonResult(eventList);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult CustomerServicePlanCreate(string CustomerID, string StartDate)
        {
            CustomerServicePlanCreateDTO newModel = new CustomerServicePlanCreateDTO();
            List<ServiceList> ServiceListForCustomer = new List<ServiceList>();
            if (StartDate != null)
            {
                String format = "ddd MMM dd yyyy HH:mm:ss GMT 0300 (GMT 03:00)";
                DateTime formattingDateTime = DateTime.ParseExact(StartDate, format, CultureInfo.InvariantCulture);
                newModel.CustomerID = CustomerID;
                var endTime = formattingDateTime.AddDays(2);
                newModel.start = formattingDateTime;
                newModel.end = DateTime.Now.AddDays(3);
            }
            else
            {
                newModel.CustomerID = CustomerID;
                var endTime = DateTime.Now.AddDays(2);
                newModel.start = DateTime.Now;
                newModel.end = DateTime.Now;
            }
            var serviceList = _customerServiceManager.GetCustomerServiceByCustomerID(CustomerID);
            foreach (var item in serviceList)
            {
                var selectedService = _serviceManager.GetById(item.ServiceID);
                ServiceListForCustomer.Add(new ServiceList
                {
                    ServiceID = selectedService.ID,
                    ServiceName = selectedService.Name,
                });
            }
            newModel.ServiceList = ServiceListForCustomer;
            return View(newModel);;
        }
        [Obsolete]
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> CustomerServicePlanCreate(CustomerServicePlanCreateDTO data)
        {
            if (data.SelectedServiceID == 0)
            {
                _notyf.Error("Hizmet seçimi boş geçilemez.");
            }
            else if (ModelState.IsValid)
            {
                var selectedService = _serviceManager.GetById(data.SelectedServiceID);
                var currentUser = await _userManager.GetUserAsync(User);
                var newCustomerProducts = _mapper.Map<CustomerProducts>(data);
                newCustomerProducts.title = data.ProductType + " " + data.title;
                newCustomerProducts.Status = true;
                newCustomerProducts.color = "#f45151";
                newCustomerProducts.textColor = "#fff";
                newCustomerProducts.CreateDate = DateTime.Now;
                newCustomerProducts.ServiceID = data.SelectedServiceID;
                newCustomerProducts.description = "Bu plan " + selectedService.Name + " hizmeti için "+ currentUser.NameSurname +  " tarafından oluşturuldu.";
                newCustomerProducts.CreatorID = currentUser.Id;
                var newEmployeeCalendarPlan = _mapper.Map<EmployeeCalendar>(data);
                var selectedEmployee = await _userManager.FindByIdAsync(data.CustomerID);
                newEmployeeCalendarPlan.description = "Bu plan "  + selectedEmployee.NameSurname + " isimli müşterinin satın aldığı " + selectedService.Name + " adlı hizmet için oluşturulmuştur. Detaylar için lütfen ilgili müşterinin hizmet takvimine bakınız.";
                newEmployeeCalendarPlan.Status = true;
                newEmployeeCalendarPlan.title = data.ProductType + " " + data.title;
                newEmployeeCalendarPlan.color = "#f45151";
                newEmployeeCalendarPlan.textColor = "#fff";
                newEmployeeCalendarPlan.EmployeeID = currentUser.Id;
                _employeeCalendarManager.Add(newEmployeeCalendarPlan);
                _customerProductsManager.Add(newCustomerProducts);
                Notification newNotification = new Notification();
                newNotification.Date = DateTime.Now;
                newNotification.isReaded = false;
                newNotification.ReceiverUserID = data.CustomerID;
                newNotification.Header = "Size Özel Plan Oluşturuldu";
                newNotification.Content = data.title +
                                          " başlıklı planınız "+ selectedEmployee.NameSurname+ " tarafından oluşturulmuştur. Detaylar için lütfen takviminize bakınız ya da buraya tıklayınız.";
                newNotification.Url = @Url.Action("CustomerProductDetails","Customer",new {EventID=newCustomerProducts.id});
                _notificationManager.Add(newNotification);
                string userMail = "";
                var selectedCustomerEmployeeList = _customerEmployeeManager.GetEmployeeListByCustomerID(data.CustomerID);
                foreach (var users in selectedCustomerEmployeeList)
                {
                    var selectedEmployeeForMail = await _userManager.FindByIdAsync(users.EmployeeID);
                    var kullaniciRolleri = await _userManager.GetRolesAsync(selectedEmployeeForMail);
                    if (kullaniciRolleri[0] == "ops")
                    {
                        userMail = selectedEmployeeForMail.Email;
                        break;
                    }
                
                }

                var dateTime = data.end;
                dateTime = dateTime.Add(new TimeSpan(-3, 0, 0));
                DelayedJobs.SendMailForSharingScudele(userMail,data.title,dateTime);
                _notyf.Success("Başarıyla ürün planı oluşturuldu");
                return RedirectToAction("CustomerServicePlanningDates", "Ops",new {CustomerID = data.CustomerID});
            }
            CustomerServicePlanCreateDTO model = new CustomerServicePlanCreateDTO();
            model.CustomerID = data.CustomerID;
            List<ServiceList> ServiceListForCustomer = new List<ServiceList>();
            var serviceList = _customerServiceManager.GetCustomerServiceByCustomerID(data.CustomerID);
            foreach (var item in serviceList)
            {
                var selectedService = _serviceManager.GetById(item.ServiceID);
                ServiceListForCustomer.Add(new ServiceList
                {
                    ServiceID = selectedService.ID,
                    ServiceName = selectedService.Name,
                });
            }
            model.ServiceList = ServiceListForCustomer;
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult CustomerPlanningServiceForADay(int EventID)
        { 
            var productsPlan = _customerProductsManager.GetById(EventID);
            CustomerPlanningServiceForADayDTO product = new CustomerPlanningServiceForADayDTO();
            if (productsPlan != null)
            {
                if (productsPlan.Status == false)
                {
                    return RedirectToAction("CustomerProductsDetail", "Ops",new {CustomerProductsID = EventID});
                }
                product = _mapper.Map<CustomerPlanningServiceForADayDTO>(productsPlan);
                product.CustomerProductsID = EventID;
            }
            else
            {
                _notyf.Error("Lütfen doğru bir seçim yaptığınızdan emin olunuz");
                return RedirectToAction("CustomerServicePlanning", "Ops");
            }
            
            return View(product);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CustomerPlanningServiceForADay(CustomerPlanningServiceForADayDTO data)
        {
            if (ModelState.IsValid)
            {
                if (data.CustomerProductFiles != null)
                {
                    foreach (var file in data.CustomerProductFiles)
                    {
                        CustomerProductsFile newFile = new CustomerProductsFile();
                        var extension = Path.GetExtension(file.FileName);
                        var newFileName = Guid.NewGuid() + extension;
                        var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/CustomerProductsFile/", newFileName);
                        var stream = new FileStream(location, FileMode.Create);
                        file.CopyTo(stream);
                        newFile.Status = true;
                        newFile.CreateDate = DateTime.Now;
                        newFile.FilePath = newFileName;
                        newFile.CustomerProductsID = data.CustomerProductsID;
                        _customerProductsFileManager.Add(newFile);
                        var selectedCustomerProduct = _customerProductsManager.GetById(data.CustomerProductsID);
                        selectedCustomerProduct.color = "#7ecc52";
                        selectedCustomerProduct.Content = data.Content;
                        selectedCustomerProduct.Status = false;
                        _customerProductsManager.Update(selectedCustomerProduct);
                        var selectedUser = _userManager.FindByIdAsync(selectedCustomerProduct.CreatorID);
                        Notification newNotification = new Notification();
                        newNotification.Date = DateTime.Now;
                        newNotification.isReaded = false;
                        newNotification.ReceiverUserID = data.CustomerID;
                        newNotification.Header = "Ürününüz Yüklendi";
                        newNotification.Content = data.title +
                                                  " başlıklı ürünüz "+ selectedUser.Result.NameSurname + " tarafından yüklenmiştir. Detaylar için lütfen takviminize bakınız ya da buraya tıklayınız.";
                        newNotification.Url = @Url.Action("CustomerProductDetails","Customer",new {EventID=selectedCustomerProduct.id});
                        _notificationManager.Add(newNotification);
                        _notyf.Success("Ürün müşteriye başarıyla gönderilmiştir.");
                    }
                    return RedirectToAction("CustomerProductsDetail", "Ops", new {CustomerProductsID = data.CustomerProductsID});
                }
                _notyf.Error("Herhangi bir ürün eklemediniz.");
                return RedirectToAction("CustomerPlanningServiceForADay", "Ops",new {EventID = data.CustomerProductsID});
            }
            var productsPlan = _customerProductsManager.GetById(data.CustomerProductsID);
            if (productsPlan == null)
            {
                return RedirectToAction("CustomerServicePlanning", "Ops");
            }
            if (productsPlan.Status == false)
            {
                return RedirectToAction("CustomerProductsDetail", "Ops",new {CustomerProductsID = data.CustomerProductsID});
            }
            var product = _mapper.Map<CustomerPlanningServiceForADayDTO>(productsPlan);
            product.CustomerProductsID = data.CustomerProductsID;
            return View(data);
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> CustomerProductsDetail(int CustomerProductsID)
        {
             CustomerDetailsDTO model = new CustomerDetailsDTO();
            CustomerProductDemandForMarketing productDemand = new CustomerProductDemandForMarketing();
            List<DemandAnswers> demandAnswersList = new List<DemandAnswers>();
            List<DemandFileClass> demandFileList = new List<DemandFileClass>();
            List<CustomerProductsClass> dataList = new List<CustomerProductsClass>();
            var selectedCustomerProduct = _customerProductsManager.GetById(CustomerProductsID);
            if (selectedCustomerProduct != null)
            {
                var customerUser = await _userManager.FindByIdAsync(selectedCustomerProduct.CustomerID);
            var creatorUser = await _userManager.FindByIdAsync(selectedCustomerProduct.CreatorID);
            var productModel = _mapper.Map<CustomerProductsClass>(selectedCustomerProduct);
            productModel.ProductstReceiverCustomerName = customerUser.NameSurname;
            productModel.ProductstCreatorName = creatorUser.NameSurname;
            productModel.ProductID = selectedCustomerProduct.id;
            var productFilePath = _customerProductsFileManager.GetByProductId(CustomerProductsID);
            productModel.ProductsFilePath = productFilePath.FilePath;
            dataList.Add(productModel);
            model.CustomerProductsList = dataList;
            demandFileList.Add(new DemandFileClass
            {
                FileName = productModel.ProductsTitle+ "-Revize-Rapor.v1",FileDate = productFilePath.CreateDate,FilePath = productFilePath.FilePath,
            });
            var demand = _demandManager.GetByProductID(CustomerProductsID);
            if (demand != null)
            {
                productDemand.DemandTitle = demand.Title;
                productDemand.DemandContent = demand.Content;
                productDemand.DemandDate = demand.CreateDate;
                productDemand.CreatorName = customerUser.NameSurname;
                model.CustomerRevisedRequest = productDemand;
                var revisedCounter = 2;
                var selectedDemandAnswers = _demandAnswerManager.GetByDemandId(demand.ID);
                foreach (var item in selectedDemandAnswers)
                {
                    var receiverName = await _userManager.FindByIdAsync(item.ReceiverID);
                    var senderName = await _userManager.FindByIdAsync(item.SenderID);
                    if(item.AnswerFilePath != null && item.AnswerFilePath != null)
                    {
                        demandAnswersList.Add(new DemandAnswers
                        {
                            Message = item.Message, DemandAnswerDate = item.CreateTime, ReceiverName = receiverName.NameSurname,
                            SenderName = senderName.NameSurname,AnswerType = item.DemandAnswerType,FilePath = item.AnswerFilePath,FileName = item.FileName + ".v"+ revisedCounter
                        });
                        demandFileList.Add(new DemandFileClass
                        {
                            FilePath = item.AnswerFilePath,FileDate = item.CreateTime,
                            FileName =  item.FileName  + ".v"+ revisedCounter,
                        });
                        revisedCounter++;
                    }
                    else
                    {
                        demandAnswersList.Add(new DemandAnswers
                        {
                            Message = item.Message, DemandAnswerDate = item.CreateTime, ReceiverName = receiverName.NameSurname,
                            SenderName = senderName.NameSurname,AnswerType = item.DemandAnswerType,
                        });
                    }
                }
                model.DemandAnswersList = demandAnswersList;
            }
            }
            else
            {
                _notyf.Error("Lütfen doğru bir seçim yaptığınızdan emin olun");
                return RedirectToAction("CustomerServicePlanning", "Ops");   
            }
            model.DemandFileList = demandFileList;
            return View(model);
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CustomerProductsDetail(CustomerDetailsDTO data)
        {
            var selectedCustomerProductDemand = _demandManager.GetByProductID(data.CustomerProductsList[0].ProductID);
            if (selectedCustomerProductDemand == null)
            {
                _notyf.Error("Bir hata oluştu. Lütfen tekrar deneyiniz.");
                return RedirectToAction("CustomerProductsDetail","Ops",new {CustomerProductsID = data.CustomerProductsList[0].ProductID});
            }
            DemandAnswer newDemandAnswer = new DemandAnswer();
            newDemandAnswer.DemandID = selectedCustomerProductDemand.ID;
            newDemandAnswer.Message = data.DemandAnswer;
            newDemandAnswer.SenderID = selectedCustomerProductDemand.CreatorId;
            newDemandAnswer.ReceiverID = selectedCustomerProductDemand.ReceiverId;
            newDemandAnswer.Status = true;
            newDemandAnswer.CreateTime = DateTime.Now;
            newDemandAnswer.DemandAnswerType = 0;
            if (data.RevisedFile != null)
            {
                var selectedProductTitle = _customerProductsManager.GetById(data.CustomerProductsList[0].ProductID).title;
                newDemandAnswer.FileName = selectedProductTitle + "-Revize-Ops";
                var extension = Path.GetExtension(data.RevisedFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandFiles/", newFileName);
                var stream = new FileStream(location, FileMode.Create);
                data.RevisedFile.CopyTo(stream);
                newDemandAnswer.AnswerFilePath = newFileName;
                _demandAnswerManager.Add(newDemandAnswer);
            }
            else
            {
                _demandAnswerManager.Add(newDemandAnswer);
            }
            _notyf.Success("Yanıtınız başarıyla müşteriye gönderilmiştir.");
            return RedirectToAction("CustomerProductsDetail","Ops",new {CustomerProductsID = data.CustomerProductsList[0].ProductID});
        }
        
         [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> DemandToEmployee()
        {
            DemandToEmployeeDTO newModel = new DemandToEmployeeDTO();
            List<ComingDemantToMe> demandList = new List<ComingDemantToMe>();
            var employeeList = await (from user in _context.Users
                join userRole in _context.UserRoles
                    on user.Id equals userRole.UserId
                join role in _context.Roles
                    on userRole.RoleId equals role.Id
                where((role.Name == "designer" || role.Name == "ops" || role.Name == "marketing") && user.Status == true)
                select user).ToListAsync();
            var currentUser =  _userManager.GetUserAsync(User).Result;
            var demandListByEmployee = _demandManager.GetByEmployeeId(currentUser.Id);
            var demandListInbox = _demandManager.GetDemandInboxByReceiverId(currentUser.Id);
            List<Demand> demandListAll = demandListByEmployee.Concat(demandListInbox).ToList();
            foreach (var item in demandListAll)
            {
                var receiverUser = await _userManager.FindByIdAsync(item.ReceiverId);
                var senderUser = await _userManager.FindByIdAsync(item.CreatorId);
                demandList.Add(new ComingDemantToMe
                {
                    Title = item.Title,
                    ID = item.ID,
                    ReceiverName = receiverUser.NameSurname,
                    productId = item.CustomerProductsID,
                    SenderName = senderUser.NameSurname,
                    Status = item.Status,
                });
            }
            newModel.CreatorID = currentUser.Id;
            newModel.EmployeeList = employeeList;
            newModel.DemandListInbox = demandList;
            return View(newModel);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DemandToEmployee(DemandToEmployeeDTO data)
        {
            if (ModelState.IsValid)
            {
                var demand = _mapper.Map<Demand>(data);
                demand.CreateDate = DateTime.Now;
                demand.Status = true;
                _demandManager.Add(demand);
                if (data.DemandFiles != null)
                {
                    foreach (var file in data.DemandFiles)
                {
                    var newFile = new DemandFile();
                    var extension = Path.GetExtension(file.FileName);
                    var newFileName = Guid.NewGuid() + extension;
                    var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandFiles/", newFileName);
                    var stream = new FileStream(location, FileMode.Create);
                    file.CopyTo(stream);
                    newFile.Path = newFileName;
                    newFile.DemandID = demand.ID;
                    newFile.CreateDate = DateTime.Now;
                    newFile.CreatorID = data.CreatorID;
                    newFile.Status = true;
                    newFile.FileName = "test1";
                    _demandFileManager.Add(newFile);
                    
                }
                }
                var selectedEmployee = _userManager.FindByIdAsync(data.CreatorID).Result;
                Notification newNotification = new Notification();
                newNotification.Date = DateTime.Now;
                newNotification.isReaded = false;
                newNotification.ReceiverUserID = data.ReceiverID;
                newNotification.Header = "Personel Talebi";
                newNotification.Content = data.Title +
                                          " başlıklı talep "+ selectedEmployee.NameSurname + " tarafından size atanmıştır. Detaylar için lütfen taleplerinize bakınız ya da buraya tıklayınız.";
                var receiverEmployee = _userManager.FindByIdAsync(data.ReceiverID);
                var kullaniciRolleri = await _userManager.GetRolesAsync(receiverEmployee.Result);
                if (kullaniciRolleri[0] == "ops")
                {
                    newNotification.Url = @Url.Action("DemandInbox", "Ops",
                        new {id = demand.ID});
                }
                else if (kullaniciRolleri[0] == "designer")
                {
                    newNotification.Url = @Url.Action("DemandInbox", "Designer",
                        new {id = demand.ID});
                }
                else if (kullaniciRolleri[0] == "marketing")
                {
                    newNotification.Url = @Url.Action("DemandInbox", "Marketing",
                        new {id = demand.ID});
                }

                _notificationManager.Add(newNotification);
                _notyf.Success("Talep başarıyla oluşturuldu");
                return RedirectToAction("DemandDetails","Ops", new { id = demand.ID });
            }
            else
            {
                _notyf.Error("Talep oluşturulurken bir hata oluştu.");
            }
            var employeeList = await (from user in _context.Users
                join userRole in _context.UserRoles
                    on user.Id equals userRole.UserId
                join role in _context.Roles
                    on userRole.RoleId equals role.Id
                where((role.Name == "designer" || role.Name == "ops" || role.Name == "marketing") && user.Status == true)
                select user).ToListAsync();
            var currentUser =  _userManager.GetUserAsync(User).Result;
            DemandToEmployeeDTO model = new DemandToEmployeeDTO();
            model.CreatorID = currentUser.Id;
            model.EmployeeList = employeeList;
            return View(model);
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> DemandDetails(int id)
        {
            DemandDetailsDTO model = new DemandDetailsDTO();
            List<DemandDetailClass> dataList = new List<DemandDetailClass>();
            List<DemandAnswersForEmployee> demandAnswersList = new List<DemandAnswersForEmployee>();
            var selectedDemand = _demandManager.GetById(id);
            var selectedDemandFile = _demandFileManager.GetByDemandID(selectedDemand.ID);
            string demandFilePath;
            if (selectedDemandFile.Count == 0)
            {
                demandFilePath = null;
            }
            else
            {
                demandFilePath = selectedDemandFile[0].Path;
            }
            var receiverEmployee = await _userManager.FindByIdAsync(selectedDemand.ReceiverId);
            var creatorEmployee = await _userManager.FindByIdAsync(selectedDemand.CreatorId);
            dataList.Add(new DemandDetailClass
            {
                DemandContent = selectedDemand.Content, DemandCreateTime = selectedDemand.CreateDate,
                DemandCreatorName = creatorEmployee.NameSurname,
                DemandFilePath = demandFilePath,
                DemandReceiverName = receiverEmployee.NameSurname, DemandTitle = selectedDemand.Title
            });
            var selectedDemandAnswers = _demandAnswerManager.GetByDemandId(id);
            foreach (var item in selectedDemandAnswers)
            {
                var senderName = await _userManager.FindByIdAsync(item.SenderID);
                var receiverName = await _userManager.FindByIdAsync(item.ReceiverID);
                demandAnswersList.Add(new DemandAnswersForEmployee
                {
                    Message = item.Message, AnswerType = item.DemandAnswerType,FileName = item.FileName,DemandAnswerDate = item.CreateTime,FilePath = item.AnswerFilePath,
                    ReceiverName = receiverName.NameSurname,SenderName = senderName.NameSurname,
                });
            }
            model.EmployeeDemandAnswers = demandAnswersList;
            model.DemandID = selectedDemand.ID;
            model.DemandDetailList = dataList;
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DemandDetails(DemandDetailsDTO data)
        {
            DemandAnswer newDemandAnswer = new DemandAnswer();
            var selectedDemand = _demandManager.GetById(data.DemandID);
            newDemandAnswer.Message = data.DemandAnswer;
            newDemandAnswer.Status = true;
            newDemandAnswer.DemandID = selectedDemand.ID;
            newDemandAnswer.ReceiverID = selectedDemand.ReceiverId;   
            newDemandAnswer.SenderID = selectedDemand.CreatorId;
            newDemandAnswer.CreateTime = DateTime.Now;
            newDemandAnswer.DemandAnswerType = 2;
            if (data.DemandFile != null)
            {
                var extension = Path.GetExtension(data.DemandFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandFiles/", newFileName);
                var stream = new FileStream(location, FileMode.Create);
                data.DemandFile.CopyTo(stream);
                newDemandAnswer.FileName = data.DemandFile.FileName;
                newDemandAnswer.AnswerFilePath = newFileName;
            }
            _demandAnswerManager.Add(newDemandAnswer);
            _notyf.Success("Yanıtınız başarıyla gönderildi");
            return RedirectToAction("DemandDetails", "Ops", new {id = selectedDemand.ID});
        }
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> DemandInbox(int id)
        {
            var selectedDemand = _demandManager.GetById(id);
            var currentUser = await _userManager.GetUserAsync(User);
            if (selectedDemand.CreatorId == currentUser.Id)
            {
                return RedirectToAction("DemandDetails", "Ops", new {id = selectedDemand.ID});
            }
            DemandDetailsDTO model = new DemandDetailsDTO();
            List<DemandDetailClass> dataList = new List<DemandDetailClass>();
            List<DemandAnswersForEmployee> demandAnswersList = new List<DemandAnswersForEmployee>();
            var selectedDemandFile = _demandFileManager.GetByDemandID(selectedDemand.ID);
            string demandFilePath;
            if (selectedDemandFile.Count == 0)
            {
                demandFilePath = null;
            }
            else
            {
                demandFilePath = selectedDemandFile[0].Path;
            }
            var receiverEmployee = await _userManager.FindByIdAsync(selectedDemand.ReceiverId);
            var creatorEmployee = await _userManager.FindByIdAsync(selectedDemand.CreatorId);
            dataList.Add(new DemandDetailClass
            {
                DemandContent = selectedDemand.Content, DemandCreateTime = selectedDemand.CreateDate,
                DemandCreatorName = creatorEmployee.NameSurname,
                DemandFilePath = demandFilePath,
                DemandReceiverName = receiverEmployee.NameSurname, DemandTitle = selectedDemand.Title
            });
            var selectedDemandAnswers = _demandAnswerManager.GetByDemandId(id);
            foreach (var item in selectedDemandAnswers)
            {
                var receiverName = await _userManager.FindByIdAsync(item.ReceiverID);
                var senderName = await _userManager.FindByIdAsync(item.SenderID);
                demandAnswersList.Add(new DemandAnswersForEmployee
                {
                    Message = item.Message, AnswerType = item.DemandAnswerType,FileName = item.FileName,DemandAnswerDate = item.CreateTime,FilePath = item.AnswerFilePath,
                    ReceiverName = receiverName.NameSurname,SenderName = senderName.NameSurname,
                });
            }
            model.DemandDetailList = dataList;
            model.DemandID = selectedDemand.ID;
            model.EmployeeDemandAnswers = demandAnswersList;
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DemandInbox(DemandDetailsDTO data)
        {
            DemandAnswer newDemandAnswer = new DemandAnswer();
            var selectedDemand = _demandManager.GetById(data.DemandID);
            newDemandAnswer.Message = data.DemandAnswer;
            newDemandAnswer.Status = true;
            newDemandAnswer.DemandID = selectedDemand.ID;
            newDemandAnswer.ReceiverID = selectedDemand.CreatorId;
            newDemandAnswer.SenderID = selectedDemand.ReceiverId;
            newDemandAnswer.CreateTime = DateTime.Now;
            newDemandAnswer.DemandAnswerType = 1;
            if (data.DemandFile != null)
            {
                var extension = Path.GetExtension(data.DemandFile.FileName);
                var newFileName = Guid.NewGuid() + extension;
                var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/DemandFiles/", newFileName);
                var stream = new FileStream(location, FileMode.Create);
                data.DemandFile.CopyTo(stream);
                newDemandAnswer.FileName = data.DemandFile.FileName;
                newDemandAnswer.AnswerFilePath = newFileName;
            }
            _demandAnswerManager.Add(newDemandAnswer);
            _notyf.Success("Yanıtınız başarıyla gönderildi");
            return RedirectToAction("DemandInbox", "Ops", new {id = selectedDemand.ID});
        }
        public IActionResult EmployeeCalendar(string EmployeeID)
        {
            return View();
        }
        [HttpGet]
        public IActionResult EmployeeCalendarPlanCreate(string EmployeeID, string StartDate)
        {
            EmployeeCalendarPlanCreateDTO newModel = new EmployeeCalendarPlanCreateDTO();
            if (StartDate != null)
            {
                String format = "ddd MMM dd yyyy HH:mm:ss GMT 0300 (GMT 03:00)";
                DateTime formattingDateTime = DateTime.ParseExact(StartDate, format, CultureInfo.InvariantCulture);
                newModel.EmployeeID = EmployeeID;
                var endTime = formattingDateTime.AddDays(2);
                newModel.start = formattingDateTime;
            }
            else
            {
                newModel.EmployeeID = EmployeeID;
                var endTime = DateTime.Now.AddDays(2);
                newModel.start = DateTime.Now;
                newModel.end = endTime;
            }
            return View(newModel);;
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeCalendarPlanCreate(EmployeeCalendarPlanCreateDTO data)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);
                var newEmployeeCalendarPlan = _mapper.Map<EmployeeCalendar>(data);
                newEmployeeCalendarPlan.Status = true;
                newEmployeeCalendarPlan.color = "#f45151";
                newEmployeeCalendarPlan.textColor = "#fff";
                newEmployeeCalendarPlan.EmployeeID = currentUser.Id;
                _employeeCalendarManager.Add(newEmployeeCalendarPlan);
                _notyf.Success("Başarıyla ürün planı oluşturuldu");
                return RedirectToAction("EmployeeCalendar", "Ops",new {EmployeeID = data.EmployeeID});
            }
            EmployeeCalendarPlanCreateDTO model = new EmployeeCalendarPlanCreateDTO();
            model.EmployeeID = data.EmployeeID;
            return View(model);
        }
        [HttpGet]
        public IActionResult EmployeeCalendarPlanEdit(int EventID)
        {
            var selectedEvent = _employeeCalendarManager.GetById(EventID);
            var model = _mapper.Map<EmployeeCalendarPlanCreateDTO>(selectedEvent);
            model.EventID = EventID;
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeCalendarPlanEdit(EmployeeCalendarPlanCreateDTO data)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var updatedEvent = _mapper.Map<EmployeeCalendar>(data);
            updatedEvent.id = data.EventID;
            updatedEvent.Status = true;
            updatedEvent.color = "#f45151";
            updatedEvent.textColor = "#fff";
            _employeeCalendarManager.Update(updatedEvent);
            _notyf.Success("Etkinlik başarıyla güncellendi");
            return RedirectToAction("EmployeeCalendar", "Ops",new {EmployeeID = currentUser.Id});
        }

        [HttpGet]
        public async Task<IActionResult> EmployeeCalendarPlanDelete(int EventID)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var selectedEvent = _employeeCalendarManager.GetById(EventID);
            selectedEvent.Status = false;
            _employeeCalendarManager.Update(selectedEvent);
            _notyf.Success("Etkinlik başarıyla silindi");
            return RedirectToAction("EmployeeCalendar", "Ops",new {EmployeeID = currentUser.Id});
        }
        [HttpGet]
        public async Task<IActionResult> CustomerServicePlanDelete(int EventID)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            var selectedEvent = _customerProductsManager.GetById(EventID);
            _customerProductsManager.Delete(selectedEvent);
            _notyf.Success("Etkinlik başarıyla silindi");
            return RedirectToAction("CustomerServicePlanningDates", "Ops",new {CustomerID = selectedEvent.CustomerID});
        }

        [HttpGet]
        public IActionResult CustomerServicePlanEdit(int EventID)
        {
            var selectedEvent = _customerProductsManager.GetById(EventID);
            if (selectedEvent.Status == false)
            {
                return RedirectToAction("CustomerProductsDetail", "Ops",new {CustomerProductsID = EventID});
            }
            var product = _mapper.Map<CustomerPlanningServiceForADayDTO>(selectedEvent);
            var seperatorString = product.title.Split(" ");
            var count = 0;
            string newTitle= null;
            foreach (var item in seperatorString)
            {
                if (count != 0)
                {
                    newTitle += item+" ";
                }
                count += 1;
            }

            product.title = newTitle;
            product.CustomerProductsID = EventID;
            return View(product);
        }

        [HttpPost]
        public IActionResult CustomerServicePlanEdit(CustomerPlanningServiceForADayDTO data)
        {
            var updatedEvent = _customerProductsManager.GetById(data.CustomerProductsID);
            updatedEvent.start = data.start;
            updatedEvent.end = data.end;
            updatedEvent.title = data.ProductType + " " + data.title;
            _customerProductsManager.Update(updatedEvent);
            _notyf.Success("Etkinlik başarıyla güncellendi");
            return RedirectToAction("CustomerServicePlanningDates", "Ops",new {CustomerID = data.CustomerID});
        }

        public async Task<IActionResult> CustomerPayments()
        {
            List<CustomerListWithPaymentRoutineName> customerPaymentList = new List<CustomerListWithPaymentRoutineName>();
            string ServiceNamesForCustomer = "";
            var currentUser = await _userManager.GetUserAsync(User);;
            var customerIDsForEmployee = _customerEmployeeManager.GetEmployeeListByEmployeeID(currentUser.Id);
            foreach (var oneCustomerEmployee in customerIDsForEmployee)
            {
                var selectedCustomer = await _userManager.FindByIdAsync(oneCustomerEmployee.CustomerID);
                var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(selectedCustomer.Id);
                ServiceNamesForCustomer = "";
                PaymentRoutineType paymentRoutineType = new PaymentRoutineType();
                foreach (var customerServices in customerService)
                {
                    paymentRoutineType = _paymentRoutineTypeManager.GetById(customerServices.PaymentRoutineTypeID);
                    var selectedService = _serviceManager.GetById(customerServices.ServiceID);
                    ServiceNamesForCustomer = selectedService.Name + ", " + ServiceNamesForCustomer;
                }

                customerPaymentList.Add(new CustomerListWithPaymentRoutineName
                {
                    CustomerID = selectedCustomer.Id, CustomerName = selectedCustomer.NameSurname, CustomerMail = selectedCustomer.Email,
                    ServiceNames = ServiceNamesForCustomer,PaymentRoutineName = paymentRoutineType.Name
                });
            }


            return View(customerPaymentList);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerPaymentTracking(string CustomerID)
        {
            CustomerPaymentTrackingDTO model = new CustomerPaymentTrackingDTO();
            List<Services> serviceList = new List<Services>();
            double PaymentPriceSum = 0;
            List<PaymentHistoryClass> paymentHistoryList = new List<PaymentHistoryClass>();
            var selectedCustomer = await _userManager.FindByIdAsync(CustomerID);
            model.CustomerMail = selectedCustomer.Email;
            model.CustomerName = selectedCustomer.NameSurname;
            model.CustomerID = selectedCustomer.Id;
            StringBuilder sb = new StringBuilder();
            var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(selectedCustomer.Id);
            foreach (var service in customerService)
            {
                var selectedService = _serviceManager.GetById(service.ServiceID);
                serviceList.Add(selectedService);
                sb.Append(selectedService.Name + ", ");
            }
            var selectedCustomerPaymentHistory = _customerPaymentsManager.GetPaymentListByCustomerID(selectedCustomer.Id);
            foreach (var payment in selectedCustomerPaymentHistory)
            {
                PaymentPriceSum += payment.PaymentPrice;
                paymentHistoryList.Add(new PaymentHistoryClass
                {
                    PaymentDate = payment.PaymentDate,
                    PaymentPrice = payment.PaymentPrice,
                });
            }
            model.CustomerServices = sb.ToString();
            model.serviceList = serviceList;
            model.PaymentHistoryList = paymentHistoryList;
            model.PaymentPriceSum = PaymentPriceSum;
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> CustomerPaymentTracking(CustomerPaymentTrackingDTO data, IFormCollection collection)
        {
            var selectedCustomer = await _userManager.FindByIdAsync(data.CustomerID);
            if (data.SelectedServiceID == 0)
            {
                _notyf.Error("Müşteri ödeme kaydı yapılırken bir hata oluştu.");
                return RedirectToAction("CustomerPaymentTracking", new { CustomerID = selectedCustomer.Id });
            }
            if (data.PaymentPrice == 0)
            {
                _notyf.Error("Müşteri ödeme kaydı yapılırken bir hata oluştu.");
                return RedirectToAction("CustomerPaymentTracking", new { CustomerID = selectedCustomer.Id });
            }
            if (ModelState.IsValid)
            {
               
                var customerServiceData = _customerServiceManager.GetCustomerServiceByCustomerIDandCustomerService(data.CustomerID,
                    data.SelectedServiceID);
                CustomerPayment newCustomerPayment = new CustomerPayment();
                newCustomerPayment.CustomerID = selectedCustomer.Id;
                var price = collection["PaymentPrice"].ToString();
                newCustomerPayment.PaymentPrice = double.Parse(price, System.Globalization.CultureInfo.InvariantCulture);
                newCustomerPayment.PaymentDate = data.SelectedDate;
                newCustomerPayment.PaymentRoutineTypeID = customerServiceData.PaymentRoutineTypeID;
                newCustomerPayment.Status = true;
                _customerPaymentsManager.Add(newCustomerPayment);
                _notyf.Success("Müşteri ödeme kaydı tamamlandı");
                return RedirectToAction("CustomerPaymentTracking", new { CustomerID = selectedCustomer.Id });
            }
            
            CustomerPaymentTrackingDTO model = new CustomerPaymentTrackingDTO();
            List<Services> serviceList = new List<Services>();
            model.CustomerMail = selectedCustomer.Email;
            model.CustomerName = selectedCustomer.NameSurname;
            model.CustomerID = selectedCustomer.Id;
            StringBuilder sb = new StringBuilder();
            var customerService = _customerServiceManager.GetCustomerServiceByCustomerID(selectedCustomer.Id);
            foreach (var service in customerService)
            {
                var selectedService = _serviceManager.GetById(service.ServiceID);
                serviceList.Add(selectedService);
                sb.Append(selectedService.Name + ", ");
            }
            model.CustomerServices = sb.ToString();
            model.serviceList = serviceList;
            _notyf.Error("Müşteri ödeme kaydı yapılırken bir hata oluştu.");
            return View(model);
        }
        
        [HttpGet]
        public IActionResult CloseDemand(int CustomerProductsID)
        {
            var demand = _demandManager.GetByProductID(CustomerProductsID);
            demand.Status = false;
            _demandManager.Update(demand);
            _notyf.Success("Müşteri talebi başarıyla kapatıldı");
            return RedirectToAction("CustomerProductsDetail", "Ops",new {CustomerProductsID = CustomerProductsID});
        }
        
        [HttpGet]
        public IActionResult CloseDemandForInbox(int DemandID)
        {
            var demand = _demandManager.GetById(DemandID);
            demand.Status = false;
            _demandManager.Update(demand);
            _notyf.Success("Müşteri talebi başarıyla kapatıldı");
            return RedirectToAction("DemandDetails", "Ops",new {id = DemandID});
        }
        
       
        
        
    }
}