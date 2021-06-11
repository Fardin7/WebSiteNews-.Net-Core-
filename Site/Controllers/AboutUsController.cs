using DAL;
using Model;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace Site.Controllers
{
    public class AboutUsController : BaseController
    {

        public ActionResult Index()
        {
            return View();
        }
      
    }
}