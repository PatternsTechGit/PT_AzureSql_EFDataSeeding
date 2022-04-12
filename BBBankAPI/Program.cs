using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Services;
using Services.Contracts;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();

var connectionString = configuration.GetConnectionString("BBBankDBConnString");

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<DbContext, BBBankContext>();

builder.Services.AddDbContext<BBBankContext>(
b => b.UseSqlServer(connectionString)
.UseLazyLoadingProxies(true)
);
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseAuthorization();

app.MapControllers();

app.Run();
