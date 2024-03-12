using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Infrastructure.Persistence
{
    public class GroceryStoreDbContext(DbContextOptions<GroceryStoreDbContext> options) : DbContext(options)
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<SaleProduct> SalesProducts { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Vendor> Vendors { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<PurchaseProduct> PurchasesProducts { get; set; }

        // when the SaveChangesAsync method is called then it will perform the logic within this
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var currentTime = DateTime.UtcNow;
            var user = "System";

            foreach (var entry in ChangeTracker.Entries<FullAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = currentTime;
                        entry.Entity.CreatedBy = user;
                        break;
                    case EntityState.Modified:
                        entry.Entity.LastUpdateDate = currentTime;
                        entry.Entity.LastUpdateBy = user;
                        break;
                }
            }

            foreach (var entry in ChangeTracker.Entries<SimpleAuditable>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreationDate = currentTime;
                        entry.Entity.CreatedBy = user;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        // applying configurations made to each entity
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

    }
}
