using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Site.ViewModels;


namespace Site.Controllers
{
    public class CategoryController : BaseController
    {
        private readonly Iservice<Category> _service;
        private readonly ICategoryService _categoryService;
        //  private Context db = new Context();
        public CategoryController(Iservice<Category> service,ICategoryService categoryService)
        {
            _service = service;
            _categoryService = categoryService;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CategoryList(int count)
        {
            var model = _service.Get().Take(count).ToList();
            return PartialView("_CategoryList", model);
        }

        public ActionResult LastNewsOfCategory(int newscount, int newstype)
        {
            var query = _categoryService.LastNewsOfCategory(newstype).ToList();
            var model = (from news in query
                         select new NewsOfCategory
                         {
                             Title = news.Key,
                             News = news.OrderByDescending(a=>a.PublishDate).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Take(newscount)
                         }).ToList();



            return PartialView("_ListNewsOfCategory", model);
        }

    }
}