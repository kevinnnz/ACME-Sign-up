# ACME Activity Sign-up
Please note: Due to time restraints the application currently is not completed. Some features will be unavailable. 

## How to Install

### Back-End Server
Before running make sure to install [ASP.NET Core](https://dotnet.microsoft.com/en-us/download)
Open the folder: `Acme/Acme` and run the command `dotnet restore` from the command line. 

### Front-End Server
Before running make sure you have [NodeJS](https://nodejs.org/en/) installed as well as [Angular CLI](https://angular.io/cli)
Open the folder `AcmeFrontend` in command line. Run `npm install`. Next run `ng serve` for a dev server. Navigate to `http://localhost:4200/`. 

## Technologies Used
* [ASP.NET CORE 6.0](https://docs.microsoft.com/en-us/aspnet/core/release-notes/aspnetcore-6.0?view=aspnetcore-6.0)
* [EntityFramwork](https://docs.microsoft.com/en-us/ef/)
* [Angular](https://angular.io/docs)
* [UIKit](https://getuikit.com/docs/introduction)

## Requirements
The requirements for the project were to use the OCAS tech stack (.NET CORE, EntityFramework, and Angular). 

Users are able to sign-up to an activity and provide their comments. The database model that I ended up going with looks like this: 

[ Employee ] *-------* [ EmployeeActivity ] *-------* [Activity]

The employee model table all the employee information, the activity table holds the name of the activity. They are brought together to the EmployeeActivity table which has a field for comments and a joins the employee to the activity.

