using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class SiteEmployeeMap : CoreMap<SiteEmployee>
    {
        public SiteEmployeeMap()
        {
            ToTable("dbo.SiteEmployees");
            Property(x => x.Name).IsOptional();
            Property(x => x.LastName).IsOptional();
            Property(x => x.BirthDate).HasColumnType("date").IsOptional();
            Property(x => x.HireDate).HasColumnType("date").IsOptional();
            Property(x => x.TownID).IsOptional();
            Property(x => x.ProvinceID).IsOptional();
            Property(x => x.ID).IsOptional();
            Property(x => x.Profession).HasMaxLength(50).IsOptional();

            
        }
    }
}
