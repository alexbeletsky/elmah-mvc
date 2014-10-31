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

using System.Linq;
using System.Security.Principal;
using System.Web.Mvc;
using System.Web.Security;

namespace Elmah.Mvc
{
    [Authorize]
    public class ElmahController : Controller
    {
        public ActionResult Index(string resource)
        {
            /* Adapted by Alexander Beletsky */
            return new ElmahResult();
        }

        public ActionResult Detail(string resource)
        {
            /* Adapted by Alexander Beletsky */
            return new ElmahResult();
        }
        
		/// <summary>
		/// Copies over current authorization to the filtercontext, prior to authorizing access to the Elmah location
		/// </summary>
		/// <param name="filterContext"></param>
		protected override void OnAuthorization(AuthorizationContext filterContext)
		{
			var cookieName = FormsAuthentication.FormsCookieName;

			if (filterContext.HttpContext.User.Identity.IsAuthenticated && filterContext.HttpContext.Request.Cookies != null && filterContext.HttpContext.Request.Cookies[cookieName] != null)
			{
				var authenticationTicket = FormsAuthentication.Decrypt(filterContext.HttpContext.Request.Cookies[cookieName].Value);

				if (authenticationTicket != null)
				{
					var roles = authenticationTicket.UserData.Split('|').Where(r => !string.IsNullOrEmpty(r)).ToArray();

					var userIdentity = new GenericIdentity(authenticationTicket.Name);
					var userPrincipal = new GenericPrincipal(userIdentity, roles);

					filterContext.HttpContext.User = userPrincipal;
				}
			}	
        }
    }
}
