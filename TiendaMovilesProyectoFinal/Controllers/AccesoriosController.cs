using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using TiendaMovilesProyectoFinal.Models;

namespace TiendaMovilesProyectoFinal.Controllers
{
    public class AccesoriosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Accesorios
        public ActionResult Index()
        {
            var accesorios = db.Accesorios.Include(a => a.MarcaId).Include(a => a.ModeloId);
            return View(accesorios.ToList());
        }

        // GET: Accesorios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesorio accesorio = db.Accesorios.Find(id);
            if (accesorio == null)
            {
                return HttpNotFound();
            }
            return View(accesorio);
        }

        // GET: Accesorios/Create
        public ActionResult Create()
        {
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre");
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre");
            return View();
        }

        // POST: Accesorios/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Descripcion,Precio,ImagenUrl,MarcaId,ModeloId")] Accesorio accesorio)
        {
            if (ModelState.IsValid)
            {
                db.Accesorios.Add(accesorio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", accesorio.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre", accesorio.ModeloId);
            return View(accesorio);
        }

        // GET: Accesorios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesorio accesorio = db.Accesorios.Find(id);
            if (accesorio == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", accesorio.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre", accesorio.ModeloId);
            return View(accesorio);
        }

        // POST: Accesorios/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Descripcion,Precio,ImagenUrl,MarcaId,ModeloId")] Accesorio accesorio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accesorio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaId = new SelectList(db.Marcas, "Id", "Nombre", accesorio.MarcaId);
            ViewBag.ModeloId = new SelectList(db.Modelos, "Id", "Nombre", accesorio.ModeloId);
            return View(accesorio);
        }

        // GET: Accesorios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accesorio accesorio = db.Accesorios.Find(id);
            if (accesorio == null)
            {
                return HttpNotFound();
            }
            return View(accesorio);
        }

        // POST: Accesorios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accesorio accesorio = db.Accesorios.Find(id);
            db.Accesorios.Remove(accesorio);
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
