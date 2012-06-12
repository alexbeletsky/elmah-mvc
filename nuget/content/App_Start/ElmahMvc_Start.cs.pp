[assembly: WebActivator.PreApplicationStartMethod(typeof($rootnamespace$.App_Start.ElmahMvc), "Start")]
namespace $rootnamespace$.App_Start
{
    public class ElmahMvc
    {
        public static void Start()
        {
            Elmah.Mvc.Bootstrap.Initialize();
        }
    }
}