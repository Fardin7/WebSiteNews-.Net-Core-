using DAL;
using Model;
using Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class HomeController : BaseController
    {
        private readonly Iservice<News> _service;
        public HomeController(Iservice<News> service)
        {
            this._service = service;
        }
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult NotFound()
        {

            return View();
        }
        public ActionResult Error()
        {
            
            return View();
        }
        

    }
}
