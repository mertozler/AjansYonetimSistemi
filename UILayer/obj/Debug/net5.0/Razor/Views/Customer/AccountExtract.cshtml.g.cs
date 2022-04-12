#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25ff1dca29be2db44014cfa0d0f10bf6d7863c96"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_AccountExtract), @"mvc.1.0.view", @"/Views/Customer/AccountExtract.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25ff1dca29be2db44014cfa0d0f10bf6d7863c96", @"/Views/Customer/AccountExtract.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_AccountExtract : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EntityLayer.DTOs.AccountExtractDTO>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
  
    ViewBag.Title = "Hesap Özeti";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link href=\"https://cdn.datatables.net/1.11.4/css/dataTables.bootstrap4.min.css\" rel=\"stylesheet\" />\r\n    <link href=\"https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            WriteLiteral("\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/jquery/latest/jquery.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/momentjs/latest/moment.min.js""></script>
    <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js""></script>
    <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css""/>
    <script src=""//cdn.datatables.net/1.11.4/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.11.4/js/dataTables.bootstrap4.min.js""></script>

    <script>
            $(document).ready(function () {
                $('#CustomerDataTable').DataTable();
            });
            $(document).ready(function () {
                                 $('#customerServiceDataTable').DataTable();
                             });
            $(document).ready(function () {
                                             $('#CustomerE");
                WriteLiteral("mployeeDataTable\').DataTable();\r\n                                         });\r\n             $(document).ready(function () {\r\n                        $(\'#employeePaymentList\').DataTable();\r\n                    });\r\n        </script>\r\n");
            }
            );
            WriteLiteral(@"

<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Hesap Özeti</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""/Customer/"">Customer</a></li>
                    <li class=""breadcrumb-item active"">AccountExtract</li>
                </ol>
            </div>
        </div>
    </div><!-- /.container-fluid -->
</section>


<section>
    <div id=""accordion"" style=""margin: 20px;"">
        <div class=""card shadow mt-5"">
            <div class=""card-header bg-dark"">
                <a href=""#collapseCompanyList"" class=""card-link p-1"" data-toggle=""collapse"">
                    Satın Aldığım Hizmetler
                </a>
            </div>
            <div id=""collapseCompanyList"" class=""collapse show"">
                <div class=""card-body"">
                    <d");
            WriteLiteral(@"iv class=""row table-responsive-sm"">
                        <div class=""col-md-12 "">
                            <table id=""CustomerDataTable"" class=""display"" style=""width:100%"">
                                <thead>
                                <tr>
                                    <th>Hizmet ID</th>
                                    <th>Hizmet Adı</th>
                                    <th>Hizmet Açıklaması</th>
                                    <th>Satın Alma Tarihi</th>
                                    <th>Bitiş Tarihi</th>
                                </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 77 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                 foreach (var item in Model.CustomerServiceList)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 80 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.ServiceId);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 81 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.ServiceName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 82 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.ServiceDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 83 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.ServiceStartDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                          \r\n                                        <td>");
#nullable restore
#line 85 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.ServiceStartDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 87 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                </tbody>
                            </table>
    
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<section>
    <div id=""accordion"" style=""margin: 20px;"">
        <div class=""card shadow mt-5"">
            <div class=""card-header bg-dark"">
                <a href=""#collapseCompanyList"" class=""card-link p-1"" data-toggle=""collapse"">
                    Ödeme Geçmişim
                </a>
            </div>
            <div id=""collapseCompanyList"" class=""collapse show"">
                <div class=""card-body"">
                    <div class=""row table-responsive-sm"">
                        <div class=""col-md-12 "">
                            <table id=""employeePaymentList"" class=""display"" style=""width:100%"">
                                <thead>
                                <tr>
                                    <th>Ödeme Tarihi</th>
                       ");
            WriteLiteral("             <th>Ödeme Tutarı</th>\r\n                                </tr>\r\n                                </thead>\r\n                                <tbody>\r\n");
#nullable restore
#line 119 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                        foreach (var item in Model.CustomerPaymentHistory)
                                                           {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                <tr>\r\n                                        <td>");
#nullable restore
#line 122 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.PaymentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 123 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.PaymentPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₺</td>\r\n                                </tr>\r\n");
#nullable restore
#line 125 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                                               
                                                           }

#line default
#line hidden
#nullable disable
            WriteLiteral("                       \r\n                                </tbody>\r\n                            </table>\r\n                            <label>Toplam Ödeme Tutarı: ");
#nullable restore
#line 130 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                                   Write(Model.PaymentPriceSum);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" ₺</label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</section>

<section>
        <div id=""accordion"" style=""margin: 20px;"">
            <div class=""card shadow mt-5"">
                <div class=""card-header bg-dark"">
                    <a href=""#collapseCompanyList"" class=""card-link p-1"" data-toggle=""collapse"">
                       İlgilenen Personeller
                    </a>
                     
                </div>
                <div id=""collapseCompanyList"" class=""collapse show"">
                    <div class=""card-body"">
                        <div class=""row table-responsive-sm"">
                            <div class=""col-md-12 "">
                                <table id=""CustomerEmployeeDataTable"" class=""display"" style=""width:100%"">
                                    <thead>
                                    <tr>
                                       
                        ");
            WriteLiteral("                <th>Personel Adı</th>\r\n                                        <th>Personel Rolü</th>\r\n                                    </tr>\r\n                                    </thead>\r\n                                    <tbody>\r\n");
#nullable restore
#line 161 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                             foreach (var item in Model.CustomerEmployeeList)
                                            {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                <tr>\r\n                                                    <td>");
#nullable restore
#line 164 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                                   Write(item.EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    <td>");
#nullable restore
#line 165 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                                   Write(item.EmployeeRole);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                                    \r\n                                                </tr>\r\n");
#nullable restore
#line 168 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                            }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                       
                                    
                                    </tbody>
                                </table>
    
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>
");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EntityLayer.DTOs.AccountExtractDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591