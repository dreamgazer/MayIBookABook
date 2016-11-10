using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mayibookabook.Models;
using PagedList;

namespace Mayibookabook.Controllers
{
    [Authorize]
    public class newbookmanageController : Controller
    {
        private newbookDB db = new newbookDB();
        private bookDB db2 = new bookDB();

        // GET: manage
        public ActionResult Index(string searchString, int page = 1)
        {
            var results = from m in db.books
                          select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                results = results.Where(s => s.title.Contains(searchString));
            }
            return View(results.OrderBy(p => p.ID).ToPagedList(page, 15));
        }

        public ActionResult choose(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            book book = db.books.Find(id);
            book tempbook = new book
            {
                ID = db2.books.Select(e => e.ID).Max()+1,
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
            return RedirectToAction("Index");
        }

        // GET: manage/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: manage/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,grade,title,author,press,lenderID,lendername,lendercontact")] book book)
        {
            if (ModelState.IsValid)
            {
                db.books.Add(book);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: manage/Edit/5
        public ActionResult Edit(int? id)
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

        // POST: manage/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 http://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,grade,title,author,press,lenderID,lendername,lendercontact")] book book)
        {
            if (ModelState.IsValid)
            {
                db.Entry(book).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: manage/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: manage/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            book book = db.books.Find(id);
            db.books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
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
