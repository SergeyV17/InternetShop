using Shop.Data.Models;
using Shop.Data.Models.Interfaces;

namespace Shop.ViewModels
{
    public class ShopCartViewModel
    {
        public Cart Cart { get; }

        public IShippingMethod ShippingMethod { get; }

        public decimal Total => Cart.PurchaseAmount + ShippingMethod.Value;

        public ShopCartViewModel(Cart cart, IShippingMethod shippingMethod)
        {
            Cart = cart;
            ShippingMethod = shippingMethod;
        }
    }
}
