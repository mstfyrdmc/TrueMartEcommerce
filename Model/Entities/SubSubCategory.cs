using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class SubSubCategory : CoreEntity
    {
        public Guid SubCategoryID { get; set; }
        public string SubSubCategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }


        public virtual SubCategory SubCategories { get; set; }
    }
}
