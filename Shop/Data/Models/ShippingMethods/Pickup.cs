using Shop.Data.Models.Interfaces;

namespace Shop.Data.Models.ShippingMethods
{
    /// <summary>
    /// Класс самовывоза
    /// </summary>
    public class Pickup : IShippingMethod
    {
        public string Name => "Самовывоз";
        public decimal Value => 0;
    }
}
    