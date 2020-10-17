using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TeaStore.Core.Entities;
using TeaStore.Core.Entities.WeightAggregate;

namespace TeaStore.Infrastructure.Data.Config
{
    public class WeightConfiguration : IEntityTypeConfiguration<Weight>
    {
        public void Configure(EntityTypeBuilder<Weight> builder)
        {



        }
    }
}
