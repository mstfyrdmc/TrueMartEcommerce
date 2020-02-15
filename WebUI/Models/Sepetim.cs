using Core.Entity;
using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Models
{
    public class Sepetim 
    {
        public Guid AppUserID { get; set; }
        public Guid ID { get; set; }
        public string UrunAdi { get; set; }
        public decimal? Fiyati { get; set; }
        public int Adet { get; set; }
        public string Resim { get; set; }
        
    }
}