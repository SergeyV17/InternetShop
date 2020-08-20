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
            //Database.EnsureCreated(); // создаем бд с новой схемой     
        }

        public DbSet<Good> Goods { get; set; }
        public DbSet<ShopCartItem> ShopCartItem { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
    }
}
