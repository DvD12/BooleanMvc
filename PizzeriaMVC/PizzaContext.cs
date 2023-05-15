using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PizzeriaMVC.Models;
using PizzeriaMVC.Seeders;
using System.Diagnostics;

namespace PizzeriaMVC
{
    public class PizzaContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<ImageEntry> ImageEntries { get; set; }
        public DbSet<PizzaModel> Pizzas { get; set; }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<IngredientModel> Ingredients { get; set; }

        public PizzaContext(DbContextOptions<PizzaContext> dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                              .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                              .AddJsonFile("appsettings.json")
                              .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("PizzaDbConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    }
}
