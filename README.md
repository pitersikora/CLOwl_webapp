# Clowl Web App README

Hi! This is Clowl, a project created as a bachelors degree assignment. The application is a simple e-learning platform.
It is written using ASP .Net 5 MVC along with MSSQL database. Feel free to download the source code and check it out.

# Developer environment preparation

## Prerequisites

- Visual Studio 2019 or newer
- SQL Server 2019 Express (minimum)
- SQL Server Management Studio (SSMS) - for convenient UI management

## Steps for deployment

- Open Visual Studio and choose "Clone Repository" option
	- use this URL path https://github.com/pitersikora/CLOwl_webapp.git
	- install .NET 5 and other dependencies that are shown after cloning the repository.

- Open SQL Server Management Studio 
	- on launch before connecting to DB server, copy the "Server name" value for later
	- on SSMS Object Explorer - right mouse click on "Databases" folder and select "New Database"
	- write down your DB name and press ok to create, copy the DB name for later.

- On Visual Studio
	- open `appsettings.json` file and edit the *`"DefaultConnection"`* string so that first two values are your Server name and Database name e.g.
*`"DefaultConnection": "Server=COMPUTER\\SQLEXPRESS;Database=ClowlDB`*
	- go to Tools -> NuGet Package Manager -> Package Manager Console
	- execute `update-database` console command.

After the DB migration procedure is finished you should be able to run development app by running IIS Express on Visual Studio.
