using MaterialsExchange.Models;

namespace MaterialsExchange.Interfaces
{
    public interface IMaterialRepository
    {
        ICollection<Material> GetMaterials();
        Material GetMaterial(int id);
        bool MaterialExists(int mateId);
        bool CreateMaterial(Material material);
        bool Save();
        bool UpdateMaterial(Material material);
        bool DeleteMaterial(Material material);
    }
}
