#pragma checksum "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "86b4a8567d2285378ac645e2c3fd49c7b3ec83eb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Customer_CustomerDesign), @"mvc.1.0.view", @"/Views/Customer/CustomerDesign.cshtml")]
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
#line 1 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
using X.PagedList;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
using X.PagedList.Mvc.Core;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
using X.PagedList.Web.Common;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"86b4a8567d2285378ac645e2c3fd49c7b3ec83eb", @"/Views/Customer/CustomerDesign.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"3224af5ce27acab0b62f40cbe5ea9479d8929782", @"/Views/_ViewImports.cshtml")]
    public class Views_Customer_CustomerDesign : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IPagedList<string>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/ekko-lightbox/ekko-lightbox.min.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/plugins/ekko-lightbox/ekko-lightbox.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/dist/css/adminlte.css?v=3.2.0"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("alt", new global::Microsoft.AspNetCore.Html.HtmlString(""), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("id", new global::Microsoft.AspNetCore.Html.HtmlString("myImg"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("onclick", new global::Microsoft.AspNetCore.Html.HtmlString("onClick(this)"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 6 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
  
    ViewBag.Title = "Tasarımlar";
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "86b4a8567d2285378ac645e2c3fd49c7b3ec83eb6493", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "86b4a8567d2285378ac645e2c3fd49c7b3ec83eb7532", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "86b4a8567d2285378ac645e2c3fd49c7b3ec83eb8647", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
<section class=""content-header"">
    <div class=""container-fluid"">
        <div class=""row mb-2"">
            <div class=""col-sm-6"">
                <h1>Tasarımlarım</h1>
            </div>
            <div class=""col-sm-6"">
                <ol class=""breadcrumb float-sm-right"">
                    <li class=""breadcrumb-item""><a href=""/Customer/"">Customer</a></li>
                    <li class=""breadcrumb-item active"">CustomerDesign</li>
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
                                                                        Tasarımlarım
                                                                    </h3>
                                              ");
            WriteLiteral("                  </div>\r\n            <div id=\"collapseCompanyCreate\">\r\n                <div class=\"card-body\">\r\n");
#nullable restore
#line 38 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                     if (Model.Count == 0){

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"alert alert-info\" role=\"alert\">\r\n                        <strong>Bilgi!</strong> Henüz bir tasarım kaydınız yok.\r\n                    </div>\r\n");
#nullable restore
#line 42 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"gallery-image\">\r\n");
#nullable restore
#line 44 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                         foreach (var item in Model)
                        {



#line default
#line hidden
#nullable disable
            WriteLiteral(@"                            <div class=""img-box"">
                                <div class=""transparent-box"">
                                    <div class=""caption"">
                                        <p>Tasarım</p>
                                        <p class=""opacity-low"">Orjinal Boyutta Görmek İçin Tıkla</p>
                                    </div>
                                </div>
                                ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "86b4a8567d2285378ac645e2c3fd49c7b3ec83eb12417", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 2352, "~/", 2352, 2, true);
#nullable restore
#line 55 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
AddHtmlAttributeValue("", 2354, item, 2354, 5, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                            </div>\r\n");
#nullable restore
#line 57 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n\r\n\r\n\r\n                    </div>\r\n\r\n                    <br/>\r\n");
#nullable restore
#line 67 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                      if (Model.Count >= 1)
                     {
                         

#line default
#line hidden
#nullable disable
#nullable restore
#line 69 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                    Write(Html.PagedListPager((IPagedList) Model, page => Url.Action("CustomerDesign", new {page}), new PagedListRenderOptions
                         {
                             LiElementClasses = new string[] {"page-item"},
                             PageClasses = new string[] {"page-link"},
                             LinkToFirstPageFormat = "<< İlk", LinkToPreviousPageFormat = "< Önceki", LinkToNextPageFormat = "Sonraki >", LinkToLastPageFormat = "Son >>",
                         }));

#line default
#line hidden
#nullable disable
#nullable restore
#line 74 "D:\MERT\Coding\.NET CORE\AjansYonetimSistemi\UILayer\Views\Customer\CustomerDesign.cshtml"
                           
                     }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                </div>
            </div>
        </div>
    </div>
</section>
<div id=""modal01"" class=""modal"" onclick=""this.style.display='none'"">
     <div class=""modal-content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"" id=""editEmployeeLabel"">Tasarım</h4>
                    <button type=""button"" class=""close"" data-dismiss=""modal"">
                        <span>X</span>
                    </button>
                </div>
                
         <div class=""modal-body"">
             <span class=""close"">&times;&nbsp;&nbsp;&nbsp;&nbsp;</span>
             <div class=""modal-content"">
                 <a");
            BeginWriteAttribute("href", " href=\"", 3826, "\"", 3833, 0);
            EndWriteAttribute();
            WriteLiteral(@" id=""href"" target=""_blank"">
                 <img id=""img01"" style=""max-width:100%"">
                </a>
             </div>
         </div>
         </div>
</div>

<script>
function onClick(element) {
  document.getElementById(""img01"").src = element.src;
  document.getElementById(""modal01"").style.display = ""block"";
  document.getElementById(""href"").href=element.src;
}
</script>
<style>

#myImg {
  border-radius: 5px;
  cursor: pointer;
  transition: 0.3s;
}

#myImg:hover {opacity: 0.2;}

/* The Modal (background) */
.modal {
  display: none; /* Hidden by default */
  position: fixed; /* Stay in place */
  z-index: 1; /* Sit on top */
  padding-top: 100px; /* Location of the box */
  left: 0;
  top: 0;
  width: 100%; /* Full width */
  height: 100%; /* Full height */
  overflow: auto; /* Enable scroll if needed */
  background-color: rgb(0,0,0); /* Fallback color */
  background-color: rgba(0,0,0,0.9); /* Black w/ opacity */
}

/* Modal Content (Image) */
.modal-conte");
            WriteLiteral(@"nt {
  margin: auto;
  display: block;
  width: 80%;
  max-width: 700px;
}

/* Caption of Modal Image (Image Text) - Same Width as the Image */
#caption {
  margin: auto;
  width: 80%;
  max-width: 700px;
  text-align: center;
  color: #ccc;
  padding: 10px 0;
  height: 150px;
}

/* Add Animation - Zoom in the Modal */
.modal-content, #caption {
  animation-name: zoom;
  animation-duration: 0.6s;
}


/* The Close Button */
.close {
  position: absolute;
  top: 15px;
  right: 35px;
  color: #f1f1f1;
  font-size: 40px;
  font-weight: bold;
  transition: 0.3s;
}

.close:hover,
.close:focus {
  color: #bbb;
  text-decoration: none;
  cursor: pointer;
}

   
    .gallery-image {
      padding: 20px;
      display: flex;
      flex-wrap: wrap;
      justify-content: center;
    }
    
    .gallery-image img {
      height: 250px;
      width: 350px;
      transform: scale(1.0);
      transition: transform 0.4s ease;
    }
    
    .img-box {
      box-sizin");
            WriteLiteral(@"g: content-box;
      margin: 10px;
      height: 250px;
      width: 350px;
      overflow: hidden;
      display: inline-block;
      color: white;
      position: relative;
      background-color: white;
    }
    
    .caption {
      position: absolute;
      bottom: 5px;
      left: 20px;
      opacity: 0.0;
      transition: transform 0.3s ease, opacity 0.3s ease;
    }
    
    .transparent-box {
      height: 250px;
      width: 350px;
      background-color:rgba(0, 0, 0, 0);
      position: absolute;
      top: 0;
      left: 0;
      transition: background-color 0.3s ease;
    }
    
    .img-box:hover img { 
      transform: scale(1.1);
    }
    
    .img-box:hover .transparent-box {
      background-color:rgba(0, 0, 0, 0.5);
    }
    
    .img-box:hover .caption {
      transform: translateY(-20px);
      opacity: 300;
    }
    
    .img-box:hover {
      cursor: pointer;
    }
    
    .caption > p:nth-child(2) {
      font-size: 0.8em;
    }
 ");
            WriteLiteral("   \r\n    .opacity-low {\r\n      opacity: 300;\r\n    }\r\n</style>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IPagedList<string>> Html { get; private set; }
    }
}
#pragma warning restore 1591
