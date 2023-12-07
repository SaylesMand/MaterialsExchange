using MaterialsExchange.Models;

namespace MaterialsExchange.Interfaces
{
    public interface ISellerRepository
    {
        ICollection<Seller> GetSellers();
        Seller GetSeller(int id);
        bool SellerExists(int sellId);
        bool CreateSeller(Seller seller);
        bool Save();
        bool UpdateSeller(Seller seller);
        bool DeleteSeller(Seller seller);
    }
}
