using MaterialsExchange.Models;

namespace MaterialsExchange.Interfaces
{
    public interface IMaterialRepository
    {
        ICollection<Material> GetMaterials();
        Material GetMaterial(int id);
        bool MaterialExists(int mateId);

    }
}
