using System;
using Shop.Data.Models.Interfaces;

namespace Shop.Data.Models
{
    public class CreateOrder: ICreateOrder
    {
        private readonly AppDbContext _dbContext;
        private readonly Cart _cart;

        public CreateOrder(AppDbContext dbContext, Cart cart)
        {
            _dbContext = dbContext;
            _cart = cart;
        }

        public void CreateNewOrder(Order order)
        {
            order.OrderDateTime = DateTime.Now;
            _dbContext.Order.Add(order);

            _dbContext.SaveChanges();

            var items = _cart.Items;

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
