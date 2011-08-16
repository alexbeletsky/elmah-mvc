using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ElmahMvc.Areas.Admin.Controllers {
    class ElmahResult : ActionResult {
        private string _resouceType;

        public ElmahResult(string resouceType) {
            _resouceType = resouceType;
        }

        public override void ExecuteResult(ControllerContext context) {
            var factory = new Elmah.ErrorLogPageFactory();

            if (!string.IsNullOrEmpty(_resouceType)) {
                var pathInfo = "/" + _resouceType;
                System.Web.HttpContext.Current.RewritePath(PathForStylesheet(), pathInfo, System.Web.HttpContext.Current.Request.QueryString.ToString());
            }

            var httpHandler = factory.GetHandler(System.Web.HttpContext.Current, null, null, null);
            httpHandler.ProcessRequest(HttpContext.Current);
        }

        private string PathForStylesheet() {
            return _resouceType != "stylesheet" ? HttpContext.Current.Request.Path.Replace(String.Format("/{0}", _resouceType), string.Empty) : HttpContext.Current.Request.Path;
        }
    }

    public class ElmahController : Controller {
        public ActionResult Index(string type) {
            return new ElmahResult(type);
        }
    }

    public class ElmahDownloadController : AsyncController {
        public void IndexAsync() {
            AsyncManager.OutstandingOperations.Increment();

            var factory = new Elmah.ErrorLogPageFactory();
            System.Web.HttpContext.Current.RewritePath(HttpContext.Request.Path, "/download", HttpContext.Request.QueryString.ToString());
            var httpHandler = (IHttpAsyncHandler)factory.GetHandler(System.Web.HttpContext.Current, null, null, null);

            httpHandler.BeginProcessRequest(System.Web.HttpContext.Current, (r) => {
                AsyncManager.OutstandingOperations.Decrement();
                },
                null);
            
        }

        public ActionResult IndexCompleted() {
            return new EmptyResult();
        }

    }
}
