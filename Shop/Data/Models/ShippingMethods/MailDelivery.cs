using Shop.Data.Models.Interfaces;

namespace Shop.Data.Models.ShippingMethods
{
    public class MailDelivery : IShippingMethod
    {
        public string Name => "Почта России";
        public decimal Value => 250m;
    }
}
