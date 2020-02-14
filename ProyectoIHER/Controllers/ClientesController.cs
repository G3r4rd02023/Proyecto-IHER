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
    
    public class ClientesController : Controller
    {
        private ProyectoIHERContext db = new ProyectoIHERContext();

        // GET: Clientes
        [Authorize (Roles = "Ver")]
        public ActionResult Index()
        {
            var clientes = db.Clientes.Include(c => c.Nacionalidad);
            return View(clientes.ToList());
        }

        // GET: Clientes/Details/5
        [Authorize (Roles = "Ver")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // GET: Clientes/Create
        [Authorize (Roles = "Crear")]
        public ActionResult Create()
        {
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "Descripcion");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClienteID,ClienteRTN,ClienteNombre,ClienteApellido,Direccion,Telefono,Correo,NacionalidadID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Clientes.Add(cliente);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "Descripcion", cliente.NacionalidadID);
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        [Authorize (Roles = "Editar")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "Descripcion", cliente.NacionalidadID);
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClienteID,ClienteRTN,ClienteNombre,ClienteApellido,Direccion,Telefono,Correo,NacionalidadID")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cliente).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NacionalidadID = new SelectList(db.Nacionalidads, "NacionalidadID", "Descripcion", cliente.NacionalidadID);
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        [Authorize (Roles = "Eliminar")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cliente cliente = db.Clientes.Find(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Cliente cliente = db.Clientes.Find(id);
            db.Clientes.Remove(cliente);
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
