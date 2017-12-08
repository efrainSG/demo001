using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using tiendas.Models;

namespace tiendas.Controllers
{
    public class propietariosController : Controller
    {
        private TiendasEntities db = new TiendasEntities();

        // GET: propietarios
        public ActionResult Index()
        {
            return View(db.propietarios.ToList());
        }

        // GET: propietarios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propietario propietario = db.propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // GET: propietarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: propietarios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,telefono,direccion,correo,passwd,registro")] propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.propietarios.Add(propietario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(propietario);
        }

        // GET: propietarios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propietario propietario = db.propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: propietarios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,telefono,direccion,correo,passwd,registro")] propietario propietario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(propietario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(propietario);
        }

        // GET: propietarios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            propietario propietario = db.propietarios.Find(id);
            if (propietario == null)
            {
                return HttpNotFound();
            }
            return View(propietario);
        }

        // POST: propietarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            propietario propietario = db.propietarios.Find(id);
            db.propietarios.Remove(propietario);
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
