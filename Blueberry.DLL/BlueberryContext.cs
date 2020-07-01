using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Blueberry.DLL.Models;

namespace Blueberry.DLL
{
    public class BlueberryContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<BlueberryException> Exceptions { get; set; }
        public DbSet<Harvest> Harvests { get; set; }

        public BlueberryContext()
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BlueberryData>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
