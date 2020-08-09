using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Shop.Data.Models.Interfaces;

namespace Shop.Data.Models
{
    public class Orders: IOrders
    {
        private readonly AppDbContext _dbContext;
        private readonly ShopCart _shopCart;

        public Orders(AppDbContext dbContext, ShopCart shopCart)
        {
            _dbContext = dbContext;
            _shopCart = shopCart;
        }

        public void CreateOrder(Order order)
        {
            order.OrderDateTime = DateTime.Now;
            _dbContext.Order.Add(order);

            _dbContext.SaveChanges();

            var items = _shopCart.Items;

            foreach (var item in items)
            {
                var orderDetail = new OrderDetail()
                {
                    GoodId = item.Good.Id,
                    OrderId = order.Id,
                    Value = item.Good.Value
                };

                _dbContext.OrderDetail.Add(orderDetail);
            }

            _dbContext.SaveChanges();
        }
    }
}
