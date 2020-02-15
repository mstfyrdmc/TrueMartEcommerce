using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ImageMap : CoreMap<Image>
    {
        public ImageMap()
        {
            ToTable("dbo.Image");
            Property(x => x.ImagePath).HasMaxLength(150).IsOptional();
            Property(x => x.ProductID).IsOptional();
        }
    }
}
