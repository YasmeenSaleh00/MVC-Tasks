using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SchoolProject.Models;
namespace SchoolProject.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Student> Students { get; set; }    

        //to use fluent api approch
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>(entity =>
            {
                entity.Property(s => s.FirstName)
              .IsRequired()            
              .HasMaxLength(50);       

                entity.Property(s => s.LastName)
                      .IsRequired()
                      .HasMaxLength(50);

           
                entity.Property(x => x.IsDeleted)
                .HasDefaultValue(false).ValueGeneratedOnAdd(); 
                entity.HasIndex(s => s.Email).IsUnique();
                entity.ToTable(t => t.HasCheckConstraint("CH_Student_Age_Min", "Age > 0"));
                //عند الانشاء عبي القيمة
                entity.Property(s => s.CreationDate)
      .HasDefaultValueSql("GETDATE()")
      .ValueGeneratedOnAdd()
      .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Ignore); // هذا السطر يمنع التعديل نهائياً على ناريخ الانشاء

            });


        }
    }
}
