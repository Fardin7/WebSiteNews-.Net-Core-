#pragma checksum "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "57d71b984bd355ef4ddc02c8d5a4f70d2430d6be"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Subcategories_Index), @"mvc.1.0.view", @"/Areas/admin/Views/Subcategories/Index.cshtml")]
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
#line 1 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\_ViewImports.cshtml"
using Site;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\_ViewImports.cshtml"
using Model;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\_ViewImports.cshtml"
using Site.ViewModels;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"57d71b984bd355ef4ddc02c8d5a4f70d2430d6be", @"/Areas/admin/Views/Subcategories/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6020ce3a7b9b07951dfc728b1c7297965713bf86", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Subcategories_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Model.Subcategory>>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("src", new global::Microsoft.AspNetCore.Html.HtmlString("~/Scripts/CustomJs/SubCategory.js"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
#line 3 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n");
            DefineSection("scripts", async() => {
                WriteLiteral("\r\n\r\n    ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("script", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "57d71b984bd355ef4ddc02c8d5a4f70d2430d6be4100", async() => {
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
                WriteLiteral("\r\n");
            }
            );
            WriteLiteral("\r\n<p>\r\n    ");
#nullable restore
#line 13 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<table class=\"table\" id=\"Subcategoriestable\">\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 35 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
     foreach (var item in Model)
    {

#line default
#line hidden
#nullable disable
            WriteLiteral("        <tr");
            BeginWriteAttribute("id", " id=\"", 828, "\"", 841, 1);
#nullable restore
#line 37 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
WriteAttributeValue("", 833, item.Id, 833, 8, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(">\r\n            <td>\r\n                ");
#nullable restore
#line 39 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Category.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 42 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Subcategory2.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 45 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 48 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
           Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            </td>\r\n            <td>\r\n                <img");
            BeginWriteAttribute("src", " src=\"", 1292, "\"", 1316, 1);
#nullable restore
#line 51 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
WriteAttributeValue("", 1298, item.ImageAddress, 1298, 18, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral(" style=\"width:210px;height:160px;\"");
            BeginWriteAttribute("alt", " alt=\"", 1351, "\"", 1357, 0);
            EndWriteAttribute();
            WriteLiteral(" />\r\n            </td>\r\n            <td>\r\n                ");
#nullable restore
#line 54 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
           Write(Html.ActionLink("Edit", "Edit", new { id = item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n");
            WriteLiteral("                <button");
            BeginWriteAttribute("onclick", " onclick=\'", 1581, "\'", 1620, 3);
            WriteAttributeValue("", 1591, "deleteSubcategories(", 1591, 20, true);
#nullable restore
#line 56 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
WriteAttributeValue("", 1611, item.Id, 1611, 8, false);

#line default
#line hidden
#nullable disable
            WriteAttributeValue("", 1619, ")", 1619, 1, true);
            EndWriteAttribute();
            WriteLiteral(">حذف</button>\r\n\r\n            </td>\r\n        </tr>\r\n");
#nullable restore
#line 60 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Subcategories\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</table>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Model.Subcategory>> Html { get; private set; }
    }
}
#pragma warning restore 1591