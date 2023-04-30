using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPersistence.EntityTypeConfiguration
{
    public class ModelConfiguration:IEntityTypeConfiguration<Model>
    {
        public void Configure(EntityTypeBuilder)
    }
}
