using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ProductDetailController : Controller
    {
        ProductDetailService pds = new ProductDetailService();
        ProductService ps = new ProductService();
        ProductSizeService pss = new ProductSizeService();
        ProductColourService pcs = new ProductColourService();
        public ActionResult Index()
        {

            return View(pds.GetActive());
        }
        public ActionResult Insert()
        {
            ViewBag.ProductID = new SelectList(ps.GetAll(), "ID", "ProductName");
            ViewBag.ProductSizeID = new SelectList(pss.GetAll(), "ID", "Size");
            ViewBag.ProductColourID = new SelectList(pcs.GetAll(), "ID", "Colour");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(ProductDetail item)
        {
            //size ve colr kaydolmuyor
            ViewBag.ProductID = new SelectList(ps.GetAll(), "ID", "ProductName", item.ProductID);
            ViewBag.ProductSizeID = new SelectList(pss.GetActive(), "ID", "Size", item.ProductSizeID);
            ViewBag.ProductColourID = new SelectList(pcs.GetActive(), "ID", "Colour", item.ProductColourID);

           
            if (ModelState.IsValid)
            {
                ProductDetail detay = new ProductDetail();
                detay.ID = Guid.NewGuid();
                detay.ProductColourID = item.ProductColourID;
                detay.ProductSizeID = item.ProductSizeID;
                detay.Description = item.Description;
                detay.ProductID = item.ProductID;

                bool sonuc = pds.Add(detay);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ürün Detayı ekleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Ürün Detayı işleminde bir hata oluştu";
            }
            return View();

        }
        public ActionResult Update(Guid id)
        {
            ViewBag.ProductID = new SelectList(ps.GetAll(), "ID", "ProductName");
            ViewBag.ProductSizeID = new SelectList(pss.GetActive(), "ID", "Size");
            ViewBag.ProductColourID = new SelectList(pcs.GetActive(), "ID", "Colour");
            return View(pds.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(ProductDetail item)
        {
            ViewBag.ProductID = new SelectList(ps.GetAll(), "ID", "ProductName", item.ProductID);
            ViewBag.ProductSizeID = new SelectList(pss.GetActive(), "ID", "Size", item.ProductSizeID);
            ViewBag.ProductColourID = new SelectList(pcs.GetActive(), "ID", "Colour", item.ProductColourID);

            ProductDetail guncellenecek = pds.GetByID(item.ID);
            guncellenecek.Description = item.Description;
            guncellenecek.ProductColourID = item.ProductColourID;
            guncellenecek.ProductID = item.ProductID;
            guncellenecek.ProductSizeID = item.ProductSizeID;
            guncellenecek.ID = item.ID;
            if (ModelState.IsValid)
            {
                bool sonuc = pds.Update(item);
                if (sonuc)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ürün Detayı güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Ürün Detayı güncelleme işleminde bir hata oluştu";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            pds.Remove(id);
            return RedirectToAction("Index");
        }
    }
}