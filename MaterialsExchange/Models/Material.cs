namespace MaterialsExchange.Models
{
    public class Material
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
