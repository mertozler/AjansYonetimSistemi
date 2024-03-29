#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "653b0045410af811acb4616c015ee363657f06ce"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared_Components_NavbarNotification_Default), @"mvc.1.0.view", @"/Views/Shared/Components/NavbarNotification/Default.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"653b0045410af811acb4616c015ee363657f06ce", @"/Views/Shared/Components/NavbarNotification/Default.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared_Components_NavbarNotification_Default : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<List<EntityLayer.Concrete.Notification>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n<li class=\"nav-item dropdown\">\r\n  <a class=\"nav-link\" data-toggle=\"dropdown\" href=\"#\" aria-expanded=\"false\">\r\n    <i class=\"far fa-bell\"></i>\r\n    <span class=\"badge badge-danger navbar-badge\">");
#nullable restore
#line 6 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
                                             Write(Model.Count);

#line default
#line hidden
#nullable disable
            WriteLiteral("</span>\r\n  </a>\r\n  <div class=\"dropdown-menu dropdown-menu-lg dropdown-menu-right\" style=\"left: inherit; right: 0px; overflow: clip;\">\r\n");
#nullable restore
#line 9 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
     foreach (var item in Model.Take(5))
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("      <a");
            BeginWriteAttribute("href", " href=\"", 448, "\"", 464, 1);
#nullable restore
#line 11 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
WriteAttributeValue("", 455, item.Url, 455, 9, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" class=\"dropdown-item\"");
            BeginWriteAttribute("onclick", " onclick=\"", 487, "\"", 524, 3);
            WriteAttributeValue("", 497, "changeReadedValue(", 497, 18, true);
#nullable restore
#line 11 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
WriteAttributeValue("", 515, item.Id, 515, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 523, ")", 523, 1, true);
            EndWriteAttribute();
            WriteLiteral(">\r\n\r\n        <div class=\"media\">\r\n          <div class=\"media-body\">\r\n\r\n            <h3 class=\"dropdown-item-title\">\r\n              ");
#nullable restore
#line 17 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
         Write(item.Header);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n              <span class=\"float-right text-sm text-danger\"><i class=\"fas fa-star\"></i></span>\r\n            </h3>\r\n            <p class=\"text-sm\">");
#nullable restore
#line 20 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
                          Write(item.Content);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n            <p class=\"text-sm text-muted\"><i class=\"far fa-clock mr-1\"></i>");
#nullable restore
#line 21 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
                                                                      Write(item.Date);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n\r\n\r\n          </div>\r\n        </div>\r\n\r\n      </a>\r\n      <div class=\"dropdown-divider\"></div>\r\n");
#nullable restore
#line 29 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\Components\NavbarNotification\Default.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <a href=""#"" class=""dropdown-item"">
      <a href=""/Home/SeeAllNotification"" class=""dropdown-item dropdown-footer"">Bütün Bildirimleri Gör</a>

    </a>
    <div class=""dropdown-divider""></div>
  </div>
</li>

<script>
  function changeReadedValue(id) {
    $.ajax({
      url: '/Home/ChangeReadedValue',
      type: 'POST',
      data: {
        id: id
      },
      success: function (data) {
        if (data.success) {
          $('#notification-count').text(data.count);
        }
      }
    });
  }
</script>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<List<EntityLayer.Concrete.Notification>> Html { get; private set; }
    }
}
#pragma warning restore 1591
