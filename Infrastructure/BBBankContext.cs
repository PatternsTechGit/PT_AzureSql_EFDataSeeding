using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class BBBankContext : DbContext
    {
        public BBBankContext(DbContextOptions<BBBankContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>(b =>
            {
                modelBuilder.Entity<User>(b =>
                {
                    b.HasData(new User
                    {
                        Id = "b6111852-a1e8-4757-9820-70b8c20e1ff0",    // Unique GUID of the User
                        FirstName = "Ali",                              // FirstName
                        LastName = "Taj",                               // LastName
                        Email = "malitaj-dev@outlook.com",              // Email ID
                        ProfilePicUrl = "https://res.cloudinary.com/demo/image/upload/w_400,h_400,c_crop,g_face,r_max/w_200/lady.jpg"   // Profile Image URL

                    });
                });

                b.HasData(new Account
                {
                    // Here Id is a Primary key which acts as a forign key in Transaction class
                    Id = "37846734-172e-4149-8cec-6f43d1eb3f60",
                    AccountNumber = "0001-1001",                // Account Number
                    AccountTitle = "Ali Taj",                   // Account Title
                    CurrentBalance = 3500M,                     // Current Balance
                    AccountStatus = AccountStatus.Active,        // Account status
                    UserId = "b6111852-a1e8-4757-9820-70b8c20e1ff0" // Forign Key of User
                });

                b.HasData(new Account
                {
                    // Here Id is a Primary key which acts as a forign key in Transaction class
                    Id = "2f115781-c0d2-4f98-a70b-0bc4ed01d780",
                    AccountNumber = "0002-2002",                    // Account Number
                    AccountTitle = "Salman Taj",                    // Account Title
                    CurrentBalance = 545M,                          // Current Balance
                    AccountStatus = AccountStatus.Active,           // Account status
                    UserId = "582ebb0b-f9e0-4385-8787-37bd337f18b7" // Forign Key of User

                });
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
        }
    }
}