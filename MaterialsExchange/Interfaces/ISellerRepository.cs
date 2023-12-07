using MaterialsExchange.Models;

namespace MaterialsExchange.Interfaces
{
    public interface ISellerRepository
    {
        ICollection<Seller> GetSellers();
        Seller GetSeller(int id);
        bool SellerExists(int sellId);
    }
}
