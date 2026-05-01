using Company_DataBase_Task.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;

namespace Company_DataBase_Task
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions options) : base(options)
        {
        }

        //DbSet prop
        public DbSet<Department> Departments { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<AssignmentEmployees> AssignmentEmployees { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Self-Referencing Relationship
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Manager)      
                .WithMany(m => m.Team)      
                .HasForeignKey(e => e.ManagerId);
            modelBuilder.Entity<Employee>()
                .HasOne(e => e.Department)      
                .WithMany(d => d.Employees)     
                .HasForeignKey(e => e.DepartmentId);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(MainEntity).IsAssignableFrom(entityType.ClrType) && entityType.ClrType != typeof(MainEntity))
                {
                    modelBuilder.Entity(entityType.ClrType)
                        .Property("IsDeleted")
                        .HasDefaultValue(false);

                    modelBuilder.Entity(entityType.ClrType)
                        .Property("CreationDate")
                        .HasDefaultValueSql("GETDATE()");
                       
                }
            }

        }

    }
}
