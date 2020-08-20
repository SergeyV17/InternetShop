namespace Shop.Data.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int GoodId { get; set; }
        public decimal Value { get; set; }
    }
}
