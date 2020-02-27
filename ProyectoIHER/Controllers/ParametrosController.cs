using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using ProyectoIHER.Models;

namespace ProyectoIHER.Controllers
{
    public class ParametrosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Parametros
        public ActionResult Index()
        {
            return View(db.Parametroes.ToList());
        }

        // GET: Parametros/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametroes.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return View(parametro);
        }

        // GET: Parametros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Parametros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParametroID,ParametroName,Valor,AspNetUserID,FechaCreacion,FechaModificacion")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
               
                parametro.AspNetUserID = User.Identity.GetUserName();
                parametro.FechaCreacion = DateTime.Now;
                parametro.FechaModificacion = DateTime.Now;
                db.Parametroes.Add(parametro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(parametro);
        }

        // GET: Parametros/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametroes.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return View(parametro);
        }

        // POST: Parametros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParametroID,ParametroName,Valor,AspNetUserID,FechaCreacion,FechaModificacion")] Parametro parametro)
        {
            if (ModelState.IsValid)
            {
                parametro.AspNetUserID = User.Identity.GetUserName();
                parametro.FechaCreacion = DateTime.Now;
                parametro.FechaModificacion = DateTime.Now;
                db.Entry(parametro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(parametro);
        }

        // GET: Parametros/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Parametro parametro = db.Parametroes.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            return View(parametro);
        }

        // POST: Parametros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Parametro parametro = db.Parametroes.Find(id);
            db.Parametroes.Remove(parametro);
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
