#pragma checksum "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "5607f389eed8da18149c7d899fd4f159c048e50e"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_admin_Views_NewsCategories_Delete), @"mvc.1.0.view", @"/Areas/admin/Views/NewsCategories/Delete.cshtml")]
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
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5607f389eed8da18149c7d899fd4f159c048e50e", @"/Areas/admin/Views/NewsCategories/Delete.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"6020ce3a7b9b07951dfc728b1c7297965713bf86", @"/Areas/admin/Views/_ViewImports.cshtml")]
    public class Areas_admin_Views_NewsCategories_Delete : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<Model.NewsCategory>
    {
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("\r\n");
#nullable restore
#line 3 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
  
    ViewBag.Title = "Delete";

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n<h2>Delete</h2>\r\n\r\n<h3>Are you sure you want to delete this?</h3>\r\n<div>\r\n    <h4>NewsCategory</h4>\r\n    <hr />\r\n    <dl class=\"dl-horizontal\">\r\n        <dt>\r\n            ");
#nullable restore
#line 15 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 19 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.DisplayFor(model => model.Title));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 23 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 27 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.DisplayFor(model => model.IsActive));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n        <dt>\r\n            ");
#nullable restore
#line 31 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.DisplayNameFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dt>\r\n\r\n        <dd>\r\n            ");
#nullable restore
#line 35 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.DisplayFor(model => model.CreateDate));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </dd>\r\n\r\n    </dl>\r\n\r\n");
#nullable restore
#line 40 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
     using (Html.BeginForm()) {
        

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
   Write(Html.AntiForgeryToken());

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"form-actions no-color\">\r\n            <input type=\"submit\" value=\"Delete\" class=\"btn btn-default\" /> |\r\n            ");
#nullable restore
#line 45 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
       Write(Html.ActionLink("Back to List", "Index"));

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n        </div>\r\n");
#nullable restore
#line 47 "D:\WebSiteNews(Core)\WebSiteNews(Core)\Site\Areas\admin\Views\NewsCategories\Delete.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("</div>\r\n");
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
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<Model.NewsCategory> Html { get; private set; }
    }
}
#pragma warning restore 1591
