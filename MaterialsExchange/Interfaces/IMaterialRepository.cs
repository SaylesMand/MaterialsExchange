using MaterialsExchange.Models;

namespace MaterialsExchange.Interfaces
{
    public interface IMaterialRepository
    {
        ICollection<Material> GetMaterials();
    }
}
