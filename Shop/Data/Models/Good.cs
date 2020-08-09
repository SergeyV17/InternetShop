namespace Shop.Data.Models
{
    /// <summary>
    /// Класс товара
    /// </summary>
    public class Good
    {
        public int Id { get; }
        public string Articul { get; }
        public string Name { get; }
        public decimal Value { get; }

        /// <summary>
        /// Конструктор товара
        /// </summary>
        /// <param name="articul">артикул</param>
        /// <param name="name">наименование</param>
        /// <param name="value">цена</param>
        public Good(string articul, string name, decimal value)
        {
            Articul = articul;
            Name = name;
            Value = value;
        }
    }
}
