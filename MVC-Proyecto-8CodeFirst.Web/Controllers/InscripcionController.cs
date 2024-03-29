﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD_Proyecto_8CodeFirst.Model.DAL;
using MVC_CRUD_Proyecto_8CodeFirst.Model.Models;

namespace MVC_Proyecto_8CodeFirst.Web.Controllers
{
    public class InscripcionController : Controller
    {
        private EstudianteContext db = new EstudianteContext();

        // GET: Inscripcion
        public ActionResult Index()
        {
            var inscripcion = db.Inscripcion.Include(i => i.Curso).Include(i => i.Estudiante);
            return View(inscripcion.ToList());
        }

        // GET: Inscripcion/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // GET: Inscripcion/Create
        public ActionResult Create()
        {
            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Descripcion");
            ViewBag.EstudianteID = new SelectList(db.Estudiante, "EstudianteID", "Nombres");
            return View();
        }

        // POST: Inscripcion/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "InscripcionID,CursoID,EstudianteID")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Inscripcion.Add(inscripcion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Descripcion", inscripcion.CursoID);
            ViewBag.EstudianteID = new SelectList(db.Estudiante, "EstudianteID", "Nombres", inscripcion.EstudianteID);
            return View(inscripcion);
        }

        // GET: Inscripcion/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Descripcion", inscripcion.CursoID);
            ViewBag.EstudianteID = new SelectList(db.Estudiante, "EstudianteID", "Nombres", inscripcion.EstudianteID);
            return View(inscripcion);
        }

        // POST: Inscripcion/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "InscripcionID,CursoID,EstudianteID")] Inscripcion inscripcion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inscripcion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CursoID = new SelectList(db.Curso, "CursoID", "Descripcion", inscripcion.CursoID);
            ViewBag.EstudianteID = new SelectList(db.Estudiante, "EstudianteID", "Nombres", inscripcion.EstudianteID);
            return View(inscripcion);
        }

        // GET: Inscripcion/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            if (inscripcion == null)
            {
                return HttpNotFound();
            }
            return View(inscripcion);
        }

        // POST: Inscripcion/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inscripcion inscripcion = db.Inscripcion.Find(id);
            db.Inscripcion.Remove(inscripcion);
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
