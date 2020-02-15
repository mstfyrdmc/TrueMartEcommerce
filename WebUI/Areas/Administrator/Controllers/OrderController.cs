using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class OrderController : Controller
    {
        OrderService os = new OrderService();
        AppUserService aus = new AppUserService();
        ShipperService ss = new ShipperService();
        OrderDetailService ods = new OrderDetailService();
        

       
        public ActionResult Index()
        {
            return View(os.GetAll());
        }
        
        
    }
}