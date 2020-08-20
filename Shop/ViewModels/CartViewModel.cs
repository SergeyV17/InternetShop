using Shop.Data.Models;
using Shop.Data.Models.Interfaces;

namespace Shop.ViewModels
{
    /// <summary>
    /// Модель представление корзины с товарами
    /// </summary>
    public class CartViewModel
    {
        public Cart Cart { get; }

        public IShippingMethod ShippingMethod { get; }

        public decimal Total => Cart.PurchaseAmount + ShippingMethod.Value;

        public CartViewModel(Cart cart, IShippingMethod shippingMethod)
        {
            Cart = cart;
            ShippingMethod = shippingMethod;
        }
    }
}
