using DAL;
using Model;
using Newtonsoft.Json;
using Service.Interface;
using System;
using Microsoft.AspNetCore.Mvc;
namespace Site.Controllers
{
    public class NewsLetterController : BaseController
    {
        private readonly Iservice<NewsLetter> _service;
        private readonly INewsLetterService _NewsLetterService;
        private readonly IUnitOfWork _unitOfWork;



        //  private Context db = new Context();
        public NewsLetterController(Iservice<NewsLetter> service, INewsLetterService NewsLetterService, IUnitOfWork unitOfWork)
        {
            _service = service;
            _NewsLetterService = NewsLetterService;
            _unitOfWork = unitOfWork;
        }
        public ActionResult Create(string partialname)
        {
            return PartialView(partialname);
        }


        [HttpPost]
        public string Create(NewsLetter newsletter)
        {
            var textresult = "امکان ثبت خبرنامه نیست!";
            newsletter.CreateDate = DateTime.Now;
            if (ModelState.IsValid)
            {
               
                _service.Insert(newsletter);
                var result = _unitOfWork.Complete();

                if (result == 1)
                {
                    textresult = "خبر نامه ثبت شد!";
                }
            }
            if (newsletter.Email==null)
            {
                ModelState.AddModelError("Email", "ایمیل وارد شود");
            }

            return JsonConvert.SerializeObject(new { message = textresult });

        }

    }
}