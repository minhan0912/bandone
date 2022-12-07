using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Context;

namespace WebApplication2.Areas.Admin.Controllers
{
    public class products1Controller : Controller
    {
        private QUANLITHOITRANGEntities db = new QUANLITHOITRANGEntities();

        // GET: products1
        public ActionResult Index()
        {
            var products = db.products.Include(p => p.catalog);
            return View(products.ToList());
        }

        // GET: products1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: products1/Create
        public ActionResult Create()
        {
            ViewBag.catalog_id = new SelectList(db.catalogs, "id", "name");
            return View();
        }

        // POST: products1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Create([Bind(Include = "id,catalog_id,name,price,content,discount,created,views,image_link")] product product , HttpPostedFileBase image_link)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image_link.ContentLength>0)
                    {
                        string _FileName = Path.GetFileName(image_link.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), _FileName);
                        image_link.SaveAs(_path);
                        product.image_link = _FileName;
                    }
                    db.products.Add(product);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Message = "không thành công!!";
                }

            }

           
            ViewBag.Catalog_id = new SelectList(db.catalogs, "id", "name");
            return View(product);
        }

        // GET: products1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.catalog_id = new SelectList(db.catalogs, "id", "name", product.catalog_id);
            return View(product);

        }

        // POST: products1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult Edit([Bind(Include = "id,catalog_id,name,price,content,discount,created,views,image_link")] product product, HttpPostedFileBase image_link, FormCollection form)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (image_link != null)
                    {
                        string _FileName = Path.GetFileName(image_link.FileName);
                        string _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), _FileName);
                        image_link.SaveAs(_path);
                        product.image_link = _FileName;
                        // get Path of old image for deleting it
                        _path = Path.Combine(Server.MapPath("~/Content/hinhanh"), form["oldimage"]);
                        if (System.IO.File.Exists(_path))
                            System.IO.File.Delete(_path);

                    }
                    else
                        product.image_link = form["oldimage"];
                    db.Entry(product).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    ViewBag.Message = "không thành công!!";
                }

                return RedirectToAction("Index");
            }
            ViewBag.catalog_id = new SelectList(db.catalogs, "id", "name", product.catalog_id);
            return View(product);
        }

        // GET: products1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            product product = db.products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: products1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            product product = db.products.Find(id);
            db.products.Remove(product);
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
