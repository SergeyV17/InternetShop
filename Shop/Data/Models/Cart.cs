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
    public class Cart
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Конструктор репозитория товаров
        /// </summary>
        /// <param name="dbContext">контекст данных</param>
        public Cart(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public string Id { get; set; }
        public List<ShopCartItem> Items => GetShopCartItems();

        public decimal PurchaseAmount => GetCartPurchase();

        /// <summary>
        /// Метод проверяющий на наличие в сессии корзины товаров и возвращающий корзину товаров
        /// </summary>
        /// <param name="service">сервис</param>
        /// <returns>корзина</returns>
        public static Cart GetCart(IServiceProvider service)
        {
            ISession session = service.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = service.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new Cart(context) {Id = cartId};
        }

        /// <summary>
        /// Метод добавления товара в корзину
        /// </summary>
        /// <param name="good">товар</param>
        public void AddItemToCart(Good good)
        {
            if (Items.Count(i => i.Good == good) == 0 && good != null)
            {
                const int initialQuantity = 1;

                _dbContext.ShopCartItem.Add(new ShopCartItem()
                {
                    CartId = Id,
                    Good = good,
                    Quantity = initialQuantity
                });
            }
            else
                AddItemQuantity(good);

            _dbContext.SaveChanges();
        }

        public void AddItemQuantity(Good good)
        {
            if (good == null) return;
            var cartItem = _dbContext.ShopCartItem.FirstOrDefault(i => i.CartId == Id && i.Good == good);

            if (cartItem != null)
                cartItem.Quantity++;

            _dbContext.SaveChanges();
        }

        public void RemoveItemQuantity(Good good)
        {
            if (good == null) return;
            var cartItem = _dbContext.ShopCartItem.FirstOrDefault(i => i.CartId == Id && i.Good == good);

            if (cartItem == null)
                return;

            if (cartItem.Quantity == 1)
                _dbContext.ShopCartItem.Remove(cartItem);
            else if (cartItem.Quantity > 0)
                cartItem.Quantity--;

            _dbContext.SaveChanges();
        }

        /// <summary>
        /// Метод возвращающий коллекцию товаров в текущей корзине
        /// </summary>
        /// <returns>коллекция товаров</returns>
        private List<ShopCartItem> GetShopCartItems()
        {
            return _dbContext.ShopCartItem.Where(i => i.CartId == Id).Include(i => i.Good).ToList();
        }

        private decimal GetCartPurchase()
        {
            return Enumerable.Sum(_dbContext.ShopCartItem.Where(i => i.CartId == Id), item => item.Good.Value * item.Quantity);
        }
    }
}
