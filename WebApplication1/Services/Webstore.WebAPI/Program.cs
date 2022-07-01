using ContextDB.DAL;
using DataLayer;
using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.EntityFrameworkCore;
using Webstore.WebAPI.Infrastructure.Middleware;
using WebStore.Interfaces.Services;
using WebStore.Logging;
using WebStore.Services.Data;
using WebStore.Services.Services.InSQL;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddLog4Net();

var config = builder.Configuration;
var services = builder.Services;
// Add services to the container.

var db_type = config["DB:Type"];
var db_connection_string = config.GetConnectionString(db_type);

switch (db_type)
{
    case "SqlServer":
        services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(db_connection_string, o => o.MigrationsAssembly("WebStore.DAL")));
        break;
    case "Sqlite":
        services.AddDbContext<WebStoreDB>(opt => opt.UseSqlite(db_connection_string, o => o.MigrationsAssembly("WebStore.DAL.Sqlite")));
        break;
}

services.AddScoped<DbInitializer>();

services.AddIdentity<User, Role>(/*opt => { opt... }*/)
   .AddEntityFrameworkStores<WebStoreDB>()
   .AddDefaultTokenProviders();

services.Configure<IdentityOptions>(opt =>
{
#if DEBUG
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
    opt.Password.RequiredLength = 3;
    opt.Password.RequiredUniqueChars = 3;
#endif
    opt.User.RequireUniqueEmail = false;
    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIGKLMNOPQRSTUVWXYZ1234567890";
    opt.Lockout.AllowedForNewUsers = false;
    opt.Lockout.MaxFailedAccessAttempts = 10;
    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
});

//services.ConfigureApplicationCookie(opt =>
//{
//    opt.Cookie.Name = "GB.WebStore";
//    opt.Cookie.HttpOnly = true;

//    opt.ExpireTimeSpan = TimeSpan.FromDays(10);

//    opt.LoginPath = "/Account/Login";
//    opt.LogoutPath = "/Account/Logout";
//    opt.AccessDeniedPath = "/Account/AccessDenied";

//    opt.SlidingExpiration = true;
//});

services.AddScoped<IEmployeesData, InSQLEmployeesData>();
services.AddScoped<IProductData, InSQLProductData>();
services.AddScoped<IOrderService, SqlOrderService>();
services.AddScoped<IBlogData, InSQLBlogData>();

services.AddControllers(opt =>
{
    opt.InputFormatters.Add(new XmlSerializerInputFormatter(opt));
    opt.OutputFormatters.Add(new XmlSerializerOutputFormatter());
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
services.AddSwaggerGen(opt =>
{
    var webstore_webapi_xml = Path.ChangeExtension(Path.GetFileName(typeof(Program).Assembly.Location), ".xml");
    var dataLayer_xml = Path.ChangeExtension(Path.GetFileName(typeof(Product).Assembly.Location), ".xml");

    const string debug_path = "bin/Debug/net6.0";

    if (File.Exists(webstore_webapi_xml))
        opt.IncludeXmlComments(webstore_webapi_xml);
    else if (File.Exists(Path.Combine(debug_path, webstore_webapi_xml)))
        opt.IncludeXmlComments(Path.Combine(debug_path, webstore_webapi_xml));

    if (File.Exists(dataLayer_xml))
        opt.IncludeXmlComments(dataLayer_xml);
    else if (File.Exists(Path.Combine(debug_path, dataLayer_xml)))
        opt.IncludeXmlComments(Path.Combine(debug_path, dataLayer_xml));
});

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db_initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
    await db_initializer.InitializeAsync(
        RemoveBefore: app.Configuration.GetValue("DB:Recreate", false),
        AddTestData: app.Configuration.GetValue("DB:AddTestData", false));
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.UseMiddleware<ExceptionHandler>();

app.MapControllers();

app.Run();
