#pragma checksum "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d046507b1de5a8dd244f5f159ce4a4822327edf8"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ADMIN_Views_AdminNhanviens_Details), @"mvc.1.0.view", @"/Areas/ADMIN/Views/AdminNhanviens/Details.cshtml")]
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
#line 1 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\_ViewImports.cshtml"
using WebQLKSORACLE;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\_ViewImports.cshtml"
using WebQLKSORACLE.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"d046507b1de5a8dd244f5f159ce4a4822327edf8", @"/Areas/ADMIN/Views/AdminNhanviens/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc4b9db8154b33e3a0452e0284c13b5d769f876", @"/Areas/ADMIN/Views/_ViewImports.cshtml")]
    public class Areas_ADMIN_Views_AdminNhanviens_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<WebQLKSORACLE.Models.Nhanvien>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info btn-xs waves-effect waves-light"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminNhanviens", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Edit", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-default"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
  
    ViewData["Title"] = "Details";
    Layout = "~/Areas/ADMIN/Views/Shared/_ADMINLayout.cshtml";

#line default
#line hidden
#nullable disable
            WriteLiteral(@"
<!-- breadcrumb area start -->
<section class=""breadcrumb__area box-plr-75"">
    <div class=""container-fluid"">
        <div class=""row"">
            <div class=""col-xxl-12"">
                <div class=""breadcrumb__wrapper"">
                    <nav aria-label=""breadcrumb"">
                        <ol class=""breadcrumb"">
                            <li class=""breadcrumb-item"">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d046507b1de5a8dd244f5f159ce4a4822327edf86207", async() => {
                WriteLiteral("Trang chủ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("</li>\r\n                            <li class=\"breadcrumb-item\">");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d046507b1de5a8dd244f5f159ce4a4822327edf87834", async() => {
                WriteLiteral("Danh sách nhân viên");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                            <li class=""breadcrumb-item active"" aria-current=""page""><a></a>Thông tin nhân viên</li>
                        </ol>
                    </nav>
                </div>
            </div>
        </div>
    </div>
</section>
<!-- breadcrumb area end -->

<div class=""dropdown js__drop_down"" style=""padding-top: 13px; padding-bottom: 13px"">
    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d046507b1de5a8dd244f5f159ce4a4822327edf89395", async() => {
                WriteLiteral("Chỉnh sửa nhân viên");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 29 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                                                                                                                                 WriteLiteral(Model.MaNv);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n    <!-- /.sub-menu -->\r\n</div>\r\n<table class=\"table table-hover no-margin\">\r\n    <tbody>\r\n        <tr>\r\n            <td>ID: </td>\r\n            <td>");
#nullable restore
#line 36 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
           Write(Model.MaNv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Tên nhân viên: </td>\r\n            <td>");
#nullable restore
#line 40 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
           Write(Model.TenNv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</i></td>\r\n        </tr>\r\n        <tr>\r\n            <td>Email: </td>\r\n            <td>");
#nullable restore
#line 44 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
           Write(Model.EmailNv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Số điện thoại: </td>\r\n            <td>");
#nullable restore
#line 48 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
           Write(Model.SdtNv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Địa chỉ: </td>\r\n            <td>");
#nullable restore
#line 52 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
           Write(Model.DiachiNv);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n        <tr>\r\n            <td>Trạng thái: </td>\r\n            <td>\r\n");
#nullable restore
#line 57 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                 if (@Model.TrangthaiNv == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"notice notice-blue\">Active</span>\r\n");
#nullable restore
#line 60 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"notice notice-danger\">Block</span>\r\n");
#nullable restore
#line 64 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>Giới tính: </td>\r\n            <td>\r\n");
#nullable restore
#line 70 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                 if (@Model.GioitinhNv == true)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"notice notice-blue\">Nam</span>\r\n");
#nullable restore
#line 73 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <span class=\"notice notice-blue\">Nữ</span>\r\n");
#nullable restore
#line 77 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
                }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </td>\r\n        </tr>\r\n        <tr>\r\n            <td>Role: </td>\r\n            <td>");
#nullable restore
#line 82 "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\AdminNhanviens\Details.cshtml"
           Write(Model.Role.TenR);

#line default
#line hidden
#nullable disable
            WriteLiteral("</td>\r\n        </tr>\r\n\r\n    </tbody>\r\n</table>\r\n\r\n<div class=\"form-group\"> \r\n    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "d046507b1de5a8dd244f5f159ce4a4822327edf816418", async() => {
                WriteLiteral("Quay lại danh sách nhân viên");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_2.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n</div>");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<WebQLKSORACLE.Models.Nhanvien> Html { get; private set; }
    }
}
#pragma warning restore 1591