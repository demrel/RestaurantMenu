using Microsoft.Extensions.FileProviders;
using RestaurantMenu.Application;
using RestaurantMenu.Application.Interfaces;
using RestaurantMenu.Infrastructure;
using RestaurantMenu.Web.DependencyHelpers;
using RestaurantMenu.Web.Services;

var builder = WebApplication.CreateBuilder(args);
var SPACORSSSERVICE = "_ALLOWSPACORS";
// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddApplicationServices().AddInfrastructureServices(builder.Configuration).AddWebServices().AddCorsService(SPACORSSSERVICE);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(SPACORSSSERVICE);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
