namespace Shop.Data.Models
{
    /// <summary>
    /// Класс товара находящегося в корзине
    /// </summary>
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Good Good { get; set; }
        public decimal Value { get; set; }
        public string ShopCartId { get; set; }
    }
}
