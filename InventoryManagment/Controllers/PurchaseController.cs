using InventoryManagment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InventoryManagment.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_managmentEntities db = new Inventory_managmentEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<Purchase> list = db.Purchases.OrderByDescending(x=>x.id).ToList();
            return View(list);
        }
        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<String> list = db.Products.Select(selector: x => x.product_name).ToList();
            ViewBag.ProductName= new SelectList(list);
            return View();
        }
        [HttpPost]
        public ActionResult PurchaseProduct(Purchase pur)
        {
            db.Purchases.Add(pur);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            List<String> list = db.Products.Select(selector: x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }
        [HttpPost]
        public ActionResult Edit(int id, Purchase pur)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            p.Purchase_date = pur.Purchase_date;
            p.purchase_prod = pur.purchase_prod;
            p.Purchase_qnty = pur.Purchase_qnty;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }


        [HttpGet]
        public ActionResult Details(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Purchase p = db.Purchases.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product p)
        {
            db.Purchases.Remove(db.Purchases.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }

}