using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using DAL;
using Model;
using Service.Interface;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;

namespace Site.Area.admin.Controllers
{
    public class NewsCategoriesController : BaseController
    {
        private INewsCategoryService _newscategoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Iservice<NewsCategory> _service;
        public NewsCategoriesController(INewsCategoryService newscategoryService, IUnitOfWork unitOfWork, Iservice<NewsCategory> service)
        {
            this._newscategoryService = newscategoryService;
            this._unitOfWork = unitOfWork;
            this._service = service;
        }


        // GET: Categories
        public ActionResult Index()
        {
            return View(_newscategoryService.Get());
        }

        // GET: NewsCategories/Create
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult CreatePartial()
        {
            return PartialView("NewsCategoryCreatePartial");
        }

        // POST: NewsCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<string> Create([Bind("Id,Title,IsActive,CreateDate,")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<object> newsCategores = new List<object>();

                    _service.Insert(newsCategory);

                   await _unitOfWork.CompleteAsync();

                    newsCategores.AddRange(_newscategoryService.Get().Select(z =>
                        new Category
                        {
                            Id = z.Id,
                            Title = z.Title
                        }).ToList());

                    return JsonConvert.SerializeObject(newsCategores, Formatting.Indented);

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }

            return "InvalidForm!";
        }

        // GET: NewsCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            NewsCategory newsCategory = _service.GetByID(id);

            if (newsCategory == null)
            {
                return NotFound();
            }
            return View(newsCategory);
        }

        // POST: NewsCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Title,IsActive,CreateDate")] NewsCategory newsCategory)
        {
            if (ModelState.IsValid)
            {
                _service.Update(newsCategory);

                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            return View(newsCategory);
        }

        // GET: NewsCategories/Delete/5
        public string Delete(int? id)
        {
            if (id == null)
            {
                return "NotNullable Id";
            }
            try
            {
                _service.Delete(id);

                _unitOfWork.Complete();

                return "ok";

            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }
    }
}
