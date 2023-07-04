using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Warehouse.EntityConfigurations
{
    class ProviderConfiguration : EntityTypeConfiguration<Provider>
    {
        public ProviderConfiguration()
        {
            HasKey(p => p.Id);

            Property(p => p.Name)
                .IsRequired();
        }
    }
}
