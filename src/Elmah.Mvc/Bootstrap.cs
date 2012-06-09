using System.Web.Mvc;
using System.Web.Routing;

namespace Elmah.Mvc
{
    public class Bootstrap
    {
        public static void Initialize()
        {
            var namespaces = new[] { "Elmah.Mvc" };
            var routes = RouteTable.Routes;

            routes.MapRoute(
                "Elmah.Mvc",
                "elmah/{resource}",
                new { controller = "Elmah", action = "Index", resource = UrlParameter.Optional },
                null,
                namespaces);

            routes.MapRoute(
                "Elmah.Mvc.Detail",
                "elmah/detail/{resource}",
                new { controller = "Elmah", action = "Detail", resource = UrlParameter.Optional },
                null,
                namespaces);
        }
    }
}
