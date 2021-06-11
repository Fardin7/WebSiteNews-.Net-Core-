using Site.CustomAuthorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace Site.Controllers
{

    public class BaseController : Controller
    {
        //private static readonly ILog Logger = LogManager.GetLogger(System.Environment.MachineName);

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
            
        //    base.OnActionExecuting(filterContext);
        //}

        //protected override void OnActionExecuting(ActionExecutingContext filterContext)
        //{


        //    Thread.CurrentThread.CurrentUICulture = new CultureInfo("fa-IR");
        //    base.OnActionExecuting(filterContext);

        //}
        //protected override void ExecuteCore()
        //{


        //    base.ExecuteCore();
        //}

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
        //    Logger.Error(string.Format("{0} Error in {1} action and {2} controller , Error Code is {3}", message, action, controller, statuscode), ex);
        //    // Response.Redirect("/Home/Error");
        //    filterContext.Result = new ViewResult()
        //    {
        //        ViewName = "Error",

        //    };
        //}
    }
}