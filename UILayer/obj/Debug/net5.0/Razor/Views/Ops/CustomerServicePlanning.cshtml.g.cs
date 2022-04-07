#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b04d5f21c8afbbe80e20bd7b6d2bffea93f18803"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ops_CustomerServicePlanning), @"mvc.1.0.view", @"/Views/Ops/CustomerServicePlanning.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b04d5f21c8afbbe80e20bd7b6d2bffea93f18803", @"/Views/Ops/CustomerServicePlanning.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Ops_CustomerServicePlanning : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
  
    ViewBag.Title = "Müşteri Hizmet Planla";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("Styles", async() => {
                WriteLiteral("\r\n    <link href=\"https://cdn.datatables.net/1.11.4/css/dataTables.bootstrap4.min.css\" rel=\"stylesheet\" />\r\n    <link href=\"https://cdn.datatables.net/1.11.5/css/jquery.dataTables.min.css\" rel=\"stylesheet\" />\r\n   \r\n   \r\n");
            }
            );
            DefineSection("Scripts", async() => {
                WriteLiteral(@"
    
     <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/jquery/latest/jquery.min.js""></script>
     <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/momentjs/latest/moment.min.js""></script>
     <script type=""text/javascript"" src=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js""></script>
     <link rel=""stylesheet"" type=""text/css"" href=""https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css"" />
     <script src=""//cdn.datatables.net/1.11.4/js/jquery.dataTables.min.js""></script>
         <script src=""https://cdn.datatables.net/1.11.4/js/dataTables.bootstrap4.min.js""></script>

     <script>
            $(document).ready(function () {
                $('#CustomerDataTable').DataTable();
            });
            $(document).ready(function () {
                                 $('#customerServiceDataTable').DataTable();
                             });
        </script>
     
   
    <script>
     $(function () {
         var Place");
                WriteLiteral(@"HolderElement = $('#PlaceHolderHere');
         $('button[data-toggle=""ajax-modal""]').click(function (event)
         {
            var url = $(this).data('url');
            $.get(url).done(function (data) {
               PlaceHolderElement.html(data);
               PlaceHolderElement.find('.modal').modal('show');
                }
                )
                
         })
         PlaceHolderElement.on('click', '[data-save=""modal""]', function (event) {
             var form = $(this).parents('.modal').find('form');
             var actionUrl = form.attr('action');
             var sendData = form.serialize();
             $.post(actionUrl,sendData).done(function(data){
             PlaceHolderElement.find('.modal').modal('hide');    
             })
         })
     })
    </script>
  <script>
  $(function() {
    $('input[name=""DateRange""]').daterangepicker({
      singleDatePicker: true,
      showDropdowns: true,
      locale: {
            format: 'DD/MM/YYYY'
        ");
                WriteLiteral("  }\r\n    }, );\r\n  });\r\n  </script>\r\n   \r\n    \r\n");
            }
            );
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Müşteri Hizmet Planla</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""/Ops/"">Ops</a></li>
                    <li class=""breadcrumb-item active"">CustomerServicePlanning</li>
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
                    Müşteri Listesi
                </a>
            </div>
            <div id=""collapseCompanyList"" class=""collapse show"">
                <div class=""card-body"">
                    <div ");
            WriteLiteral(@"class=""row table-responsive-sm"">
                        <div class=""col-md-12 "">
                            <table id=""CustomerDataTable"" class=""display"" style=""width:100%"">
                                <thead>
                                <tr>
                                    <th>Müşteri ID</th>
                                    <th>Müşteri Adı</th>
                                    <th>Müşteri Maili</th>
                                    <th>Müşterinin Hizmetleri</th>
                                    <th>Hizmet Planlaması Yap</th>
                                </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 110 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 113 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                       Write(item.CustomerID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 114 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                       Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 115 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                         if (item.ServiceNames != "")
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>");
#nullable restore
#line 117 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                           Write(item.ServiceNames);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 118 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"bg-warning\">Müşteriye bir hizmet tanımlanmamıştır</td>\r\n");
#nullable restore
#line 122 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            \r\n                                        <td>");
#nullable restore
#line 124 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                       Write(item.CustomerMail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n    \r\n");
#nullable restore
#line 127 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                              if (item.ServiceNames != "")
                                                                                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                                                                    <a");
            BeginWriteAttribute("href", " href=\"", 5423, "\"", 5514, 1);
#nullable restore
#line 129 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
WriteAttributeValue("", 5430, Url.Action("CustomerServicePlanningDates","Ops",new {CustomerID = item.CustomerID}), 5430, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            BeginWriteAttribute("onClick", " onClick=", 5515, "", 5556, 3);
            WriteAttributeValue("", 5524, "setCustomerID(", 5524, 14, true);
#nullable restore
#line 129 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
WriteAttributeValue("", 5538, item.CustomerID, 5538, 16, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 5554, ");", 5554, 2, true);
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\" style=\"float: right;\">Hizmet Planla</a>\r\n");
#nullable restore
#line 130 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                                                                                    <a href=""#""  class=""btn btn-danger btn-sm"" style=""float: right; pointer-events: none; cursor: default;"">Müşteriye bir hizmet tanımlanmamıştır</a>
");
#nullable restore
#line 134 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
                                                                                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 136 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
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

<script>
function setCustomerID(id) {
           ");
#nullable restore
#line 150 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerServicePlanning.cshtml"
      Write(ViewBag.CustomerIDForEvent);

#line default
#line hidden
#nullable disable
            WriteLiteral(" = id;\r\n        }\r\n</script>\r\n    \r\n\r\n\r\n\r\n  ");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591
