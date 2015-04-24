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
using System.Linq;

namespace Elmah.Mvc
{
    internal class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] _allowedRoles;
        private readonly string[] _allowedUsers;

        private readonly bool _isHandlerDisabled;
        private readonly bool _requiresAuthentication;

        public AuthorizeAttribute()
        {
            _allowedRoles = Settings.AllowedRoles.Split(',')
                            .Where(r => !string.IsNullOrWhiteSpace(r))
                            .Select(r => r.Trim())
                            .ToArray();

            _allowedUsers = Settings.AllowedUsers.Split(',')
                                    .Where(r => !string.IsNullOrWhiteSpace(r))
                                    .Select(r => r.Trim())
                                    .ToArray();

            _isHandlerDisabled = Settings.DisableHandler;
            _requiresAuthentication = Settings.RequiresAuthentication;
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return !_isHandlerDisabled && (!_requiresAuthentication || UserIsAllowed(httpContext));
        }

        /// <summary>
        /// Check that current user is in allowed roles AND in allowed usernames
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowed(System.Web.HttpContextBase httpContext)
        {

            return UserIsAllowedByRole(httpContext) && UserIsAllowedByName(httpContext);
        }

        /// <summary>
        /// Check that current user is  in allowed roles
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowedByRole(System.Web.HttpContextBase httpContext)
        {
            return httpContext.Request.IsAuthenticated &&
                   (_allowedRoles.Any(r => r == "*" || httpContext.User.IsInRole(r)));
        }

        /// <summary>
        /// Check that user is in allowed usernames
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowedByName(System.Web.HttpContextBase httpContext)
        {
            var stringComparison = StringComparison.Ordinal;

            if (!Settings.UserAuthCaseSensitive)
            {
                stringComparison = StringComparison.OrdinalIgnoreCase;
            }

            return httpContext.Request.IsAuthenticated &&
                  (_allowedUsers.Any(u => u == "*" || u.Equals(httpContext.User.Identity.Name, stringComparison)));
        }
    }
}