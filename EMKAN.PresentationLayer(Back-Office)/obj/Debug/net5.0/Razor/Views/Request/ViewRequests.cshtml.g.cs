#pragma checksum "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "25bd5700195beaea86783d86bc2722095d855bcb"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Request_ViewRequests), @"mvc.1.0.view", @"/Views/Request/ViewRequests.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"25bd5700195beaea86783d86bc2722095d855bcb", @"/Views/Request/ViewRequests.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"bd6247efcd79b2c55af66504419e6d4cff1ac3ee", @"/Views/_ViewImports.cshtml")]
    public class Views_Request_ViewRequests : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<EMKAN.PresentationLayer_Back_Office_.Models.ViewServices>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("href", new global::Microsoft.AspNetCore.Html.HtmlString("~/css/site.css"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("rel", new global::Microsoft.AspNetCore.Html.HtmlString("stylesheet"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("title", new global::Microsoft.AspNetCore.Html.HtmlString("Add New Request"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn "), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("background-color:#F88379"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Create", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/Service/Service-js.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
  
    ViewData["Title"] = "ViewEmpServices";
    Layout = "_CustomLayout";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<!--Datatable style-->\r\n");
            DefineSection("Style", async() => {
                WriteLiteral("\r\n    <link rel=\"stylesheet\" type=\"text/css\" href=\"https://cdn.datatables.net/1.10.25/css/jquery.dataTables.css\">\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("link", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.SelfClosing, "25bd5700195beaea86783d86bc2722095d855bcb6421", async() => {
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
            WriteLiteral("<br />\r\n<br />\r\n<br />\r\n\r\n\r\n<p>\r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25bd5700195beaea86783d86bc2722095d855bcb7702", async() => {
                WriteLiteral("<i class=\"fa fa-plus\"></i> Submit a New Request");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "harf", 1, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
#nullable restore
#line 19 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
AddHtmlAttributeValue("", 420, Url.Action("Create", "Request"), 420, 32, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
</p>

<table class=""table table-bordered table-striped text-center"" id=""Mytable"">
    <thead>
        <tr>
            <th>
                

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
                Maintanence Type
            </th>
            <th>
                Status
            </th>

        </tr>
    </thead>
    <tbody>
");
#nullable restore
#line 50 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
         foreach (var item in Model)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <tr>\r\n                <td>\r\n                    <button type=\"button\" data-toggle=\"modal\"");
            BeginWriteAttribute("onclick", " onclick=\"", 1297, "\"", 1329, 3);
            WriteAttributeValue("", 1307, "setRequestId(", 1307, 13, true);
#nullable restore
#line 54 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
WriteAttributeValue("", 1320, item.ID, 1320, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1328, ")", 1328, 1, true);
            EndWriteAttribute();
            WriteLiteral(" data-target=\"#replyModel\"");
            BeginWriteAttribute("value", " value=\"", 1356, "\"", 1372, 1);
#nullable restore
#line 54 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
WriteAttributeValue("", 1364, item.ID, 1364, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"display:contents; color:#F88379; font-size:24px\"> <i class=\"fa fa-info-circle\" aria-hidden=\"true\"></i></button>\r\n");
            WriteLiteral("                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 58 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
               Write(item.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 61 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
               Write(item.RequestDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                <td>\r\n                    ");
#nullable restore
#line 64 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
               Write(item.ResponseDate);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n\r\n                <td>\r\n                    ");
#nullable restore
#line 68 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
               Write(item.ServiceType);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                </td>\r\n                \r\n                <td");
            BeginWriteAttribute("id", " id=\"", 1991, "\"", 2008, 1);
#nullable restore
#line 71 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
WriteAttributeValue("", 1996, item.Status, 1996, 12, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n");
#nullable restore
#line 72 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                     if (item.Status == 0)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("<label> In progress</label>");
#nullable restore
#line 73 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                                                }
                    else if (item.Status == 1)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <label> Closed</label>\r\n");
#nullable restore
#line 77 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                    }
                    else if (item.Status == 2)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <label> Open</label>\r\n");
#nullable restore
#line 81 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                    }
                    else if (item.Status == 3)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <label> Reject</label>\r\n");
#nullable restore
#line 85 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                    }
                    else if (item.Status == 4)
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <label> Approve</label>\r\n");
#nullable restore
#line 89 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral("                        <label> Done</label>\r\n");
#nullable restore
#line 93 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("                </td>\r\n\r\n\r\n            </tr>\r\n");
#nullable restore
#line 98 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral(@"    </tbody>
</table>

<div class=""modal fade"" id=""replyModel"" tabindex=""-1"" role=""dialog"" aria-labelledby=""replyModelLabel"" aria-hidden=""true"">
    <div class=""modal-dialog"" role=""document"">
        <div class=""modal-content"">

            <div class=""modal-header"">
                <button type=""button"" class=""close"" data-dismiss=""modal"" aria-label=""Close"">
                    <span aria-hidden=""true"">&times;</span>
                </button>
            </div>
            <div class=""modal-body"">

                <div class=""form-group"">
                    <h5>Description of the issue</h5>
                    <label id=""description"">  </label>
                </div>

                <div class=""form-group"">
                    <h5>Maintanence Type</h5>
                    <label id=""servicetype""> </label>
                </div>

                <div class=""form-group"">
                    <h5> Reply Response</h5>
                    <label id=""content"" style="" background-color: #F8");
            WriteLiteral(@"8379""></label>
                </div>

                <div class=""form-group"">
                    <label> </label>

                </div>
                <input type=""text"" class=""form-control"" required=""required"" id=""requestid"" hidden />
            </div>

        </div>
    </div>
</div>
<!--Data Table-->
");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    <script type=\"text/javascript\" charset=\"utf8\" src=\"https://cdn.datatables.net/1.10.25/js/jquery.dataTables.js\"></script>\r\n    <script type=\"text/javascript\">\r\n         var mvcBaseUrl = \'");
#nullable restore
#line 142 "C:\Users\ssarr\Desktop\EMKAN_T2\EMKAN\EMKAN.PresentationLayer(Back-Office)\Views\Request\ViewRequests.cshtml"
                      Write(ViewBag.BaseMvcUrl);

#line default
#line hidden
#nullable disable
                WriteLiteral(@"';
        var table = $('#Mytable').DataTable();
            if (!table.data().any()) {
               
            }
            else {
                $(document).ready(function () {
                    table;
                });


            }



    </script>
");
            }
            );
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "25bd5700195beaea86783d86bc2722095d855bcb18497", async() => {
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