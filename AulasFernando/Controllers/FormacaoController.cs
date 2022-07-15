using AulasFernando.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AulasFernando.Controllers
{
    public class FormacaoController : Controller
    {
        private readonly Contexto db;
        public FormacaoController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: FormacaoController
        public ActionResult Index()
        {
            return View(db.FORMACAO.ToList());
        }

        // GET: FormacaoController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: FormacaoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormacaoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Formacao collection)
        {
            try
            {
                db.FORMACAO.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormacaoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.FORMACAO.Where(a=>a.ID == id).FirstOrDefault());
        }

        // POST: FormacaoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Formacao collection)
        {
            try
            {
                db.FORMACAO.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: FormacaoController/Delete/5
        public ActionResult Delete(int id)
        {
            db.FORMACAO.Remove(db.FORMACAO.Where(a => a.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: FormacaoController/Delete/5
       
    }
}
