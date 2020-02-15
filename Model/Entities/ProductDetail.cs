using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class ProductDetail : CoreEntity
    {

        public Guid? ProductSizeID { get; set; }
        public Guid? ProductColourID { get; set; }
        public Guid ProductID { get; set; }
        public string Description { get; set; }

        public virtual Product Product { get; set; }
        public virtual ProductSize ProductSize { get; set; }
        public virtual ProductColour ProductColour { get; set; }
    }
}
