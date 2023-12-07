using MaterialsExchange.Models;

namespace MaterialsExchange.Interfaces
{
    public interface ISellerRepository
    {
        ICollection<Seller> GetSellers();
    }
}
