using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using DAL;
using Model;
using Service.Interface;
using Business;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;

namespace Site.Area.admin.Controllers
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
        private readonly IHostingEnvironment _hostingEnvironment;
        public NewsController(Iservice<News> service, INewsService newsService, IUnitOfWork unitOfWork, ICategoryService categoryService,
          ISubCategoryService subCategoryService, INewsCategoryService newscategoryService, INewsSubCategoryService newsSubCategoryService
            , INewsFileService newsFileService, IHostingEnvironment hostingEnvironment)
        {
            this._service = service;
            this._newsService = newsService;
            this._unitOfWork = unitOfWork;
            this._categoryService = categoryService;
            this._subCategoryService = subCategoryService;
            this._newscategoryService = newscategoryService;
            this._newssubCategoryService = newsSubCategoryService;
            _newsFileService = newsFileService;
            this._hostingEnvironment = hostingEnvironment;

        }

        // GET: Articles
        public ActionResult Index()
        {
            var article = _service.Get().ToList();
            return View(article);
        }

        // GET: Articles/Details/5
        public ActionResult Details(string id, int type)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            News article = _newsService.GetByTitleAndType(id, type);
            if (article == null)
            {
                return NotFound();
            }
            return PartialView("_ViewNewsPartial", article);
        }

        // GET: Articles/Create

        public ActionResult Create()
        {
            try
            {
                //FileManagement._fileManagement = null;
                ViewBag.CategoryId = new SelectList(_categoryService.Get(), "Id", "Title");
                ViewBag.NewsCategoryId = new SelectList(_newscategoryService.Get(), "Id", "Title");

            }
            catch (Exception ex)
            {
                return View();
            }

            return View();
        }
        [HttpGet]
        public void GenerateFile(string filename)
        {
            //Response.ContentType = "application/pdf";
            //Response.AppendHeader("Content-Disposition", "attachment; filename=" + filename);
            //Response.TransmitFile(Server.MapPath("~/NewsFiles/" + filename));
            //Response.End();


        }
        public bool DeleteNewsFile(string addressimage,int id)
        {
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;

                var deletedFileAddress = Path.Combine(webRootPath, Path.GetFileName(addressimage));

                System.IO.File.Delete(deletedFileAddress);

                NewsFile article = _newsFileService.GetByID(id);

                _newsFileService.Delete(article);

                _unitOfWork.Complete();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

        public bool DeleteImage(string addressimage)
        {
            try
            {
                string webRootPath = _hostingEnvironment.WebRootPath;

                var deletedFileAddress = Path.Combine(webRootPath, Path.GetFileName(addressimage));

                System.IO.File.Delete(deletedFileAddress);
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }
        [HttpPost]
        public string SaveNewFile(string savedImage)
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

                savedAddres = "/NewsFiles/" + randomGuid + name;

                savedImage = Path.Combine(webRootPath + "/NewsFiles/", randomGuid + name);

                System.IO.FileStream fileStream = System.IO.File.Open(savedImage, System.IO.FileMode.Create);

                fileData.CopyTo(fileStream);

                fileStream.Close();
            }
            return savedAddres;


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

                savedAddres = "/NewsImage/" + randomGuid + name;

                savedImage = Path.Combine(webRootPath + "/NewsImage/", randomGuid + name);

                System.IO.FileStream fileStream = System.IO.File.Open(savedImage, System.IO.FileMode.Create);

                fileData.CopyTo(fileStream);

                fileStream.Close();
            }
            return savedAddres;

        }
        // POST: Articles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public JsonResult Create([Bind("Id,Title,Description,Body,KeyWord,PublishDate,IsActive,ImageAddress,SubcategoryId,NewsType,NewsSubcategoryId,NewsFileAddress")] News news,string NewsFileAddress)
        {
           
            if (news.PublishDate == null)
            {
                news.PublishDate = DateTime.Now;
            }
            if (news.SubcategoryId == 0)
            {

                ModelState.AddModelError("SubcategoryId", "please select subcategory");

            }
            if (news.NewsSubcategoryId == 0)
            {

                ModelState.AddModelError("NewsSubcategoryId", "please select NewsSubcategoryId");

            }
            if (ModelState.IsValid)
            {
                // news.ApplicationUserId = User.Identity.GetUserId();
                if (news.ImageAddress == null)
                {
                    news.ImageAddress = "/NewsImage/DefaultImage.png";
                }
               
                _service.Insert(news);
                _unitOfWork.Complete();

                if (NewsFileAddress != null)
                {
                    string webRootPath = _hostingEnvironment.WebRootPath;
                    FileInfo file = new FileInfo(Path.Combine(webRootPath, "NewsFiles", Path.GetFileName(NewsFileAddress)));
                    NewsFile newsFile = new NewsFile()
                    {
                        Name = Path.GetFileName(NewsFileAddress),
                        Size = (int)file.Length,
                        Type = Path.GetExtension(NewsFileAddress),
                        UploadDate = DateTime.Now,
                        NewsId = news.Id
                    };
                    _newsFileService.Insert(newsFile);
                    _unitOfWork.Complete();
                }
                return Json(new { data = "1" });
            }

            ViewBag.CategoryId = new SelectList(_categoryService.Get(), "Id", "Title");
            ViewBag.NewsCategoryId = new SelectList(_newscategoryService.Get(), "Id", "Title");
            return Json(new { data = "0" });
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new BadRequestResult();
            }
            News news = _newsService.Get(q => q.Id == id, null, "Subcategory.Category,NewsSubCategory.NewsCategory,NewsFiles").FirstOrDefault();
            if (news == null)
            {
                return NotFound();
            }
            ViewBag.CategoryId = new SelectList(_categoryService.Get(), "Id", "Title", news.Subcategory.CategoryId);
            ViewBag.SubcategoryId = new SelectList(_subCategoryService.Get().Where(q => q.CategoryId == news.Subcategory.CategoryId), "Id", "Title", news.SubcategoryId);

            ViewBag.NewsCategoryId = new SelectList(_newscategoryService.Get(), "Id", "Title", news.NewsSubCategory.NewsCategoryId);
            ViewBag.NewsSubcategoryId = new SelectList(_newssubCategoryService.Get().Where(q => q.NewsCategoryId == news.NewsSubCategory.NewsCategoryId), "Id", "Title", news.NewsSubcategoryId);

            return View(news);
        }

        // POST: Articles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        public JsonResult Edit([Bind("Id,Title,Description,Body,KeyWord,PublishDate,IsActive,ImageAddress,SubcategoryId,NewsType,NewsSubcategoryId")] News news,string NewsFileAddress)
        {

            if (ModelState.IsValid)
            {
                if (news.PublishDate == null)
                {
                    news.PublishDate = DateTime.Now;
                }
                // news.ApplicationUserId = User.Identity.;

                if (news.ImageAddress == null)
                {
                    news.ImageAddress = "/NewsImage/DefaultImage.png";
                }
                _service.Update(news); 
                _unitOfWork.Complete();
                var hasfile = false;
                var filename = "";
                News editednews = _newsService.GetByID(news.Id);
                var fileId = 0;
                if (editednews.NewsFiles!=null)
                {
                    hasfile = true;
                    filename = editednews.NewsFiles.FirstOrDefault().Name;
                    fileId = editednews.NewsFiles.FirstOrDefault().Id;
                }               
                return Json(new { data = "1", existfile = hasfile,fileId= fileId, existfilename = filename });
            }

            ViewBag.CategoryId = new SelectList(_categoryService.Get(), "Id", "Title");
            ViewBag.NewsCategoryId = new SelectList(_newscategoryService.Get(), "Id", "Title");
            return Json(new { data = "0" });
        }



        // Get: Articles/Delete/5
        public bool Delete(int id)
        {
            var result = false;
            try
            {
                News article = _newsService.GetByID(id);

                _newsService.Delete(article);

                _unitOfWork.Complete();

                result = true;
            }
            catch (Exception)
            {

                throw new Exception();
            }
            return result;
        }

        public string FillNewsCategory(int id, string categorytype)
        {
            List<object> newsSubCategores = new List<object>();

            string jsonString = "";

            if (categorytype == "NewsSubcategoryId")
            {
                newsSubCategores.AddRange(_newssubCategoryService.Get().Where(q => q.NewsCategoryId == id).Select(z =>
                new NewsSubCategory
                {
                    Id = z.Id,
                    Title = z.Title
                }).ToList());

                jsonString = JsonConvert.SerializeObject(newsSubCategores);
            }
            else
            {
                newsSubCategores.AddRange(_subCategoryService.Get().Where(q => q.CategoryId == id).Select(z =>
                    new Subcategory
                    {
                        Id = z.Id,
                        Title = z.Title
                    }).ToList());

                jsonString = JsonConvert.SerializeObject(newsSubCategores);
            }
            return jsonString;

        }
    }
}
