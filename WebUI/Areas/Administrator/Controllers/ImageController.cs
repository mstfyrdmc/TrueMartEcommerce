using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebUI.Models;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ImageController : Controller
    {
        ImageService ImageService = new ImageService();
        ProductService ps = new ProductService();
        public ActionResult Index()
        {
            ViewBag.ProductID = new SelectList(ps.GetActive(), "ID", "ProductName");
            return View(ImageService.GetAll());
        }
        public ActionResult Insert()
        {
            ViewBag.ProductID = new SelectList(ps.GetActive(), "ID", "ProductName");
            return View();
        }
        [HttpPost]
        public ActionResult Insert(Image item,HttpPostedFileBase fluResim)
        {
            ViewBag.ProductID = new SelectList(ps.GetActive(), "ID", "ProductName",item.ProductID);
            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.ProductImage, out sonuc);
                
                if (sonuc)
                {
                    item.ImagePath = fileResult;
                    bool eklemeSonucu = ImageService.Add(item);
                    if (eklemeSonucu)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ViewBag.Message = "Ekleme sırasında bir hata oluştu.";
                    }

                }
                else
                {
                    ViewBag.Message = fileResult;
                }
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            Image guncellenecek = ImageService.GetByID(id);

            ViewBag.ProductID = new SelectList(ps.GetActive(), "ID", "ProductName",guncellenecek.ProductID );

            return View(ImageService.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(Image item,HttpPostedFileBase fluResim)
        {
            ViewBag.ProductID = new SelectList(ps.GetActive(), "ID", "ProductName", item.ProductID);

            Image guncellenecek = ImageService.GetByID(item.ID);
            guncellenecek.ImagePath = item.ImagePath;
            guncellenecek.ProductID = item.ProductID;
            if (ModelState.IsValid)
            {
                if (fluResim != null)
                {
                    bool sonuc;
                    string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.ProductImage, out sonuc);
                    if (sonuc)
                    {
                        guncellenecek.ImagePath = fileResult;
                    }
                }
                bool eklemeSonucu = ImageService.Update(guncellenecek);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Categori güncelleme işleminde bir hata oluştu";
                }
            }
            else
            {
                ViewBag.Message = "Girmiş olduğunuz bilgileri kontrol ediniz";
            }

            return View();
        }
        public ActionResult Delete(Guid id)
        {
            ImageService.Remove(id);
            return RedirectToAction("Index");
        }
    }
}