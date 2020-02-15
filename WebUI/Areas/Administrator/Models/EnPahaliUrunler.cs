using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Areas.Administrator.Models
{
    public class EnPahaliUrunler
    {
        public string UrunAdi { get; set; }
        public decimal? UrunFiyati { get; set; }

        public int Stock { get; set; }
    }
}