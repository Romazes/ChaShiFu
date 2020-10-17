using System;
using System.Collections.Generic;
using System.Text;
using TeaStore.Core.Entities.WeightAggregate;

namespace TeaStore.Core.Entities
{
    public class Weight : BaseEntity
    {
        public string Name { get; set; }

        public int Value { get; set; }

        public List<WeightCatalogItem> WeightMenuItems { get; set; }
    }
}
