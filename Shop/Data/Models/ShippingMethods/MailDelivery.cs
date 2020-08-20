using Shop.Data.Models.Interfaces;

namespace Shop.Data.Models.ShippingMethods
{
    /// <summary>
    /// Класс доставки почтой России
    /// </summary>
    public class MailDelivery : IShippingMethod
    {
        public string Name => "Почта России";
        public decimal Value => 250m;
    }
}
