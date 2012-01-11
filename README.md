ELMAH MVC Controller
================

For painless integration of ELMAH into ASP.NET MVC application. For detailed instructions, please check link below.

See, [http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html](http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html).

What's the benefit?
-------------------

With ELMAH.MVC you got nice and clear MVC style routing to ELMAH error page. By default, it is being installed into Admin area, so ELMAH can be accessed by:

	http://yourapp/admin/elmah
	
By doing that, you can apply any authorization strategies or routes. In short, no more

	http://yourapp/elmah.axd
	
That could be used for [ASP.NET session hijacking with Google and ELMAH](http://www.troyhunt.com/2012/01/aspnet-session-hijacking-with-google.html).

How to use in my application?
--------------------------------

Easy. Install ELMAH by NuGet, in package console

	Install-Package Elmah.MVC
	
How to got rid of default ELMAH handlers?
---------------------------------------------

Unfortunately, NuGet package could not remove existing AXD handlers, so you have to do it manually. Just open web.config and remove such sections:

	<httpHandlers>
      <add verb="POST,GET,HEAD" path="elmah.axd" type="Elmah.ErrorLogPageFactory, Elmah" />
    </httpHandlers>

And

	<handlers>
      <add name="Elmah" path="elmah.axd" verb="POST,GET,HEAD" type="Elmah.ErrorLogPageFactory, Elmah" preCondition="integratedMode" />
    </handlers>
    
Just see web.config of test application in this repo.

Source code and contribution
============================

You are very welcome to change and improve the code. Please note that once src/Areas/Admin/Controllers/ElmahController.cs is changed, corresponding nuget/content/Areas/Admin/Controllers/ElmahController.cs.pp have to be changed as well.

Recent changes
==============

* 11-Jan-2012 - minor style changes and readme correction
* 29-Aug-2011 - nuget package created
* 29-Aug-2011 - reimplemented controller to avoid usage of additional routing instructions