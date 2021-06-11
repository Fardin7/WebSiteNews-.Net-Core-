using DAL;
using Microsoft.AspNetCore.Mvc;
using Model;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Site.Area.admin.Controllers
{
    public class SettingController : BaseController
    {

        private readonly Iservice<News> _service;
        private readonly INewsService _newsService;
        private readonly IUnitOfWork _unitOfWork;
        public SettingController(Iservice<News> service, INewsService newsService, IUnitOfWork unitOfWork)
        {
            this._service = service;
            this._newsService = newsService;
            this._unitOfWork = unitOfWork;


        }
        // GET: admin/Setting
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult GetTrendingNews()
        {

            return View("TrendingNews", _service.Get().OrderByDescending(q=>q.PublishDate));

        }

        public ActionResult GetBannerNews()
        {

            return View("BannerNews", _service.Get().OrderByDescending(q => q.PublishDate));

        }
        public string SetTrendingNews(int newsid)
        {
            var news = _service.GetByID(newsid);
            if (news.IsTrend)
            {
                news.IsTrend = false;
            }
            else
            {
                news.IsTrend = true;
                news.TrendingDate = DateTime.Now;
            }
       
            _service.Update(news);
            var result = _unitOfWork.Complete();
            if (result==1)
            {
                return "انجام شد";
            }
            return "خطای رخ داده است";
           
        }
        public string SetTopNews(int newsid)
        {
            var topnews = _service.Get(q => q.IsBanner);
            if (topnews.Count()!=0)
            {
                var news = topnews.FirstOrDefault();
                news.IsBanner = false;
                _service.Update(news);
                _unitOfWork.Complete();
            }
            var selectednews = _service.GetByID(newsid);
            selectednews.IsBanner = true;
            _service.Update(selectednews);

            if (_unitOfWork.Complete()==1)
            {
                return "انجام شد";
            }
            return "خطای رخ داده است";
        }

    }
}