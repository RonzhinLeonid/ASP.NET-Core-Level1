using DataLayer;
using DataLayer.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using DataLayer.Orders;

namespace ContextDB.DAL
{
    public class WebStoreDB : IdentityDbContext<User, Role, string>
    {
        public DbSet<Employee> Employees { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Brand> Brands { get; set; } = null!;

        public DbSet<Section> Sections { get; set; } = null!;

        public DbSet<Blog> Blogs { get; set; } = null!;

        public DbSet<Order> Orders { get; set; } = null!;

        public WebStoreDB(DbContextOptions<WebStoreDB> options) : base(options)
        {

        }
    }
}