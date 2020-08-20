using Shop.Data.Models.Interfaces;

namespace Shop.Data.Models.ShippingMethods
{
    /// <summary>
    /// Класс курьерской доставки
    /// </summary>
    public class ExpressDelivery : IShippingMethod
    {
        public string Name => "Курьерская доставка";
        public decimal Value => 600m;
    }
}
