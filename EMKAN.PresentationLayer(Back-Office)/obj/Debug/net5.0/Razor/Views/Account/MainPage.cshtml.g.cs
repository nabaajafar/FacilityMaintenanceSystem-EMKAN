#pragma checksum "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Account\MainPage.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "de44ed852456ec85704446ec7702378abc61d6c1"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Account_MainPage), @"mvc.1.0.view", @"/Views/Account/MainPage.cshtml")]
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
#line 1 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\_ViewImports.cshtml"
using EMKAN.PresentationLayer_Back_Office_;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\_ViewImports.cshtml"
using EMKAN.PresentationLayer_Back_Office_.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"de44ed852456ec85704446ec7702378abc61d6c1", @"/Views/Account/MainPage.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd6247efcd79b2c55af66504419e6d4cff1ac3ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Account_MainPage : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
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
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper;
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 1 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Account\MainPage.cshtml"
  
    Layout = "_Layout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n<!DOCTYPE html>\r\n<html lang=\"en\">\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("head", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de44ed852456ec85704446ec7702378abc61d6c13617", async() => {
                WriteLiteral("\r\n    \r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.HeadTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_HeadTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("body", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "de44ed852456ec85704446ec7702378abc61d6c14599", async() => {
                WriteLiteral(@"
    

    <div class=""row justify-content-center"">
        <div class=""jumbotronClientHome"">
            <div class=""container mt-3"">
                <h1>
                    Welcome to
                    <span class=""logo"" style=""font-size: 30pt; color: #263949"">
                        <span style=""color: #4C5D70"">EMKAN</span>
                    </span>
                    System
                </h1>
                <p class=""lead"">for T2 facility maintenance management</p>
            </div>
        </div>

        <br />
        <br />
        <br />
        <br />
        <br />
        <br />
    </div>
    <!-- Sidebar Toggle (Topbar) -->
    <button id=""sidebarToggleTop"" class=""btn btn-link d-md-none rounded-circle mr-3"">
        <i class=""fa fa-bars""></i>
    </button>

    <!-- End of Topbar -->
    <!-- Content Row -->
    <div class=""row justify-content-around"">

        <div class=""card text-left"" style=""width: 18rem;"">
            <div class=""card-body"" styl");
                WriteLiteral(@"e=""background-color:#263949"">
                <h5 class=""card-title""> My Requests</h5>
                <p class=""card-text"">View All my Requests</p>
                <a href=""#"" class=""btn "" style=""background-color: #F88379"">View</a>
            </div>
        </div>

        <div class=""card text-left"" style=""width: 18rem;"">
            <div class=""card-body"">
                <h5 class=""card-title""> Dashboard</h5>
                <p class=""card-text"">Quickly view your request information </p>
                <a href=""#"" class=""btn "" style=""background-color: #F88379"">View</a>
            </div>
        </div>

        <div class=""card text-left"" style=""width: 18rem;"">
            <div class=""card-body"">
                <h5 class=""card-title""> New Request</h5>
                <p class=""card-text"">Easily Describe your issue to be solved  </p>
                <a href=""#"" class=""btn "" style=""background-color: #F88379"">Submit a Request</a>
            </div>
        </div>
    </div>

    <b");
                WriteLiteral("r />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n    <br />\r\n\r\n\r\n    <!-- End of Page Wrapper -->\r\n    <!-- Scroll to Top Button-->\r\n    <a class=\"scroll-to-top rounded\" href=\"#page-top\">\r\n        <i class=\"fas fa-angle-up\"></i>\r\n    </a>\r\n\r\n\r\n\r\n");
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.BodyTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_BodyTagHelper);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n\r\n</html>");
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
