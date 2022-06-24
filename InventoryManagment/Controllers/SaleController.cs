using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagment.Controllers
{
    public class SaleController : Controller
    {
        Inventory_managmentEntities db = new Inventory_managmentEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<Sale> list = db.Sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<String> list = db.Products.Select(selector: x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult SaleProduct(Sale sa)
        {
            db.Sales.Add(sa);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            List<String> list = db.Products.Select(selector: x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }
        [HttpPost]
        public ActionResult Edit(int id, Sale sa)
        {
            Sale s = db.Sales.Where(x => x.id == id).SingleOrDefault();
            s.Sale_date = sa.Sale_date;
            s.Sale_prod = sa.Sale_prod;
            s.Sale_qnty = sa.Sale_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult SaleDetails(int id)
        {
            Sale sa = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sa);
        }

        [HttpGet]
        public ActionResult Deletesale(int id)
        {
            Sale sa = db.Sales.Where(x => x.id == id).SingleOrDefault();
            return View(sa);
        }
        [HttpPost]
        public ActionResult Deletesale(int id, Sale sa)
        {
            db.Sales.Remove(db.Sales.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }


    }


}