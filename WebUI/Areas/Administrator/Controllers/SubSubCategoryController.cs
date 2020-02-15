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
    public class SubSubCategoryController : Controller
    {
        SubSubCategoryService altaltkategori = new SubSubCategoryService();
        SubCategoryService altkatagori = new SubCategoryService();
        public ActionResult Index()
        {
            return View(altaltkategori.GetAll());
        }
        public ActionResult Insert()
        {
            ViewBag.SubCategoryID = new SelectList(altkatagori.GetActive(), "ID", "SubCategoryName");
            return View();
        }

        [HttpPost]
        public ActionResult Insert(SubSubCategory item ,HttpPostedFileBase fluResim)
        {
            ViewBag.SubCategoryID = new SelectList(altkatagori.GetActive(), "ID", "SubCategoryName", item.SubCategoryID);
            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.SubSubCategory, out sonuc);
                if (sonuc)
                {
                    item.ImagePath = fileResult;
                }
                else
                {
                    ViewBag.Message = "Ekleme işleminde hata oluştu";
                }
                bool eklemeSonucu = altaltkategori.Add(item);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Ekleme işleminde sorun oluştu";
                }
            }
            return View();
        }

        public ActionResult Update(Guid id)
        {
            SubSubCategory subSubCategory = altaltkategori.GetByID(id);
            ViewBag.SubCategoryID = new SelectList(altkatagori.GetActive(), "ID", "SubCategoryName", subSubCategory.SubCategoryID);

            return View(altaltkategori.GetByID(id));
        }
        [HttpPost]
        public ActionResult Update(SubSubCategory item,HttpPostedFileBase fluResim)
        {
            ViewBag.SubCategoryID = new SelectList(altkatagori.GetActive(), "ID", "SubCategoryName", item.SubCategoryID);
            SubSubCategory guncellenecek = altaltkategori.GetByID(item.ID);
            guncellenecek.SubSubCategoryName = item.SubSubCategoryName;
            guncellenecek.Description = item.Description;
            guncellenecek.SubCategoryID = item.SubCategoryID;

            if (ModelState.IsValid)
            {
                bool sonuc;
                string fileResult = FxFunction.ImageUpload(fluResim, FolderPath.SubSubCategory, out sonuc);
                if (sonuc)
                {
                    item.ImagePath = fileResult;
                }
                else
                {
                    ViewBag.Message = "Güncelleme işleminde hata oluştu";
                }
                bool eklemeSonucu = altaltkategori.Update(item);
                if (eklemeSonucu)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Message = "Güncelleme işleminde sorun oluştu";
                }
            }
            return View();
        }
    }
}