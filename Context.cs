using Microsoft.EntityFrameworkCore;

namespace EF
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Customer>(e =>
            {
                e.HasKey(x => x.Id);
                e.Property(x => x.Id).HasColumnName("Id").ValueGeneratedOnAdd();
                e.Property(x => x.FirstName).HasColumnName("FirstName");
                e.Property(x => x.LastName).HasColumnName("LastName");
                e.ToTable("Customer");
            });
        }
    }


    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
