This program is a web-based application form.

I have chosen ASP.NET Core Web App (utilizing the MVC architectural pattern) in .NET Core 6.
For the front-end, I have employed Razor + Bootstrap to ensure responsiveness.

Within this repository, the following components are included:

A DB folder containing the .bacpac file for the exported database.
A Project folder containing all the source code.
A PublishedProject folder housing the published project.
To run the application:

Adapt the ConnectionString in app.settings.json according to your server.
The database can be created by migrating the project. Just have in mind that some random data will be needed to generate the ReasonsForSigningUp table, everything else will be created automatically.
