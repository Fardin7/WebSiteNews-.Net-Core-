using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Model;
using Newtonsoft.Json;
using Service.Interface;

namespace Site.Area.admin.Controllers
{
    public class SubcategoriesController : BaseController
    {
        private ISubCategoryService _subcategoryService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly Iservice<Subcategory> _service;
        private readonly ICategoryService _categoryservice;
        private readonly IHostingEnvironment _hostingEnvironment;
        public SubcategoriesController(ISubCategoryService subcategoryService, IUnitOfWork unitOfWork, Iservice<Subcategory> service, ICategoryService categoryservice, IHostingEnvironment hostingEnvironment)
        {
            this._subcategoryService = subcategoryService;
            this._unitOfWork = unitOfWork;
            this._service = service;
            this._categoryservice = categoryservice;
            this._hostingEnvironment = hostingEnvironment;
        }

        // GET: Subcategories
        public ActionResult Index()
        {          
            return View(_subcategoryService.Get());
        }

        // GET: Subcategories/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryservice.Get(), "Id", "Title");
            ViewBag.SubcategoryId = new SelectList(_subcategoryService.Get(), "Id", "Title");

            return View("Create");
        }
        public ActionResult CreatePartial()
        {
            return PartialView("SubCategoryCreatePartial");
            //
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public string Create([Bind("Id,Title,IsActive,ImageAddress,CategoryId,SubcategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<object> subcategorylis = new List<object>();
                    if (subcategory.ImageAddress == null)
                    {
                        subcategory.ImageAddress = "/CategoryImage/CategoryDefaultImage.jpg";
                    }

                    _service.Insert(subcategory);

                    _unitOfWork.Complete();

                    subcategorylis.AddRange(_subcategoryService.Get().Where(q => q.CategoryId == subcategory.CategoryId).Select(z =>
                           new Category
                           {
                               Id = z.Id,
                               Title = z.Title,
                               ImageAddress = z.ImageAddress
                           }

                        ).ToList());
                    return JsonConvert.SerializeObject(subcategorylis, Formatting.Indented);

                }
                catch (Exception ex)
                {

                    return ex.Message;
                }
            }
            return "InvalidForm!";
        }

        // GET: Subcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            Subcategory subcategory = _service.GetByID(id);

            if (subcategory == null)
            {
                return NotFound();
            }

            ViewBag.CategoryId = new SelectList(_categoryservice.Get(), "Id", "Title", subcategory.CategoryId);
            ViewBag.SubcategoryId = new SelectList(_subcategoryService.Get(), "Id", "Title", subcategory.SubcategoryId);
            return View(subcategory);
        }

        //// POST: Subcategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("Id,Title,IsActive,ImageAddress,CategoryId,SubcategoryId")] Subcategory subcategory)
        {
            if (ModelState.IsValid)
            {
                if (subcategory.ImageAddress == null)
                {
                    subcategory.ImageAddress = "/CategoryImage/CategoryDefaultImage.jpg";
                }
                _service.Update(subcategory);
                _unitOfWork.Complete();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(_categoryservice.Get(), "Id", "Title", subcategory.CategoryId);
            ViewBag.SubcategoryId = new SelectList(_subcategoryService.Get(), "Id", "Title", subcategory.SubcategoryId);
            return View(subcategory);
        }

        //// GET: Subcategories/Delete/5
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

                return "ok";

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

                savedAddres = "/SubCategoryImage/" + randomGuid + name;

                savedImage = Path.Combine(webRootPath + "/SubCategoryImage/", randomGuid + name);

                System.IO.FileStream fileStream = System.IO.File.Open(savedImage, System.IO.FileMode.Create);

                fileData.CopyTo(fileStream);

                fileStream.Close();
            }
            return savedAddres;

        }
    }
}
