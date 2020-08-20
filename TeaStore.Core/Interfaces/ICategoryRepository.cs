using System;
using System.Collections.Generic;
using System.Text;
using TeaStore.Core.Entities;

namespace TeaStore.Core.Interfaces
{
    public interface ICategoryRepository : IAsyncRepository<Category>
    {
    }
}
