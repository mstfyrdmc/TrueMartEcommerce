﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class ProductSize : CoreEntity
    {
        public string Size { get; set; }

        public virtual List<ProductDetail> ProductDetails { get; set; }
    }
}
