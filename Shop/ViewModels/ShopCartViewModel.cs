using Shop.Data.Models;

namespace Shop.ViewModels
{
    public class ShopCartViewModel
    {
        public ShopCart ShopCart { get; }

        public ShopCartViewModel(ShopCart shopCart)
        {
            ShopCart = shopCart;
        }
    }
}
