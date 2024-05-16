using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> TaiKhoan { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }

        public DbSet<Voucher> Voucher { get; set; }

        public DbSet<Bill> Bill { get; set; }

        public DbSet<ProductCategory> ProductCategory { get; set; }

        public DbSet<Product> Product { get; set; }

        public DbSet<ProductSale> ProductSale { get; set; }

        public DbSet<ProductBill> ProductBill { get; set; }
        public DbSet<ProductInfo> ProductInfo { get; set; }

        public DbSet<ProductImage> ProductImage { get; set; }
        public DbSet<Cart> Cart { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductBill>()
            .HasKey(m => new { m.ProductID, m.BillID });
            base.OnModelCreating(modelBuilder);
            modelBuilder
            .Entity<ProductImage>(builder =>
    {
                builder.HasNoKey();
                builder.ToTable("ProductImage");
    });
        }
    }
}
