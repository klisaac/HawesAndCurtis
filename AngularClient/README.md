# Hawes and Curtis LTD task
A sample application built using **ASP.NET Core 5 ** and **Angular 9 **. Boilerplate for **ASP.NET Core reference application** with **Entity Framework Core**, implementing **Clean Architecture** (Core, Application, Infrastructure and Presentation Layers) and **Domain Driven Design** (Entities, Repositories, Domain/Application Services, DTO's...) by applying **SOLID principles**.

Also implements **best practices** like **loosely-coupled, dependency-inverted** architecture and using **design patterns** such as **Dependency Injection**, logging, validation, exception handling and so on.

* CQRS
* MedatR, FluentValidator, AutoMapper
* Swagger
* Use case design
* Unit tests


## Getting Started
Use these instructions to get the project up and running.

### Prerequisites
You will need the following tools:

* [Visual Studio Code or Visual Studio 2019](https://visualstudio.microsoft.com/vs/) (version 16.3 or later)
* [.NET Core SDK 5](https://dotnet.microsoft.com/download/dotnet-core/3.0)
 * [Node.js](https://nodejs.org/en/) (version 10 or later) with npm (version 6.11.3 or later)

### Setup
Follow these steps to get your development environment set up:

  1. Copy the repository

  2. At the root directory, restore required packages by running:
      ```
     dotnet restore
     ```
  3. Ensure the connection strings in the below files point to the local SQL Server instance.
     ```
     appsettings.json, appsettings.Development.json, appsettings.Staging.json & appsettings.Production.json
     ```
  4. Next, build the solution by running:
     ```
     dotnet build
     ```
  5. Next, within the `\HawesAndCurtis\WebApi` directory, launch the back end by running:
     ```
     dotnet run --project "dotnet run --project HawesAndCurtis.Api"
     ```
  6. Once the back end has started, within the `\AngularClient` directory, perform the following commands to install the packages and launch the front end:
      ```
     a) npm install
     b) ng serve -o
     ```
    
  7. Launch [https://localhost:7001/index.html](https://localhost:7001/index.html) in your browser to view the REST API documentation (Swagger UI)

  8. Launch [http://localhost:3000/](http://localhost:3000/) in your browser to view the Angular UI.

## Technologies
* .NET Core 5
* ASP.NET Core 3.1
* Entity Framework Core 3.1.7
* Angular 9

## Versions
The [master](hhttps://github.com/klisaac/) branch is running .NET Core 5. 
