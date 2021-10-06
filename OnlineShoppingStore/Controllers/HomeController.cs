using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineShoppingStore.DAL;
using OnlineShoppingStore.Models;

namespace OnlineShoppingStore.Controllers
{
    public class HomeController : Controller
    {

        ProductServices db = new ProductServices();
        public ActionResult Index()
        {  
            
            return View(db.GetData());
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(ProductModel e)
        {
            db.Add(e);
            ModelState.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            var row = db.GetData().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Delete(ProductModel obj)
        {
            db.Del(obj);
            return RedirectToAction("Index");
        }


        public ActionResult Edit(int id)
        {
            var row = db.GetData().Find(model => model.Id == id);
            return View(row);
        }

        [HttpPost]
        public ActionResult Edit(ProductModel obj)
        {
            db.Update(obj);
            return RedirectToAction("Index");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}