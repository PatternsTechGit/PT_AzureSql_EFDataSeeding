# AzureSQL and Data Seeding in Asp.net Core

## What is Entity Framework Core

EF Core can serve as an object-relational mapper (O/RM), which:

* Enables .NET developers to work with a database using .NET objects.
* Eliminates the need for most of the data-access code that typically needs to be written.

## What are the three approaches in Entity Framework?

* The [Database First Approach](https://www.tutorialspoint.com/entity_framework/entity_database_first_approach.htm#:~:text=The%20Database%20First%20Approach%20provides,between%20the%20database%20and%20controller.) creates the entity framework from an existing database. It creates model codes (classes, properties, DbContext etc..) from the database in the project and those classes become the link between the database and controller.

* The [Model First Approach](https://docs.microsoft.com/en-us/ef/ef6/modeling/designer/workflows/model-first#:~:text=Model%20First%20allows%20you%20to,in%20the%20Entity%20Framework%20Designer.) allows you to create a new model using the Entity Framework Designer and then generate a database schema from the model. The model is stored in an EDMX file (.edmx extension) and can be viewed and edited in the Entity Framework Designer.

* The [Code First Approach](https://www.entityframeworktutorial.net/code-first/what-is-code-first.aspx#:~:text=In%20the%20Code%2DFirst%20approach,illustrates%20the%20code%2Dfirst%20approach.) focus on the domain of the application and start creating classes for  domain entity rather than design database. The workflow targets a database that doesn’t exist and Code First will create it.

## About this exercise

Previously we developed a base structure of an api solution in Asp.net core that have just one function which returns data of the last three years total balances against a given AccountID. 
 
![MicrosoftTeams-image (1)](https://user-images.githubusercontent.com/100709775/161592915-395a3983-2efb-459d-ac63-1815249193f7.png)

There are 4 Projects in the solution. 

- **Entities** : That have DB Model Account with one-to-many Transaction and Response Model of LineGraphData that will be returned as API Response. 
- **Infrastructure**: BBBankContext that serves as fake DBContext that populates one Account with three Transactions with hardcoded data. 
- **Services**: That has TranasacionService with the logic of converting Account and its Transactions into LineGraphData after fetching it from BBBankContext. 

- **BBBankAPI**: That has TransactionController which is implementation of ASP.net core’s API, to call Services layer. 

![MicrosoftTeams-image](https://user-images.githubusercontent.com/100709775/161592969-78e99e2b-070f-45a5-a15f-8299364f0554.png)

For more details about this base project See: https://github.com/PatternsTechGit/PT_ServiceOrientedArchitecture 


## In this exercise

 * We will use EF Code first approach to generate Database of a fictitious bank application called BBBank.
 * Applying Data Seeding to the database.

 Here are the steps to begin with 

 ## Step 1: Create Azure SQL

 Open [Azure Portal](https://portal.azure.com/) and go to your subscription.

 Create a new resource and select SQL Database and click create as below 

![1](https://user-images.githubusercontent.com/100709775/161048255-a5a920dd-99b5-4722-affe-c9cd05eec839.PNG)

* Select relevant subscrition
* Select relevant resource group (create new resource group if not exists)
* Enter database name : BBBankDB
* Select relevant server or create a new server
* Click Review + Create

It will create a new Azure SQL database as below :

![2](https://user-images.githubusercontent.com/100709775/161048264-2f677161-a521-4a20-af02-8f7f8d4b4512.PNG)

 ## Step 2: Inherit BBBankContext from Entity Framework core 

 To use `DBContext` install EF Core using the command in Package Manager Console as below 

```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.Design
```

For for migrations run the command as below 

```
Install-Package Microsoft.EntityFrameworkCore.SqlServer
```

BBBankContext will be dependency injected in `Program.cs` so first we will inherit the BBankContext class with DbContext and we will pass options to BBBankContext class constructor

```cs
   public class BBBankContext: DbContext
    {
        public BBBankContext(DbContextOptions<BBBankContext> options) : base(options) { }   
    }

```


 ## Step 3: Creating DbSet

 A [DbSet](https://docs.microsoft.com/en-us/dotnet/api/system.data.entity.dbset-1?view=entity-framework-6.2.0#:~:text=A%20DbSet%20represents%20the%20collection,Set%20method.) represents the collection of all entities in the context, or that can be queried from the database, of a given type. DbSet objects are created from a DbContext using the DbContext.Set method.


Initilize all the Database models with DbSet in `BBBankContext` class

```cs
     public class BBBankContext: DbContext
    {
        public BBBankContext(DbContextOptions<BBBankContext> options) : base(options) { }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
     }
```


 ## Step 4: Data Seeding 

[Data seeding](https://docs.microsoft.com/en-us/ef/core/modeling/data-seeding#:~:text=Data%20seeding%20is%20the%20process,Custom%20initialization%20logic) is the process of populating a database with an initial set of data.

`OnModelCreating` method can be override in your derived context which is used to configure your model. This is the most powerful method of configuration and allows configuration to be specified without modifying your entity classes.


Previously we have set hardcoded data which looks like below

```cs
public class BBBankContext
{
        public BBBankContext()
        {
            this.Accounts = new List<Account>();                // intilizing empty accounts

           // intializing some transactions
            var tomTransactions = new List<Transaction>();
            tomTransactions.Add(new Transaction()
            {
                Id = Guid.NewGuid().ToString(),                 // Auto generating Id
                TransactionAmount = 3000M,                      // Transaction of 3000$
                TransactionDate = DateTime.Now.AddDays(1),      // Tranaction happed yesterday
                TransactionType = TransactionType.Deposit       // ammount was added
            });
            tomTransactions.Add(new Transaction()
            {
                Id = Guid.NewGuid().ToString(),                 // Auto generating Id
                TransactionAmount = -500M,                      // Transaction of 500$
                TransactionDate = DateTime.Now.AddYears(-1),    // Transaction happend one year ago
                TransactionType = TransactionType.Withdraw      // amount was subtracted
            });
            tomTransactions.Add(new Transaction()
            {
                Id = Guid.NewGuid().ToString(),                 // Auto generating Id
                TransactionAmount = 1000M,                      // Transaction of 100$
                TransactionDate = DateTime.Now.AddYears(-2),    // Transaction happend two year ago
                TransactionType = TransactionType.Deposit       // amount was added
            });
            this.Accounts.Add(new Account
            {
                Id = "37846734-172e-4149-8cec-6f43d1eb3f60",    // Unique GUID of the account
                AccountNumber = "0001-1001",                    // Account number
                AccountTitle = "Tom Hanks",                     // Account Title
                CurrentBalance = 3500M,                         // Account balance matches the transaction
                AccountStatus = AccountStatus.Active,           // Account status
                Transactions = tomTransactions                  // associating above transactions with the account
            }); 
        }
        public List<Account> Accounts { get; set; }
        
}

```


In this step we will add an override `OnModelCreating` method in BBBankContext class and initialize the data.

Here we have addded the migration that changes to the data specified with `HasData` are transformed to calls to `InsertData(), UpdateData(), and DeleteData()`.

```cs
 protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //The modelBuilder is being used to construct the model for this context.
            modelBuilder.Entity<Account>(b =>
            {
                b.HasData(new Account
                {
                    // Here Id is a Primary key which acts as a forign key in Transaction class
                    Id = "37846734-172e-4149-8cec-6f43d1eb3f60",            
                    AccountNumber = "0001-1001",                // Account Number
                    AccountTitle = "Raas Masood",               // Account Title
                    CurrentBalance = 3500M,                     // Current Balance
                    AccountStatus = AccountStatus.Active        // Account status

                });

                modelBuilder.Entity<Transaction>().HasData(
                  new
                  {
                      Id = Guid.NewGuid().ToString(),                           // Auto generating Id    
                      AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",       // Here AccountId is a Forign key from linked with Class Account and Id property
                      TransactionAmount = 3000M,                                // Transaction of 3000$
                      TransactionDate = DateTime.Now.AddDays(-1),               // Transaction happend one day ago
                      TransactionType = TransactionType.Deposit                 // Ammount was added    
                  },
                  new
                  {
                      Id = Guid.NewGuid().ToString(),                           // Auto generating Id
                      AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",
                      TransactionAmount = -500M,                                // Transaction of 500$
                      TransactionDate = DateTime.Now.AddYears(-1),              // Transaction happend one year ago
                      TransactionType = TransactionType.Withdraw                // Amount was subtracted

                  },
                  new
                  {
                      Id = Guid.NewGuid().ToString(),                           // Auto generating Id    
                      AccountId = "37846734-172e-4149-8cec-6f43d1eb3f60",       
                      TransactionAmount = 1000M,                                // Transaction of 1000$
                      TransactionDate = DateTime.Now.AddYears(-2),              // Transaction happend two years ago
                      TransactionType = TransactionType.Deposit                 // Ammount was added

                  }
                );
            });
        }
```


## Step 5: Setting up Connection string 

Go to the database from Azure portal and click on link Connection String under settings tab and copy the connectionstring value as below 

![3](https://user-images.githubusercontent.com/100709775/161055681-804d2faf-34ae-43d1-beea-270ba87c3006.PNG)

Go to appsettings.json and add a new section for Connection Strings as below :

```cs
 "ConnectionStrings": {
    "BBBankDBConnString": "Server=tcp:YourBankDB.database.windows.net,1433;Initial Catalog=YourBankDB;Persist Security Info=False;User ID=UserId;Password=UserPassword;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
  }
```

 ## Step 6: Dependency Injecting BBBankContext in Program.cs 

 Open the program.cs and paste the code as below 

 ```cs
var builder = WebApplication.CreateBuilder(args);

// Reading the appsettings.json from current directory.
var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

// Fetching the value BBBankDBConnString from connectionstring section.
var connectionString = configuration.GetConnectionString("BBBankDBConnString");

// Add services to the container.

builder.Services.AddControllers();
///...Dependency Injection settings
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<DbContext, BBBankContext>();

//Adding EF DBContext in the application services using the connectionString fetched above.
//UseLazyLoadingProxies : Lazy loading means that the related data is transparently loaded from the database when the navigation property is accessed.
builder.Services.AddDbContext<BBBankContext>(
b => b.UseSqlServer(connectionString)
.UseLazyLoadingProxies(true)
);
var app = builder.Build();
 ```

 To Resolve UseSqlServer and UseLazyLoadingProxies install the folloiwing nugets in Api project

 ```
Install-Package Microsoft.EntityFrameworkCore

Install-Package Microsoft.EntityFrameworkCore.Design

Install-Package Microsoft.EntityFrameworkCore.SqlServer

Install-Package Microsoft.EntityFrameworkCore.Proxies
 ```

  ## Step 7: Making sure the conenction string is working 

  * Open server explorer right click data connection and select add connection...
  * Select Microsoft SQL Server
  * Enter the credentails and click Test Connection

![4](https://user-images.githubusercontent.com/100709775/161059404-ec8e5d6d-d788-406c-97ae-8bef335471e3.PNG)


  ## Step 8: Resolve IP access error 

  You might get an error because by-default your IP address is blocked, To resolve this error go to the database from Azure portal and click 'Set Server Firewall' as below 

  ![5](https://user-images.githubusercontent.com/100709775/161060394-d2adae0e-504a-42c1-bb90-cbe4521fa3b1.PNG)

  Select the Relevant IP address and click add.


## Step 9 : Setting Virtual keyword

The `virtual` keyword in C# is used to override the base class member in its derived class based on the requirement.

Here we will add virtual keyword to `Transactions` object in Account class and `Account` object in Transaction class as below :

```cs
 public class Transaction : BaseEntity
    {
        public TransactionType TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public decimal TransactionAmount { get; set; }
        public virtual Account Account { get; set; }
    }

     public class Account : BaseEntity
    {
        public string AccountNumber { get; set; }
        public string AccountTitle { get; set; }
        public decimal CurrentBalance { get; set; }
        public AccountStatus AccountStatus { get; set; }
        public virtual ICollection<Transaction> Transactions { get; set; }
    }
```

  ## Step 10: Migrations 

The  [Migration](https://docs.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli) 
 feature in EF Core provides a way to incrementally update the database schema to keep it in sync with the application's data model while preserving existing data in the database.

 open package manage console and select infrastructure project and install the following nugest 

 ```
Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.Relational
 ```

Run the command `Add-Migration` which creates a new migration class as per specified name with the `Up()` and `Down()` methods. The `Up()` method contains code for creating database objects and the `Down()` method contains code for dropping or deleting database objects.

```
Add-Migration FirstMigration
```

Then run the `update-Database` which executes the last migration file created by the Add-Migration command and applies changes to the database schema.

```
Update-Database
```

Verify that the data is present in the database by accessing the table from server explorer as below : 
![11111](https://user-images.githubusercontent.com/100709775/161940859-25a55be4-36b5-4da2-8c89-e4d8b23b3e6a.PNG)

Run the API with URL http://localhost:5070/api/Transaction/GetLastThreeYearsBalancesById/37846734-172e-4149-8cec-6f43d1eb3f60 and see results as below 

![222222](https://user-images.githubusercontent.com/100709775/161940867-5ef6b1b2-1295-4bd2-a13f-86f3bf75915b.png)
