namespace Shop.Data.Models.Interfaces
{
    /// <summary>
    /// Интерфейс определяющий способ доставки
    /// </summary>
    public interface IShippingMethod
    {
        public string Name { get;  }
        public decimal Value { get;  }
    }
}
