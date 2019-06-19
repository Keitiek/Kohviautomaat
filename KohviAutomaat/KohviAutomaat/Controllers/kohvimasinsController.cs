using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KohviAutomaat.Models;

namespace KohviAutomaat.Controllers
{
    public class kohvimasinsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        [Authorize]
        public ActionResult Hooldus()
        {
            return View(db.kohvimasins.ToList());
        }
        public ActionResult klient()
        {
            var model = db.kohvimasins.Where(m => m.Topsejuua > 0 ).ToList();
            return View(model);
        }

        // GET: kohvimasins/Joojook
        public ActionResult Joo(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kohvimasin kohvimasin = db.kohvimasins.Find(id);
            if (kohvimasin == null)
            {
                return HttpNotFound();
            }
            kohvimasin.Topsejuua--;
            db.Entry(kohvimasin).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Klient");
       
        }
        [Authorize]
        // GET: kohvimasins/Täitepakk
        public ActionResult Täitepakk(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kohvimasin kohvimasin = db.kohvimasins.Find(id);
            if (kohvimasin == null)
            {
                return HttpNotFound();
            }
            kohvimasin.Topsejuua += kohvimasin.Täitepakis;
            db.Entry(kohvimasin).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Hooldus");

        }

        // GET: kohvimasins
        public ActionResult Index()
        {
            return View(db.kohvimasins.ToList());
        }

        // GET: kohvimasins/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kohvimasin kohvimasin = db.kohvimasins.Find(id);
            if (kohvimasin == null)
            {
                return HttpNotFound();
            }
            return View(kohvimasin);
        }

        // GET: kohvimasins/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kohvimasins/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Jooginimi,Täitepakis,Topsejuua")] kohvimasin kohvimasin)
        {
            if (ModelState.IsValid)
            {
                db.kohvimasins.Add(kohvimasin);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kohvimasin);
        }

        // GET: kohvimasins/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kohvimasin kohvimasin = db.kohvimasins.Find(id);
            if (kohvimasin == null)
            {
                return HttpNotFound();
            }
            return View(kohvimasin);
        }

        // POST: kohvimasins/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,jooginimi,Täitepakis,topsejuua")] kohvimasin kohvimasin)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kohvimasin).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kohvimasin);
        }

        // GET: kohvimasins/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            kohvimasin kohvimasin = db.kohvimasins.Find(id);
            if (kohvimasin == null)
            {
                return HttpNotFound();
            }
            return View(kohvimasin);
        }

        // POST: kohvimasins/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            kohvimasin kohvimasin = db.kohvimasins.Find(id);
            db.kohvimasins.Remove(kohvimasin);
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
