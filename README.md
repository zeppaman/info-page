# info-page
Info page is a library used to add cange log track and show build info inside a web application.

The target of this project is to add a "info page feature" without any condifuration issue.

Simply adding a library from nuget you get a fully working page thar show you:

* Information about Assembly
* Inofrmation about all loaded assembly
* License
* Changelog

##How to configure
Configuration is easy. Step 1 is to add to visual studio project by nuget. You just need to search for InfoPage package and add it to your MVC project.

To complete your installation you need also few others step:

### 1. Add " runAllManagedModulesForAllRequests="true"" to module tag in web.config
After that you should have something like that
<code lan="xml">
...
<system.webServer>
    <modules runAllManagedModulesForAllRequests="true">
      <remove name="FormsAuthentication" />
    </modules>
  </system.webServer>
  ---
</code>

### 2.Place changelog and info files 
InfoPage looks for files to show inside information pages. These file supports Markdown syntax and can be edited during your work. 
Conventiionally these file must be on the root of web application and must be called "info.md","changelog.md", "license.md", but this could be changed by configuration.

See wiki for more details.

