#pragma checksum "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7d7e4ad2a127b1c43c77d0129730157f172ddc0a"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_BuildingManager_ViewServices), @"mvc.1.0.view", @"/Views/BuildingManager/ViewServices.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7d7e4ad2a127b1c43c77d0129730157f172ddc0a", @"/Views/BuildingManager/ViewServices.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd6247efcd79b2c55af66504419e6d4cff1ac3ee", @"/Views/_ViewImports.cshtml")]
    public class Views_BuildingManager_ViewServices : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EMKAN.PresentationLayer_Back_Office_.Models.ViewServices>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap-grid.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap-reboot.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/js/bootstrap.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Active.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Service/Service-js.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
  
    ViewData["Title"] = "View All NewServices";
    Layout = "_CustomLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("<!--Datatable style-->\r\n");
            DefineSection("Style", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a6846", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral(@"<h1>View All New Services</h1>



<table  id=""Mytable"" class=""table table-bordered table-striped text-center"">
    <thead>

        <tr>
            <th>
                Service ID
            </th>
            <th>
                Client Name
            </th>
            <th>
                Description
            </th>
            <th>
                Request Date
            </th>
            <th>
                Response Date
            </th>
            <th>
                Room No
            </th>
            <th>
                Floor No
            </th>
            <th>
                Building ID
            </th>

            <th>
                Service Type
            </th>

            <th>
                Approve

            </th>

            <th>
                Reject

            </th>
        </tr>

    </thead>
    <tbody>
");
#nullable restore
#line 62 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td");
            BeginWriteAttribute("id", " id=\"", 1375, "\"", 1388, 1);
#nullable restore
#line 65 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
WriteAttributeValue("", 1380, item.ID, 1380, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                    ");
#nullable restore
#line 66 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td id=\"UserId\">\r\n                    ");
#nullable restore
#line 69 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.ClientFullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td id=\"Description\">\r\n                    ");
#nullable restore
#line 72 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 75 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.RequestDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 78 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.ResponseDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 81 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.RoomNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 84 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.FloorNo));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 87 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.BulidingID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 91 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
               Write(Html.DisplayFor(modelItem => item.ServiceType));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n\r\n                <td>\r\n\r\n                    <button type=\"button\" class=\"btn  btn-circle btn-sm\" style=\"background-color: #89D88C\" id=\"activate\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2560, "\"", 2587, 3);
            WriteAttributeValue("", 2570, "Approve(", 2570, 8, true);
#nullable restore
#line 97 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
WriteAttributeValue("", 2578, item.ID, 2578, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2586, ")", 2586, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-check\"></i>     </button>\r\n                </td>\r\n                <td>\r\n                    <button type=\"button\" class=\"btn  btn-circle btn-sm\" style=\"background-color: #F88379\" id=\"deactivate\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2799, "\"", 2825, 3);
            WriteAttributeValue("", 2809, "Reject(", 2809, 7, true);
#nullable restore
#line 100 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
WriteAttributeValue("", 2816, item.ID, 2816, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2824, ")", 2824, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-times\"></i></button>\r\n                </td>\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 105 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n    </tbody>\r\n</table>\r\n<!--Data Table-->\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\" charset=\"utf8\" src=\"https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js\"></script>\r\n    <script type=\"text/javascript\">\r\n         var mvcBaseUrl = \'");
#nullable restore
#line 113 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\BuildingManager\ViewServices.cshtml"
                      Write(ViewBag.BaseMvcUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        var table = $(\'#Mytable\').DataTable();\r\n\r\n        if (!table.data().any()) {\r\n           \r\n        }\r\n        else {\r\n            $(document).ready(function () {\r\n                table;\r\n            });\r\n        }\r\n\r\n    </script>\r\n");
            }
            );
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a15798", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a16913", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a18028", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a19143", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a20183", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "7d7e4ad2a127b1c43c77d0129730157f172ddc0a21298", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EMKAN.PresentationLayer_Back_Office_.Models.ViewServices>> Html { get; private set; }
    }
}
#pragma warning restore 1591