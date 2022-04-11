#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d212d550d83f886e84b4799fbe2daa280d97476d"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Ops_CustomerPayments), @"mvc.1.0.view", @"/Views/Ops/CustomerPayments.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d212d550d83f886e84b4799fbe2daa280d97476d", @"/Views/Ops/CustomerPayments.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Ops_CustomerPayments : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
  
    ViewBag.Title = "Müşteri Ödeme Takip";
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
                <h1>Müşteri Ödeme Takip</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""/Ops/"">Ops</a></li>
                    <li class=""breadcrumb-item active"">CustomerPayments</li>
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
                    <div class=""ro");
            WriteLiteral(@"w table-responsive-sm"">
                        <div class=""col-md-12 "">
                            <table id=""CustomerDataTable"" class=""display"" style=""width:100%"">
                                <thead>
                                <tr>
                                    <th>Müşteri ID</th>
                                    <th>Müşteri Adı</th>
                                    <th>Müşteri Maili</th>
                                    <th>Müşterinin Hizmetleri</th>
                                    <th>Müşterinin Ödeme Planı</th>
                                    <th>Hizmet Planlaması Yap</th>
                                </tr>
                                </thead>
                                <tbody>
");
#nullable restore
#line 111 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                 foreach (var item in Model)
                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                    <tr>\r\n                                        <td>");
#nullable restore
#line 114 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                       Write(item.CustomerID);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 115 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                       Write(item.CustomerName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 116 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                         if (item.ServiceNames != "")
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td>");
#nullable restore
#line 118 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                           Write(item.ServiceNames);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n");
#nullable restore
#line 119 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                        }
                                        else
                                        {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            <td class=\"bg-warning\">Müşteriye bir hizmet tanımlanmamıştır</td>\r\n");
#nullable restore
#line 123 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                            \r\n                                        <td>");
#nullable restore
#line 125 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                       Write(item.CustomerMail);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>");
#nullable restore
#line 126 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                       Write(item.PaymentRoutineName);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n                                        <td>\r\n    \r\n");
#nullable restore
#line 129 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                              if (item.ServiceNames != "")
                                                                                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                                                                                                    <a");
            BeginWriteAttribute("href", " href=\"", 5556, "\"", 5642, 1);
#nullable restore
#line 131 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
WriteAttributeValue("", 5563, Url.Action("CustomerPaymentTracking","Ops",new {CustomerID = item.CustomerID}), 5563, 79, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"btn btn-warning btn-sm\" style=\"float: right;\">Ödeme Takibi Yap</a>\r\n");
#nullable restore
#line 132 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                                                                                                                                    <a href=""#""  class=""btn btn-danger btn-sm"" style=""float: right; pointer-events: none; cursor: default;"">Müşteriye bir hizmet tanımlanmamıştır</a>
");
#nullable restore
#line 136 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
                                                                                                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral(" </td>\r\n                                    </tr>\r\n");
#nullable restore
#line 138 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
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
#line 152 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Ops\CustomerPayments.cshtml"
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
