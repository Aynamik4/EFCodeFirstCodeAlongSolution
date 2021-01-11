using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFCodeFirstCodeAlong.Models
{
    class EFContext : DbContext
    {
        //const string connectionString = @"Server=(localdb)\mssqllocaldb;Database=EFCore;Trusted_Connection=True;";

        string connectionString = string.Empty;

        public EFContext() : base()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("SomeConnectionString");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}
