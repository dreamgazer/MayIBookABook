using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mayibookabook.Models;

namespace Mayibookabook.Controllers
{
    public class LendController : Controller
    {
        private newbookDB db = new newbookDB();

        // GET: newbooks/Create
        public ActionResult Index()
        {
            return View();
        }

        // POST: newbooks/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(book book)
        {
            return View();
        }

        public ActionResult Lendconfirm(book book)
        {
            book.lenderID = (int)Session["ID"];
            book.lendercontact = (string)Session["contact"];
            book.lendername = (string)Session["name"];
            Session["title"] = book.title;
            Session["author"] = book.author;
            Session["press"] = book.press;
            return View(book);
        }

        public ActionResult Lended(book book)
        {
            book.lenderID = (int)Session["ID"];
            book.lendercontact = (string)Session["contact"];
            book.lendername = (string)Session["name"];
            book.title = (string)Session["title"];
            book.author = (string)Session["author"];
            book.press = (string)Session["press"];
            db.books.Add(book);
            db.SaveChanges();
            Session["title"] =null;
            Session["author"] = null;
            Session["press"] = null;
            return View();

        }
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
