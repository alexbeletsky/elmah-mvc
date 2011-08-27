Elmah MVC Controller
====================

For headacheless intergration of Elmah into ASP.NET MVC application. For detailed instructions, please check link below.

See, [http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html](http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html)

Test application
================

1. In VS2010 New -> Project -> ASP.NET MVC3 Application
2. Install Elmah by NuGet, in package console - Install-Package elmah
3. Add Admin area for application
4. Add ElmahController.cs to Area/Elmah/Controllers folder.
5. Create new route to Elmah (see Areas/Admin/AdminAreaRegistration.cs)
6. Run application and go to /admin/elmah

How to use in my application?
=============================

Easy. Install Elmah by NuGet, in package console

	Install-Package elmah

It is optional (but preferable) to create new Area called Admin. Inside AreaRegistration.cs your should place routing for ELMAH controller:

    context.MapRoute(
        "Admin_elmah",
        "Admin/elmah/{type}",
        new { action = "Index", controller = "Elmah", type = UrlParameter.Optional }
    );

Copy ElmahController.cs and place to yours Areas/Admin/Controller folder, add file to project. Don't forget to change the namespace according to your project.

Configure ELMAH logging options (Memory, XML, SQL), use Web.Config of this project as example. Run application, and see that:

	/admin/elmah

works. 

Optional (but very preferable) is to secure your controller with Authorize attribute:

	[Authorize(Users = "Admin")]
	public class ElmahController : Controller
	{

That's it.

Code for re-use
===============

[Controller](https://github.com/alexanderbeletsky/elmah.mvc.controller/blob/master/Areas/Admin/Controllers/ElmahController.cs),
[Routing] (https://github.com/alexanderbeletsky/elmah.mvc.controller/blob/master/Areas/Admin/AdminAreaRegistration.cs)