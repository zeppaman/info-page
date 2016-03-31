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

| Property  | Value  | Meaning  |
|-----------|---------|----------|
|  **BaseUrl** |  String | is the url where Info Page Respond. /info is the default value   |
|  **ChangeLogPath** | String  |  the path relative to root application for change log file. This file support markdown syntax  |
|  **LicensePath** |  String |  the path relative to root application for License file. This file support markdown syntax    |
|  **InfoPath** | String  |  the path relative to root application for info about application. This file support markdown syntax    |
|  **ShowInfo** | bool |  By default it is true if Info file is found. Can be edited to force to hide file even if present o show it anyway |
|  **ShowLicense** |  bool |  By default it is true if license file is found. Can be edited to force to hide file even if present o show it anyway |
|  **ShowChangeLog** | bool  |  By default it is true if change file is found. Can be edited to force to hide file even if present o show it anyway |
|  **ApplicationName** | String  | This is the application name. If empty main assembly name will be used.This field has only presentation purpouse  |
|  **ApplicationSubtitle** |  String |  This is a subtitle to show inside info page. If empty main assembly name will be used.This field has only presentation purpouse. Set it as an empty string to hide |

# Override views
This can be done by placing a view inside "views" folder of main MVC application. This view can be copied from repository inside view folder of InfoPage library project [here](https://github.com/zeppaman/info-page/blob/master/InfoPage/Views/home.html). After that you can simply edit the view and alter as You prefer.

##<a name="how-to-use">How to Use</a>
How to use it simply depends on what you need and on how you usually work. InfoPage is a powerfull swissknife that helps you to in many way. Below some tips.

### Keep track of application changes
Yes we know that there is repository to comment you commits, but this menaning of "changes" is more related with stackholders and final user instead of developers. In lot of projects we need to track and let user know what set of changes or new feature are included in running software version. This can be simply achieved introducing InfoPage and keeping track of most important changes inside changelog.md file. In my project's I write a line h2 entry for each iteration and I describe inside what changes was done in iteration. When usefull I also add a bullet list to report all fixes and minor changes. So, after release, final user or stackholder can look what features or fixes have been released.

### Show license
This feature is quite self-explaining. Just create a file called license.md in the root of the appliction and copy inside your license to sho that to the user

### Show info about application
What you place inside info.md will be displayed on info page main page and is something like this readme. There are no written rules about what you can place here and no limits of lenght. In example in an open source project could be some notes about the author and the project.

### Show info about build and assembly
This feature is an out-of-the-box feature very useful to manage multiple enviroments expecially when you are not basing deploy on continuous integration. In practice just browsing infopage path you can see main assembly version and all loaded assembly with version. So, simply looking at that, you can understand if there are some difference between environments or if the code runnind on production is the one you expect.


### How can I integrate it in my application
More convenient way is to place a link somewhere that open infopage path, because this is a "system" page that don't need to be shown to the final user. Alternatively you can override a view loading your css styles and integrate it in your theme, if you need. stadnard view don't use Razor, so if you would use it you need to include Nancy.Razor extension. Keep in mind this is an OWIN application so integration is limited. Main concept behind this library is something easy to integrate as-is, if you need more customization think about integrate InfoPage in your application without using OWIN. Ask me how by opening a issue. Final walkaround to easily integrate InfoPage is to edit view removing all styles and add an iframe in your application that load InfoPage path.

























see wiki for more details
