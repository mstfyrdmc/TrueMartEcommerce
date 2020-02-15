using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
   
    public class ProductCommentController : Controller
    {
        ProductCommentService pc = new ProductCommentService();
        ProductService ps = new ProductService();
        AppUserService aus = new AppUserService();
        public ActionResult Index()
        {
            return View(pc.GetAll());
        }
       
    }
}