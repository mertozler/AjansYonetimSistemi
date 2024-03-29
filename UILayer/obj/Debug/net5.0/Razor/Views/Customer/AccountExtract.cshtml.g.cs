#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7deb890db8c5d3c38ec847f50ea7bdeef4edd0dd"
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7deb890db8c5d3c38ec847f50ea7bdeef4edd0dd", @"/Views/Customer/AccountExtract.cshtml")]
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
            <div class=""card-header bg-gradient-gray-dark"">
                                                                   <h3 class=""card-title"">
                                                                       Satın Aldığım Hizmetler
                                                                   </h3>
                                  ");
            WriteLiteral(@"                             </div>
            <div id=""collapseCompanyList"" class=""collapse show"">
                <div class=""card-body"">
                    <div class=""row table-responsive-sm"">
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
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 84 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                       Write(item.ServiceEndDate.ToString("MM/dd/yyyy"));

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                    </tr>\r\n");
#nullable restore
#line 86 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                </tbody>\r\n                            </table>\r\n    \r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</section>\r\n");
#nullable restore
#line 97 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
 if (Model.ShouldCustomerBeAbleTooSeePaymentHistoryIsActive)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section>
        <div id=""accordion"" style=""margin: 20px;"">
            <div class=""card shadow mt-5"">
                <div class=""card-header bg-gradient-gray-dark"">
                    <h3 class=""card-title"">
                        Ödeme Geçmişim
                    </h3>
                </div>
                <div id=""collapseCompanyList"" class=""collapse show"">
                    <div class=""card-body"">
                        <div class=""row table-responsive-sm"">
                            <div class=""col-md-12 "">
                                <table id=""employeePaymentList"" class=""display"" style=""width:100%"">
                                    <thead>
                                    <tr>
                                        <th>Ödeme Tarihi</th>
                                        <th>Ödeme Tutarı</th>
                                    </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 119 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                     foreach (var item in Model.CustomerPaymentHistory)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 122 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                           Write(item.PaymentDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 123 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                           Write(item.PaymentPrice);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₺</td>\r\n                                        </tr>\r\n");
#nullable restore
#line 125 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                                               
                                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                       \r\n                                    </tbody>\r\n                                </table>\r\n                                <label>Toplam Ödeme Tutarı: ");
#nullable restore
#line 130 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                                       Write(Model.PaymentPriceSum);

#line default
#line hidden
#nullable disable
            WriteLiteral(" ₺</label>\r\n                            </div>\r\n                        </div>\r\n                    </div>\r\n                </div>\r\n            </div>\r\n        </div>\r\n    </section>\r\n");
#nullable restore
#line 138 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 140 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
 if (Model.ShouldCustomerBeAbleTooSeeRelevantPersonelIsActive)
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <section>
        <div id=""accordion"" style=""margin: 20px;"">
            <div class=""card shadow mt-5"">
                <div class=""card-header bg-gradient-gray-dark"">
                    <h3 class=""card-title"">
                        İlgilenen Personeller
                    </h3>
                </div>
                <div id=""collapseCompanyList"" class=""collapse show"">
                    <div class=""card-body"">
                        <div class=""row table-responsive-sm"">
                            <div class=""col-md-12 "">
                                <table id=""CustomerEmployeeDataTable"" class=""display"" style=""width:100%"">
                                    <thead>
                                    <tr>

                                        <th>Personel Adı</th>
                                        <th>Personel Rolü</th>
                                    </tr>
                                    </thead>
                                    <tbody>
");
#nullable restore
#line 163 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                     foreach (var item in Model.CustomerEmployeeList)
                                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        <tr>\r\n                                            <td>");
#nullable restore
#line 166 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                           Write(item.EmployeeName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                            <td>");
#nullable restore
#line 167 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
                                           Write(item.EmployeeRole);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n\r\n                                        </tr>\r\n");
#nullable restore
#line 170 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
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
#nullable restore
#line 183 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\AccountExtract.cshtml"
}

#line default
#line hidden
#nullable disable
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
