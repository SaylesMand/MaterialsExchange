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
        public ICollection<Seller> GetSellers()
        {
            return _context.Seller.OrderBy(s => s.Id).ToList();
        }
    }
}
