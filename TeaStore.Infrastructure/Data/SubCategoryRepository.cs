using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.Infrastructure.Data
{
    public class SubCategoryRepository : EfRepository<SubCategory>, ISubCategoryRepository
    {
        public SubCategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
