#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_Navbar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "b70f2b9ad522509d10083e13e79b83932670b40a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__Navbar), @"mvc.1.0.view", @"/Views/Shared/_Navbar.cshtml")]
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
#nullable restore
#line 1 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_Navbar.cshtml"
using Project.ViewComponents;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"b70f2b9ad522509d10083e13e79b83932670b40a", @"/Views/Shared/_Navbar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__Navbar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-inline"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"<nav class=""main-header navbar navbar-expand navbar-white navbar-light"">
    <!-- Left navbar links -->
    <ul class=""navbar-nav"">
      <li class=""nav-item"">
        <a class=""nav-link"" data-widget=""pushmenu"" href=""#"" role=""button""><i class=""fas fa-bars""></i></a>
      </li>
      <li class=""nav-item d-none d-sm-inline-block"">
        <a href=""/Home/"" class=""nav-link"">Home</a>
      </li>
      <li class=""nav-item d-none d-sm-inline-block"">
        <a href=""#"" class=""nav-link"">Contact</a>
      </li>
    </ul>

    <!-- Right navbar links -->
    <ul class=""navbar-nav ml-auto"">
      <!-- Navbar Search -->
      <li class=""nav-item"">
        <a class=""nav-link"" data-widget=""navbar-search"" href=""#"" role=""button"">
          <i class=""fas fa-search""></i>
        </a>
        <div class=""navbar-search-block"">
          ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "b70f2b9ad522509d10083e13e79b83932670b40a4657", async() => {
                WriteLiteral(@"
            <div class=""input-group input-group-sm"">
              <input class=""form-control form-control-navbar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
              <div class=""input-group-append"">
                <button class=""btn btn-navbar"" type=""submit"">
                  <i class=""fas fa-search""></i>
                </button>
                <button class=""btn btn-navbar"" type=""button"" data-widget=""navbar-search"">
                  <i class=""fas fa-times""></i>
                </button>
              </div>
            </div>
          ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n        </div>\r\n      </li>\r\n      \r\n      ");
#nullable restore
#line 40 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_Navbar.cshtml"
 Write(await Component.InvokeAsync("NavbarNotification"));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
      
   
      
      <li class=""nav-item"">
               
                 <a href=""/Account/Logout"" class=""nav-link"">
                 <i class=""fas fa-sign-out-alt"">Logout</i>
                            </a>
                
              
           
            </li>
      
      <li class=""nav-item"">
             
            </li>
     
    </ul>
  </nav>");
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
