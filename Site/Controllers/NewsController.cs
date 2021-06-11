using DAL;
using Model;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Site.ViewModels;
using Site.Helper;
namespace Site.Controllers
{
    public class NewsController : BaseController
    {

        private readonly Iservice<News> _service;
        private readonly INewsService _newsService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICategoryService _categoryService;
        private readonly ISubCategoryService _subCategoryService;
        private readonly INewsCategoryService _newscategoryService;
        private readonly INewsSubCategoryService _newssubCategoryService;
        private readonly INewsFileService _newsFileService;
        //  private Context db = new Context();
        public NewsController(Iservice<News> service, INewsService newsService, IUnitOfWork unitOfWork, ICategoryService categoryService,
          ISubCategoryService subCategoryService, INewsCategoryService newscategoryService, INewsSubCategoryService newsSubCategoryService
            , INewsFileService newsFileService)
        {
            this._service = service;
            this._newsService = newsService;
            this._unitOfWork = unitOfWork;
            this._categoryService = categoryService;
            this._subCategoryService = subCategoryService;
            this._newscategoryService = newscategoryService;
            this._newssubCategoryService = newsSubCategoryService;
            _newsFileService = newsFileService;
        }
        // GET: user/News
        public  ActionResult Index(int type, string categoryname, string newscategoryname)
        {
            
           
            var newscategoryid = 0;
            var categoryid = 0;
            if (newscategoryname!=null)
            {
                newscategoryid= _newscategoryService.Get(q => q.Title == newscategoryname).FirstOrDefault().Id;

            }
            if (categoryname!=null)
            {
                categoryid= _categoryService.Get(q => q.Title == categoryname).FirstOrDefault().Id;

            }

            //  Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("fa-IR");
            var newstype = type;
                //(int)Enum.Parse(typeof(NewsType), CultureHelper.EnumLocalizeValueToName(type, Thread.CurrentThread.CurrentUICulture));

            var model = _newsService.ListNewsOfNewsCategoryAndCategory(newstype, categoryname, newscategoryname, 4);
            double pagecount = _service.Get(q => q.NewsSubCategory.NewsCategory.Title == newscategoryname || q.Subcategory.Category.Title == categoryname).Where(q => q.NewsType == newstype && q.IsActive && q.PublishDate <= DateTime.Now).Count();
            pagecount = Math.Ceiling(pagecount / 4);
            var newslist = new List<NewsIndexPaging>();
            foreach (var item in model)
            {
                newslist.Add(new NewsIndexPaging()
                {
                    NewsType = newstype,
                    Category = categoryid,
                    NewsCategory = newscategoryid,
                    Description = item.Description,
                    ImageAddress = item.ImageAddress,
                    PublishDate = item.PublishDate.Value,
                    NewsCategoryTitle=item.NewsSubCategory.NewsCategory.Title,
                    SubCategoryTitle=item.Subcategory.Title,
                    PageNumber=3,
                    Pages = pagecount,
                    Title = item.Title,
                    Url = Url.RouteUrl("news", new { type = type, cattegory = item.Subcategory.Title, newscattegory = item.NewsSubCategory.NewsCategory.Title, id = item.Title })



                });
            }
            return View(newslist);
        }
        public ActionResult IndexPartial(int type, string categoryname, string newscategoryname, string partialname, int count)
        {


            var model = _newsService.ListNewsOfNewsCategoryAndCategory(type, categoryname, newscategoryname, count);
            double pagecount = _service.Get(q => q.NewsSubCategory.NewsCategory.Title == newscategoryname && q.Subcategory.Title == categoryname && q.NewsType == type && q.IsActive && q.PublishDate<=DateTime.Now).Count();
            pagecount = Math.Ceiling((double)pagecount / count);

            ViewBag.pagecount = pagecount;
            return PartialView(partialname, model);
        }

        public string NewsOfNewsCategoryAndCategoryPaging(int type, int categoryname, int newscategoryname, int count, int pagenumber)
        {         
            var model = _newsService.RelatedNewsPagin(type, categoryname, newscategoryname, count, pagenumber);
            var news = new List<NewsIndexPaging>();
            foreach (var item in model)
            {
                news.Add(new NewsIndexPaging()
                {
          
                    Description = item.Description,
                    ImageAddress = item.ImageAddress,
                    PublishDate = item.PublishDate,
                    NewsCategoryTitle = item.NewsSubCategory.NewsCategory.Title,
                    SubCategoryTitle = item.Subcategory.Title,
                    PageNumber = 3,
                
                    Title = item.Title,
                    Url = Url.RouteUrl("news", new { type = type, cattegory = item.Subcategory.Title, newscattegory = item.NewsSubCategory.NewsCategory.Title, id = item.Title })



                });;
            }
            return JsonConvert.SerializeObject(news);
        }

        // GET: user/News/Details/5
        public ActionResult Details(string id, int type)
        {
            
            var typeint = type;
                //(int)Enum.Parse(typeof(NewsType), CultureHelper.EnumLocalizeValueToName(type, Thread.CurrentThread.CurrentUICulture));
            return View(_newsService.GetByTitleAndType(id, typeint));

        }
        public ActionResult LastNews(int newscount, int newstype, string partialname)
        {

            var model = _service.Get(q => q.NewsType == newstype).OrderByDescending(q => q.PublishDate).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Take(newscount).ToList();

            return PartialView(partialname, model);
        }

        public ActionResult NewsPagingView(int newstype)
        {
            var count = _service.Get(q => q.NewsType == newstype).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Count();

            return PartialView("_newspaging", Math.Ceiling((double)count / 4));
        }

        public string NewsPaging(int newscount, int pagenumber, int newstype)
        {
            var newstypename = CultureHelper.EnumLocalize(Enum.GetName(typeof(NewsType), newstype), Thread.CurrentThread.CurrentUICulture);

            var model = _service.Get(q => q.NewsType == newstype).OrderByDescending(q => q.PublishDate).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Take(newscount * pagenumber).Skip(newscount * (pagenumber - 1)).ToList();
            var list = new List<LastNews>();
            foreach (var item in model)
            {

                list.Add(new LastNews()
                {
                    Title = item.Title,
                    ImageAddress = item.ImageAddress,
                    Url = Url.RouteUrl("news", new { type = newstypename, cattegory = item.Subcategory.Title, newscattegory = item.NewsSubCategory.NewsCategory.Title, id = item.Title })


                });
            }
            string articls = JsonConvert.SerializeObject(list);
            return articls;
        }

        public ActionResult TrendingNews(int count)
        {
            return  PartialView("_TrendNews", _service.Get(q => q.IsTrend == true).OrderByDescending(q => q.TrendingDate).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).Take(count).ToList());
        }
        public ActionResult BannerNews()
        {
            return PartialView("_BannerNews", _service.Get(q => q.IsBanner == true).Where(q => q.PublishDate <= DateTime.Now && q.IsActive).FirstOrDefault());
        }
    }
}
