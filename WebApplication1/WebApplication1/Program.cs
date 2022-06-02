using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebStore.DAL.Context;
using WebApplication1.Data;
using WebApplication1.Services;
using WebApplication1.Services.Interfaces;
//using WebApplication1.Services.InMemory;
using WebApplication1.Services.InSQL;

var builder = WebApplication.CreateBuilder(args);

var services = builder.Services;
// Add services to the container.
services.AddControllersWithViews();

//services.AddScoped<IEmployeesData, InMemoryEmployeesData>();
//services.AddScoped<IProductData, InMemoryProductData>();
//services.AddScoped<IBlogData, InMemoryBlogData>();
services.AddScoped<IEmployeesData, InSQLEmployeesData>();
services.AddScoped<IProductData, InSQLProductData>();
services.AddScoped<IBlogData, InSQLBlogData>();

var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
var mapper = mapperConfiguration.CreateMapper();
services.AddSingleton(mapper);


//services.AddDbContext<ApplicationDataContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
services.AddDbContext<WebStoreDB>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
});
services.AddScoped<DbInitializer>();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await db_initializer.InitializeAsync(
        RemoveBefore: app.Configuration.GetValue("DbRecreate", false),
        AddTestData: app.Configuration.GetValue("DbAddTestData", false));
}

//app.UseHttpsRedirection();

//app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
