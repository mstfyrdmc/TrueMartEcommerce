using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class SubCategory : CoreEntity
    {
        public Guid CategoryID { get; set; }
        public string SubCategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }

        public virtual Category Category { get; set; }
    }
}
