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
using System.Web.Mvc;

namespace Elmah.Mvc
{
    internal class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] _allowedRoles;
        private readonly bool _isHandlerDisabled;
        private readonly bool _requiresAuthentication;

        public AuthorizeAttribute()
        {
			_allowedRoles = Settings.AllowedRoles.Split(',')
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .Select(r => r.Trim())
                .ToArray();

			_isHandlerDisabled = Settings.DisableHandler;
			_requiresAuthentication = Settings.RequiresAuthentication;
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            var authorizationProviderForElmah =
                DependencyResolver.Current.GetService<IAuthorizerForElmah>();

            if (authorizationProviderForElmah == null)
            {
                return !_isHandlerDisabled
                       && (!_requiresAuthentication
                           || (httpContext.Request.IsAuthenticated
                               && _allowedRoles.Any(r => r == "*" || httpContext.User.IsInRole(r))));
            }

            return authorizationProviderForElmah.IsAuthorizedForElmah(httpContext.User.Identity.Name);
        }
    }
}