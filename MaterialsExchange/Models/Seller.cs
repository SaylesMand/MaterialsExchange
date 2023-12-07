namespace MaterialsExchange.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Material> Materials { get; set; }
    }
}
