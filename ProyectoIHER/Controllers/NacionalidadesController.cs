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
    public class NacionalidadesController : Controller
    {
        private ProyectoIHERContext db = new ProyectoIHERContext();

        // GET: Nacionalidades
        public ActionResult Index()
        {
            return View(db.Nacionalidads.ToList());
        }

        // GET: Nacionalidades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // GET: Nacionalidades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nacionalidades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NacionalidadID,Descripcion")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Nacionalidads.Add(nacionalidad);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nacionalidad);
        }

        // GET: Nacionalidades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // POST: Nacionalidades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NacionalidadID,Descripcion")] Nacionalidad nacionalidad)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nacionalidad).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nacionalidad);
        }

        // GET: Nacionalidades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            if (nacionalidad == null)
            {
                return HttpNotFound();
            }
            return View(nacionalidad);
        }

        // POST: Nacionalidades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nacionalidad nacionalidad = db.Nacionalidads.Find(id);
            db.Nacionalidads.Remove(nacionalidad);
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
