using System.Web;
using System.Web.Mvc;

namespace BLL
{
    public class SessionTimeOut : ActionFilterAttribute 
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                HttpContext ctx = HttpContext.Current;
                if (HttpContext.Current.Session["idAdmin"] == null)
                {
                    filterContext.Result = new RedirectResult("~/Home/Login");
                    return;
                }
                base.OnActionExecuting(filterContext);
            }
        }
}