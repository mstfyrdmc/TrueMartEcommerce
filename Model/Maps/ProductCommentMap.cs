using Core.Map;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Maps
{
   public class ProductCommentMap : CoreMap<ProductComment>
    {
        public ProductCommentMap()
        {
            ToTable("dbo.ProductComments");
            Property(m => m.Comment).IsOptional();
            Property(m => m.ProductLikes).IsOptional();
            Property(m => m.ProductID).IsOptional();
            Property(m => m.AppUserID).IsOptional();

        }
    }
}
