# AcmeCorp
AcmeCorp store with a draw/lottery

When the blazor project is turned on, checkout the different pages in on the website. Or test out the swagger interface for the api. 

The project includes:

- 2x class libaries
	+ One for model classes
	+ One is for the serialnumber generator and validator
- 1 asp.net core api
	+ for handling api calls and database context
- 1 asp.net core blazor project
	+ for the website and viewing the data
- 1 msunit test project
	+ for testing the serialnumber validator
## Project Setup Guide
### Prerequisites

- Visual Studio or Visual Studio Code
- .NET SDK
- SQL Server (or SQL Server Express)

### Step 1: Create Database Migration

Open the NuGet Package Manager Console and run the following commands:

`cd AcmeCorp.Web.Api dotnet ef migrations add InitialMigration`

This creates an initial migration based on the model.

### Step 2: Update Database

Run the following command to apply the migration and update the database:

`dotnet ef database update`

This creates the database and applies the migration.

### Step 3: Checkout the Serial Numbers

look at `serialnumbers.txt` file in the `AcmeCorp.Web.Api/Data` folder. This file should contain the initial serial numbers for the draw.

### Step 4: run the unit tests :D