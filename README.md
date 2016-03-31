# InfoPage: Info Page for MVC sites
Info page is a library used to add cange log track and show build info inside a web application. The target of this project is to add a "info page feature" without any condiguration issue.

If you can't image it, think about "php info" and add to it the capability to manage application changes and info (license,info, build number...).

Simply adding a library from nuget you get a fully working page thar show you:

* Information about Assembly
* Inofrmation about all loaded assembly
* License
* Changelog

##Info page tutorial summary
1. [How to install](#how-to-install)
2. [How to configure](#how-to-configure)
3. [How to use](#how-to-use)

##<a name="how-to-install">How to install & configure</a>
Configuration is easy. Step 1 is to add to visual studio project by nuget. You just need to search for InfoPage package and add it to your MVC project.

To complete your installation you need also few others step:

### 1. Add " runAllManagedModulesForAllRequests="true"" to module tag in web.config
After that you should have something like that
```xml
...
<system.webServer>
    <modules runAllManagedModulesForAllRequests="true">
      <remove name="FormsAuthentication" />
    </modules>
  </system.webServer>
  ---
```

### 2.Edit startup file
You have to configure infopage in a startup owin module, after adding InfoPage from nuget you should have startup.cs and you should fix as below:
```cs
using InfoPage.Configuration;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InfoPage.WebTest.Startup))]
namespace InfoPage.WebTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            InfoPageConfigurator.Configure(app, 
                x => {
                    x.BaseUrl = "custom-info";
                    x.ApplicationName = "My Sample Application";
                });
        }
    }
}

```


### 3.Place changelog and info files and start to use it during developement
InfoPage looks for files to show inside information pages. These file supports Markdown syntax and can be edited during your work. 
Conventiionally these file must be on the root of web application and must be called "info.md","changelog.md", "license.md", but this could be changed by configuration.


##<a name="how-to-configure">How to configure</a>


### Settings 
You can customize InfoPage behaviour settings configuration. All property of   InfoPageConfiguration.cs can be changed by user.
| property  | Values  | Meaning  |
|---|---|---|
|  BaseUrl |  String | is the url where Info Page Respond. /info is the default value   |
|  ChangeLogPath | String  |  the path relative to root application for change log file. This file support markdown syntax  |
|  LicensePath |  String |  the path relative to root application for License file. This file support markdown syntax    |
|  InfoPath | String  |  the path relative to root application for info about application. This file support markdown syntax    |
|  ShowInfo | bool |  By default it is true if Info file is found. Can be edited to force to hide file even if present o show it anyway |
|  ShowLicense |  bool |  By default it is true if license file is found. Can be edited to force to hide file even if present o show it anyway |
|  ShowChangeLog | bool  |  By default it is true if change file is found. Can be edited to force to hide file even if present o show it anyway |
|  ApplicationName | String  | This is the application name. If empty main assembly name will be used.This field has only presentation purpouse  |
|  ApplicationSubtitle |  String |  This is a subtitle to show inside info page. If empty main assembly name will be used.This field has only presentation purpouse. Set it as an empty string to hide |

# Override views


##<a name="how-to-use">How to Use</a>

























see wiki for more details
