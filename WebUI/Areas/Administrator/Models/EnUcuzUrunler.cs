using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Areas.Administrator.Models
{
    public class EnUcuzUrunler
    {
        public string UrunAdi { get; set; }
        public decimal? Price { get; set; }
        public int Stock { get; set; }
    }
}