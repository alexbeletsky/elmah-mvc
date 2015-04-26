//
// ELMAH.Mvc
// Copyright (c) 2011 Atif Aziz, James Driscoll. All rights reserved.
//
//  Author(s):
//
//      James Driscoll
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//    http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

namespace Elmah.Mvc
{
    using System.Web.Mvc;
    using System.Web.Routing;

    public class Bootstrap
    {
        public static void Initialize()
        {
	        var disableHandleError = Settings.DisableHandleErrorFilter;
            if (!disableHandleError)
            {
                GlobalFilters.Filters.Add(new HandleErrorAttribute());
            }
            
            var namespaces = new[] { "Elmah.Mvc" };
            var routes = RouteTable.Routes;

			var elmahRoute = Settings.Route;

            routes.MapRoute(
                "Elmah.Mvc",
                string.Format("{0}/{{resource}}", elmahRoute),
                new
                {
                    controller = "Elmah",
                    action = "Index",
                    resource = UrlParameter.Optional
                },
                null,
                namespaces);

            routes.MapRoute(
                "Elmah.Mvc.Detail",
                string.Format("{0}/detail/{{resource}}", elmahRoute),
                new
                    {
                        controller = "Elmah",
                        action = "Detail",
                        resource = UrlParameter.Optional
                    },
                null,
                namespaces);

            if (elmahRoute != "elmah" && Settings.IgnoreDefaultRoute)
            {
                routes.IgnoreRoute("elmah");
                routes.IgnoreRoute("elmah/{*pathinfo}");
                routes.IgnoreRoute("{*elmahinsubfolder}", new { elmahinsubfolder = @".*/elmah(/.*)?" });
            }
        }
    }
}
