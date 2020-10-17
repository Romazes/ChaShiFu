using System;
using System.Collections.Generic;
using System.Text;

namespace TeaStore.Core.Entities.WeightAggregate
{
    public class WeightCatalogItem
    {
        public int WeightId { get; set; }
        public Weight Weight { get; set; }

        public int CatalogItemId { get; set; }
        public CatalogItem CatalogItem { get; set; }
    }
}
