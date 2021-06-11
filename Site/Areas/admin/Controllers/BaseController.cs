using Site.CustomAuthorization;
using Site.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;

namespace Site.Area.admin.Controllers
{
   // [Authorize(Roles = "User")]
    [Area("admin")]
    public class BaseController : Controller
    {
        
        //private readonly ILogger<HomeController> _logger;

        //public BaseController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}
    //    [AllowAnonymous]
    //protected override void OnException(ExceptionContext filterContext)
    //{
    //    var ex = filterContext.Exception;
    //    var message = ex.Message;
    //    var statuscode = 0;
    //    if (filterContext.Exception is HttpException)
    //    {
    //        statuscode = ((HttpException)filterContext.Exception).GetHttpCode();
    //    }
    //    filterContext.ExceptionHandled = true;
    //    var action = filterContext.RequestContext.RouteData.Values["action"];
    //    var controller = filterContext.RequestContext.RouteData.Values["controller"];
    //    System.IO.File.WriteAllText(Server.MapPath("~/Content/errrr3.txt"), message + "  " + action + "  " + controller);
    //    Logger.Error(string.Format("{0} Error in {1} action and {2} controller , Error Code is {3}", message, action, controller, statuscode), ex);
    //    filterContext.Result = new ViewResult()
    //    {
    //        ViewName = "Error",

    //    };
    //}
}
}