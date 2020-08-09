using Microsoft.EntityFrameworkCore;
using Shop.Data.Models;

namespace Shop.Data
{
    /// <summary>
    /// Класс контекста базы данных
    /// </summary>
    public sealed class AppDbContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста БД
        /// </summary>
        /// <param name="options">опции</param>
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            //Database.EnsureDeleted(); // удаляем бд со старой схемой
        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        /// <summary>
        /// Переопределение метода OnModelCreating
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Разрешение на использование readonly полей в классе Good
            modelBuilder.Entity<Good>(
                g =>
                {
                    g.HasKey("Id");
                    g.Property(e => e.Articul).IsRequired();
                    g.Property(e => e.Name).IsRequired();
                    g.Property(e => e.Value).IsRequired();
                });
        }
    }
}
