#pragma checksum "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ExportToExcel.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "89a8fec355a729f2a976c2514c04dcdb84f7ec2f"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_ExportToExcel), @"mvc.1.0.razor-page", @"/Pages/ExportToExcel.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/ExportToExcel")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"89a8fec355a729f2a976c2514c04dcdb84f7ec2f", @"/Pages/ExportToExcel.cshtml")]
    public class Pages_ExportToExcel : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 3 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ExportToExcel.cshtml"
  
    Layout = "~/Pages/Shared/_Layout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- App Header -->
<div class=""appHeader bg-primary text-light"">
    <div class=""left"">
        <a href=""javascript:;"" class=""headerButton goBack"">
            <ion-icon name=""chevron-back-outline""></ion-icon>
        </a>
    </div>
    <div class=""pageTitle"">Delivery Picking</div>
    <div class=""right"">
    </div>
</div>
<!-- * App Header -->
<!-- App Capsule -->
<div id=""appCapsule"">

    <div class=""fab-button animate top-right"">
");
            WriteLiteral("        <a href=\"#\" class=\"fab\" id=\"open-model-button\">\r\n            <ion-icon name=\"add-outline\"></ion-icon>\r\n        </a>\r\n    </div>\r\n");
            WriteLiteral(@"

    <div class=""section full mt-2 mb-2"">
        <div class=""section-title"">Export To Excel</div>
        <div class=""wide-block pt-2 pb-2"">

            <form class=""needs-validation"" novalidate>
                <div class=""form-group boxed"">
                    <div class=""input-wrapper"">
                        <label class=""label"" for=""Business_Name"">From Date </label>
");
            WriteLiteral("                        ");
#nullable restore
#line 45 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ExportToExcel.cshtml"
                   Write(Html.EditorFor(m => m.Input.FromDate, new { @type = "date", @class = "form-control", @placeholder = "To Date", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                        ");
#nullable restore
#line 46 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ExportToExcel.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.FromDate, "", new { @class = "text-danger" }));

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
                        <label class=""label"" for=""Business_Name"">To Date </label>
                        ");
#nullable restore
#line 56 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ExportToExcel.cshtml"
                   Write(Html.EditorFor(m => m.Input.ToDate, new { @type = "date", @class = "form-control", @placeholder = "To Date", autocomplete = "off" }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            WriteLiteral("                        ");
#nullable restore
#line 58 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\ExportToExcel.cshtml"
                   Write(Html.ValidationMessageFor(m => m.Input.ToDate, "", new { @class = "text-danger" }));

#line default
#line hidden
#nullable disable
            WriteLiteral(@"

                        <i class=""clear-input"">
                            <ion-icon name=""close-circle""></ion-icon>
                        </i>
                    </div>
                    </div>
                    <div class=""mt-5"">
                        <button class=""btn btn-primary btn-block"" id=""btnSubmit"" type=""submit"">Submit</button>
                    </div>

            </form>


        </div>
    </div>
</div>
<!-- * App Capsule -->
");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QR_Material_Scanner.Pages.ExportToExcelModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.ExportToExcelModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.ExportToExcelModel>)PageContext?.ViewData;
        public QR_Material_Scanner.Pages.ExportToExcelModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591