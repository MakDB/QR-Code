#pragma checksum "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "22988d24fa07055572e78b5bee7e6001a4651880"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_ResetPassword), @"mvc.1.0.razor-page", @"/Pages/ResetPassword.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"22988d24fa07055572e78b5bee7e6001a4651880", @"/Pages/ResetPassword.cshtml")]
    public class Pages_ResetPassword : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
  

    Layout = "~/Pages/Shared/_Plain.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"<!-- App Capsule -->
<div id=""appCapsule"">

    <div class=""login-form"">
        <div class=""section"">
            <h1>Reset Password</h1>
            <h4>Type your email to reset your password</h4>
        </div>
        <div class=""section mt-2 mb-5"">
            <form method=""post"">
                ");
#nullable restore
#line 17 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
           Write(Html.ValidationSummary(true, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 18 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
           Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n                ");
#nullable restore
#line 20 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
           Write(Html.HiddenFor(m => m.Input.Token));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                ");
#nullable restore
#line 21 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
           Write(Html.HiddenFor(m => m.Input.Email));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("\r\n                <div class=\"form-group boxed\">\r\n                    <div class=\"input-wrapper\">\r\n                        ");
#nullable restore
#line 34 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
                   Write(Html.PasswordFor(m => m.Input.Password, new { @class = "form-control", @placeholder = "Password" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 35 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.Password, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <i class=""clear-input"">
                            <ion-icon name=""close-circle""></ion-icon>
                        </i>
                    </div>
                </div>
                <div class=""form-group boxed"">
                    <div class=""input-wrapper"">
                        ");
#nullable restore
#line 43 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
                   Write(Html.TextBoxFor(m => m.Input.ConfirmPassword, new { @class = "form-control", @placeholder = "ConfirmPassword" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 44 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ResetPassword.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.ConfirmPassword, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
                        <i class=""clear-input"">
                            <ion-icon name=""close-circle""></ion-icon>
                        </i>
                    </div>
                </div>

                <div class=""form-button-group"">
                    <button type=""submit"" class=""btn btn-primary btn-block btn-lg"">Reset</button>
                </div>

            </form>
        </div>
    </div>



</div>
<!-- * App Capsule -->");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QR_Material_Scanner.Pages.ResetPasswordModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.ResetPasswordModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.ResetPasswordModel>)PageContext?.ViewData;
        public QR_Material_Scanner.Pages.ResetPasswordModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
