using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Products.Models;
using System.Reflection;

namespace Products.Infrastructure
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImages> ProductImages { get; set; }
        public DbSet<ProductBuyer> ProductsBuyers { get; set; }
        public DbSet<Buyer> Buyers { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
       : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);
        }
    }
}
