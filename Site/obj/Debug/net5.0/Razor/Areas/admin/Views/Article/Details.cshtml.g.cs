#pragma checksum "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "efec03f792b4f9ee3add394fcfbef1eff8f52d13"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_Article_Details), @"mvc.1.0.view", @"/Areas/admin/Views/Article/Details.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"efec03f792b4f9ee3add394fcfbef1eff8f52d13", @"/Areas/admin/Views/Article/Details.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6020ce3a7b9b07951dfc728b1c7297965713bf86", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_Article_Details : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Model.Article>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
  
    ViewBag.Title = "Details";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Details</h2>\r\n\r\n<div>\r\n    <h4>Article</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 14 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ArticleSubcategory.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 18 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.ArticleSubcategory.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 22 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 26 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 30 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 34 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.Description));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 38 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 42 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.Body));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 46 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 50 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.KeyWord));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 54 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.PublishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 58 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.PublishDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 62 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 66 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 70 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayNameFor(model => model.ImageAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 74 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
       Write(Html.DisplayFor(model => model.ImageAddress));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n</div>\r\n<p>\r\n    ");
#nullable restore
#line 80 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
Write(Html.ActionLink("Edit", "Edit", new { id = Model.Id }));

#line default
#line hidden
#nullable disable
            WriteLiteral(" |\r\n    ");
#nullable restore
#line 81 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\Article\Details.cshtml"
Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</p>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Model.Article> Html { get; private set; }
    }
}
#pragma warning restore 1591
