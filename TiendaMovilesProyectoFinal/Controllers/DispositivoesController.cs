using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaMovilesProyectoFinal.Models;

namespace TiendaMovilesProyectoFinal.Controllers
{
    public class DispositivoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Dispositivoes
        public ActionResult Index()
        {
            var dispositivos = db.Dispositivos.Include(d => d.Marca).Include(d => d.Modelo).Include(d => d.SistemaOperativo);
            return View(dispositivos.ToList());
        }

        // GET: Dispositivoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // GET: Dispositivoes/Create
        /*[Authorize(Roles = "Administrador")]*/
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre");
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre");
            ViewBag.SistemaOperativoId = new SelectList(db.SistemaOperativos, "Id", "Nombre");
            return View();
        }

        // POST: Dispositivoes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Precio,Stock,MarcaId,ModeloId,SistemaOperativoId,ImagenArchivo")] Dispositivo dispositivo)
        {
            if (ModelState.IsValid)
            {
                if (dispositivo.ImagenArchivo != null && dispositivo.ImagenArchivo.ContentLength > 0)
                {
                    // Genera un nombre único para el archivo basado en el tiempo actual
                    var fileName = Path.GetFileNameWithoutExtension(dispositivo.ImagenArchivo.FileName);
                    var extension = Path.GetExtension(dispositivo.ImagenArchivo.FileName);
                    var newFileName = $"{fileName}_{DateTime.Now.Ticks}{extension}";

                    // Ruta de almacenamiento de la imagen en el servidor
                    var path = Path.Combine(Server.MapPath("~/Images/"), newFileName);
                    dispositivo.ImagenArchivo.SaveAs(path);

                    // Guarda la ruta de la imagen en la base de datos
                    dispositivo.ImagenUrl = "/Images/" + newFileName;
                }

                db.Dispositivos.Add(dispositivo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", dispositivo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre", dispositivo.ModeloId);
            ViewBag.SistemaOperativoId = new SelectList(db.SistemaOperativos, "Id", "Nombre", dispositivo.SistemaOperativoId);
            return View(dispositivo);
        }


        // GET: Dispositivoes/Edit/5
        /*[Authorize(Roles = "Administrador")]*/
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", dispositivo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre", dispositivo.ModeloId);
            ViewBag.SistemaOperativoId = new SelectList(db.SistemaOperativos, "Id", "Nombre", dispositivo.SistemaOperativoId);
            return View(dispositivo);
        }

        // POST: Dispositivoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,MarcaId,ModeloId,SistemaOperativoId,Stock")] Dispositivo dispositivo, HttpPostedFileBase ImagenFile)
        {
            if (ModelState.IsValid)
            {
                if (ImagenFile != null && ImagenFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(ImagenFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images/"), fileName);
                    ImagenFile.SaveAs(path);
                    dispositivo.ImagenUrl = "~/Images/" + fileName;
                }
                db.Entry(dispositivo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", dispositivo.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre", dispositivo.ModeloId);
            ViewBag.SistemaOperativoId = new SelectList(db.SistemaOperativos, "Id", "Nombre", dispositivo.SistemaOperativoId);
            return View(dispositivo);
        }

        // GET: Dispositivoes/Delete/5
        /*[Authorize(Roles = "Administrador")]*/
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            if (dispositivo == null)
            {
                return HttpNotFound();
            }
            return View(dispositivo);
        }

        // POST: Dispositivoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dispositivo dispositivo = db.Dispositivos.Find(id);
            db.Dispositivos.Remove(dispositivo);
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
