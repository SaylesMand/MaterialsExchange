using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Models;

namespace MaterialsExchange.Repository
{
    public class SellerRepository : ISellerRepository
    {
        private readonly AppDbContext _context;

        public SellerRepository(AppDbContext context)
        {
            _context = context;
        }

        public Seller GetSeller(int id)
        {
            return _context.Seller.Where(s => s.Id == id).FirstOrDefault();
        }

        public ICollection<Seller> GetSellers()
        {
            return _context.Seller.OrderBy(s => s.Id).ToList();
        }

        public bool SellerExists(int sellId)
        {
            return _context.Seller.Any(s => s.Id == sellId);
        }
    }
}
