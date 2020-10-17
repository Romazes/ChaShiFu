using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TeaStore.Core.Entities;
using TeaStore.Core.Entities.WeightAggregate;

namespace TeaStore.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<CatalogItem> CatalogItems { get; set; }
        public DbSet<Weight> Weights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WeightCatalogItem>()
                .HasKey(t => new { t.WeightId, t.CatalogItemId });

            modelBuilder.Entity<WeightCatalogItem>()
                .HasOne(pt => pt.Weight)
                .WithMany(p => p.WeightMenuItems)
                .HasForeignKey(pt => pt.WeightId);

            modelBuilder.Entity<WeightCatalogItem>()
                .HasOne(pt => pt.CatalogItem)
                .WithMany(t => t.WeightMenuItems)
                .HasForeignKey(pt => pt.CatalogItemId);
        }
    }
}
