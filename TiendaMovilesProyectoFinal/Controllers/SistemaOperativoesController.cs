using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TiendaMovilesProyectoFinal.Models;

namespace TiendaMovilesProyectoFinal.Controllers
{
    public class SistemaOperativoesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SistemaOperativoes
        public ActionResult Index()
        {
            return View(db.SistemaOperativos.ToList());
        }

        // GET: SistemaOperativoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaOperativo sistemaOperativo = db.SistemaOperativos.Find(id);
            if (sistemaOperativo == null)
            {
                return HttpNotFound();
            }
            return View(sistemaOperativo);
        }

        // GET: SistemaOperativoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SistemaOperativoes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre")] SistemaOperativo sistemaOperativo)
        {
            if (ModelState.IsValid)
            {
                db.SistemaOperativos.Add(sistemaOperativo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sistemaOperativo);
        }

        // GET: SistemaOperativoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaOperativo sistemaOperativo = db.SistemaOperativos.Find(id);
            if (sistemaOperativo == null)
            {
                return HttpNotFound();
            }
            return View(sistemaOperativo);
        }

        // POST: SistemaOperativoes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre")] SistemaOperativo sistemaOperativo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sistemaOperativo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sistemaOperativo);
        }

        // GET: SistemaOperativoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SistemaOperativo sistemaOperativo = db.SistemaOperativos.Find(id);
            if (sistemaOperativo == null)
            {
                return HttpNotFound();
            }
            return View(sistemaOperativo);
        }

        // POST: SistemaOperativoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SistemaOperativo sistemaOperativo = db.SistemaOperativos.Find(id);
            db.SistemaOperativos.Remove(sistemaOperativo);
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
