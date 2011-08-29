ELMAH MVC Controller
====================

For painless integration of ELMAH into ASP.NET MVC application. For detailed instructions, please check link below.

See, [http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html](http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html)

Test application
================

1. In VS2010 New -> Project -> ASP.NET MVC3 Application
2. Install ELMAH by NuGet, in package console - Install-Package elmah
3. Add Admin area for application
4. Add ELMAHController.cs to Areas/Admin/Controllers folder.
5. Create new route to ELMAH (see Areas/Admin/AdminAreaRegistration.cs)
6. Run application and go to /admin/elmah

How to use in my application?
=============================

Easy. Install ELMAH by NuGet, in package console

	Install-Package Elmah.MVC

Source code and contribution
============================

You are very welcome to change and improve the code. Please note that once src/Areas/Admin/Controllers/ElmahController.cs is changed, corresponding nuget/content/Areas/Admin/Controllers/ElmahController.cs.pp have to be changed as well.

Recent changes
==============

29-Aug-2011 - nuget package created
29-Aug-2011 - reimplemented controller to avoid usage of additional routing instructions