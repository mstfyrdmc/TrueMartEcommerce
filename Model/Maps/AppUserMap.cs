using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class AppUserMap : CoreMap<AppUser>
    {
        public AppUserMap()
        {
            ToTable("dbo.AppUsers");
            Property(m => m.UserName).HasMaxLength(50).IsRequired();
            Property(m => m.Name).HasMaxLength(50).IsRequired();
            Property(m => m.Surname).HasMaxLength(50).IsRequired();
            Property(m => m.Password).HasMaxLength(50).IsRequired();
            Property(m => m.BirthDate).HasColumnType("date").IsOptional();
            Property(m => m.IsAdmin).IsOptional();
            Property(m => m.EmailAdress).HasMaxLength(150).IsOptional();
            Property(m => m.Sex).IsOptional();
            


        }
    }
}
