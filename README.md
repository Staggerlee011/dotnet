# dotnet

this is a test repo for me to play around .net core 3. 

Basic config: 

- code is .net core 3 based on a mvc project 
- build and release is done via azure devops piplines 
- hosting is done via azure msdn windows azure apps with letsencrypt for ssl for both dev and production

## security headers

adding security headers can be completed by the below steps:

- Add nuget package: NWebsec.AspNetCore.Middleware
- Add securityheadersattribute.cs
- Add securityheadersmiddleware.cs
- update startup.cs to contain: app.UseSecurityHeaders();

## configuration settings

Updated code to use dev.sjb.ninja index text and navbar color be different.

- Updated appsettings.json / development.appsettings.json with environment variables.
- added same variables to azure web apps
- updated HomeController to add configuration and ViewData settings

