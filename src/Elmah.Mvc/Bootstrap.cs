﻿//
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

using System.Web.Mvc;
using System.Web.Routing;

namespace Elmah.Mvc
{
    public class Bootstrap
    {
        public static void Initialize()
        {
            GlobalFilters.Filters.Add(new HandleErrorAttribute());

            /* Adapted by Alexander Beletsky */
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