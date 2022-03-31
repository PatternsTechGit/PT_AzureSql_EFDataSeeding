# AzureSQL and Data Seeding in Asp.net Core

## What is Entity Framework Core
EF Core can serve as an object-relational mapper (O/RM), which:

* Enables .NET developers to work with a database using .NET objects.
* Eliminates the need for most of the data-access code that typically needs to be written.

## What are the three approaches in Entity Framework?
  
* The [Database First Approach](https://www.tutorialspoint.com/entity_framework/entity_database_first_approach.htm#:~:text=The%20Database%20First%20Approach%20provides,between%20the%20database%20and%20controller.) creates the entity framework from an existing database. It creates model codes (classes, properties, DbContext etc.) from the database in the project and those classes become the link between the database and controller.
  
* The [Model First Approach](https://docs.microsoft.com/en-us/ef/ef6/modeling/designer/workflows/model-first#:~:text=Model%20First%20allows%20you%20to,in%20the%20Entity%20Framework%20Designer.) allows you to create a new model using the Entity Framework Designer and then generate a database schema from the model. The model is stored in an EDMX file (.edmx extension) and can be viewed and edited in the Entity Framework Designer.
  
* The [Code First Approach](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx#:~:text=In%20the%20Code%2DFirst%20approach,illustrates%20the%20code%2Dfirst%20approach.) focus on the domain of the application and start creating classes for  domain entity rather than design database. The workflow targets a database that doesn’t exist and Code First will create it.

## About this exercise

Previously We already has a service oriented architecture base framework in place  which contains  four (4) types of projects 


* API Project : Contains the Controllers of our application
  
* Entities : Contains database models like BaseEntity, Account and Transaction along with repsonse model like LineGraphData
  
* Infrastructure layer: contains the BBBankContextData in which we have initialized database models with the hard coded values 
  
* Services : Maintains the concept of Speration of Concern (SOC) this layer contain the business logic of the application distributes in Services as per their purpose. e.g. TransactionService

To see how this was setup [Click Here](https://github.com/PatternsTechGit/PT_ServiceOrientedArchitecture)

In this exersie
 we will use EF Code first approach to generate  DB of a ficticous bank application called BBBank.

 Here are the steps to begin with 

 <font size="5" color="grey">**Step 1: Create Azure SQL**</font> 

 Open [Azure Portal](https://portal.azure.com/) and go to your subscription.

 Create a new resource and select SQL Database and click create as below 

![1](https://user-images.githubusercontent.com/100709775/161048255-a5a920dd-99b5-4722-affe-c9cd05eec839.PNG)

* Select relevant subscrition
* Select relevant resource group (create new resource group if not exists)
* Enter database name : BBBankDB
* Select relevant server 
* Click Review + Create

It will create a new Azure SQL database as below :

![2](https://user-images.githubusercontent.com/100709775/161048264-2f677161-a521-4a20-af02-8f7f8d4b4512.PNG)

 <font size="5" color="grey">**Step 2: Inherit BBBankContext from Entity Framework core**</font> 

 To use DBContext install EF Core using the command in Package Manager Console as below 

```
Install-Package Microsoft.EntityFrameworkCore.Design
```

For for migrations run the command as below 
```
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

BBBankContext will be dependency injected in `Program.cs` so we have to pass its options to `BBBankContext` class using constructor

```cs
public BBBankContext(DbContextOptions<BBBankContext> options) : base(options) { }

 ```  


 <font size="5" color="grey">**Step 3: Creating DbSet**</font> 

 A [DbSet](https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset-1?view=entity-framework-6.2.0#:~:text=A%20DbSet%20represents%20the%20collection,Set%20method.) represents the collection of all entities in the context, or that can be queried from the database, of a given type. DbSet objects are created from a DbContext using the DbContext.Set method.


Initilize all the Database models with DbSet in `BBBankContext` class

```cs
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
```

