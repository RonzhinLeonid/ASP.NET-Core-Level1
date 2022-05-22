using AutoMapper;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using DataLayer;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IEmployeesData, InMemoryEmployeesData>();

var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
var mapper = mapperConfiguration.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddDbContext<ApplicationDataContext>(options =>
{
    options.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=root;Database=WebApi;");
});

var app = builder.Build();

//app.UseHttpsRedirection();

//app.UseAuthorization();

if(app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
