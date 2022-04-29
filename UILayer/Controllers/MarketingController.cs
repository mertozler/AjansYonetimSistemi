using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BackgroundJobs.Schedules;
using BusinessLayer.Concrete;
using BusinessLayer.Utils;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project.Models;
using Notification = EntityLayer.Concrete.Notification;

namespace Project.Controllers
{
    [Authorize(Roles = "marketing")]
    public class MarketingController : Controller
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
        private EmployeeCalendarManager _employeeCalendarManager =
            new EmployeeCalendarManager(new EfEmployeeCalendarRepository());
        DemandAnswerManager _demandAnswerManager = new DemandAnswerManager(new EfDemandAnswersRepository());
        
        CustomerProdutcsManager _customerProductsManager = new CustomerProdutcsManager(new EfCustomerProductsRepository());
        CustomerProductsFileManager _customerProductsFileManager = new CustomerProductsFileManager(new EfCustomerProductsFileRepository());
        DemandManager _demandManager = new DemandManager(new EfDemandRepository());
        DemandFilesManager _demandFileManager = new DemandFilesManager(new EfDemandFilesRepository());
        private CustomerEmployeeManager _customerEmployeeManager =
            new CustomerEmployeeManager(new EfCustomerEmployeeRepository());
        private readonly ILogger<MarketingController> _logger;

        private NotificationManager _notificationManager = new NotificationManager(new EfNotificationRepository());
        public MarketingController(INotyfService notyf,Context context,IMapper mapper,
            UserManager<ApplicationUser> userManager,ILogger<MarketingController> logger)
        {
            _userManager = userManager;
            _mapper = mapper;
            _notyf = notyf;
            _context = context;
            _logger = logger;
        }
        // GET
        public IActionResult Index()
        {
            return View();
        }
        
        public async Task<IActionResult> CustomerServicePlanning()
        {
            List<CustomerListWithServiceName> customerServiceList = new List<CustomerListWithServiceName>();
            try
            {
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

            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(customerServiceList);
        }
        
        public IActionResult CustomerServicePlanningDates(string CustomerID)
        {
            try
            {
                var selectedCustomerServiceCheck = _customerServiceManager.GetCustomerServiceByCustomerID(CustomerID);
                if (selectedCustomerServiceCheck.Count == 0)
                {
                    _notyf.Error("Müşteriye henüz bir hizmet tanımlaması olmadığından hizmet planlaması yapılamamaktadır.");
                    return RedirectToAction("CustomerServicePlanning", "Marketing");
                }
                ViewBag.CustomerID = CustomerID;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View();
        }
        
        public IActionResult GetAllEvents(string CustomerID)
        {
            List<Event> eventList = new List<Event>();
            try
            {
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return new JsonResult(eventList);
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult CustomerServicePlanCreate(string CustomerID, string StartDate)
        {
            CustomerServicePlanCreateDTO newModel = new CustomerServicePlanCreateDTO();
            try
            {
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
                    newModel.end = endTime;
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            
            return View(newModel);;
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> CustomerServicePlanCreate(CustomerServicePlanCreateDTO data)
        {
            CustomerServicePlanCreateDTO model = new CustomerServicePlanCreateDTO();
            try
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
                newCustomerProducts.Status = true;
                newCustomerProducts.title = data.ProductType + " " + data.title;
                newCustomerProducts.color = "#f45151";
                newCustomerProducts.textColor = "#fff";
                newCustomerProducts.ServiceID = data.SelectedServiceID;
                newCustomerProducts.description = "Bu plan " + selectedService.Name + " hizmeti için "+ currentUser.NameSurname +  " tarafından oluşturuldu.";
                newCustomerProducts.CreateDate = DateTime.Now;
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
                var selectedEmployeePhoneNumber = selectedEmployee.PhoneNumber;
                DelayedJobs.SendMailForSharingScudele(userMail,data.title,dateTime,selectedEmployeePhoneNumber);
                _notyf.Success("Başarıyla ürün planı oluşturuldu");
                return RedirectToAction("CustomerServicePlanningDates", "Marketing",new {CustomerID = data.CustomerID});
            }
            
            List<ServiceList> ServiceListForCustomer = new List<ServiceList>();
            model.CustomerID = data.CustomerID;
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(model);

        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult CustomerPlanningServiceForADay(int EventID)
        {
            CustomerPlanningServiceForADayDTO product = new CustomerPlanningServiceForADayDTO();
            try
            {
                var productsPlan = _customerProductsManager.GetById(EventID);
                if (productsPlan.Status == false)
                {
                    return RedirectToAction("CustomerProductsDetail", "Marketing",new {CustomerProductsID = EventID});
                }
                product = _mapper.Map<CustomerPlanningServiceForADayDTO>(productsPlan);
                product.CustomerProductsID = EventID;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
            return View(product);
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CustomerPlanningServiceForADay(CustomerPlanningServiceForADayDTO data)
        {
            try
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
                        selectedCustomerProduct.Status = false;
                        selectedCustomerProduct.Content = data.Content;
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
                    return RedirectToAction("CustomerProductsDetail", "Marketing", new {CustomerProductsID = data.CustomerProductsID});
                }
                _notyf.Error("Herhangi bir ürün eklemediniz.");
                return RedirectToAction("CustomerPlanningServiceForADay", "Marketing",new {EventID = data.CustomerProductsID});
            }
            var productsPlan = _customerProductsManager.GetById(data.CustomerProductsID);
            if (productsPlan == null)
            {
                return RedirectToAction("CustomerServicePlanning", "Marketing");
            }
            if (productsPlan.Status == false)
            {
                return RedirectToAction("CustomerProductsDetail", "Marketing",new {CustomerProductsID = data.CustomerProductsID});
            }
            var product = _mapper.Map<CustomerPlanningServiceForADayDTO>(productsPlan);
            product.CustomerProductsID = data.CustomerProductsID;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
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
            try
            {
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
                _notyf.Error("Lütfen bir ürün seçtiğinizden emin olunuz.");
                return RedirectToAction("CustomerServicePlanning", "Marketing");
            }

           
            model.DemandFileList = demandFileList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(model);
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult CustomerProductsDetail(CustomerDetailsDTO data)
        {
            try
            {
                var selectedCustomerProductDemand = _demandManager.GetByProductID(data.CustomerProductsList[0].ProductID);
                if (selectedCustomerProductDemand == null)
                {
                    _notyf.Error("Bir hata oluştu. Lütfen tekrar deneyiniz.");
                    return RedirectToAction("CustomerProductsDetail","Marketing",new {CustomerProductsID = data.CustomerProductsList[0].ProductID});
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
                    newDemandAnswer.FileName = selectedProductTitle + "-Revize-Rapor";
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return RedirectToAction("CustomerProductsDetail","Marketing",new {CustomerProductsID = data.CustomerProductsList[0].ProductID});
        }
        
         [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> DemandToEmployee()
        {
            DemandToEmployeeDTO newModel = new DemandToEmployeeDTO();
            List<ComingDemantToMe> demandList = new List<ComingDemantToMe>();
            try
            {
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
            return View(newModel);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DemandToEmployee(DemandToEmployeeDTO data)
        {
            DemandToEmployeeDTO model = new DemandToEmployeeDTO();
            try
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
                return RedirectToAction("DemandDetails","Marketing", new { id = demand.ID });
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
            
            model.CreatorID = currentUser.Id;
            model.EmployeeList = employeeList;
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> DemandInbox(int id)
        {
            DemandDetailsDTO model = new DemandDetailsDTO();
            try
            {
                var selectedDemand = _demandManager.GetById(id);
            var currentUser = await _userManager.GetUserAsync(User);
            if (selectedDemand.CreatorId == currentUser.Id)
            {
                return RedirectToAction("DemandDetails", "Marketing", new {id = selectedDemand.ID});
            }
            
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(model);
        }
        
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DemandInbox(DemandDetailsDTO data)
        {
            DemandAnswer newDemandAnswer = new DemandAnswer();
            var selectedDemand = _demandManager.GetById(data.DemandID);
            try
            {
                
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
            return RedirectToAction("DemandInbox", "Marketing", new {id = selectedDemand.ID});
        }
        
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public async Task<IActionResult> DemandDetails(int id)
        {
            DemandDetailsDTO model = new DemandDetailsDTO();
            List<DemandDetailClass> dataList = new List<DemandDetailClass>();
            List<DemandAnswersForEmployee> demandAnswersList = new List<DemandAnswersForEmployee>();
            try
            {
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
                    var receiverName = await _userManager.FindByIdAsync(item.ReceiverID);
                    var senderName = await _userManager.FindByIdAsync(item.SenderID);
                    demandAnswersList.Add(new DemandAnswersForEmployee
                    {
                        Message = item.Message, AnswerType = item.DemandAnswerType,FileName = item.FileName,DemandAnswerDate = item.CreateTime,FilePath = item.AnswerFilePath,
                        ReceiverName = receiverName.NameSurname,SenderName = senderName.NameSurname,
                    });
                }
                model.EmployeeDemandAnswers = demandAnswersList;
                model.DemandID = selectedDemand.ID;
                model.DemandDetailList = dataList;  
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(model);
        }
        [Microsoft.AspNetCore.Mvc.HttpPost]
        public async Task<IActionResult> DemandDetails(DemandDetailsDTO data)
        {
            DemandAnswer newDemandAnswer = new DemandAnswer();
            var selectedDemand = _demandManager.GetById(data.DemandID);
            try
            {
               
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return RedirectToAction("DemandDetails", "Marketing", new {id = selectedDemand.ID});
        }
        public IActionResult EmployeeCalendar()
        {
            return View();
        }
        
        public IActionResult GetAllEventsForEmployee(string EmployeeID)
        {
            List<EmployeeEvent> eventList = new List<EmployeeEvent>();
            try
            {
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return new JsonResult(eventList);
        }
        
        [HttpGet]
        public IActionResult EmployeeCalendarPlanCreate(string EmployeeID, string StartDate)
        {
            EmployeeCalendarPlanCreateDTO newModel = new EmployeeCalendarPlanCreateDTO();
            try
            {
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
           
            
            return View(newModel);;
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeCalendarPlanCreate(EmployeeCalendarPlanCreateDTO data)
        {
            EmployeeCalendarPlanCreateDTO model = new EmployeeCalendarPlanCreateDTO();
            try
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
                    return RedirectToAction("EmployeeCalendar", "Marketing",new {EmployeeID = data.EmployeeID});
                }
                
                model.EmployeeID = data.EmployeeID; 
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(model);
        }
        
        [HttpGet]
        public async Task<IActionResult> EmployeeCalendarPlanEdit(int EventID)
        {
            EmployeeCalendarPlanCreateDTO model = new EmployeeCalendarPlanCreateDTO();
            try
            {
                var selectedEvent = _employeeCalendarManager.GetById(EventID);
                if (selectedEvent != null)
                { model = _mapper.Map<EmployeeCalendarPlanCreateDTO>(selectedEvent);
                    model.EventID = EventID;
                }
                else
                {
                    var currentUser = await _userManager.GetUserAsync(User);
                    _notyf.Error("Lütfen doğru bir seçim yaptığınzdan emin olunuz");
                    return RedirectToAction("EmployeeCalendar", "Marketing", new  { EmployeeID = currentUser.Id });
                } 
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
           
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> EmployeeCalendarPlanEdit(EmployeeCalendarPlanCreateDTO data)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            try
            {
                
                var updatedEvent = _mapper.Map<EmployeeCalendar>(data);
                updatedEvent.id = data.EventID;
                updatedEvent.Status = true;
                updatedEvent.color = "#f45151";
                updatedEvent.textColor = "#fff";
                _employeeCalendarManager.Update(updatedEvent);
                _notyf.Success("Etkinlik başarıyla güncellendi");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return RedirectToAction("EmployeeCalendar", "Marketing",new {EmployeeID = currentUser.Id});
        }
        
        [HttpGet]
        public async Task<IActionResult> EmployeeCalendarPlanDelete(int EventID)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            try
            {
                
                var selectedEvent = _employeeCalendarManager.GetById(EventID);
                selectedEvent.Status = false;
                _employeeCalendarManager.Update(selectedEvent);
                _notyf.Success("Etkinlik başarıyla silindi");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return RedirectToAction("EmployeeCalendar", "Marketing",new {EmployeeID = currentUser.Id});
        }
        [HttpGet]
        public async Task<IActionResult> CustomerServicePlanDelete(int EventID)
        {
            var selectedEvent = _customerProductsManager.GetById(EventID);
            try
            {
                var currentUser = await _userManager.GetUserAsync(User);
                
                _customerProductsManager.Delete(selectedEvent);
                _notyf.Success("Etkinlik başarıyla silindi"); 
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
           
            return RedirectToAction("CustomerServicePlanningDates", "Marketing",new {CustomerID = selectedEvent.CustomerID});
        }
        
        [HttpGet]
        public IActionResult CustomerServicePlanEdit(int EventID)
        {
            CustomerPlanningServiceForADayDTO product = new CustomerPlanningServiceForADayDTO();
            try
            {
                var selectedEvent = _customerProductsManager.GetById(EventID);
                if (selectedEvent.Status == false)
                {
                    return RedirectToAction("CustomerProductsDetail", "Marketing",new {CustomerProductsID = EventID});
                }
                product = _mapper.Map<CustomerPlanningServiceForADayDTO>(selectedEvent);
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
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
            return View(product);
        }

        [HttpPost]
        public IActionResult CustomerServicePlanEdit(CustomerPlanningServiceForADayDTO data)
        {
            try
            {
                var updatedEvent = _customerProductsManager.GetById(data.CustomerProductsID);
                updatedEvent.start = data.start;
                updatedEvent.end = data.end;
                updatedEvent.title = data.ProductType + " " + data.title;
                _customerProductsManager.Update(updatedEvent);
                _notyf.Success("Etkinlik başarıyla güncellendi");
            }
            catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }

           
            return RedirectToAction("CustomerServicePlanningDates", "Marketing",new {CustomerID = data.CustomerID});
        }
        
        
        [HttpGet]
        public IActionResult CloseDemand(int CustomerProductsID)
        {
            try
            {
                var demand = _demandManager.GetByProductID(CustomerProductsID);
                demand.Status = false;
                _demandManager.Update(demand);
                _notyf.Success("Müşteri talebi başarıyla kapatıldı");
            } catch (Exception e)
            {
                _logger.LogError(e, e.Message);
            }
            
           
            return RedirectToAction("CustomerProductsDetail", "Marketing",new {CustomerProductsID = CustomerProductsID});
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
                        mailService.SendMailWithReceiverMailContextAndSubject(selectedUser.Email, "Şifre Güncelleme", "Şifreniz başarıyla değiştirilmiştir.");
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
            return RedirectToAction("Profile", "Marketing");
        }
        
    }
}