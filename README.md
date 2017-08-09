ELMAH.MVC
=========
[![Build status](https://ci.appveyor.com/api/projects/status/b2qui7s4kv3w784u/branch/master?svg=true)](https://ci.appveyor.com/project/issafram/elmah-mvc/branch/master) [![Join the chat at https://gitter.im/alexbeletsky/elmah-mvc](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/alexbeletsky/elmah-mvc?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

For painless integration of ELMAH into ASP.NET MVC application.

What's changed in 2.0 version?
------------------------------

For details, please follow that blog post - [ELMAH.MVC v.2.0 - Release Candidate](http://www.beletsky.net/2012/06/elmahmvc-v200-release-candidate.html)

What's the goal?
-------------------

With ELMAH.MVC you got nice and clear MVC style routing to ELMAH error page. ELMAH can be accessed by:

	http://yourapp.com/elmah

By doing that, you can apply any authorization strategies or routes. In short, no more

	http://yourapp.com/elmah.axd

That could be used for [ASP.NET session hijacking with Google and ELMAH](http://www.troyhunt.com/2012/01/aspnet-session-hijacking-with-google.html).

How to use in my application?
------------------------------

Easy. Install ELMAH by NuGet, in package console

	Install-Package Elmah.MVC

For further ELMAH configuration please check the [documentation](https://code.google.com/p/elmah/).

Should I use HandleErrorAttribute?
----------------------------------

If you tried to use ELMAH in ASP.NET MVC, you are probably implemented your own HandleErrorAttribute, as it's shown in this [example](http://stackoverflow.com/questions/766610/how-to-get-elmah-to-work-with-asp-net-mvc-handleerror-attribute). You no longer need to apply this custom code with Elmah.MVC. As soon you installed package, so can safely remove your HandleError attribute, since it's already included into package.

Will exceptions be logged in "customError='On'" mode?
--------------------------------------------------------

Yes, even if you configured application to use custom error pages, the exception will be logged.

How can I configure Elmah.MVC?
------------------------------

There is a simple configuration section in web.config file.

	<appSettings>
		<add key="elmah.mvc.disableHandler" value="false" />
		<add key="elmah.mvc.disableHandleErrorFilter" value="false" />
		<add key="elmah.mvc.requiresAuthentication" value="false" />
		<add key="elmah.mvc.IgnoreDefaultRoute" value="false" />
		<add key="elmah.mvc.allowedRoles" value="*" />
		<add key="elmah.mvc.allowedUsers" value="*" />
		<add key="elmah.mvc.route" value="elmah" />
		<add key="elmah.mvc.UserAuthCaseSensitive" value="true" />
	</appSettings>

* `elmah.mvc.disableHandler` - turn on/off ELMAH.MVC handler
* `elmah.mvc.disableHandleErrorFilter` - by default `HandleErrorAttribute()` is set as global filter, to disable it, set value to "true"
* `elmah.mvc.requiresAuthentication` - secure /elmah route with authentication
* `elmah.mvc.allowedRoles` - in case of authentication is turned on, you can specify exact roles of user that have access (eg. "Admins")
* `elmah.mvc.allowedUsers` - in case of authentication is turned on, you can specify exact users that have access (eg. "johndoe")
* `elmah.mvc.route` - configure ELMAH.MVC access route

You can either disable handler or apply authentication, based on application roles.

You can also tweek the ELMAH default route. If you just install the package, ELMAH will be availabled at `/elmah`, howether if you would like to change that, change `elmah.mvc.route`, this setting is a MVC route prefix, used during ELMAH routes registration. For instance, if you change that to `secure/admin/errors` you will get ELMAH at `http://yourapp.com/secure/admin/errors`.

Default route issue
-------------------

You might change the `elmah.mvc.route` to a custom one, but still able to see ELMAH reports at `/elmah`. This issue is caused by the way how [ASP.NET MVC matches controllers in separate namespaces](http://www.beletsky.net/2012/07/aspnet-mvc-routes-and-namespaces.html). There are no good workaround for that (at least one I know), so if I makes a trouble to you, I recommend to reconsider the application, without using default route.

**UPDATE**: You might also consider ignoring ``/elmah`` route explicitly as described [here](https://github.com/alexanderbeletsky/elmah.mvc/issues/26).

**UPDATE 2**: [@chaoaretasty](https://github.com/chaoaretasty) has added an option, to allow ignoring default role. Set `elmah.mvc.IgnoreDefaultRoute` setting option to `true`.

Related articles and posts
--------------------------

[ELMAH.MVC 2.0.1 Update is Out](http://www.beletsky.net/2012/08/elmahmvc-201-update-is-out.html)

[ELMAH.MVC v.2.0.0 - Release Candidate](http://www.beletsky.net/2012/06/elmahmvc-v200-release-candidate.html)

[ELMAH.MVC v2.0 is coming](http://www.beletsky.net/2012/06/elmahmvc-v20-is-coming.html)

[Slides of ELMAH.MVC talk](https://speakerdeck.com/alexbeletsky/elmah-and-elmahmvc)

[ELMAH MVC controller released on NuGet](http://www.beletsky.net/2011/08/elmah-mvc-controller-released-on-nuget.html)

[Integrating ELMAH to ASP.NET MVC in right way](http://www.beletsky.net/2011/03/integrating-elmah-to-aspnet-mvc-in.html)

Recent changes
==============

* 30-Apr-2015 - v.2.1.2 Added `UserAuthCaseSensitive` setting by [@issafram](https://github.com/issafram). `IgnoreDefaultRoute` now works for subfolders by [@DavidDeSloovere](https://github.com/DavidDeSloovere).
* 09-Jul-2013 - v.2.1.1 fixes by [@papci](https://github.com/papci)
* 01-Jul-2013 - v.2.1.0 user based authentication by [@papci](https://github.com/papci)
* 02-Jun-2013 - v.2.0.3 ignoring default role by [@chaoaretasty](https://github.com/chaoaretasty)
* 06-Nov-2012 - v.2.0.2 flag to turn on/off default HandleErrorAttribute()
* 16-Aug-2012 - v.2.0.1 custom routes, VB.NET support
* 13-Jun-2012 - v.2.0 major changes, packed to class library, HandleError attribute etc.
* 11-Jan-2012 - minor style changes and readme correction
* 29-Aug-2011 - nuget package created
* 29-Aug-2011 - reimplemented controller to avoid usage of additional routing instructions

Licence
=======

[Apache 2.0](http://www.apache.org/licenses/LICENSE-2.0)
