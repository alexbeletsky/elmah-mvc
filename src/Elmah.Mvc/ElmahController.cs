using System.Web.Mvc;

namespace Elmah.Mvc.Controllers
{
    public class ElmahController : Controller
    {
        public ActionResult Index(string resource)
        {
            return new ElmahResult();
        }

        public ActionResult Detail(string resource)
        {
            return new ElmahResult();
        }
    }
}
