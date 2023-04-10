using ColoursAPITest.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddLogging();
builder.Services.AddDatabaseDeveloperPageExceptionFilter();


ConfigurationManager configuration = builder.Configuration;

//var server = configuration["DBServer"] ?? "ms-sql-server";
//var port = configuration["DBPort"] ?? "1443";
//var user = configuration["DBUser"] ?? "SA";
//var password = configuration["DBPassword"] ?? "Pa55w0rd2023";
//var database = configuration["Database"] ?? "ColoursDb";

//builder.Services.AddDbContext<ColourContext>(options =>
//    options.UseSqlServer($"Server={server},{port};Initial Catalog={database};" +
//    $"User ID={user};Password={password}"));

//builder.Services.AddDbContext<ColourContext>(options =>
//                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddDbContext<ColourContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DockerConnection")));

//builder.Services.AddMvc();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseRouting();
app.MapControllers();
app.Run();