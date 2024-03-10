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
	
When running the project for the first time, itll generate the serial numbers and save them in the database. And a copy in AcmeCorp.Web.Api/Data in a txt file to easily test and debug. Itll also save some products in the data base. To see see what is generated check out AcmeCorp.Web.Api/Data/AcmeCorpApiSeeder.cs


## Idea for the project
I found the company from the Road Runner series, and thought they would make a good subject for a new test website. 
The site needed to be able to send a serial number to enter a draw. Which i took some inspiration from the taiwan lottery system, where reciepts have a "Lottery Number".
![picture1](https://github.com/FaNzu/AcmeCorp/blob/main/taiwan_receipt.webp)

## Project Setup Guide
### Prerequisites

- Visual Studio or Visual Studio Code
- .NET SDK
- SQL Server (or SQL Server Express)

### Step 1: Open NuGet Package Manager Console

![picture1](https://github.com/FaNzu/AcmeCorp/blob/main/READMEPicture1.PNG)
Open the NuGet Package Manager Console and run the following commands:

### Step 2: Update Database
Run the following command to apply the migration and update the database:

> Make sure the project applying too is the AcmeCorp.Web.Api project.
![image](https://github.com/FaNzu/AcmeCorp/blob/main/READMEPicture2.PNG)

Command: `Update-Database`

This creates the database and applies the migration.

### Step 3: Start the right projects
In the top, click on the drop down menu at the START button. And select the configure startup projects.
![image](https://github.com/FaNzu/AcmeCorp/blob/main/READMEPicture3.PNG)

and click on multiple startup projects, and start both 'AcmeCorp.Web.Api' and 'AcmeCorp.Web.Blazor'. click apply and ok

### Step 5: Start the projects!

### Step 4: Checkout the Serial Numbers

look at `serialnumbers.txt` file in the `AcmeCorp.Web.Api/Data` folder. This file should contain the initial serial numbers for the draw.

### Step 5: run the unit tests :D
