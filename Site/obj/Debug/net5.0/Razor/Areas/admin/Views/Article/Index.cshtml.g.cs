#pragma checksum "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "28c1d590799d3141295b916dfe3c3a98b8ed4d35"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Article_Index), @"mvc.1.0.view", @"/Areas/admin/Views/Article/Index.cshtml")]
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
#nullable restore
#line 2 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
using System.Globalization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
using Resource;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"28c1d590799d3141295b916dfe3c3a98b8ed4d35", @"/Areas/admin/Views/Article/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6020ce3a7b9b07951dfc728b1c7297965713bf86", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Article_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<IEnumerable<Model.Article>>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 4 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
  
    ViewBag.Title = "Index";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Index</h2>\r\n\r\n<p>\r\n    ");
#nullable restore
#line 11 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
Write(Html.ActionLink("Create New", "Create"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n<table class=\"table\">\r\n    <tr>\r\n        <th>\r\n  \r\n            ");
#nullable restore
#line 17 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.ArticleSubcategory.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 20 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 23 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 26 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 29 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 32 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.PublishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 35 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th>\r\n            ");
#nullable restore
#line 38 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayNameFor(model => model.ImageAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </th>\r\n        <th></th>\r\n    </tr>\r\n\r\n");
#nullable restore
#line 43 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
 foreach (var item in Model) {

#line default
#line hidden
#nullable disable
            WriteLiteral("    <tr>\r\n        <td> \r\n            \r\n");
            WriteLiteral("           ");
#nullable restore
#line 48 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
      Write(Html.RouteLink(item.Title, "article1", new {  id = item.Title,cat=" مقاله لرستان" ,subcat="محیط زیستjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjjj"}));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n            ");
#nullable restore
#line 49 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.ArticleSubcategory.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 52 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 55 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 58 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 61 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 64 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.PublishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 67 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 70 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.DisplayFor(modelItem => item.ImageAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n        <td>\r\n            ");
#nullable restore
#line 73 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.ActionLink("Edit", "Edit", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            ");
#nullable restore
#line 74 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.ActionLink("Details", "Details", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n            ");
#nullable restore
#line 75 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
       Write(Html.ActionLink("Delete", "Delete", new { id=item.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </td>\r\n    </tr>\r\n");
#nullable restore
#line 78 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Index.cshtml"
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<IEnumerable<Model.Article>> Html { get; private set; }
    }
}
#pragma warning restore 1591
