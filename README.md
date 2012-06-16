ELMAH.MVC
=========

For painless integration of ELMAH into ASP.NET MVC application.

What's changed in 2.0 version?
------------------------------

For details, please follow that blog post - [ELMAH.MVC v.2.0 - Release Candidate](http://www.beletsky.net/2012/06/elmahmvc-v200-release-candidate.html)

What's the goal?
-------------------

With ELMAH.MVC you got nice and clear MVC style routing to ELMAH error page. ELMAH can be accessed by:

	http://yourapp/elmah
	
By doing that, you can apply any authorization strategies or routes. In short, no more

	http://yourapp/elmah.axd
	
That could be used for [ASP.NET session hijacking with Google and ELMAH](http://www.troyhunt.com/2012/01/aspnet-session-hijacking-with-google.html).

How to use in my application?
------------------------------

Easy. Install ELMAH by NuGet, in package console

	Install-Package Elmah.MVC

For further ELMAH configuration please check the [documentation](https://code.google.com/p/elmah/).
	
Should I use HandleErrorAttribute?
----------------------------------

If you tried to use ELMAH in ASP.NET MVC, you are probably implemented your own HandleErrorAttribute, as it's shown in this [example](http://stackoverflow.com/questions/766610/how-to-get-elmah-to-work-with-asp-net-mvc-handleerror-attribute). You no longer need to apply this custom code with Elmah.MVC. As soon you installed package, so can safely remove your HandleError attribute, since it's already included into package.

Will exceptions being logged in "customError='On'" mode?
--------------------------------------------------------

Yes, even in you configured application to use custom error pages, the exception will be logged. 
	
How can I configure Elmah.MVC?
------------------------------

There is a simple configuration section in web.config file.

	<appSettings>
		<add key="elmah.mvc.disableHandler" value="false" />
		<add key="elmah.mvc.requiresAuthentication" value="false" />
		<add key="elmah.mvc.allowedRoles" value="*" />
	</appSettings>

You can either disable handler or apply authentication, based on application roles.

Recent changes
==============

* 13-Jun-2012 - v.2.0 major changes, packed to class library, HandleError attribute etc.
* 11-Jan-2012 - minor style changes and readme correction
* 29-Aug-2011 - nuget package created
* 29-Aug-2011 - reimplemented controller to avoid usage of additional routing instructions