using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TiendaMovilesProyectoFinal.Models;

namespace TiendaMovilesProyectoFinal.Controllers
{
    public class ValoracionsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Valoracions
        public ActionResult Index()
        {
            var valoraciones = db.Valoraciones.Include(v => v.Dispositivo);
            return View(valoraciones.ToList());
        }

        // GET: Valoracions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoraciones.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            return View(valoracion);
        }

        // GET: Valoracions/Create
        public ActionResult Create()
        {
            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "Id", "Nombre");
            return View();
        }

        // POST: Valoracions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Comentario,Puntuacion,DispositivoId")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                db.Valoraciones.Add(valoracion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "Id", "Nombre", valoracion.DispositivoId);
            return View(valoracion);
        }

        // GET: Valoracions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoraciones.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "Id", "Nombre", valoracion.DispositivoId);
            return View(valoracion);
        }

        // POST: Valoracions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Comentario,Puntuacion,DispositivoId")] Valoracion valoracion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valoracion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DispositivoId = new SelectList(db.Dispositivos, "Id", "Nombre", valoracion.DispositivoId);
            return View(valoracion);
        }

        // GET: Valoracions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valoracion valoracion = db.Valoraciones.Find(id);
            if (valoracion == null)
            {
                return HttpNotFound();
            }
            return View(valoracion);
        }

        // POST: Valoracions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valoracion valoracion = db.Valoraciones.Find(id);
            db.Valoraciones.Remove(valoracion);
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
