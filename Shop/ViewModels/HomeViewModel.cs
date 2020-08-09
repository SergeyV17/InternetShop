using System.Collections.Generic;
using Shop.Data.Models;

namespace Shop.ViewModels
{
    /// <summary>
    /// Модель представление домашней страницы
    /// </summary>
    public class HomeViewModel
    {
        public IEnumerable<Good> Goods { get; }

        /// <summary>
        /// Конструктор модели представления домашней страницы
        /// </summary>
        /// <param name="goods"></param>
        public HomeViewModel(IEnumerable<Good> goods)
        {
            Goods = goods;
        }
    }
}
