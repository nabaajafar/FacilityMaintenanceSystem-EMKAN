#pragma checksum "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "c4217879da1cd217bccd6988294f6682790bdb09"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_MaintenanceManager_ViewClients), @"mvc.1.0.view", @"/Views/MaintenanceManager/ViewClients.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"c4217879da1cd217bccd6988294f6682790bdb09", @"/Views/MaintenanceManager/ViewClients.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd6247efcd79b2c55af66504419e6d4cff1ac3ee", @"/Views/_ViewImports.cshtml")]
    public class Views_MaintenanceManager_ViewClients : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EMKAN.PresentationLayer_Back_Office_.Models.ViewClient>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap-grid.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/lib/bootstrap/dist/css/bootstrap-reboot.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/Active.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/UserStatus/UserStatus.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 4 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
  
    ViewData["Title"] = "ViewClients"; Layout = "_CustomLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n\r\n<h1>All Clients</h1>\r\n<!--Datatable style-->\r\n");
            DefineSection("Style", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c4217879da1cd217bccd6988294f6682790bdb096511", async() => {
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
            WriteLiteral("<table  id=\"Mytable\" class=\"table table-bordered table-striped text-center\">\r\n    <thead>\r\n        <tr>\r\n            <th>\r\n               \r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 23 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.DisplayNameFor(model => model.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n          \r\n            <th>\r\n                ");
#nullable restore
#line 27 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.DisplayNameFor(model => model.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </th>\r\n            <th>\r\n                ");
#nullable restore
#line 30 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.DisplayNameFor(model => model.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
            </th>
            
            <th>
               Active
            </th>
            <th>
                Activate
            </th>
            <th>
                Deactivate
            </th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 46 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr>\r\n            <td");
            BeginWriteAttribute("id", " id=\"", 1183, "\"", 1196, 1);
#nullable restore
#line 49 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
WriteAttributeValue("", 1188, item.ID, 1188, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n                ");
#nullable restore
#line 50 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.HiddenFor(modelItem => item.ID));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 53 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.DisplayFor(modelItem => item.FullName));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            \r\n            <td>\r\n                ");
#nullable restore
#line 57 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.DisplayFor(modelItem => item.Username));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 60 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
           Write(Html.DisplayFor(modelItem => item.Phone));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n           \r\n            <td id=\"status\">\r\n");
#nullable restore
#line 64 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                 if (item.Status == 1)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("<label style=\"color:#89D88C\"><i class=\"fa fa-check\" aria-hidden=\"true\"></i> </label>");
#nullable restore
#line 65 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                                                                                                     }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <label style=\"color:#F88379\"><i class=\"fa fa-times\" aria-hidden=\"true\"></i> </label>\r\n");
#nullable restore
#line 69 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n");
#nullable restore
#line 73 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                 if (item.Status == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"button\" class=\"btn  btn-circle btn-sm\" style=\"background-color: #D8D8D8\" id=\"activate\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2153, "\"", 2181, 3);
            WriteAttributeValue("", 2163, "Activate(", 2163, 9, true);
#nullable restore
#line 75 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
WriteAttributeValue("", 2172, item.ID, 2172, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2180, ")", 2180, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-check\"></i>     </button>\r\n");
#nullable restore
#line 76 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <button type=\"button\" class=\"btn  btn-circle btn-sm\" style=\"background-color: #89D88C\" id=\"activate\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2406, "\"", 2434, 3);
            WriteAttributeValue("", 2416, "Activate(", 2416, 9, true);
#nullable restore
#line 79 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
WriteAttributeValue("", 2425, item.ID, 2425, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2433, ")", 2433, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-check\"></i>     </button>\r\n");
#nullable restore
#line 80 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n            </td>\r\n            <td>\r\n                <button type=\"button\" class=\"btn  btn-circle btn-sm\" style=\"background-color: #F88379\" id=\"deactivate\"");
            BeginWriteAttribute("onclick", " onclick=\"", 2657, "\"", 2687, 3);
            WriteAttributeValue("", 2667, "Deactivate(", 2667, 11, true);
#nullable restore
#line 85 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
WriteAttributeValue("", 2678, item.ID, 2678, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 2686, ")", 2686, 1, true);
            EndWriteAttribute();
            WriteLiteral("><i class=\"fa fa-times\"></i></button>\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 88 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </tbody>\r\n</table>\r\n<!--Data Table-->\r\n");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\" charset=\"utf8\" src=\"https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js\"></script>\r\n    <script type=\"text/javascript\">\r\n         var mvcBaseUrl = \'");
#nullable restore
#line 95 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\MaintenanceManager\ViewClients.cshtml"
                      Write(ViewBag.BaseMvcUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral("\';\r\n        var table = $(\'#Mytable\').DataTable();\r\n        if (!table.data().any()) {\r\n          \r\n        }\r\n        else {\r\n            $(document).ready(function () {\r\n                table;\r\n\r\n            });\r\n\r\n\r\n\r\n        }\r\n\r\n    </script>\r\n");
            }
            );
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c4217879da1cd217bccd6988294f6682790bdb0916819", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c4217879da1cd217bccd6988294f6682790bdb0917934", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c4217879da1cd217bccd6988294f6682790bdb0919049", async() => {
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
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "c4217879da1cd217bccd6988294f6682790bdb0920164", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "c4217879da1cd217bccd6988294f6682790bdb0921279", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<EMKAN.PresentationLayer_Back_Office_.Models.ViewClient>> Html { get; private set; }
    }
}
#pragma warning restore 1591