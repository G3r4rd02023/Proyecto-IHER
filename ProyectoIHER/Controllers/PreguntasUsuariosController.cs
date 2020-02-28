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
    public class PreguntasUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PreguntasUsuarios
        public ActionResult Index()
        {
            var preguntasUsuarios = db.PreguntasUsuarios.Include(p => p.Preguntas);
            return View(preguntasUsuarios.ToList());
        }

        // GET: PreguntasUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntasUsuario preguntasUsuario = db.PreguntasUsuarios.Find(id);
            if (preguntasUsuario == null)
            {
                return HttpNotFound();
            }
            return View(preguntasUsuario);
        }

        // GET: PreguntasUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.PreguntaID = new SelectList(db.Preguntas, "PreguntaID", "NombrePregunta");
            return View();
        }

        // POST: PreguntasUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PreguntasUsuarioID,Respuesta,PreguntaID,AspNetUserID,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] PreguntasUsuario preguntasUsuario)
        {
            if (ModelState.IsValid)
            {
                preguntasUsuario.AspNetUserID = User.Identity.GetUserName();
                preguntasUsuario.CreadoPor = User.Identity.GetUserName();
                preguntasUsuario.FechaCreacion = DateTime.Now;
                preguntasUsuario.ModificadoPor = User.Identity.GetUserName();
                preguntasUsuario.FechaModificacion = DateTime.Now;
                db.PreguntasUsuarios.Add(preguntasUsuario);
                db.SaveChanges();
                return RedirectToAction("SetPassword","Manage");
            }

            ViewBag.PreguntaID = new SelectList(db.Preguntas, "PreguntaID", "NombrePregunta", preguntasUsuario.PreguntaID);
            return View(preguntasUsuario);
        }

        // GET: PreguntasUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntasUsuario preguntasUsuario = db.PreguntasUsuarios.Find(id);
            if (preguntasUsuario == null)
            {
                return HttpNotFound();
            }
            ViewBag.PreguntaID = new SelectList(db.Preguntas, "PreguntaID", "NombrePregunta", preguntasUsuario.PreguntaID);
            return View(preguntasUsuario);
        }

        // POST: PreguntasUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PreguntasUsuarioID,Respuesta,PreguntaID,AspNetUserID,CreadoPor,FechaCreacion,ModificadoPor,FechaModificacion")] PreguntasUsuario preguntasUsuario)
        {
            if (ModelState.IsValid)
            {
                preguntasUsuario.AspNetUserID = User.Identity.GetUserName();
                preguntasUsuario.CreadoPor = User.Identity.GetUserName();
                preguntasUsuario.FechaCreacion = DateTime.Now;
                preguntasUsuario.ModificadoPor = User.Identity.GetUserName();
                preguntasUsuario.FechaModificacion = DateTime.Now;
                db.Entry(preguntasUsuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PreguntaID = new SelectList(db.Preguntas, "PreguntaID", "NombrePregunta", preguntasUsuario.PreguntaID);
            return View(preguntasUsuario);
        }

        // GET: PreguntasUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PreguntasUsuario preguntasUsuario = db.PreguntasUsuarios.Find(id);
            if (preguntasUsuario == null)
            {
                return HttpNotFound();
            }
            return View(preguntasUsuario);
        }

        // POST: PreguntasUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PreguntasUsuario preguntasUsuario = db.PreguntasUsuarios.Find(id);
            db.PreguntasUsuarios.Remove(preguntasUsuario);
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
