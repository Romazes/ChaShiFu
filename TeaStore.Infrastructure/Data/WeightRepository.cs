using TeaStore.Core.Entities;
using TeaStore.Core.Interfaces;

namespace TeaStore.Infrastructure.Data
{
    public class WeightRepository : EfRepository<Weight>, IWeightRepository
    {
        public WeightRepository(ApplicationDbContext context) : base(context) { }
    }
}
