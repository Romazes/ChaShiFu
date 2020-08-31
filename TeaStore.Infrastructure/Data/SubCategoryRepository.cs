using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.Infrastructure.Data
{
    public class SubCategoryRepository : EfRepository<SubCategory>, ISubCategoryRepository
    {
        SubCategory sb = new SubCategory();

        public SubCategoryRepository(ApplicationDbContext context) : base(context) { }

        public override async Task<IEnumerable<SubCategory>> GetAll()
        {
            return await Context.Set<SubCategory>().Include(c => c.Category).ToListAsync();
        }

        public async Task<List<string>> GetAllListUniqueOrderBy()
        {
            return await Context.Set<SubCategory>().OrderBy(n => n.Name).Select(n => n.Name)
                .Distinct().ToListAsync();
        }

        //public ValueTask<T> GetById(int id) => Context.Set<T>().FindAsync(id);
        public async Task<SubCategory> GetByCategoryId(int id)
        {
             return await Context.Set<SubCategory>().Include(c => c.Category).SingleOrDefaultAsync(i => i.Id == id);
        }
    }
}
