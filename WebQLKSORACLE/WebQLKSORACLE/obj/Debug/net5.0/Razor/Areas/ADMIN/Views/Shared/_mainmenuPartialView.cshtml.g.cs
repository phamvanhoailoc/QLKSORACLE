#pragma checksum "E:\Hoc Tap\oracle\QLKS\WebQLKSORACLE\WebQLKSORACLE\Areas\ADMIN\Views\Shared\_mainmenuPartialView.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "42b970e13be548b35a186d9641720b7ca8621221"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_ADMIN_Views_Shared__mainmenuPartialView), @"mvc.1.0.view", @"/Areas/ADMIN/Views/Shared/_mainmenuPartialView.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"42b970e13be548b35a186d9641720b7ca8621221", @"/Areas/ADMIN/Views/Shared/_mainmenuPartialView.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"7dc4b9db8154b33e3a0452e0284c13b5d769f876", @"/Areas/ADMIN/Views/_ViewImports.cshtml")]
    public class Areas_ADMIN_Views_Shared__mainmenuPartialView : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<dynamic>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Admin", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("logo"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("waves-effect"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminRoLes", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Index", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "AdminKhachhangs", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
            WriteLiteral("<div class=\"main-menu\">\r\n    <header class=\"header\">\r\n        ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42b970e13be548b35a186d9641720b7ca86212215560", async() => {
                WriteLiteral("Admin");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
        <button type=""button"" class=""button-close fa fa-times js__menu_close""></button>
    </header>
    <!-- /.header -->
    <div class=""content"">

        <div class=""navigation"">
            <ul class=""menu js__accordion"">
                <li class=""current"">
                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42b970e13be548b35a186d9641720b7ca86212217305", async() => {
                WriteLiteral("<i class=\"menu-icon mdi mdi-view-dashboard\"></i><span>Trang chủ</span>");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_3);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                </li>
                <li>
                    <a class=""waves-effect parent-item js__control"" href=""#""><i class=""menu-icon mdi mdi-flower""></i><span>Quản lý hệ thống</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a >Quản lý tài khoản</a></li>                       
                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42b970e13be548b35a186d9641720b7ca86212219234", async() => {
                WriteLiteral("Quản lý quyền truy cập");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>

                <li>
                    <a class=""waves-effect parent-item js__control"" href=""#""><i class=""menu-icon mdi mdi-chart-bar""></i><span>Quản lý khách hàng</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li>");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "42b970e13be548b35a186d9641720b7ca862122111241", async() => {
                WriteLiteral("Danh sách khách hàng");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_0.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_0);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_6.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_6);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"</li>

                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
                <li>
                    <a class=""waves-effect parent-item js__control"" href=""#""><i class=""menu-icon mdi mdi-cube-outline""></i><span>Admin UI</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a href=""ui-notification.html"">Notification</a></li>
                        <li><a href=""profile.html"">Profile</a></li>
                        <li><a href=""ui-range-slider.html"">Range Slider</a></li>
                        <li><a href=""ui-sweetalert.html"">Sweet Alert</a></li>
                        <li><a href=""ui-treeview.html"">Tree view</a></li>
                        <li><a href=""widgets.html"">Widget</a></li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
                <li>
                    <a class=""waves-effect parent-item j");
            WriteLiteral(@"s__control"" href=""#""><i class=""menu-icon mdi mdi-buffer""></i><span>User Interface</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a href=""ui-buttons.html"">Buttons</a></li>
                        <li><a href=""ui-cards.html"">Cards</a></li>
                        <li><a href=""ui-checkbox-radio.html"">Checkboxs-Radios</a></li>
                        <li><a href=""ui-components.html"">Components</a></li>
                        <li><a href=""ui-draggable-cards.html"">Draggable Cards</a></li>
                        <li><a href=""ui-modals.html"">Modals</a></li>
                        <li><a href=""ui-typography.html"">Typography</a></li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
                <li>
                    <a class=""waves-effect"" href=""inbox.html""><i class=""menu-icon mdi mdi-email-outline""></i><span>Mail</span></a>
                </li>
    ");
            WriteLiteral(@"            <li>
                    <a class=""waves-effect parent-item js__control"" href=""#""><i class=""menu-icon mdi mdi-pencil-box""></i><span>Forms</span><span class=""notice notice-blue"">7</span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a href=""form-elements.html"">General Elements</a></li>
                        <li><a href=""form-advanced.html"">Advanced Form</a></li>
                        <li><a href=""form-fileupload.html"">Form Uploads</a></li>
                        <li><a href=""form-validation.html"">Form Validation</a></li>
                        <li><a href=""form-wizard.html"">Form Wizard</a></li>
                        <li><a href=""form-wysiwig.html"">Wysiwig Editors</a></li>
                        <li><a href=""form-xeditable.html"">X-editable</a></li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
                <li>
                    <a class=""waves-effect parent-item js__control"" hr");
            WriteLiteral(@"ef=""#""><i class=""menu-icon mdi mdi-table""></i><span>Tables</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a href=""tables-basic.html"">Basic Tables</a></li>
                        <li><a href=""tables-datatable.html"">Data Tables</a></li>
                        <li><a href=""tables-responsive.html"">Responsive Tables</a></li>
                        <li><a href=""tables-editable.html"">Editable Tables</a></li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
                <li>
                    <a class=""waves-effect parent-item js__control"" href=""#""><i class=""menu-icon mdi mdi-book-multiple-variant""></i><span>Page</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a href=""page-starter.html"">Starter Page</a></li>
                        <li><a href=""page-login.htm");
            WriteLiteral(@"l"">Login</a></li>
                        <li><a href=""page-register.html"">Register</a></li>
                        <li><a href=""page-recoverpw.html"">Recover Password</a></li>
                        <li><a href=""page-lock-screen.html"">Lock Screen</a></li>
                        <li><a href=""page-confirm-mail.html"">Confirm Mail</a></li>
                        <li><a href=""page-404.html"">Error 404</a></li>
                        <li><a href=""page-500.html"">Error 500</a></li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
                <li>
                    <a class=""waves-effect parent-item js__control"" href=""#""><i class=""menu-icon mdi mdi-folder-multiple""></i><span>Extra Pages</span><span class=""menu-arrow fa fa-angle-down""></span></a>
                    <ul class=""sub-menu js__content"">
                        <li><a href=""extras-contact.html"">Contact list</a></li>
                        <li><a href=""extras-email-template.html"">Ema");
            WriteLiteral(@"il template</a></li>
                        <li><a href=""extras-faq.html"">FAQ</a></li>
                        <li><a href=""extras-gallery.html"">Gallery</a></li>
                        <li><a href=""extras-invoice.html"">Invoice</a></li>
                        <li><a href=""extras-maps.html"">Maps</a></li>
                        <li><a href=""extras-pricing.html"">Pricing</a></li>
                        <li><a href=""extras-projects.html"">Projects</a></li>
                        <li><a href=""extras-taskboard.html"">Taskboard</a></li>
                        <li><a href=""extras-timeline.html"">Timeline</a></li>
                        <li><a href=""extras-tour.html"">Tour</a></li>
                    </ul>
                    <!-- /.sub-menu js__content -->
                </li>
            </ul>
            <!-- /.menu js__accordion -->
        </div>
        <!-- /.navigation -->
    </div>
    <!-- /.content -->
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<dynamic> Html { get; private set; }
    }
}
#pragma warning restore 1591