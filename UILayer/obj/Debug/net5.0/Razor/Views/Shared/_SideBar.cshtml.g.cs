#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "a6a0b6b72a4966ec8ed88ee410240ebb49aa6958"
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
#line 1 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
using EntityLayer.Concrete;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"a6a0b6b72a4966ec8ed88ee410240ebb49aa6958", @"/Views/Shared/_SideBar.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Shared__SideBar : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
  
    var girisYapanKullanici = await UserManager.GetUserAsync(User);
    IList<string> kullaniciRolleri = null;
    if(girisYapanKullanici!=null)
    {
        kullaniciRolleri = await UserManager.GetRolesAsync(girisYapanKullanici);
    }
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
#nullable restore
#line 18 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
 if (kullaniciRolleri == null)
{
    
}

else if (kullaniciRolleri[0] == "admin")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""../../index3.html"" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">Ajans Yönetim Sistemi</span>
    </a>
    <!-- Sidebar -->
    <div class=""sidebar"">
                       <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
           
                           <div class=""info"">
");
#nullable restore
#line 36 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                if (SignInManager.IsSignedIn(User))
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\">Hoşgeldin ");
#nullable restore
#line 38 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                                                    Write(girisYapanKullanici.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 39 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }
                               else
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\"></a>\r\n");
#nullable restore
#line 43 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                           </div>
                       </div>
      <!-- SidebarSearch Form -->
      <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
          <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
          <div class=""input-group-append"">
            <button class=""btn btn-sidebar"">
              <i class=""fas fa-search fa-fw""></i>
            </button>
          </div>
        </div><div class=""sidebar-search-results""><div class=""list-group""><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-li");
            WriteLiteral(@"ght""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text");
            WriteLiteral(@"-light""></strong></div><div class=""search-path""></div></a></div></div>
      </div>

      <!-- Sidebar Menu -->
      <nav class=""mt-2"">
          <ul class=""nav nav-pills nav-sidebar flex-column nav-flat nav-child-indent"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
              <!-- Add icons to the links using the .nav-icon class
    with font-awesome or any other icon font library -->
              <li class=""nav-item"">
                  <a href=""#"" class=""nav-link"">
                      <i class=""nav-icon fas fa-tachometer-alt""></i>
                      <p>
                          Personeller
                          <i class=""right fas fa-angle-left""></i>
                      </p>
                  </a>
                  <ul class=""nav nav-treeview"">
                      <li class=""nav-item"">
                          <a href=""/Admin/DefineEmployee"" class=""nav-link"">
                              <i class=""far fa-circle nav-icon""></i>
                          ");
            WriteLiteral(@"    <p>Personel Tanımlama</p>
                          </a>
                      </li>
                      <li class=""nav-item"">
                          <a href=""/Admin/EmployeePerfomance"" class=""nav-link"">
                              <i class=""far fa-circle nav-icon""></i>
                              <p>Personel Perfomans Durumu</p>
                          </a>
                      </li>
                  </ul>
              </li>
              <li class=""nav-item"">
                  <a href=""/Admin/Services"" class=""nav-link"">
                      <i class=""nav-icon far fa-image""></i>
                      <p>
                          Hizmetler
                      </p>
                  </a>
              </li>
              
                  <li class=""nav-item"">
                                <a href=""#"" class=""nav-link"">
                                    <i class=""nav-icon fas fa-edit""></i>
                                    <p>
                                ");
            WriteLiteral(@"        Müşteriler
                                        <i class=""right fas fa-angle-left""></i>
                                    </p>
                                </a>
                                <ul class=""nav nav-treeview"">
                                    <li class=""nav-item"">
                                        <a href=""/Admin/CreateCustomer"" class=""nav-link"">
                                            <i class=""far fa-circle nav-icon""></i>
                                            <p>Müşteri Tanımlama</p>
                                        </a>
                                    </li>
                                    <li class=""nav-item"">
                                        <a href=""/Admin/CustomerDefineServices"" class=""nav-link"">
                                            <i class=""far fa-circle nav-icon""></i>
                                            <p>Müşteri Hizmet Tanımlama</p>
                                        </a>
                      ");
            WriteLiteral("              </li>\r\n                                </ul>\r\n                            </li>\r\n              \r\n              \r\n              \r\n\r\n          </ul>\r\n      </nav>\r\n      <!-- /.sidebar-menu -->\r\n    </div>\r\n    <!-- /.sidebar -->\r\n  </aside>\r\n");
#nullable restore
#line 128 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
}
else if (kullaniciRolleri[0] == "designer")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""../../index3.html"" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">Ajans Yönetim Sistemi</span>
    </a>
    <!-- Sidebar -->
    <div class=""sidebar"">
                       <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
           
                           <div class=""info"">
");
#nullable restore
#line 142 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                if (SignInManager.IsSignedIn(User))
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\">Hoşgeldin ");
#nullable restore
#line 144 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                                                    Write(girisYapanKullanici.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 145 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }
                               else
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\"></a>\r\n");
#nullable restore
#line 149 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                           </div>
                       </div>
      <!-- SidebarSearch Form -->
      <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
          <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
          <div class=""input-group-append"">
            <button class=""btn btn-sidebar"">
              <i class=""fas fa-search fa-fw""></i>
            </button>
          </div>
        </div><div class=""sidebar-search-results""><div class=""list-group""><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-li");
            WriteLiteral(@"ght""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text");
            WriteLiteral(@"-light""></strong></div><div class=""search-path""></div></a></div></div>
      </div>

      <!-- Sidebar Menu -->
      <nav class=""mt-2"">
          <ul class=""nav nav-pills nav-sidebar flex-column nav-flat nav-child-indent"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
              <!-- Add icons to the links using the .nav-icon class
    with font-awesome or any other icon font library -->
             
              
              <li class=""nav-item"">
                  <a href=""/Designer/CustomerServicePlanning"" class=""nav-link"">
                      <i class=""nav-icon far fa-image""></i>
                      <p>
                          Müşteri Hizmet Planlama
                      </p>
                  </a>
              </li>
              
               <li class=""nav-item"">
                                <a href=""/Designer/DemandToEmployee"" class=""nav-link"">
                                    <i class=""nav-icon fas fa-paper-plane""></i>
                        ");
            WriteLiteral(@"            <p>
                                        Personele Talep Aç
                                    </p>
                                </a>
                            </li>
              
                 <li class=""nav-item"">
                                                                              <a");
            BeginWriteAttribute("href", " href=\"", 11281, "\"", 11372, 1);
#nullable restore
#line 190 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
WriteAttributeValue("", 11288, Url.Action("EmployeeCalendar","Designer",new {EmployeeID = girisYapanKullanici.Id}), 11288, 84, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""nav-link"">
                                                                                 <i class=""nav-icon far fa-calendar-alt""></i>
                                                                                 <p>
                                                                                     Takvimim
                                                                                 </p>
                                                                             </a>
                                                                         </li>
              
              
              

          </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
");
#nullable restore
#line 207 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
}
else if (kullaniciRolleri[0] == "marketing")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""../../index3.html"" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">Ajans Yönetim Sistemi</span>
    </a>
    <!-- Sidebar -->
    <div class=""sidebar"">
                       <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
           
                           <div class=""info"">
");
#nullable restore
#line 221 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                if (SignInManager.IsSignedIn(User))
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\">Hoşgeldin ");
#nullable restore
#line 223 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                                                    Write(girisYapanKullanici.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 224 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }
                               else
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\"></a>\r\n");
#nullable restore
#line 228 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                           </div>
                       </div>
      <!-- SidebarSearch Form -->
      <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
          <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
          <div class=""input-group-append"">
            <button class=""btn btn-sidebar"">
              <i class=""fas fa-search fa-fw""></i>
            </button>
          </div>
        </div><div class=""sidebar-search-results""><div class=""list-group""><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-li");
            WriteLiteral(@"ght""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text");
            WriteLiteral(@"-light""></strong></div><div class=""search-path""></div></a></div></div>
      </div>

      <!-- Sidebar Menu -->
      <nav class=""mt-2"">
          <ul class=""nav nav-pills nav-sidebar flex-column nav-flat nav-child-indent"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
              <!-- Add icons to the links using the .nav-icon class
    with font-awesome or any other icon font library -->
             
              
              <li class=""nav-item"">
                  <a href=""/Marketing/CustomerServicePlanning"" class=""nav-link"">
                      <i class=""nav-icon far fa-image""></i>
                      <p>
                          Müşteri Hizmet Planlama
                      </p>
                  </a>
              </li>
              
              <li class=""nav-item"">
                  <a href=""/Marketing/DemandToEmployee"" class=""nav-link"">
                      <i class=""nav-icon fas fa-paper-plane""></i>
                      <p>
                        ");
            WriteLiteral("  Personele Talep Aç\r\n                      </p>\r\n                  </a>\r\n              </li>\r\n              \r\n               <li class=\"nav-item\">\r\n                                                             <a");
            BeginWriteAttribute("href", " href=\"", 16411, "\"", 16503, 1);
#nullable restore
#line 269 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
WriteAttributeValue("", 16418, Url.Action("EmployeeCalendar","Marketing",new {EmployeeID = girisYapanKullanici.Id}), 16418, 85, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""nav-link"">
                                                                <i class=""nav-icon far fa-calendar-alt""></i>
                                                                <p>
                                                                    Takvimim
                                                                </p>
                                                            </a>
                                                        </li>
              
                 
              
              
              

          </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
");
#nullable restore
#line 288 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
}
else if (kullaniciRolleri[0] == "ops")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""../../index3.html"" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">Ajans Yönetim Sistemi</span>
    </a>
    <!-- Sidebar -->
    <div class=""sidebar"">
                       <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
           
                           <div class=""info"">
");
#nullable restore
#line 302 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                if (SignInManager.IsSignedIn(User))
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\">Hoşgeldin ");
#nullable restore
#line 304 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                                                    Write(girisYapanKullanici.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 305 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }
                               else
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\"></a>\r\n");
#nullable restore
#line 309 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                           </div>
                       </div>
      <!-- SidebarSearch Form -->
      <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
          <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
          <div class=""input-group-append"">
            <button class=""btn btn-sidebar"">
              <i class=""fas fa-search fa-fw""></i>
            </button>
          </div>
        </div><div class=""sidebar-search-results""><div class=""list-group""><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-li");
            WriteLiteral(@"ght""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text");
            WriteLiteral(@"-light""></strong></div><div class=""search-path""></div></a></div></div>
      </div>

      <!-- Sidebar Menu -->
      <nav class=""mt-2"">
          <ul class=""nav nav-pills nav-sidebar flex-column nav-flat nav-child-indent"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
              <!-- Add icons to the links using the .nav-icon class
    with font-awesome or any other icon font library -->
             
              
              <li class=""nav-item"">
                  <a href=""/Ops/CustomerServicePlanning"" class=""nav-link"">
                      <i class=""nav-icon far fa-image""></i>
                      <p>
                          Müşteri Hizmet Planlama
                      </p>
                  </a>
              </li>
              
              <li class=""nav-item"">
                  <a href=""/Ops/DemandToEmployee"" class=""nav-link"">
                      <i class=""nav-icon fas fa-paper-plane""></i>
                      <p>
                          Personele ");
            WriteLiteral("Talep Aç\r\n                      </p>\r\n                  </a>\r\n              </li>\r\n              \r\n               <li class=\"nav-item\">\r\n                                               <a");
            BeginWriteAttribute("href", " href=\"", 21443, "\"", 21529, 1);
#nullable restore
#line 350 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
WriteAttributeValue("", 21450, Url.Action("EmployeeCalendar","Ops",new {EmployeeID = girisYapanKullanici.Id}), 21450, 79, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(@" class=""nav-link"">
                                                  <i class=""nav-icon far fa-calendar-alt""></i>
                                                  <p>
                                                      Takvimim
                                                  </p>
                                              </a>
                                          </li>
              
                 
              
              
              

          </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
");
#nullable restore
#line 369 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
}
else if (kullaniciRolleri[0] == "customer")
{

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    <aside class=""main-sidebar sidebar-dark-primary elevation-4"">
    <!-- Brand Logo -->
    <a href=""../../index3.html"" class=""brand-link"">
        <img src=""/img/AdminLTELogo.png"" alt=""AdminLTE Logo"" class=""brand-image img-circle elevation-3"" style=""opacity: .8"">
        <span class=""brand-text font-weight-light"">Ajans Yönetim Sistemi</span>
    </a>
    <!-- Sidebar -->
    <div class=""sidebar"">
                       <div class=""user-panel mt-3 pb-3 mb-3 d-flex"">
           
                           <div class=""info"">
");
#nullable restore
#line 383 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                if (SignInManager.IsSignedIn(User))
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\">Hoşgeldin ");
#nullable restore
#line 385 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                                                                    Write(girisYapanKullanici.NameSurname);

#line default
#line hidden
#nullable disable
            WriteLiteral("</a>\r\n");
#nullable restore
#line 386 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }
                               else
                               {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                   <a href=\"#\" class=\"d-block\"></a>\r\n");
#nullable restore
#line 390 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
                               }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                           </div>
                       </div>
      <!-- SidebarSearch Form -->
      <div class=""form-inline"">
        <div class=""input-group"" data-widget=""sidebar-search"">
          <input class=""form-control form-control-sidebar"" type=""search"" placeholder=""Search"" aria-label=""Search"">
          <div class=""input-group-append"">
            <button class=""btn btn-sidebar"">
              <i class=""fas fa-search fa-fw""></i>
            </button>
          </div>
        </div><div class=""sidebar-search-results""><div class=""list-group""><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-li");
            WriteLiteral(@"ght""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text-light""></strong></div><div class=""search-path""></div></a><a href=""#"" class=""list-group-item""><div class=""search-title""><strong class=""text-light""></strong>N<strong class=""text-light""></strong>o<strong class=""text-light""></strong> <strong class=""text-light""></strong>e<strong class=""text-light""></strong>l<strong class=""text-light""></strong>e<strong class=""text-light""></strong>m<strong class=""text-light""></strong>e<strong class=""text-light""></strong>n<strong class=""text-light""></strong>t<strong class=""text-light""></strong> <strong class=""text-light""></strong>f<strong class=""text-light""></strong>o<strong class=""text-light""></strong>u<strong class=""text-light""></strong>n<strong class=""text-light""></strong>d<strong class=""text-light""></strong>!<strong class=""text");
            WriteLiteral(@"-light""></strong></div><div class=""search-path""></div></a></div></div>
      </div>

      <!-- Sidebar Menu -->
      <nav class=""mt-2"">
          <ul class=""nav nav-pills nav-sidebar flex-column nav-flat nav-child-indent"" data-widget=""treeview"" role=""menu"" data-accordion=""false"">
              <!-- Add icons to the links using the .nav-icon class
    with font-awesome or any other icon font library -->
             
              
              <li class=""nav-item"">
                  <a href=""/Customer/CustomerCalendar"" class=""nav-link"">
                      <i class=""nav-icon far fa-calendar""></i>
                      <p>
                          Paylaşım Takvimim
                      </p>
                  </a>
              </li>
              
              <li class=""nav-item"">
                  <a href=""/Customer/CustomerDesign"" class=""nav-link"">
                      <i class=""nav-icon fas fa-photo-video""></i>
                      <p>
                          Tasarımlar
");
            WriteLiteral(@"                      </p>
                  </a>
              </li>
              
              <li class=""nav-item"">
                  <a href=""/Customer/RevisedDemands"" class=""nav-link"">
                      <i class=""nav-icon fas fa-comment""></i>
                      <p>
                          Talepler
                      </p>
                  </a>
              </li>
              <li class=""nav-item"">
                  <a href=""/Customer/CustomerReports"" class=""nav-link"">
                      <i class=""nav-icon fas fa-book""></i>
                      <p>
                          Raporlar
                      </p>
                  </a>
              </li>
              
              

          </ul>
      </nav>
      <!-- /.sidebar-menu -->
    </div>
    <!-- /.sidebar -->
  </aside>
");
#nullable restore
#line 455 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Shared\_SideBar.cshtml"
}

#line default
#line hidden
#nullable disable
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public SignInManager<ApplicationUser> SignInManager { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public UserManager<ApplicationUser> UserManager { get; private set; }
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