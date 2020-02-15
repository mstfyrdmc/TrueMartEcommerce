using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Areas.Administrator.Models
{
    public class KullanicilarHangiSehirden
    {
        public string UserName { get; set; }
        public string ProvinceName { get; set; }
        public string TownName { get; set; }
        public bool IsAdmin { get; set; }

        public DateTime BirthDate { get; set; }
    }
}