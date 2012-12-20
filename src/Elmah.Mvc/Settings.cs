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
using System.Configuration;

namespace Elmah.Mvc
{
	internal class Settings
	{
		public static string AllowedRoles
		{
			get { return ConfigurationManager.AppSettings["elmah.mvc.allowedRoles"] ?? "*"; }
		}

		public static string Route
		{
			get { return ConfigurationManager.AppSettings["elmah.mvc.route"] ?? "elmah"; }
		}

		public static bool DisableHandleErrorFilter
		{
			get { return GetBoolValue("elmah.mvc.disableHandleErrorFilter", false); }
		}

		public static bool DisableHandler
		{
			get { return GetBoolValue("elmah.mvc.disableHandler", false); }
		}

		public static bool RequiresAuthentication
		{
			get { return GetBoolValue("elmah.mvc.requiresAuthentication", false); }
		}

		private static bool GetBoolValue(string key, bool defaultValue)
		{
			var value = ConfigurationManager.AppSettings[key];
			if (value == null)
				return defaultValue;
			bool returnValue;
			if (!bool.TryParse(value, out returnValue))
				return defaultValue;
			return returnValue;
		}
	}
}