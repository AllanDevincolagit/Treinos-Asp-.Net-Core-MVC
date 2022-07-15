using AulasFernando.Entidades;
using AulasFernando.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace AulasFernando.Controllers
{
    public class ProfissoesController : Controller
    {
        private readonly Contexto db;
        public ProfissoesController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: ProfissoesController
        public ActionResult Index()
        {
            return View(db.PROFISSOES.Include(a=> a.Formacao).ToList()); //dar um using para corrigir o include
        }

        // GET: ProfissoesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProfissoesController/Create
        public ActionResult Create()
        {
            ProfissoesModel model = new ProfissoesModel();
            model.ListaFormacoes = db.FORMACAO.ToList();
            return View(model);
        }

        // POST: ProfissoesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Profissoes collection)
        {
            try
            {
                db.PROFISSOES.Add(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfissoesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(db.PROFISSOES.Where(a=> a.ID == id).FirstOrDefault());
        }

        // POST: ProfissoesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Profissoes collection)
        {
            try
            {
                db.PROFISSOES.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProfissoesController/Delete/5
        public ActionResult Delete(int id)
        {
            db.PROFISSOES.Remove(db.PROFISSOES.Where(a => a.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: ProfissoesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
