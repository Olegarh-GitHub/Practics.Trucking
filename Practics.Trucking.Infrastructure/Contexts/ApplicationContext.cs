using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Practics.Trucking.Domain.Models;

namespace Practics.Trucking.Infrastructure.Contexts
{
    public sealed class ApplicationContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Specification> Specifications { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserInfo> UserInfo { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<ProducerInfo> ProducerInfo { get; set; }
        public DbSet<Session> Sessions { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
        }
    }
    
    public class ApplicationContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Trucking_SSL");

            return new ApplicationContext(optionsBuilder.Options);
        }
    }
}