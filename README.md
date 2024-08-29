## Assessment

Introduction
The purpose of this assignment is to evaluate the candidate’s familiarity with .NET technologies, programming patterns and to showcase a sample of what clean and reusable code means to the candidate. This is also helps in understanding the candidate’s basic design knowledge.
Requirements
You need to create an ASP.NET web api application to expose the information provided by this api http://www.tvmaze.com/api
Requirement 1
Implement a job to store in a database the information provided by the endpoint “Shows main information”. Storing information with https://api.tvmaze.com/shows will be enough, but keep in mind that this data can change during the course of time. 
Requirement 2
Expose and endpoint to execute the job when will be need and securize it using an api key.
Requirement 3
Expose a public endpoint to query the information stored in the database.
Architecture
There is no limit for this. Design your application as you wish, but make sure you will focus on clean code, reusability and .NET best practices. Show us that you know how to produce top notch applications.
Notes
-	Complete this assignment using .NET Framework or .NET Core and the C# language version binded to .NET versión used.
-	Try to keep the leverage/use of scaffolding tools, boilerplate templates, plugins etc. to a minimum. We don’t expect you to create things from scratch but, we also would like to see your own creation.
-	Create a readme file that explains your architectural decisions and make sure you include instructions on how to run your solution.
-	It’s mandatory to include unit tests (use the framework that you want).
-	Feel free to include more features other than the few mentioned above.

## Architecture

The architecture of the project is based on the Clean Architecture, which is a software design philosophy that separates the elements of a software system into distinct layers that are independent of each other. The main goal of this architecture is to make the software more testable, maintainable, and flexible.

## How to run the app

You'll need:
* Docker
* Docker-compose
* .NET and Visual Studio or your preferred IDE for .NET.

You can run the application with Docker-compose or with your IDE. In both cases the database will be automatically migrated on first execution.

**Option A)** Just docker-compose:

In the root of the repo run:
```
docker-compose up
```
The application will be running in http://localhost:8001/. Access the API docs in http://localhost:8001/swagger.

**Option B)** Your IDE:

Get a SQL Server DB ready by running:
```
docker-compose up aap_local_db
```
Then you can run the alten-assessment-project.API project using your IDE.
