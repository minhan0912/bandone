using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class transactionsController : Controller
    {
        private QUANLITHOITRANGEntities db = new QUANLITHOITRANGEntities();

        // GET: Admin/transactions
        public ActionResult Index()
        {
            var transactions = db.transactions.Include(t => t.Account).Include(t => t.order);
            return View(transactions.ToList());
        }

        // GET: Admin/transactions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaction transaction = db.transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // GET: Admin/transactions/Create
        public ActionResult Create()
        {
            ViewBag.user_id = new SelectList(db.Accounts, "id", "UserName");
            ViewBag.id = new SelectList(db.orders, "id", "id");
            return View();
        }

        // POST: Admin/transactions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,status,user_id,user_name,user_email,user_phone,amount,dateorder,dateship")] transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.transactions.Add(transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.user_id = new SelectList(db.Accounts, "id", "UserName", transaction.user_id);
            ViewBag.id = new SelectList(db.orders, "id", "id", transaction.id);
            return View(transaction);
        }

        // GET: Admin/transactions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaction transaction = db.transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.user_id = new SelectList(db.Accounts, "id", "UserName", transaction.user_id);
            ViewBag.id = new SelectList(db.orders, "id", "id", transaction.id);
            return View(transaction);
        }

        // POST: Admin/transactions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,status,user_id,user_name,user_email,user_phone,amount,dateorder,dateship")] transaction transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.user_id = new SelectList(db.Accounts, "id", "UserName", transaction.user_id);
            ViewBag.id = new SelectList(db.orders, "id", "id", transaction.id);
            return View(transaction);
        }

        // GET: Admin/transactions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            transaction transaction = db.transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        // POST: Admin/transactions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            transaction transaction = db.transactions.Find(id);
            db.transactions.Remove(transaction);
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
