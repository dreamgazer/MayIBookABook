using Mayibookabook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mayibookabook.Controllers
{
    public class HomeController : Controller
    {
        private bookDB db = new bookDB();
        public ActionResult Index()
        {
            if (Session["ID"] != null && Session["name"] != null && Session["contact"] != null) { 
                return View();
            }
            return RedirectToAction("Indexlogin");
        }
        public ActionResult Indexlogin()
        {
            return View();
        }
        public ActionResult Indexlogin1([Bind(Include = "ID,name,contact")] borrowerinfo logininfo)
        {
            if (ModelState.IsValid)
            {
                Session["ID"] = logininfo.ID;
                Session["contact"] = logininfo.contact;
                Session["name"] = logininfo.name;
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "使用中有任何问题或者建议欢迎联系我们：";
            return View();
 
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "使用中有任何问题或者建议欢迎联系我们：";

            return View();
        }
        public ActionResult Borrow()
        {
            if (Session["ID"] != null && Session["name"] != null && Session["contact"] != null)
                return View(db.books.ToList());
            else
                return RedirectToAction("Indexlogin");
             
        }
        public ActionResult Lend()
        {
            if (Session["ID"] != null && Session["name"] != null && Session["contact"] != null)
                return View();
            else
                return RedirectToAction("Indexlogin");

        }
    }
}