﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity.Enum
{
   public interface IEntity<T>
    {
        T ID { get; set; }
    }
}
