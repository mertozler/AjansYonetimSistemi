#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c3daba8fd5ac5decf59836b3cf2a2144154c8966"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerReports), @"mvc.1.0.view", @"/Views/Customer/CustomerReports.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c3daba8fd5ac5decf59836b3cf2a2144154c8966", @"/Views/Customer/CustomerReports.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerReports : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<EntityLayer.DTOs.CustomerReportsDTO>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-success btn-sm"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
  
    ViewBag.Title = "Raporlarım";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link href=\"https://cdn.datatables.net/1.11.4/css/dataTables.bootstrap4.min.css\" rel=\"stylesheet\" />\r\n    <link href=\"https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css\" rel=\"stylesheet\" />\r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    <script src=""//cdn.datatables.net/1.11.4/js/jquery.dataTables.min.js""></script>
    <script src=""https://cdn.datatables.net/1.11.4/js/dataTables.bootstrap4.min.js""></script>
    <script>
        $(document).ready(function () {
            $('#employeeListDataTable').DataTable();
        });
        </script>
");
            }
            );
            WriteLiteral(@"<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Raporlarım</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""/Customer/"">Customer</a></li>
                    <li class=""breadcrumb-item active"">CustomerReports</li>
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
            Raporlar
        </a>
    </div>
    <div id=""collapseCompanyList"" class=""collapse show"">
        <div class=""card-body"">
            <div class=""row table-responsive-sm"">
                <div class=""col-md-12 "">
                  ");
            WriteLiteral(@"  <table id=""employeeListDataTable"" class=""display"" style=""width:100%"">
                        <thead>
                        <tr>
                            
                            <th>Ürün Adı</th>
                            <th>Ürün Açıklaması</th>
                            <th>Ürün İçeriği</th>
                            <th>Ürün Gönderilme Tarihi</th>
                            <th>Rapor Adı</th>
                            <th>Raporu Ayarları</th>
                        </tr>
                        </thead>
                        <tbody>
                        
");
#nullable restore
#line 62 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                         foreach (var item in Model.ReportList)
                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                            <tr>\r\n\r\n                                <td>");
#nullable restore
#line 66 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                               Write(item.ProductTitle);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 67 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                               Write(item.ProductDescription);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 68 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                               Write(item.ProductContent);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 69 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                               Write(item.ProductDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
#nullable restore
#line 70 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                               Write(item.ReportName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                <td>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c3daba8fd5ac5decf59836b3cf2a2144154c89668205", async() => {
                WriteLiteral("<span class=\"badge bg-success\">Raporu İndir</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "href", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2797, "~/", 2797, 2, true);
#nullable restore
#line 71 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
AddHtmlAttributeValue("", 2799, item.ReportPath, 2799, 16, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            BeginWriteTagHelperAttribute();
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __tagHelperExecutionContext.AddHtmlAttribute("download", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                    <a");
            BeginWriteAttribute("href", " href=\"", 2951, "\"", 3039, 1);
#nullable restore
#line 72 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
WriteAttributeValue("", 2958, Url.Action("CustomerProductDetails", "Customer", new {EventID = item.ProductID}), 2958, 81, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\"><span class=\"badge bg-warning\">Ürüne Git</span></a></td>\r\n                                                                                                \t\t\t\t\t\t\t\t\t\t\t\r\n\r\n\r\n\r\n                            </tr>\r\n");
#nullable restore
#line 78 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerReports.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n                        </tbody>\r\n                    </table>\r\n                            \r\n                </div>\r\n            </div>\r\n        </div>\r\n    </div>\r\n</div>\r\n</div>\r\n</section>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<EntityLayer.DTOs.CustomerReportsDTO> Html { get; private set; }
    }
}
#pragma warning restore 1591