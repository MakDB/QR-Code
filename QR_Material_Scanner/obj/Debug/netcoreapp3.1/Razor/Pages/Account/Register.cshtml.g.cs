#pragma checksum "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "731a4c4775b0f72ea280e5cd12157ea06a02a716"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_Account_Register), @"mvc.1.0.razor-page", @"/Pages/Account/Register.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/register")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"731a4c4775b0f72ea280e5cd12157ea06a02a716", @"/Pages/Account/Register.cshtml")]
    public class Pages_Account_Register : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
  
    Layout = "~/Pages/Shared/_Admin.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h1>");
#nullable restore
#line 7 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
Write(ViewData["Title"]);

#line default
#line hidden
#nullable disable
            WriteLiteral("</h1>\r\n<div class=\"row\">\r\n    <div class=\"col-md-8\">\r\n        <section>\r\n            <form method=\"post\" role=\"form\" class=\"form-horizontal\">\r\n                ");
#nullable restore
#line 12 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <h4>Use a local account to log in.</h4>\r\n                <hr />\r\n\r\n                ");
#nullable restore
#line 17 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 20 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
               Write(Html.LabelFor(m => m.Input.UserName, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 22 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.TextBoxFor(m => m.Input.UserName, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 23 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.UserName, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 27 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
               Write(Html.LabelFor(m => m.Input.Email, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 29 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.TextBoxFor(m => m.Input.Email, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 30 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.Email, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 34 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
               Write(Html.LabelFor(m => m.Input.Password, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 36 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.PasswordFor(m => m.Input.Password, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 37 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 41 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
               Write(Html.LabelFor(m => m.Input.ConfirmPassword, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 43 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.TextBoxFor(m => m.Input.ConfirmPassword, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 44 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </div>\r\n                </div>\r\n                <div class=\"form-group\">\r\n                    ");
#nullable restore
#line 48 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
               Write(Html.LabelFor(m => m.Input.Plant, new { @class = "col-md-2 control-label" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    <div class=\"col-md-10\">\r\n                        ");
#nullable restore
#line 50 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.TextBoxFor(m => m.Input.Plant, new { @class = "form-control" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 51 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\Account\Register.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.Plant, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                    </div>
                </div>

                <div class=""form-group"">
                    <div class=""col-md-offset-2 col-md-10"">
                        <button asp-page-handler=""Register"" class=""btn btn-default"">Register</button>
                    </div>
                </div>
            </form>
        </section>
    </div>
</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QR_Material_Scanner.Pages.Account.RegisterModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.Account.RegisterModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.Account.RegisterModel>)PageContext?.ViewData;
        public QR_Material_Scanner.Pages.Account.RegisterModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
