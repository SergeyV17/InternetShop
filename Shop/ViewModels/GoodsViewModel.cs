using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    /// <summary>
    /// Модель представление для коллекции товаров
    /// </summary>
    public class GoodsViewModel
    {
        public IEnumerable<Good> Goods { get; set; }

        /// <summary>
        /// Конструктор модели представления коллекции товаров
        /// </summary>
        /// <param name="goods">коллекция товаров</param>
        public GoodsViewModel(IEnumerable<Good> goods)
        {
            Goods = goods;
        }
    }
}
