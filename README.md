Elmah MVC Controller
====================

For headacheless intergration of Elmah into ASP.NET MVC application. For detailed instructions, please check link below.

See, [http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html](http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html)

Test application
================

1. In VS2010 New -> Project -> ASP.NET MVC3 Application
2. Install Elmah by NuGet, in package console - Install-Package elmah
3. Add Admin area for application
4. Create new route to Elmah.
5. Run application and go to /admin/elmah

Code for re-use
===============

[Controller](https://github.com/alexanderbeletsky/elmah.mvc.controller/blob/master/Areas/Admin/Controllers/ElmahController.cs)
[Routing[(https://github.com/alexanderbeletsky/elmah.mvc.controller/blob/master/Areas/Admin/AdminAreaRegistration.cs)