using DAL;
using Model;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.AspNetCore.Mvc;
using Site.ViewModels;

namespace Site.Controllers
{
    public class CommentController : BaseController
    {
        private readonly Iservice<Comment> _service;
        private readonly ICommentService _commentService;
        private readonly IUnitOfWork _unitOfWork;



        //  private Context db = new Context();
        public CommentController(Iservice<Comment> service, ICommentService commentService, IUnitOfWork unitOfWork)
        {
            _service = service;
            _commentService = commentService;
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            return View();
        }
         public ActionResult PartialCommet(int newsid)
        {      
            ViewBag.newsid = newsid;
            return PartialView("Comment",new Comment() { NewsId=newsid});
        }
        [HttpPost]
        public string Insert(Comment comment)
        {
            var textresult = "امکان درج پیام وجود ندارد!";
            comment.CreatedDate = DateTime.Now;
            if (ModelState.IsValid)
            {
               
                _service.Insert(comment);
                var result = _unitOfWork.Complete();
                
                if (result == 1)
                {
                    textresult = "پیام شما ارسال شد!";
                }
            }
           
            return JsonConvert.SerializeObject(new { message= textresult });
        }

        public ActionResult ListComment(int newsid)
        {
            return  PartialView("_CommentList", _service.Get(q => q.NewsId == newsid).ToList());
        }

    }
}