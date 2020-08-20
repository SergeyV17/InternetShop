namespace Shop.Data.Models
{
    /// <summary>
    /// Класс товара
    /// </summary>
    public class Good
    {
        public int Id { get; set; }
        public string Articul { get; set; }
        public string Name { get; set; }
        public decimal Value { get; set; }
    }
}
