using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
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
using X.PagedList;

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
                FileName = customerProducts.ProductTitle + "-" + productType + ".v1",
                FileDate = customerProducts.ProductDate,
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

            return RedirectToAction("CustomerProductDetails", "Customer", new {EventID = data.CustomerProductsID});
        }

        public async Task<IActionResult> CustomerDesign(int page = 1)
        {
            List<string> ImagePath = new List<string>();
            bool isAddedInProductFile = false;
            var currentUser = await _userManager.GetUserAsync(User);
            var customerProductList = _customerProductsManager.GetCustomerProductsListByCustomerID(currentUser.Id);
            foreach (var item in customerProductList)
            {
                isAddedInProductFile = false;
                var checkDemandisExist = _demandManager.GetByProductID(item.id);
                var selectedProductImage = _customerProductsFileManager.GetByProductId(item.id);
                FileInfo fileInfo = new FileInfo(selectedProductImage.FilePath);
                string fileExt = fileInfo.Extension;
                if (fileExt == ".jpeg" || fileExt == ".jpg" || fileExt == ".gif" || fileExt == ".tiff" ||
                    fileExt == ".png" || fileExt == ".PNG")
                {
                    ImagePath.Add("CustomerProductsFile/" + selectedProductImage.FilePath);
                    isAddedInProductFile = true;
                }

                if (checkDemandisExist != null)
                {
                    var selectedDemandAnswers = _demandAnswerManager.GetByDemandId(checkDemandisExist.ID);
                    var sortedDemandAnswerList = selectedDemandAnswers.OrderByDescending(x => x.ID).ToList();
                    foreach (var demandAnswers in sortedDemandAnswerList)
                    {
                        if (demandAnswers.AnswerFilePath != null)
                        {
                            FileInfo fileInfoForAnswer = new FileInfo(demandAnswers.AnswerFilePath);
                            string fileExtension = fileInfoForAnswer.Extension;
                            if (fileExtension == ".jpeg" || fileExtension == ".jpg" || fileExtension == ".gif" ||
                                fileExtension == ".tiff" ||
                                fileExtension == ".png" || fileExtension == ".PNG")
                            {
                                if (isAddedInProductFile == true)
                                {
                                    if (ImagePath.Any())
                                    {
                                        //remove last index item in list
                                        ImagePath.RemoveAt(ImagePath.Count - 1);
                                    }
                                }

                                ImagePath.Add("DemandFiles/" + demandAnswers.AnswerFilePath);
                                break;
                            }

                        }
                    }
                }

            }


            var sortedImageList = ImagePath.OrderByDescending(x => x).ToList();
            var values = sortedImageList.ToPagedList(page, 8);
            return View(values);
        }

        public IActionResult RevisedDemands()
        {
            CustomerRevisedDemandsDTO model = new CustomerRevisedDemandsDTO();
            List<RevisedDemandListClass> revisedDemandList = new List<RevisedDemandListClass>();
            var currentUser = _userManager.GetUserAsync(User).Result;
            var customerProductList = _customerProductsManager.GetCustomerProductsListByCustomerID(currentUser.Id);
            foreach (var item in customerProductList)
            {
                var checkDemandisExist = _demandManager.GetByProductID(item.id);
                if (checkDemandisExist != null)
                {
                    var newReviseDemandListData = _mapper.Map<RevisedDemandListClass>(item);
                    newReviseDemandListData.DemandStatus = checkDemandisExist.Status;
                    newReviseDemandListData.DemandID = checkDemandisExist.ID;
                    newReviseDemandListData.RevisedMessage = checkDemandisExist.Content;
                    revisedDemandList.Add(newReviseDemandListData);
                }


            }

            model.RevisedDemandList = revisedDemandList;

            return View(model);
        }

        public async Task<IActionResult> CustomerReports()
        {
            CustomerReportsDTO model = new CustomerReportsDTO();
            //Get all customer reports in customerproducts and demandanswers
            List<ReportListClass> reportList = new List<ReportListClass>();
            var currentUser = await _userManager.GetUserAsync(User);
            var customerProductList = _customerProductsManager.GetCustomerProductsListByCustomerID(currentUser.Id);
            foreach (var product in customerProductList)
            {
                var selectedProductFile = _customerProductsFileManager.GetByProductId(product.id);
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
                        newProduct.ReportPath = "CustomerProductsFile/"+selectedProductFile.FilePath;
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
                                    if (fileExtension == ".docx" || fileExtension == ".doc" || fileExtension == ".pdf" || fileExtension == ".xls" ||
                                        fileExtension == ".xlsx" || fileExtension == ".ppt" || fileExtension == ".pptx" || fileExtension == ".txt")
                                    {
                                        var newProductWithDemand = _mapper.Map<ReportListClass>(product);
                                        newProductWithDemand.DemandStatus = checkDemandisExist.Status;
                                        newProductWithDemand.DemandID = checkDemandisExist.ID;
                                        newProductWithDemand.ReportPath = "DemandFiles/"+item.AnswerFilePath;
                                        newProductWithDemand.ReportName = newProductWithDemand.ProductTitle + "-Rapor.v"+versionCounter;
                                        versionCounter++;
                                        reportList.Add(newProductWithDemand);
                                    }
                                }
                                
                                
                            }
                           
                        }
                    }
                    else
                    {
                        newProduct.ReportName = newProduct.ProductTitle + "-Rapor.v1";
                        reportList.Add(newProduct);
                        
                    }
                }
            }
            model.ReportList = reportList;
            return View(model);
        }
    }
    
}


    
