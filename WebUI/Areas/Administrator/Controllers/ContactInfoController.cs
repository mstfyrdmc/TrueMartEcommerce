using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Areas.Administrator.Controllers
{
    public class ContactInfoController : Controller
    {
        ContactInfoService cs = new ContactInfoService();
        AppUserService aus = new AppUserService();
        ShipperService ss = new ShipperService();
        SiteEmployeeService sec = new SiteEmployeeService();
        SupplierService supser = new SupplierService();
        public ActionResult Index()
        {
            return View(cs.GetActive());
        }
        public ActionResult Insert()
        {
            ViewBag.AppUserID = new SelectList(aus.GetActive().Where(m=> m.IsAdmin==true), "ID", "UserName");
            ViewBag.ShipperID = new SelectList(ss.GetActive(), "ID", "ShipperName");
            ViewBag.SupplierID = new SelectList(supser.GetActive(), "ID", "CompanyName");
            ViewBag.SiteEmployeeID = new SelectList(sec.GetActive(), "ID", "Name",null);
            return View();
        }
        [HttpPost]
        public ActionResult Insert(ContactInfo item)
        {
            ViewBag.AppUserID = new SelectList(aus.GetActive().Where(m => m.IsAdmin == true), "ID", "UserName", item.AppUserID);
            ViewBag.ShipperID = new SelectList(ss.GetActive(), "ID", "ShipperName", item.ShipperID);
            ViewBag.SupplierID = new SelectList(supser.GetActive(), "ID", "CompanyName", item.SupplierID);
            ViewBag.SiteEmployeeID = new SelectList(sec.GetActive(), "ID", "Name", null, item.SiteEmployeeID);
           
            bool sonuc = cs.Add(item);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "İletişim bilgisi ekleme işlemi sırasında bir hata oluştu";
            }
            return View();
        }
        public ActionResult Update(Guid id)
        {
            ContactInfo guncellenecek = cs.GetByID(id);
            ViewBag.AppUserID = new SelectList(aus.GetActive().Where(m => m.IsAdmin == true), "ID", "UserName", guncellenecek.AppUserID);
            ViewBag.ShipperID = new SelectList(ss.GetActive(), "ID", "ShipperName", guncellenecek.ShipperID);
            ViewBag.SupplierID = new SelectList(supser.GetActive(), "ID", "CompanyName", guncellenecek.SupplierID);
            ViewBag.SiteEmployeeID = new SelectList(sec.GetActive(), "ID", "Name", guncellenecek.SiteEmployeeID);
            return View(guncellenecek);
        }
        [HttpPost]
        public ActionResult Update(ContactInfo item)
        {

            ViewBag.AppUserID = new SelectList(aus.GetActive().Where(m => m.IsAdmin == true), "ID", "UserName", item.AppUserID);
            ViewBag.ShipperID = new SelectList(ss.GetActive(), "ID", "ShipperName", item.ShipperID);
            ViewBag.SupplierID = new SelectList(supser.GetActive(), "ID", "CompanyName", item.ShipperID);
            ViewBag.SiteEmployee = new SelectList(sec.GetActive(), "ID", "Name", item.SiteEmployeeID);
            ContactInfo guncellenecek = cs.GetByID(item.ID);
            guncellenecek.Address = item.Address;
            guncellenecek.AppUserID = item.AppUserID;
            guncellenecek.EmailAddress = item.EmailAddress;
            guncellenecek.FaxNo = item.FaxNo;
            guncellenecek.PhoneNumber = item.PhoneNumber;
            guncellenecek.ShipperID = item.ShipperID;
            guncellenecek.SiteEmployeeID = item.SiteEmployeeID;
            guncellenecek.SupplierID = item.SupplierID;
            bool sonuc = cs.Update(guncellenecek);
            if (sonuc)
            {
                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Message = "Güncelleme işlemi esnasında bir problem yaşandı";
            }
            return View();
        }
        public ActionResult Delete(Guid id)
        {
            cs.Remove(id);
            return RedirectToAction("Index");
        }
    }
}