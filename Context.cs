using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();

                e.OwnsOne(x => x.Name, p =>
                {
                    p.Property(x => x.FirstName).HasColumnName("FirstName");
                    p.Property(x => x.LastName).HasColumnName("LastName");
                });
                e.HasMany(x => x.Orders).WithOne().HasForeignKey(x => x.CustomerId);
                e.ToTable("Customer");
            });

            modelBuilder.Entity<Order>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.HasMany(x => x.OrderLines).WithOne();
                e.HasOne(x => x.Customer).WithMany(x => x.Orders).HasForeignKey(x => x.CustomerId);
                e.ToTable("Order");
            });

            modelBuilder.Entity<OrderLine>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.ToTable("OrderLine");
            });
        }

        public class Customer
        {
            public int Id { get; set; }
            public CustomerName Name { get; set; }
            public IList<Order> Orders { get; set; }
        }


        public class CustomerName
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
        }


        public class Order
        {
            public int Id { get; set; }
            public IList<OrderLine> OrderLines { get; set; }
            public int CustomerId { get; set; }
            public Customer Customer { get; set; }
        }

        public class OrderLine
        {
            public int Id { get; set; }
            public string Product { get; set; }
            public double Price { get; set; }

        }
    }
}
