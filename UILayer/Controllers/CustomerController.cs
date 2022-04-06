using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreHero.ToastNotification.Abstractions;
using AutoMapper;
using BusinessLayer.Concrete;
using DataAccessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using EntityLayer.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class CustomerController : Controller
    {
        private readonly INotyfService _notyf;
        private readonly Context _context;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ServiceManager _serviceManager = new ServiceManager(new EfServicesRepository());
        private readonly PackageManager _packageManager = new PackageManager(new EfPackageRepository());

        private EmployeeCalendarManager _employeeCalendarManager =
            new EmployeeCalendarManager(new EfEmployeeCalendarRepository());

        private readonly ServicePackageManager _servicePackageManager =
            new ServicePackageManager(new EfServicePackageRepository());

        private readonly CustomerServiceManager _customerServiceManager =
            new CustomerServiceManager(new EfCustomerServiceRepository());

        CustomerProdutcsManager _customerProductsManager =
            new CustomerProdutcsManager(new EfCustomerProductsRepository());

        CustomerProductsFileManager _customerProductsFileManager =
            new CustomerProductsFileManager(new EfCustomerProductsFileRepository());

        DemandManager _demandManager = new DemandManager(new EfDemandRepository());
        DemandFilesManager _demandFileManager = new DemandFilesManager(new EfDemandFilesRepository());
        private DemandAnswerManager _demandAnswerManager = new DemandAnswerManager(new EfDemandAnswersRepository());
        public CustomerController(INotyfService notyf, Context context, IMapper mapper,
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _notyf = notyf;
            _context = context;
        }

        // GET
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CustomerCalendar()
        {
            return View();
        }

        public async Task<IActionResult> GetAllEventsForCustomer()
        {
            var loggedCustomer = await _userManager.GetUserAsync(User);
            List<Event> eventList = new List<Event>();
            var events = _customerProductsManager.GetCustomerProductsListByCustomerID(loggedCustomer.Id);
            foreach (var item in events)
            {
                Event newEvent = new Event();
                newEvent.id = item.id;
                newEvent.start = item.start;
                newEvent.color = item.color;
                newEvent.title = item.title;
                newEvent.textColor = item.textColor;
                newEvent.end = item.end;
                eventList.Add(newEvent);
            }

            return new JsonResult(eventList);
        }

        [HttpGet]
        public async Task<IActionResult> CustomerProductDetails(int EventID)
        {
            List<DemandAnswersForCustomer> demandAnswersList = new List<DemandAnswersForCustomer>();
            List<DemandFileClassForCustomer> demandFileList = new List<DemandFileClassForCustomer>();
            var productsPlan = _customerProductsManager.GetById(EventID);
            if (productsPlan.Status == true)
            {
                return RedirectToAction("CustomerCalendar", "Customer");
            }
            var customerProducts = _mapper.Map<CustomerProductDetailForCustomerDTO>(productsPlan);
            var productFiles = _customerProductsFileManager.GetByProductId(productsPlan.id);
            var creatorEmployee = await _userManager.FindByIdAsync(productsPlan.CreatorID);
            var creatorEmployeeRole = await _userManager.GetRolesAsync(creatorEmployee);
            string productType = "";
            if (creatorEmployeeRole[0] == "marketing")
            {
                productType = "Rapor";
            }
            else if (creatorEmployeeRole[0] == "designer")
            {
                productType = "Tasarım";
            }
            customerProducts.EmployeeName = creatorEmployee.NameSurname;
            customerProducts.ProductFilePath = productFiles.FilePath;
            // Get product demand and add to customer product
            demandFileList.Add(new DemandFileClassForCustomer
            {
                FileName = customerProducts.ProductTitle + "-" + productType + ".v1", FileDate = customerProducts.ProductDate,
                FilePath = customerProducts.ProductFilePath,
            });
            var demand = _demandManager.GetByProductID(EventID);
            if (demand != null)
            {
               
                var loggedCustomer = await _userManager.GetUserAsync(User);
                CustomerProductDemand productDemand = new CustomerProductDemand();
                productDemand.DemandTitle = demand.Title;
                productDemand.DemandContent = demand.Content;
                productDemand.DemandDate = demand.CreateDate;
                productDemand.CreatorName = loggedCustomer.NameSurname;
                customerProducts.RevisedRequest = productDemand;
                var revisedCounter = 2;
                var selectedDemand = _demandAnswerManager.GetByDemandId(demand.ID);
                foreach (var demandItem in selectedDemand)
                {
                    var receiverName = await _userManager.FindByIdAsync(demandItem.ReceiverID);
                    var senderName = await _userManager.FindByIdAsync(demandItem.SenderID);
                    if (demandItem.AnswerFilePath != null && demandItem.AnswerFilePath != null)
                    {
                        demandAnswersList.Add(new DemandAnswersForCustomer
                        {
                            Message = demandItem.Message, DemandAnswerDate = demandItem.CreateTime,
                            ReceiverName = receiverName.NameSurname,
                            SenderName = senderName.NameSurname, AnswerType = demandItem.DemandAnswerType,
                            FilePath = demandItem.AnswerFilePath, FileName = demandItem.FileName + ".v" + revisedCounter
                        });
                        demandFileList.Add(new DemandFileClassForCustomer
                        {
                            FilePath = demandItem.AnswerFilePath, FileDate = demandItem.CreateTime,
                            FileName = demandItem.FileName + ".v" + revisedCounter,
                        });
                        revisedCounter++;
                    }
                    else
                    {
                        demandAnswersList.Add(new DemandAnswersForCustomer
                        {
                            Message = demandItem.Message, DemandAnswerDate = demandItem.CreateTime,
                            ReceiverName = receiverName.NameSurname,
                            SenderName = senderName.NameSurname, AnswerType = demandItem.DemandAnswerType,
                        });
                    }
                }

               
                
            }
            customerProducts.DemandFileList = demandFileList;
            customerProducts.DemandAnswerList = demandAnswersList;
            return View(customerProducts);
        }
        
        [HttpPost]
        public async Task<IActionResult> CustomerProductDetails(CustomerProductDetailForCustomerDTO data)
        {
            Demand newDemandToEmployee = new Demand();
            var checkDemandisExist = _demandManager.GetByProductID(data.CustomerProductsID);
            if (checkDemandisExist == null)
            {
                var selectedProducts = _customerProductsManager.GetById(data.CustomerProductsID);
                var loggedCustomer = await _userManager.GetUserAsync(User);
                newDemandToEmployee.CreatorId = loggedCustomer.Id;
                newDemandToEmployee.ReceiverId = selectedProducts.CreatorID;
                newDemandToEmployee.Content = data.CustomerRequestContent;
                newDemandToEmployee.CreateDate = DateTime.Now;
                newDemandToEmployee.Status = true;
                newDemandToEmployee.CustomerProductsID = data.CustomerProductsID;
                newDemandToEmployee.Title = selectedProducts.title + " başlıklı ürünün revize talebi.";
                _demandManager.Add(newDemandToEmployee);
            }
            else
            {
                DemandAnswer newDemandAnswer = new DemandAnswer();
                newDemandAnswer.DemandID = checkDemandisExist.ID;
                newDemandAnswer.Message = data.CustomerRequestContent;
                newDemandAnswer.SenderID = checkDemandisExist.ReceiverId;
                newDemandAnswer.ReceiverID = checkDemandisExist.CreatorId;
                newDemandAnswer.Status = true;
                newDemandAnswer.CreateTime = DateTime.Now;
                newDemandAnswer.DemandAnswerType = 1;
                _demandAnswerManager.Add(newDemandAnswer);
                _notyf.Success("Yanıtınız başarıyla müşteriye gönderilmiştir.");
            }
            
            return RedirectToAction("CustomerProductDetails", "Customer", new { EventID = data.CustomerProductsID });
        }

    }
}