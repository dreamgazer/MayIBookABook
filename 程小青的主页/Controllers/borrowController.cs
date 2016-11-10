using Mayibookabook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Data;
using PagedList;


namespace Mayibookabook.Controllers
{
    public class borrowController : Controller
    {
        private bookDB db = new bookDB();
        private borrowedbooksDB db2 = new borrowedbooksDB();
        public ActionResult Index(string searchString,int page=1,string success=null)
        {
            var results = from m in db.books
                         select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.title.Contains(searchString));
            }
            ViewBag.success = success;
            return View(results.OrderBy(p => p.title).ToPagedList(page, 20));
        }

        public ActionResult choose(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }
        [HttpPost, ActionName("Choose")]
        [ValidateAntiForgeryToken]
        public ActionResult ChooseConfirmed(int id)
        {
            book book = db.books.Find(id);
           
            if (Session["ID"] != null && Session["name"] != null && Session["contact"] != null)
            {
                book tempbook = new book
                {
                    borrowerID = (int)Session["ID"],
                    borrowercontact = (string)Session["contact"],
                    borrowername = (string)Session["name"],
                   // ID = db2.books.Select(e => e.ID).Max()+1,
                    title = book.title,
                    author = book.author,
                    press = book.press,
                    lenderID = book.lenderID,
                    lendername = book.lendername,
                    lendercontact = book.lendercontact
                };
                db2.books.Add(tempbook);
                db2.SaveChanges();
                db.books.Remove(book);
                db.SaveChanges();
                return RedirectToAction("Index", new { success = "借书成功,请尽快与出借者联系！" });
            }
            return RedirectToAction("Indexlogin", "Home");
        }

    }
}