#pragma checksum "D:\MERT\Coding\.NET CORE\Github\Project\Project\UILayer\Views\Shared\_SideBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7dba6bab712894a17fe66e9b30de5ba34be2be16"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Shared__SideBar), @"mvc.1.0.view", @"/Views/Shared/_SideBar.cshtml")]
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
#line 1 "D:\MERT\Coding\.NET CORE\Github\Project\Project\UILayer\Views\_ViewImports.cshtml"
using Project;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MERT\Coding\.NET CORE\Github\Project\Project\UILayer\Views\_ViewImports.cshtml"
using Project.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "D:\MERT\Coding\.NET CORE\Github\Project\Project\UILayer\Views\Shared\_SideBar.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dba6bab712894a17fe66e9b30de5ba34be2be16", @"/Views/Shared/_SideBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SideBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral(@"

<aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""../../index3.html"" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">NEW PROJECT</span>
    </a>
    <!-- Sidebar -->
    <div class=""sidebar"">
             <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
        <div class=""image"">
          <img src=""/img/avatar4.png"" class=""img-circle elevation-2"" alt=""User Image"">
        </div>
        <div class=""info"">
            <div class=""accent-light"">LOGGED USER</div>
        </div>
      </div>
      <!-- SidebarSearch Form -->
      <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
          <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
          <div class=""input-group-append"">
            <button cl");
            WriteLiteral(@"ass=""btn btn-sidebar"">
              <i class=""fas fa-search fa-fw""></i>
            </button>
          </div>
        </div><div class=""sidebar-search-results""><div class=""list-group""><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a><a href=""#"" class=""list-group-item""><div class=""search-title""><str");
            WriteLiteral(@"ong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a></div></div>
      </div>

      <!-- Sidebar Menu -->
      <nav class=""mt-2"">
          <ul class=""nav nav-pills nav-sidebar flex-column nav-flat nav-child-indent"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
              <!-- Add icons to the links using the .nav-icon class
    with font-awesome ");
            WriteLiteral(@"or any other icon font library -->
              <li class=""nav-item"">
                  <a href=""#"" class=""nav-link"">
                      <i class=""nav-icon fas fa-tachometer-alt""></i>
                      <p>
                          Dashboard
                          <i class=""right fas fa-angle-left""></i>
                      </p>
                  </a>
                  <ul class=""nav nav-treeview"">
                      <li class=""nav-item"">
                          <a href=""../../index.html"" class=""nav-link"">
                              <i class=""far fa-circle nav-icon""></i>
                              <p>Dashboard v1</p>
                          </a>
                      </li>
                      <li class=""nav-item"">
                          <a href=""../../index2.html"" class=""nav-link"">
                              <i class=""far fa-circle nav-icon""></i>
                              <p>Dashboard v2</p>
                          </a>
                      </li>
 ");
            WriteLiteral(@"                     <li class=""nav-item"">
                          <a href=""../../index3.html"" class=""nav-link"">
                              <i class=""far fa-circle nav-icon""></i>
                              <p>Dashboard v3</p>
                          </a>
                      </li>
                  </ul>
              </li>

          </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>");
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
