using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Areas.Administrator.Models
{
    public class UrunlerdenGelenGelir
    {
        public string UrunAdi { get; set; }
        public int SatisAdedi { get; set; }
        public decimal ToplamKazanc { get; set; }
    }
}