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
    public class GestionUsuariosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: GestionUsuarios
        public ActionResult Index()
        {
            var gestionUsuarios = db.GestionUsuarios.Include(g => g.Estado);
            return View(gestionUsuarios.ToList());
        }

        // GET: GestionUsuarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionUsuarios gestionUsuarios = db.GestionUsuarios.Find(id);
            if (gestionUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(gestionUsuarios);
        }

        // GET: GestionUsuarios/Create
        public ActionResult Create()
        {
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "EstadoName");
            return View();
        }

        // POST: GestionUsuarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GestionUsuarioID,NombreUsuario,UserName,Telefono,Direccion,RolID,Email,Password,FechaCreacion,FechaVencimiento,EstadoID")] GestionUsuarios gestionUsuarios)
        {
            if (ModelState.IsValid)
            {
               
                gestionUsuarios.FechaCreacion = DateTime.Now;
                gestionUsuarios.FechaVencimiento = DateTime.Now.AddMonths(3);
                db.GestionUsuarios.Add(gestionUsuarios);
                db.SaveChanges();
                return RedirectToAction("ChangePassword","Manage");
            }
            
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "EstadoName", gestionUsuarios.EstadoID);
            return View(gestionUsuarios);
        }

        // GET: GestionUsuarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionUsuarios gestionUsuarios = db.GestionUsuarios.Find(id);
            if (gestionUsuarios == null)
            {
                return HttpNotFound();
            }
            ViewBag.RolID = new SelectList(db.Rols, "RoID", "RolName", gestionUsuarios.RolID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "EstadoName", gestionUsuarios.EstadoID);
            return View(gestionUsuarios);
        }

        // POST: GestionUsuarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GestionUsuarioID,NombreUsuario,UserName,Telefono,Direccion,RolID,Email,Password,FechaCreacion,FechaVencimiento,EstadoID")] GestionUsuarios gestionUsuarios)
        {
            if (ModelState.IsValid)
            {
                gestionUsuarios.FechaCreacion = DateTime.Now;
                gestionUsuarios.FechaVencimiento = DateTime.Now.AddMonths(3);
                db.Entry(gestionUsuarios).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            

          
            ViewBag.RolID = new SelectList(db.Rols, "RoID", "RolName", gestionUsuarios.RolID);
            ViewBag.EstadoID = new SelectList(db.Estadoes, "EstadoID", "EstadoName", gestionUsuarios.EstadoID);
            return View(gestionUsuarios);
        }

        // GET: GestionUsuarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GestionUsuarios gestionUsuarios = db.GestionUsuarios.Find(id);
            if (gestionUsuarios == null)
            {
                return HttpNotFound();
            }
            return View(gestionUsuarios);
        }

        // POST: GestionUsuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GestionUsuarios gestionUsuarios = db.GestionUsuarios.Find(id);
            db.GestionUsuarios.Remove(gestionUsuarios);
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
