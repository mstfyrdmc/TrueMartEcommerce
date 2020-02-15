using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Map
{
   public class CoreMap<T> : EntityTypeConfiguration<T> where T : CoreEntity
    {
        public CoreMap()
        {
            Property(x => x.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(x => x.CreatedIP).IsOptional();
            Property(x => x.CreatedDate).IsOptional();
            Property(x => x.ModifiedDate).IsOptional();
            Property(x => x.ModifiedIP).IsOptional();
            Property(x => x.Status).IsOptional();
        }
    }
}
