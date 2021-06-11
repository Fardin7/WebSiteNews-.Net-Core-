using Model;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Site.ViewModels;
using Site.Helper;
namespace Site.Controllers
{
    public class NewsCategoryController : BaseController
    {
        private readonly Iservice<NewsCategory> _service;
        private readonly INewsService _newsService;
        private readonly INewsCategoryService _newscategoryService;
        private readonly INewsSubCategoryService _newssubCategoryService;
        private readonly INewsFileService _newsFileService;
        public NewsCategoryController(Iservice<NewsCategory> service, INewsService newsService, ICategoryService categoryService,
          ISubCategoryService subCategoryService, INewsCategoryService newscategoryService, INewsSubCategoryService newsSubCategoryService
            , INewsFileService newsFileService)
        {
            _newscategoryService = newscategoryService;
            _newsService = newsService;
            _service = service;
        }
        // GET: NewsCategory
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IndexPartial(string partialname,int newstype)
        {
            ViewBag.newstype = newstype;
            var model = _service.Get();
            return PartialView(partialname, model);
        }

        // GET: NewsCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult LastNewsOfNewsCategory(int newscount, int newstype)
        {
            var query = _newscategoryService.LastNewsOfNewsCategory(newstype);
            var model = (from news in query
                         select new NewsOfNewsCategory
                         {
                             Title = news.Key,
                             News = news.OrderByDescending(a => a.PublishDate).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Take(newscount).ToList()
                         }).ToList();



            return PartialView("_ListNewsOfNewsCategory", model);
        }

        public ActionResult IndexNewsOfNewsCategory(int newscount, string type)
        {
   
            var typeint = (int)Enum.Parse(typeof(NewsType), CultureHelper.EnumLocalizeValueToName(type, Thread.CurrentThread.CurrentUICulture));
            var query = _newscategoryService.LastNewsOfNewsCategory(typeint);
            var model = (from news in query
                         select new NewsOfNewsCategory
                         {
                             Title = news.Key,
                             News = news.OrderByDescending(a => a.PublishDate).Where(q=>q.PublishDate<=DateTime.Now && q.IsActive).Take(newscount).ToList()
                         }).ToList();

            

            return View(model);
        }
        public string PagingNewsOfNewsCategory(int newscount, int pagenumber, int type, int newscategory)
        {
            var urltype = CultureHelper.EnumLocalize(Enum.GetName(typeof(NewsType), type), Thread.CurrentThread.CurrentUICulture);

            var newscategorytitle = _service.Get(q => q.Id == newscategory).FirstOrDefault().Title;
            var skipnews = newscount * (pagenumber - 1);
            var takenews = newscount * pagenumber;
            var query = _newscategoryService.LastNewsOfNewsCategory(type);
            var model = (from news in query
                         where news.Key == newscategorytitle

                         select new NewsOfNewsCategory
                         {

                             News = news.OrderByDescending(q => q.PublishDate).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Take(takenews).Skip(skipnews).ToList(),

                         }).ToList().FirstOrDefault();


            var list = new List<LastNews>();
            for (int i = 0; i < model.News.Count; i++)
            {
                list.Add(new LastNews()
                {
                    Title = model.News[i].Title,
                    ImageAddress = model.News[i].ImageAddress,
                    Description = model.News[i].Description,
                    Url = Url.RouteUrl("news", new { type = type, cattegory = model.News[i].Subcategory.Title, newscattegory = model.News[i].NewsSubCategory.NewsCategory.Title, id = model.News[i].Title })


                });
            }
            return JsonConvert.SerializeObject(list);
        }

        public ActionResult ViewPaging(int newstype, int newscategory)
        {
            var count = _newsService.Get(q => q.NewsType == newstype && q.NewsSubCategory.NewsCategoryId == newscategory && q.PublishDate <= DateTime.Now && q.IsActive).Count();

            return Json(new { pages = Math.Ceiling((double)count / 4), newstype = newstype, newscategory = newscategory });

        }

    }
}
