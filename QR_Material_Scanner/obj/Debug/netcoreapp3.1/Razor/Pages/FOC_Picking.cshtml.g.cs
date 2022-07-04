#pragma checksum "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\FOC_Picking.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "93424d9aee558da77e95f9204f21a9856f551b70"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Pages_FOC_Picking), @"mvc.1.0.razor-page", @"/Pages/FOC_Picking.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemMetadataAttribute("RouteTemplate", "/foc_delivery")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"93424d9aee558da77e95f9204f21a9856f551b70", @"/Pages/FOC_Picking.cshtml")]
    public class Pages_FOC_Picking : global::Microsoft.AspNetCore.Mvc.RazorPages.Page
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/js/foc-delivery-feed.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#nullable restore
#line 3 "D:\Ariston Projects\QR Material Scanner\QR_Material_Scanner - Update Delivery\QR_Material_Scanner\Pages\FOC_Picking.cshtml"
  
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
    <div class=""pageTitle"">FOC Delivery Picking</div>
    <div class=""right"">
    </div>
</div>
<!-- * App Header -->
<!-- App Capsule -->
<div id=""appCapsule"">

    <div class=""fab-button animate top-right"">
");
            WriteLiteral("        <a href=\"#\" class=\"fab\" id=\"open-model-button\">\r\n            <ion-icon name=\"add-outline\"></ion-icon>\r\n        </a>\r\n    </div>\r\n");
            WriteLiteral("\r\n\r\n    <div class=\"section full mt-2 mb-2\">\r\n        <div class=\"section-title\">FOC Delivery Picking</div>\r\n        <div class=\"wide-block pt-2 pb-2\">\r\n\r\n            <form class=\"needs-validation\" novalidate>\r\n\r\n");
            WriteLiteral("\r\n");
            WriteLiteral(@"                <div class=""form-group boxed"">
                    <div class=""input-wrapper"">
                        <label class=""label"" for=""name5"">FOC Delivery Challan Number</label>
                        <input type=""number"" class=""form-control"" id=""txtDeliveryChallanNo"" readonly=""readonly"" autocomplete=""off"" required>

                        <i class=""clear-input"">
                            <ion-icon name=""close-circle""></ion-icon>
                        </i>
                        <div class=""valid-feedback"">Looks good!</div>
                        <div class=""invalid-feedback"">Please delivery can not be blank.</div>
                    </div>
                </div>

                <div class=""form-group boxed"">
                    <div class=""searchbox"">
                        <input type=""text"" class=""form-control"" id=""txtQrCode"" autocomplete=""off"">
                        <i class=""input-icon"">
                            <ion-icon src=""/svg/qr-code-outline.svg""></ion-ico");
            WriteLiteral(@"n>
                        </i>
                    </div>
                </div>
                <div class=""section full mt-1 mb-2"">
                    <div class=""section-title"">
                        <a href=""#"" id=""hylScanMaterial""> Scanned Products</a>

                        <span id=""spanTotalQty"" class=""badge badge-primary""></span>
                        <span id=""spanTotalScanQty"" class=""badge badge-success""></span>
                    </div>
                    <div class=""content-header mb-05"">

                    </div>
                    <div class=""wide-block p-0"">

                        <div class=""table-responsive"">
                            <table class=""table"">
                                <thead>
                                    <tr>
                                        <th scope=""col"">Serial Key</th>
                                        <th scope=""col"">Material</th>
                                        <th scope=""col"">Delivery No</th>
     ");
            WriteLiteral(@"                                   <th scope=""col""><i class=""fa fa-trash"" aria-hidden=""true""></i></th>
                                    </tr>
                                </thead>
                                <tbody id=""tbodyScan"">
                                </tbody>
                            </table>
                        </div>
                        <div id=""notfoundScan""></div>
                    </div>
                </div>


                <div class=""mt-5"">
                    <button class=""btn btn-primary btn-block"" id=""btnSubmit"" type=""button"">Submit</button>
                </div>

            </form>


        </div>
    </div>


    <!-- Form Action Sheet -->
    <div class=""modal fade action-sheet"" id=""actionSheetForm"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">FOC Delivery Picking</h5");
            WriteLiteral(@">
                </div>
                <div class=""modal-body"">
                    <div class=""action-sheet-content"">
                        <form class=""needs-validation"" novalidate>
                            <div class=""form-group basic animated"">
                                <div class=""input-wrapper"">
                                    <label class=""label"" for=""Delivery"">Delivery Challan Number</label>
                                    <input type=""number"" maxlength=""10"" class=""form-control"" id=""txtDeliveryChallanNoFetch"" placeholder=""Delivery Challan Number"" required>

                                    <i class=""clear-input"">
                                        <ion-icon name=""close-circle""></ion-icon>
                                    </i>
                                    <div class=""valid-feedback"">Looks good!</div>
                                    <div class=""invalid-feedback"">Please enter Delivery Challan Number.</div>
                                </div>
 ");
            WriteLiteral(@"                           </div>

                            <div class=""section full mt-1 mb-2"">
                                <div class=""section-title"">Material Group</div>
                                <div class=""content-header mb-05"">

                                </div>
                                <div class=""wide-block p-0"">

                                    <!--  Table -->
                                    <div class=""table-responsive"">
                                        <table class=""table"">
                                            <thead>
                                                <tr>
                                                    <th scope=""col"">ID</th>
                                                    <th scope=""col"">Delivery No</th>
                                                    <th scope=""col"">Material</th>
                                                    <th scope=""col"">Qty</th>
                                                </t");
            WriteLiteral(@"r>
                                            </thead>
                                            <tbody id=""tbody"">
                                            </tbody>
                                        </table>
                                    </div>
                                    <div id=""notfound""></div>

                                </div>
                            </div>
                            <div class=""form-group basic"">
                                <button type=""button"" id=""btnScanMaterial"" class=""btn btn-primary btn-block btn-lg"" data-dismiss=""modal"">
                                    Scan Material
                                </button>
                                <button type=""button"" id=""btnDeliverySubmit"" class=""btn btn-secondary btn-block btn-lg"">
                                    Submit
                                </button>
                            </div>
                        </form>
                    </div>
              ");
            WriteLiteral(@"  </div>
            </div>
        </div>
    </div>
    <!-- * Form Action Sheet -->
    <!-- Dialog Basic -->
    <div class=""modal fade dialogbox"" id=""DialogBasic"" data-backdrop=""static"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title"">Delete Confirmation</h5>
                </div>
                <div class=""modal-body"">
                    Are you sure you want to DELETE?
                </div>
                <div class=""modal-footer"">
                    <div class=""btn-inline"">
                        <a href=""#"" class=""btn btn-text-secondary"" data-dismiss=""modal"">CLOSE</a>
                        <a href=""#"" class=""btn btn-text-primary"" id=""btnDeleteYesNo"">OK</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * Dialog Basic -->
    <!-- DialogAlert -->
    <div ");
            WriteLiteral(@"class=""modal fade dialogbox"" id=""DialogAlert"" data-backdrop=""static"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-icon text-danger"">
                    <ion-icon name=""close-circle""></ion-icon>
                </div>
                <div class=""modal-header"">
                    <h5 class=""modal-title""></h5>
                </div>
                <div class=""modal-body"">

                </div>
                <div class=""modal-footer"">
                    <div class=""btn-inline"">
                        <a href=""#"" class=""btn"" data-dismiss=""modal"">CLOSE</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * DialogAlert -->
    <!-- Panel Right -->
    <div class=""modal fade panelbox panelbox-right"" id=""PanelRight"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-");
            WriteLiteral(@"content"">
                <div class=""modal-header"">
                    <h4 class=""modal-title"">Total Scanned Material</h4>
                    <a href=""javascript:;"" data-dismiss=""modal"" class=""panel-close"">
                        <ion-icon name=""close-outline""></ion-icon>
                    </a>
                </div>
                <div class=""modal-body"">
                    <p>
                        <div id=""listScanMatrial""></div>

                    </p>
                </div>
            </div>
        </div>
    </div>
    <!-- * Panel Right -->
    <!-- Dialog Basic -->
    <div class=""modal fade dialogbox"" id=""DialogBasicConfirmation"" data-backdrop=""static"" tabindex=""-1"" role=""dialog"">
        <div class=""modal-dialog"" role=""document"">
            <div class=""modal-content"">
                <div class=""modal-header"">
                    <h5 class=""modal-title""></h5>
                </div>
                <div class=""modal-body"">
                </div>
              ");
            WriteLiteral(@"  <div class=""modal-footer"">
                    <div class=""btn-inline"">
                        <a href=""#"" class=""btn btn-text-secondary"" data-dismiss=""modal"">CLOSE</a>
                        <a href=""#"" class=""btn btn-text-primary"" id=""btnOkConfirmation"">OK</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <!-- * Dialog Basic -->
</div>
<!-- * App Capsule -->

");
            DefineSection("Scripts", async() => {
                WriteLiteral("\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "93424d9aee558da77e95f9204f21a9856f551b7014696", async() => {
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
                WriteLiteral(@"

    <script>
        // Example starter JavaScript for disabling form submissions if there are invalid fields
        (function () {
            'use strict';
            window.addEventListener('load', function () {
                // Fetch all the forms we want to apply custom Bootstrap validation styles to
                var forms = document.getElementsByClassName('needs-validation');
                // Loop over them and prevent submission
                var validation = Array.prototype.filter.call(forms, function (form) {
                    form.addEventListener('click', function (event) {
                        if (form.checkValidity() === false) {
                            event.preventDefault();
                            event.stopPropagation();
                        }
                        form.classList.add('was-validated');
                    }, false);
                });
            }, false);
        })();
    </script>
");
            }
            );
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<QR_Material_Scanner.Pages.FOC_PickingModel> Html { get; private set; }
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.FOC_PickingModel> ViewData => (global::Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary<QR_Material_Scanner.Pages.FOC_PickingModel>)PageContext?.ViewData;
        public QR_Material_Scanner.Pages.FOC_PickingModel Model => ViewData.Model;
    }
}
#pragma warning restore 1591
