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

namespace Site.Area.admin.Controllers
{
    public class CategoriesController : BaseController
    {
        private ICategoryService _categoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Iservice<Category> _service;
        private readonly IHostingEnvironment _hostingEnvironment;
        public CategoriesController(ICategoryService categoryService, IUnitOfWork unitOfWork, Iservice<Category> service, IHostingEnvironment hostingEnvironment)
        {
            this._categoryService = categoryService;
            this._unitOfWork = unitOfWork;
            this._service = service;
            this._hostingEnvironment = hostingEnvironment;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_categoryService.Get());
        }

        // GET: Categories/Create
        public ActionResult CreatePartial()
        {
            return PartialView("CategoryCreatePartial");           
        }
        public ActionResult Create()
        {
            return View("Create");           
        }
        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Create([Bind("Title,IsActive,ImageAddress")] Category category)
        {
            if (ModelState.IsValid)
            {
               try
                {

                    List<object> Categores = new List<object>();

                    if (category.ImageAddress == null)
                    {
                        category.ImageAddress = "/CategoryImage/CategoryDefaultImage.jpg";
                    }
                    _service.Insert(category);

                   _unitOfWork.Complete();

                    Categores.AddRange(_categoryService.Get().Select(z =>
                        new Category
                        {
                            Id = z.Id,
                            Title = z.Title,
                            ImageAddress = z.ImageAddress

                        }).OrderByDescending(q=>q.Id).ToList());

                    return JsonConvert.SerializeObject(Categores, Formatting.Indented);
                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            return "InvalidForm!";


        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }

            Category category = _service.GetByID(id);

            if (category == null)
            {
                return NotFound();
            }

            return View(category);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Title,IsActive,ImageAddress")] Category category)
        {
            if (ModelState.IsValid)
            {
                if (category.ImageAddress == null)
                {
                    category.ImageAddress = "/CategoryImage/CategoryDefaultImage.jpg";
                }
                _service.Update(category);

                _unitOfWork.Complete();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        [HttpPost]
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

                List<object> Categores = new List<object>();

                Categores.AddRange(_categoryService.Get().Select(z =>
                    new Category
                    {
                        Id = z.Id,
                        Title = z.Title,
                        ImageAddress = z.ImageAddress

                    }).ToList());

                return JsonConvert.SerializeObject(Categores, Formatting.Indented);
            }
            catch (Exception ex)
            {

                return ex.Message;
            }

        }

        [HttpPost]
        public string SaveImage(string savedImage)
        {
            string savedAddres = "";

            if (Request.Form.Files.Count > 0)
            {
                string webRootPath = _hostingEnvironment.WebRootPath;

                if (savedImage != null)
                {
                    var deletedFileAddress = Path.Combine(webRootPath, Path.GetFileName(savedImage));

                    System.IO.File.Delete(deletedFileAddress);
                }

                var fileData = Request.Form.Files[0];

                var name = Path.GetFileName(fileData.FileName);

                var randomGuid = Guid.NewGuid();

                savedAddres = "/CategoryImage/" + randomGuid + name;

                savedImage = Path.Combine(webRootPath + "/CategoryImage/", randomGuid + name);

                System.IO.FileStream fileStream = System.IO.File.Open(savedImage, System.IO.FileMode.Create);

                fileData.CopyTo(fileStream);

                fileStream.Close();
            }
            return savedAddres;

        }
    }
}
