using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Practise_Database_Migration.Models;
namespace Practise_Database_Migration
{
    public class SimpleEcommarceDbContext:DbContext
    {
        public SimpleEcommarceDbContext(DbContextOptions options) : base(options)
        {
        }
        //DbSet prop
        public DbSet<Category> Categories { get; set; }
        public DbSet<Brand> Brands { get; set; }     
        public DbSet<Product> Products { get; set; }
        //Fluent Api
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>(entity =>
            {
                entity.Property(s => s.Name)
              .IsRequired()
              .HasMaxLength(50);
            });
            modelBuilder.Entity<Brand>(entity =>
            {
                entity.Property(s => s.Name).IsRequired().HasMaxLength(50);
            });
            modelBuilder.Entity<Product>()
      .HasOne(p => p.Category) 
      .WithMany()              
      .HasForeignKey(p => p.CategoryId)
      .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<Product>()
    .HasOne(p => p.Brand) 
    .WithMany()           
    .HasForeignKey(p => p.BrandId)
    .OnDelete(DeleteBehavior.Restrict);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // نتحقق إذا كان الكلاس الحالي يرث من MainEntity
                if (typeof(MainEntity).IsAssignableFrom(entityType.ClrType) && entityType.ClrType != typeof(MainEntity))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("IsDeleted")
                        .HasDefaultValue(false);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property("CreationDate")
                        .HasDefaultValueSql("GETDATE()")
                        .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore);
                }
            }


        }
    }
}
