using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Web;

using Elmah.Mvc;

[assembly: AssemblyTitle("Elmah.Mvc")]
[assembly: AssemblyDescription("ELMAH adapter to ASP.NET MVC applications")]
[assembly: ComVisible(false)]
[assembly: Guid("486b1d8e-c145-43e3-978e-424000f57942")]
[assembly: InternalsVisibleTo("Elmah.Mvc.Tests")]
[assembly: PreApplicationStartMethod(typeof(Bootstrap), "Initialize")]