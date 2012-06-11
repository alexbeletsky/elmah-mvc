using System.Configuration;
using System.Linq;

namespace Elmah.Mvc
{
    internal class AuthorizeAttribute : System.Web.Mvc.AuthorizeAttribute
    {
        private readonly string[] _allowedRoles;
        private readonly bool _isHandlerDisabled;
        private readonly bool _requiresAuthentication;

        public AuthorizeAttribute()
        {
            var appSettings = ConfigurationManager.AppSettings;
            var allowedRoles = appSettings["elmah.mvc.allowedRoles"] ?? "*";
            _allowedRoles = allowedRoles.Split(',')
                .Where(r => !string.IsNullOrWhiteSpace(r))
                .Select(r => r.Trim())
                .ToArray();
            var isHandlerDisabled = appSettings["elmah.mvc.disableHandler"] ?? "false";
            bool.TryParse(isHandlerDisabled, out _isHandlerDisabled);

            var requiresAuthentication = appSettings["elmah.mvc.requiresAuthentication"] ?? "false";
            bool.TryParse(requiresAuthentication, out _requiresAuthentication);
        }

        protected override bool AuthorizeCore(System.Web.HttpContextBase httpContext)
        {
            return !_isHandlerDisabled
                   && (!_requiresAuthentication
                       || (httpContext.Request.IsAuthenticated
                           && _allowedRoles.Any(r => r == "*" || httpContext.User.IsInRole(r))));
        }
    }
}