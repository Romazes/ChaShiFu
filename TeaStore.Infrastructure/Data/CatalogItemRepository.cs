using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.Infrastructure.Data
{
    public class CatalogItemRepository : EfRepository<CatalogItem>, ICatalogItemRepository
    {
        public CatalogItemRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<CatalogItem>> GetAll()
        {
            return await Context.Set<CatalogItem>().Include(c => c.Category)
                .Include(sc => sc.SubCategory).ToListAsync();

        }
    }
}