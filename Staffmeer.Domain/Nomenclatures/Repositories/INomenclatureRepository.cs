
using Staffmeer.Persistent.Models;

namespace Staffmeer.Domain.Nomenclatures.Repositories
{
    public interface INomenclatureRepository
    {
        Task<Nomenclature> GetNomenclature(int id);
        Task<Nomenclature[]> GetNomenclatures(int[] ids);
    }
}
