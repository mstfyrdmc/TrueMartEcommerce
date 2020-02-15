using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebUI.Areas.Administrator.Models
{
    public class DashBoardViewModel
    {
        public int ToplamUrunSayisi { get; set; }
        public int ToplamMusteriSayisi { get; set; }
        public int ToplamSaticiSayisi { get; set; }
        public int ToplamUyeSayisi { get; set; }

        public int ToplamSiparisSayisi { get; set; }
        public int ToplamYorumSayisi { get; set; }

       

    }
}