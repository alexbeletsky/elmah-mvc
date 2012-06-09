[assembly: WebActivator.PreApplicationStartMethod(typeof(Elmah.Mvc.Web.App_Start.ElmahMvc_Start), "Start")]

namespace Elmah.Mvc.Web.App_Start
{
    public class ElmahMvc_Start
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}