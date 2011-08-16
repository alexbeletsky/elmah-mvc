using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElmahMvc.Areas.Admin.Controllers
{
    class ElmahResult : ActionResult
    {
        private string _resouceType;

        public ElmahResult(string resouceType)
        {
            _resouceType = resouceType;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            var factory = new Elmah.ErrorLogPageFactory();
            if (!string.IsNullOrEmpty(_resouceType))
            {
                var pathInfo = "." + _resouceType;
                HttpContext.Current.RewritePath(_resouceType != "stylesheet"
                        ? HttpContext.Current.Request.Path.Replace(String.Format("/{0}", _resouceType), string.Empty)
                        : HttpContext.Current.Request.Path, pathInfo, HttpContext.Current.Request.QueryString.ToString());
            }

            var handler = factory.GetHandler(HttpContext.Current, null, null, null);

            handler.ProcessRequest(HttpContext.Current);
        }
    }

    public class ElmahController : Controller
    {
        public ActionResult Index(string type)
        {
            return new ElmahResult(type);
        }

        public ActionResult Detail(string type)
        {
            return new ElmahResult(type);
        }
    }
}
