using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoIHER.Models;

namespace ProyectoIHER.Controllers
{
    public class BitacorasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Bitacoras
        public ActionResult Index()
        {
            var bitacoras = db.Bitacoras.Include(b => b.Objeto);
            return View(bitacoras.ToList());
        }

        // GET: Bitacoras/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacoras.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            return View(bitacora);
        }

        // GET: Bitacoras/Create
        public ActionResult Create()
        {
            ViewBag.ObjetoID = new SelectList(db.Objetoes, "ObjetoID", "ObejtoName");
            return View();
        }

        // POST: Bitacoras/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BitacoraID,Fecha,AspNetUserID,ObjetoID,Accion,Descripcion")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Bitacoras.Add(bitacora);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ObjetoID = new SelectList(db.Objetoes, "ObjetoID", "ObejtoName", bitacora.ObjetoID);
            return View(bitacora);
        }

        // GET: Bitacoras/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacoras.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            ViewBag.ObjetoID = new SelectList(db.Objetoes, "ObjetoID", "ObejtoName", bitacora.ObjetoID);
            return View(bitacora);
        }

        // POST: Bitacoras/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BitacoraID,Fecha,AspNetUserID,ObjetoID,Accion,Descripcion")] Bitacora bitacora)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bitacora).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ObjetoID = new SelectList(db.Objetoes, "ObjetoID", "ObejtoName", bitacora.ObjetoID);
            return View(bitacora);
        }

        // GET: Bitacoras/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bitacora bitacora = db.Bitacoras.Find(id);
            if (bitacora == null)
            {
                return HttpNotFound();
            }
            return View(bitacora);
        }

        // POST: Bitacoras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bitacora bitacora = db.Bitacoras.Find(id);
            db.Bitacoras.Remove(bitacora);
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
