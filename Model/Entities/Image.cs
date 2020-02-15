using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Image : CoreEntity
    {
        public Guid ProductID { get; set; }
        public string ImagePath { get; set; }

        public virtual Product Product { get; set; }
    }
}
