using System.Collections.Generic;
using System.Linq;
using Shop.Data.Models.Interfaces;
using Shop.Data.Models.ShippingMethods;

namespace Shop.Data.Models
{
    /// <summary>
    /// Репозиторий товаров
    /// </summary>
    public class Repository : IRepository
    {
        private readonly AppDbContext _dbContext;

        /// <summary>
        /// Конструктор репозитория товаров
        /// </summary>
        /// <param name="dbContext">контекст данных</param>
        public Repository(AppDbContext dbContext)
        {
            _dbContext = dbContext;

            ShippingMethods = new List<IShippingMethod>()
            {
                new MailDelivery(),
                new ExpressDelivery(),
                new Pickup()
            };
        }

        public IEnumerable<Good> Goods => _dbContext.Goods;
        public Good GetGood(int goodId) => _dbContext.Goods.FirstOrDefault(g => g.Id == goodId);

        public IEnumerable<IShippingMethod> ShippingMethods { get; }
    }
}
