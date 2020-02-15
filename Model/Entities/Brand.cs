using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Brand : CoreEntity
    {
        public string BrandName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual List<Product> Products { get; set; }
      
    }
}
