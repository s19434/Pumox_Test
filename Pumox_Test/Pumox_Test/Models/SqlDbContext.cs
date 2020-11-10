using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pumox_Test.Models
{
    public class SqlDbContext : DbContext
    {
        public DbSet<Company> Companies { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public SqlDbContext() { }

        public SqlDbContext(DbContextOptions options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(opt =>
            {
                opt.HasKey(p => p.IdCompany);

                opt.Property(p => p.IdCompany)
                    .ValueGeneratedOnAdd();

                opt.Property(p => p.Name)
                    .HasMaxLength(50)
                    .IsRequired();

                opt.HasMany(p => p.Employees)
                    .WithOne(p => p.Company)
                    .HasForeignKey(p => p.IdCompany)
                    .OnDelete(DeleteBehavior.Cascade);

            });

            modelBuilder.Entity<Employee>(opt =>
            {
                opt.HasKey(p => p.IdEmployee);

                opt.Property(p => p.IdEmployee)
                    .ValueGeneratedOnAdd();

                opt.Property(p => p.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();


                opt.Property(p => p.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
            });


        }

    }
}
