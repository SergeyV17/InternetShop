using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Shop.Data.Models
{
    /// <summary>
    /// Класс корзины товаров
    /// </summary>
    public class ShopCart
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Конструктор репозитория товаров
        /// </summary>
        /// <param name="dbContext">контекст данных</param>
        public ShopCart(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Id { get; set; }
        public IEnumerable<ShopCartItem> Items => GetShopCartItems();

        /// <summary>
        /// Метод проверяющий на наличие в сессии корзины товаров и возвращающий корзину товаров
        /// </summary>
        /// <param name="service">сервис</param>
        /// <returns>корзина</returns>
        public static ShopCart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContext>();
            string shopCartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", shopCartId);

            return new ShopCart(context) {Id = shopCartId};
        }

        /// <summary>
        /// Метод добавления товара в корзину
        /// </summary>
        /// <param name="good">товар</param>
        public void AddItemToCart(Good good)
        {
            _dbContext.ShopCartItem.Add(new ShopCartItem()
            {
                ShopCartId = Id,
                Good = good,
                Value = good.Value
            });
            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Метод возвращающий коллекцию товаров в текущей корзине
        /// </summary>
        /// <returns>коллекция товаров</returns>
        public IEnumerable<ShopCartItem> GetShopCartItems()
        {
            return _dbContext.ShopCartItem.Where(i => i.ShopCartId == Id).Include(i => i.Good);
        }
    }
}
