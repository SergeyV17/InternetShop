using System.Collections.Generic;

namespace Shop.Data.Models.Interfaces
{
    /// <summary>
    /// Интерфейс репозитория товаров
    /// </summary>
    public interface IRepository
    {
        IEnumerable<Good> Goods { get; }
        Good GetGood(int goodId);
        public IEnumerable<IShippingMethod> ShippingMethods { get; }
    }
}
    