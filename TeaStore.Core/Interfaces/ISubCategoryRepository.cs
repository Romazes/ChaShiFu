using System.Collections.Generic;
using System.Threading.Tasks;
using TeaStore.Core.Entities;

namespace TeaStore.Core.Interfaces
{
    public interface ISubCategoryRepository : IAsyncRepository<SubCategory>
    {
        Task<List<string>> GetAllListOrderedUnique();
    }
}
