using DepartmentalStoreApi.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DepartmentalStoreApi.Infrastructure
{
    public class DepartmentStoreContext : DbContext
    {
        public DepartmentStoreContext(DbContextOptions<DepartmentStoreContext> options) : base(options)
        {

        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Staff> Staff { get; set; }
        public DbSet<ProductCategory> Productcategory { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Role> Role { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {  
            //optionsBuilder.UseNpgsql("connectionString");

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Configure Role
            modelBuilder.Entity<Role>().HasKey(r => r.Id);
            modelBuilder.Entity<Role>().Property(x => x.RoleName).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Role>().Property(x => x.Description).HasMaxLength(512);
            base.OnModelCreating(modelBuilder);

            //Configure Address
            modelBuilder.Entity<Address>().HasKey(r => r.Id);
            modelBuilder.Entity<Address>().Property(x => x.AddressLine1).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.AddressLine2).HasMaxLength(128);
            modelBuilder.Entity<Address>().Property(x => x.City).HasMaxLength(64).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.State).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Address>().Property(x => x.Pincode).HasMaxLength(10).IsRequired();

            //Configure Staff
            modelBuilder.Entity<Staff>().HasKey(r => r.Id);
            modelBuilder.Entity<Staff>().Property(x => x.FirstName).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.LastName).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.PhoneNumber).HasMaxLength(10).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Gender).HasMaxLength(1).IsRequired();
            modelBuilder.Entity<Staff>().Property(x => x.Salary).IsRequired();
            modelBuilder.Entity<Staff>().HasOne(x => x.Address).WithMany(x => x.Staff).HasForeignKey(x => x.AddressId);
            modelBuilder.Entity<Staff>().HasOne(x => x.Role).WithMany(x => x.Staff).HasForeignKey(x => x.RoleId);

            //Configure Product
            modelBuilder.Entity<Product>().HasKey(r => r.ProductId);
            modelBuilder.Entity<Product>().Property(x => x.ProductName).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.Manufacturer).HasMaxLength(128).IsRequired();
            modelBuilder.Entity<Product>().Property(x => x.ShortCode).HasMaxLength(10).IsRequired();

            //modelBuilder.Entity<Product>().HasIndex(r => r.CostPrice).HasFilter("ALTER TABLE Product ADD CONSTRAINT MyUniqueConstraint CHECK (CostPrice > 0);");

            modelBuilder.Entity<Product>().Property(x => x.CostPrice).IsRequired();
            //modelBuilder.Entity<Product>().HasIndex(r => r.SellingPrice).HasFilter("ALTER TABLE Product ADD CONSTRAINT MyUniqueConstraint CHECK (SellingPrice > 0);");
            modelBuilder.Entity<Product>().Property(x => x.SellingPrice).IsRequired();

            //Configure Category
            modelBuilder.Entity<Category>().HasKey(r => r.CategoryId);
            modelBuilder.Entity<Category>().Property(r => r.CategoryName).HasMaxLength(128).IsRequired();

            //Configure ProductCategory
            modelBuilder.Entity<ProductCategory>().HasKey(pc => new { pc.ProductId, pc.CategoryId });
        }

    }
}
