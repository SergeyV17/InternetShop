using System.Collections.Generic;
using System.Linq;
using Shop.Data.Models.Interfaces;

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
        }

        public IEnumerable<Good> Goods => _dbContext.Goods;
        public Good GetGood(int goodId) => _dbContext.Goods.FirstOrDefault(g => g.Id == goodId);
    }
}
