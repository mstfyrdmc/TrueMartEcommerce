using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ProductColourController : Controller
    {
        ProductColourService pcs = new ProductColourService();
        public ActionResult Index()
        {
            return View(pcs.GetActive());
        }
        public ActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Insert(ProductColour item)
        {
            pcs.Add(item);
            return RedirectToAction("Index");
        }
        public ActionResult Update(Guid id)
        {
            return View(pcs.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(ProductColour item)
        {
            ProductColour renk = pcs.GetByID(item.ID);
            renk.Colour = item.Colour;
            pcs.Update(item);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(Guid id)
        {
            pcs.Remove(id);
            return RedirectToAction("Index");
        }


    }
}