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

using System;
using System.Web.Mvc;

namespace Elmah.Mvc
{
    internal class ElmahResult : ActionResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            // try and get the resource from the {resource} part of the route
            var routeDataValues = context.RequestContext.RouteData.Values;
            var resource = routeDataValues["resource"];
            if (resource == null)
            {
                // alternatively, try the {action} 
                var action = routeDataValues["action"].ToString();
                // but only if it is elmah/Detail/{resource}
                if ("Detail".Equals(action, StringComparison.OrdinalIgnoreCase))
                    resource = action;
            }

            var httpContext = context.HttpContext;
            var request = httpContext.Request;
            var currentPath = request.Path;
            var queryString = request.QueryString;
            if (resource != null)
            {
                // make sure that ELMAH knows what the resource is
                var pathInfo = "." + resource;
                // also remove the resource from the path - else it will start chaining
                // e.g. /elmah/detail/detail/stylesheet
                var newPath = currentPath.Remove(currentPath.Length - pathInfo.Length);
                httpContext.RewritePath(newPath, pathInfo, queryString.ToString());
            }
            else
            {
                // we can't have paths such as elmah/ as the ELMAH handler will generate URIs such as elmah//stylesheet
                if (currentPath.EndsWith("/"))
                {
                    var newPath = currentPath.Remove(currentPath.Length - 1);
                    httpContext.RewritePath(newPath, null, queryString.ToString());
                }
            }

            var unwrappedHttpContext = httpContext.ApplicationInstance.Context;
            var handler = new ErrorLogPageFactory().GetHandler(unwrappedHttpContext, null, null, null);
            handler.ProcessRequest(unwrappedHttpContext);
        }
    }
}
