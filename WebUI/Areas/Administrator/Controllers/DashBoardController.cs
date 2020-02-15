using Core.Entity.Enum;
using Model.Context;
using Model.Entities;
using Service.Option;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using WebUI.Areas.Administrator.Models;

namespace WebUI.Areas.Administrator.Controllers
{
    public class DashBoardController : Controller
    {
        
        ProductService ps = new ProductService();
        AppUserService ap = new AppUserService();
        OrderService os = new OrderService();
        OrderDetailService ods = new OrderDetailService();
        ProductCommentService pcs = new ProductCommentService();
        CategoryService cs = new CategoryService();
        ProjectContext db = new ProjectContext();
      
        public ActionResult Index()
        {
            
            ViewBag.Product = ps.GetActive();
            ViewBag.AppUser = ap.GetActive();
            ViewBag.Order = os.GetActive();
            ViewBag.OrderDetail = ods.GetActive();
            ViewBag.Comment = pcs.GetActive();

            
            DashBoardViewModel dashBoard = new DashBoardViewModel();

            dashBoard.ToplamMusteriSayisi = ap.context.AppUsers.Count(m=> m.IsAdmin==false && m.Status != Status.Deleted);
            dashBoard.ToplamSaticiSayisi = ap.context.AppUsers.Count(m => m.IsAdmin == true && m.Status!=Status.Deleted);
            dashBoard.ToplamUyeSayisi = ap.context.AppUsers.Count(m => m.Status != Status.Deleted);
            dashBoard.ToplamUrunSayisi = ap.context.Products.Count(m=> m.Status!=Status.Deleted);
            dashBoard.ToplamSiparisSayisi = os.context.Orders.Count(m => m.Status != Status.Deleted);
            dashBoard.ToplamYorumSayisi = pcs.context.ProductComments.Count(m => m.Status != Status.Deleted);



           
            return View(dashBoard);
        }

       public ActionResult Tablolar()
        {
            ViewBag.Product = ps.GetActive();
            ViewBag.AppUser = ap.GetActive();
            ViewBag.Order = os.GetActive();
            ViewBag.OrderDetail = ods.GetActive();
            ViewBag.Comment = pcs.GetActive();

            IEnumerable<EncokSatilanUrun> uruns = db.OrderDetails.GroupBy(g => g.ProductID).Select(s => new EncokSatilanUrun()
            {
                Adi = s.FirstOrDefault().Product.ProductName,
                Adet = s.Sum(m => (int)m.Quentity),
                Price = s.Sum(m => m.Price)
            }).OrderByDescending(o => o.Adet).Take(5).ToList();


            IEnumerable<EnCokYorumAlanUrun> comment = db.ProductComments.GroupBy(m => m.ProductID).Select(s => new EnCokYorumAlanUrun()
            {
                UrunAdi = s.FirstOrDefault().Product.ProductName,
                BegeniSayisi = s.Sum(m => m.ProductLikes),
                YorumSayisi = s.GroupBy(m => m.ProductID).FirstOrDefault().Count()

            }).OrderByDescending(o => o.BegeniSayisi).Take(5).ToList();

            IEnumerable<EnCokAlisVerisYapanKullanici> user = db.Orders.GroupBy(m => m.AppUserID).Select(s => new EnCokAlisVerisYapanKullanici()
            {
                UserName = s.FirstOrDefault().AppUser.UserName,
                SiparisSayisi = s.GroupBy(m => m.AppUserID).FirstOrDefault().Count()
            }).OrderByDescending(o => o.SiparisSayisi).ToList();


            IEnumerable<KullanicilarHangiSehirden> city = db.AppUsers.GroupBy(m => m.ID).Select(s => new KullanicilarHangiSehirden()
            {

                UserName = s.FirstOrDefault().UserName,
                ProvinceName = s.FirstOrDefault().Province.ProvinceName,
                TownName=s.FirstOrDefault().Town.TownName,
                IsAdmin = s.Any(m=> m.IsAdmin),
                BirthDate=s.FirstOrDefault().BirthDate
                
            }).ToList();

           
            return View(Tuple.Create<IEnumerable<EncokSatilanUrun>, IEnumerable<EnCokYorumAlanUrun>, IEnumerable<EnCokAlisVerisYapanKullanici>,IEnumerable<KullanicilarHangiSehirden>>(uruns, comment, user,city));
        }
       
        public ActionResult Urunler()
        {
         
            IEnumerable<EnPahaliUrunler> pahali = db.Products.GroupBy(m => m.ID).Select(s => new EnPahaliUrunler()
            {
                UrunAdi = s.FirstOrDefault().ProductName,
                UrunFiyati = s.FirstOrDefault().Price,
                Stock=s.FirstOrDefault().UnitsInStock
            }).OrderByDescending(o=> o.UrunFiyati).Take(10).ToList();

            IEnumerable<EnUcuzUrunler> ucuz = db.Products.GroupBy(m => m.ID).Select(s => new EnUcuzUrunler()
            {
                UrunAdi = s.FirstOrDefault().ProductName,
                Price = s.FirstOrDefault().Price,
                Stock = s.FirstOrDefault().UnitsInStock
            }).Distinct().OrderBy(o=> o.Price).Take(10).ToList();

            IEnumerable<EnCokUrunSatilanKategori> kategori = db.OrderDetails.GroupBy(g=> g.Product.CategoryID).Select(p => new EnCokUrunSatilanKategori()
            {
                
                Adet = p.Sum(m=> (int)m.Quentity),
                KategoriAdi = p.FirstOrDefault().Product.Category.CategoryName
            }).OrderBy(a=> a.Adet).ToList();


            IEnumerable<EnCokTercihEdilenKargoFirmalari> kargo = db.Orders.GroupBy(g => g.ShipperID).Select(k => new EnCokTercihEdilenKargoFirmalari()
            {
                KargoFirmalari= k.FirstOrDefault().Shipper.ShipperName,
                Sayi=k.GroupBy(m=> m.AppUserID).Count(),

                
            }).OrderByDescending(x=> x.Sayi).ToList();

            

            return View(Tuple.Create<IEnumerable<EnPahaliUrunler>,IEnumerable<EnUcuzUrunler>,IEnumerable<EnCokUrunSatilanKategori>,IEnumerable<EnCokTercihEdilenKargoFirmalari>>(pahali,ucuz,kategori,kargo));
        }
        public ActionResult Satici()
        {
            IEnumerable<SaticiKazanc> kazanc = db.OrderDetails.GroupBy(g => g.Product.AppUserID).Select(s => new SaticiKazanc()
            {
                SaticiAdi=s.FirstOrDefault().Product.AppUser.Name,
                Kazanci = s.Sum(m=> (int)m.Price)
            }).OrderByDescending(o => o.Kazanci).ToList();


            IEnumerable<UrunlerdenGelenGelir> gelir = db.OrderDetails.GroupBy(g => g.ProductID).Select(s => new UrunlerdenGelenGelir()
            {
                UrunAdi = s.FirstOrDefault().Product.ProductName,
                SatisAdedi = s.Sum(m => (int)m.Quentity),
                ToplamKazanc = s.Sum(m => (decimal)m.Price)
            }).OrderByDescending(o => o.ToplamKazanc).ToList();

            IEnumerable<SaticilarinSattigiUrunler> urunler = db.OrderDetails.GroupBy(g => g.ProductID).Select(s => new SaticilarinSattigiUrunler()
            {
                SaticiAdi=s.FirstOrDefault().Product.AppUser.Name,
                UrunAdi=s.FirstOrDefault().Product.ProductName,
                SatisAdedi=s.Sum(m=> (int)m.Quentity)
            }).ToList();

            IEnumerable<EnCokSatanMarkalar> marka = db.OrderDetails.GroupBy(g => g.Product.BrandID).Select(p => new EnCokSatanMarkalar()
            {
                MarkaAdi=p.FirstOrDefault().Product.Brand.BrandName,
                SatisAdedi=p.Sum(m=> (int)m.Quentity)
                
            }).OrderByDescending(a => a.SatisAdedi).ToList();

            return View(Tuple.Create<IEnumerable<SaticiKazanc>,IEnumerable<UrunlerdenGelenGelir>,IEnumerable<SaticilarinSattigiUrunler>,IEnumerable<EnCokSatanMarkalar>>(kazanc,gelir,urunler,marka));
        }
    }
}