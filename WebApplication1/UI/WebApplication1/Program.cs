using AutoMapper;
using DataLayer.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Polly;
using Polly.Extensions.Http;
using WebApplication1.Infrastructure.Conventions;
//using WebApplication1.Services.InMemory;
using WebStore.Interfaces.Services;
using WebStore.Interfaces.Services.Identity;
using WebStore.Interfaces.TestAPI;
using WebStore.Services.Mapping;
using WebStore.Services.Services.InCookies;
using WebStore.WebAPI.Clients.Blogs;
using WebStore.WebAPI.Clients.Employees;
using WebStore.WebAPI.Clients.Identity;
using WebStore.WebAPI.Clients.Orders;
using WebStore.WebAPI.Clients.Products;
using WebStore.WebAPI.Clients.Values;

var builder = WebApplication.CreateBuilder(args);

var config = builder.Configuration;
var services = builder.Services;

//var db_type = config["DB:Type"];
//var db_connection_string = config.GetConnectionString(db_type);

//switch (db_type)
//{
//    case "SqlServer":
//        services.AddDbContext<WebStoreDB>(opt => opt.UseSqlServer(db_connection_string, o => o.MigrationsAssembly("WebStore.DAL")));
//        break;
//    case "Sqlite":
//        services.AddDbContext<WebStoreDB>(opt => opt.UseSqlite(db_connection_string, o => o.MigrationsAssembly("WebStore.DAL.Sqlite")));
//        break;
//}
//services.AddDbContext<ApplicationDataContext>(options =>
//{
//    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"));
//});
//services.AddDbContext<WebStoreDB>(options =>
//{
//    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer"));
//});
//services.AddScoped<DbInitializer>();

services.AddIdentity<User, Role>()
   .AddDefaultTokenProviders();

services.AddHttpClient("WebStoreAPIIdentity", client =>
{
    //client.DefaultRequestHeaders.Add("accept", "application/json");
    client.BaseAddress = new(config["WebAPI"]);
})
   .AddTypedClient<IUsersClient, UsersClient>()
   .AddTypedClient<IUserStore<User>, UsersClient>()
   .AddTypedClient<IUserRoleStore<User>, UsersClient>()
   .AddTypedClient<IUserPasswordStore<User>, UsersClient>()
   .AddTypedClient<IUserEmailStore<User>, UsersClient>()
   .AddTypedClient<IUserPhoneNumberStore<User>, UsersClient>()
   .AddTypedClient<IUserTwoFactorStore<User>, UsersClient>()
   .AddTypedClient<IUserClaimStore<User>, UsersClient>()
   .AddTypedClient<IUserLoginStore<User>, UsersClient>()
   .AddTypedClient<IRolesClient, RolesClient>()
   .AddTypedClient<IRoleStore<Role>, RolesClient>()
   .AddPolicyHandler(GetRetryPolicy())
   .AddPolicyHandler(GetCircuitBreakerPolicy());

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

services.AddHttpClient("WebStoreApi", client => client.BaseAddress = new(config["WebAPI"]))
   .AddTypedClient<IValuesService, ValuesClient>()
   .AddTypedClient<IEmployeesData, EmployeesClient>()
   .AddTypedClient<IProductData, ProductsClient>()
   .AddTypedClient<IOrderService, OrdersClient>()
   .AddTypedClient<IBlogData, BlogsClient>()
   .AddPolicyHandler(GetRetryPolicy())
   .AddPolicyHandler(GetCircuitBreakerPolicy());

static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy(int MaxRetryCount = 5, int MaxJitterTime = 1000)
{
    var jitter = new Random();
    return HttpPolicyExtensions
       .HandleTransientHttpError()
       .WaitAndRetryAsync(MaxRetryCount, RetryAttempt =>
            TimeSpan.FromSeconds(Math.Pow(2, RetryAttempt)) +
            TimeSpan.FromMilliseconds(jitter.Next(0, MaxJitterTime)));
}

static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy() =>
    HttpPolicyExtensions
       .HandleTransientHttpError()
       .CircuitBreakerAsync(handledEventsAllowedBeforeBreaking: 5, TimeSpan.FromSeconds(30));

//services.AddScoped<IEmployeesData, InMemoryEmployeesData>();
//services.AddScoped<IProductData, InMemoryProductData>();
//services.AddScoped<IBlogData, InMemoryBlogData>();
//services.AddScoped<IEmployeesData, InSQLEmployeesData>();
//services.AddScoped<IProductData, InSQLProductData>();
//services.AddScoped<IOrderService, SqlOrderService>();
//services.AddScoped<IBlogData, InSQLBlogData>();
services.AddScoped<ICartService, InCookiesCartService>();

services.AddControllersWithViews(opt =>
{
    opt.Conventions.Add(new AddAreaToControllerConversation());
});

var mapperConfiguration = new MapperConfiguration(mp => mp.AddProfile(new MapperProfile()));
var mapper = mapperConfiguration.CreateMapper();
services.AddSingleton(mapper);

var app = builder.Build();

//using (var scope = app.Services.CreateScope())
//{
//    var db_initializer = scope.ServiceProvider.GetRequiredService<DbInitializer>();
//    await db_initializer.InitializeAsync(
//        RemoveBefore: app.Configuration.GetValue("DB:Recreate", false),
//        AddTestData: app.Configuration.GetValue("DB:AddTestData", false));
//}

//app.UseHttpsRedirection();

//app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "areas",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.Run();
