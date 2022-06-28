using ContextDB.DAL;
using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebStore.Interfaces.Services;
using WebStore.Services.Data;
using WebStore.Services.Services.InSQL;

var builder = WebApplication.CreateBuilder(args);

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

services.ConfigureApplicationCookie(opt =>
{
    opt.Cookie.Name = "GB.WebStore";
    opt.Cookie.HttpOnly = true;

    opt.ExpireTimeSpan = TimeSpan.FromDays(10);

    opt.LoginPath = "/Account/Login";
    opt.LogoutPath = "/Account/Logout";
    opt.AccessDeniedPath = "/Account/AccessDenied";

    opt.SlidingExpiration = true;
});

services.AddScoped<IEmployeesData, InSQLEmployeesData>();
services.AddScoped<IProductData, InSQLProductData>();
services.AddScoped<IOrderService, SqlOrderService>();
services.AddScoped<IBlogData, InSQLBlogData>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
