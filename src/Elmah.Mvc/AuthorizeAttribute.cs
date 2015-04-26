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
    using System;
    using System.Linq;

    internal class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] allowedRoles;
        private readonly string[] allowedUsers;

        private readonly bool isHandlerDisabled;
        private readonly bool requiresAuthentication;

        public AuthorizeAttribute()
        {
            this.allowedRoles = Settings.AllowedRoles.Split(',')
                            .Where(r => !string.IsNullOrWhiteSpace(r))
                            .Select(r => r.Trim())
                            .ToArray();

            this.allowedUsers = Settings.AllowedUsers.Split(',')
                                    .Where(r => !string.IsNullOrWhiteSpace(r))
                                    .Select(r => r.Trim())
                                    .ToArray();

            this.isHandlerDisabled = Settings.DisableHandler;
            this.requiresAuthentication = Settings.RequiresAuthentication;
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return !this.isHandlerDisabled && (!this.requiresAuthentication || this.UserIsAllowed(httpContext));
        }

        /// <summary>
        /// Check that current user is in allowed roles AND in allowed usernames
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowed(System.Web.HttpContextBase httpContext)
        {

            return this.UserIsAllowedByRole(httpContext) && this.UserIsAllowedByName(httpContext);
        }

        /// <summary>
        /// Check that current user is  in allowed roles
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowedByRole(System.Web.HttpContextBase httpContext)
        {
            return httpContext.Request.IsAuthenticated &&
                   (this.allowedRoles.Any(r => r == "*" || httpContext.User.IsInRole(r)));
        }

        /// <summary>
        /// Check that user is in allowed usernames
        /// </summary>
        /// <param name="httpContext"></param>
        /// <returns></returns>
        private bool UserIsAllowedByName(System.Web.HttpContextBase httpContext)
        {
            var stringComparison = Settings.UserAuthCaseSensitive ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;

            return httpContext.Request.IsAuthenticated &&
                  (this.allowedUsers.Any(u => u == "*" || u.Equals(httpContext.User.Identity.Name, stringComparison)));
        }
    }
}