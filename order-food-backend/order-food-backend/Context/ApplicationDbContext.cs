
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OrderFoodLibrary.Entities;

namespace order_food_backend.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Dish> Dishes { get; set; }
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Dish>()
                .HasKey(d => d.Id);

            modelBuilder.Entity<Dish>()
                .Property(d => d.Price)
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            modelBuilder.Entity<Dish>()
                .HasOne(d => d.Category)
                .WithMany()
                .IsRequired();

            modelBuilder.Entity<OrderItem>()
                .HasOne(x => x.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(o => o.OrderId);
        }
    }
}
