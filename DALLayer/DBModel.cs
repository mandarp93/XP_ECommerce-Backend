using DomainModels;
using Microsoft.EntityFrameworkCore;
using System;

namespace DALLayer
{
    public class DBModel:DbContext
    {
        public DBModel(DbContextOptions options) : base(options) { }

        //public static object ConfigurationManager { get; private set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Configurations.Add(new MyCategoryMapping());
        }
        public DbSet<Roles> Role { get; set; }
        public DbSet<Customers> Customer { get; set; }
        public DbSet<Products> Product { get; set; }
        public DbSet<Orders> Order { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<PaymentDetails> Payments { get; set; }
    }
}
