using aspnet;
using Microsoft.AspNetCore.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Create an instance of your Startup class and call its ConfigureServices method
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services);

var app = builder.Build();

// Call the Configure method on your Startup class
startup.Configure(app, app.Environment);

app.Run();
