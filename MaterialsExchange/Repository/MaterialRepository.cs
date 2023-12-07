using MaterialsExchange.Data;
using MaterialsExchange.Interfaces;
using MaterialsExchange.Models;

namespace MaterialsExchange.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly AppDbContext _context;
        public MaterialRepository(AppDbContext context)
        {
            _context = context;
        }
        public ICollection<Material> GetMaterials()
        {
            return _context.Material.OrderBy(m => m.Id).ToList();
        }
    }
}
