Imports Elmah.Mvc.Bootstrap

<Assembly: WebActivator.PreApplicationStartMethod(GetType(Elmah.Mvc.Web.App_Start.ElmahMvc_Start), "Start")> 

Namespace Elmah.Mvc.Web.App_Start
    Public Class ElmahMvc_Start
        Public Shared Sub Start()
            Bootstrap.Initialize()
        End Sub
    End Class
End Namespace
