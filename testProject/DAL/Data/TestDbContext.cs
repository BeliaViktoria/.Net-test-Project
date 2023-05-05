namespace DAL.Data
{
    using DAL.Models;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

    public partial class TestDbContext : DbContext
    {
        public TestDbContext()
        {
        }

        public TestDbContext(DbContextOptions<TestDbContext> options)
        : base(options)
        {
        }

        public virtual DbSet<User>? Users { get; set; } = null;

        public virtual DbSet<Order>? Orders { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.Property(e => e.Login).HasColumnName("Login");

                entity.Property(e => e.Password).HasColumnName("password");

                entity.Property(e => e.FirstName).HasColumnName("FirstName");

                entity.Property(e => e.LastName).HasColumnName("LastName");

                entity.Property(e => e.DateOfBirth).HasColumnName("DateOfBirth");

                entity.Property(e => e.Gender).HasColumnName("Gender");
            });


            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Orders");

                entity.Property(e => e.OrderID).HasColumnName("OrderID");

                entity.Property(e => e.UserID).HasColumnName("UserID");

                entity.Property(e => e.OrderDate).HasColumnName("OrderDate");

                entity.Property(e => e.OrderCost).HasColumnName("OrderCost");

                entity.Property(e => e.ItemsDescription).HasColumnName("ItemsDescription");

                entity.Property(e => e.ShippingAddress).HasColumnName("ShippingAddress");
                
            });
        }
    }
}
