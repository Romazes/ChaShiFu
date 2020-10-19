using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.Infrastructure.Data
{
    public class CategoryRepository : EfRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApplicationDbContext context) : base(context) { }
    }
}
