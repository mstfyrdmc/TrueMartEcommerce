﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
   public class Category : CoreEntity
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
