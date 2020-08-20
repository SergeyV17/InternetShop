namespace Shop.Data.Models
{
    /// <summary>
    /// Класс товара находящегося в корзине
    /// </summary>
    public class ShopCartItem
    {
        public int Id { get; set; }
        public Good Good { get; set; }
        public string CartId { get; set; }
        public int Quantity { get; set; }
    }
}
