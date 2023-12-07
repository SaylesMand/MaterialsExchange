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

        public bool CreateMaterial(Material material)
        {
            _context.Add(material);
            return Save();
        }

        public Material GetMaterial(int id)
        {
            return _context.Material.Where(m => m.Id == id).FirstOrDefault();
        }

        public ICollection<Material> GetMaterials()
        {
            return _context.Material.OrderBy(m => m.Id).ToList();
        }

        public bool MaterialExists(int mateId)
        {
            return _context.Material.Any(m => m.Id == mateId);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0? true: false;
        }

        public bool UpdateMaterial(Material material)
        {
            _context.Update(material);
            return Save();
        }
    }
}
