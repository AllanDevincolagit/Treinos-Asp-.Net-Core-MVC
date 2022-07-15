using AulasFernando.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AulasFernando.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly Contexto db;   //aqui no private readonly, deve-se usar o nome da classe de contexto criada

        public UsuariosController(Contexto contexto)
        {
            db = contexto;
        }
        // GET: UsuariosController
        public ActionResult Index (string query, string TipoPesquisa)
        {
            if (string.IsNullOrEmpty(query))
            {
                return View(db.USUARIOS.ToList()); //vai retornar os objetos lista da classe de usuários registrados no bd para a página de list
            }
            else if (TipoPesquisa == "Todos")
            {
                return View(db.USUARIOS.Where(a => a.Login.Contains(query) || a.Nome.Contains(query)));
            }
            else if (TipoPesquisa == "Login")
            {
                return View(db.USUARIOS.Where(a => a.Login.Contains(query)));
            }
            else if (TipoPesquisa == "Nome")
            {
                return View(db.USUARIOS.Where(a => a.Nome.Contains(query)));
            }else {
                return View(db.USUARIOS.ToList());
            }
        }

        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UsuariosController/Create
        public ActionResult Create ()
        {
            return View();
        }

        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuarios collection) //vai pegar a tabela da classe de usuários
        {
            try
            {
                db.USUARIOS.Add(collection); //o nome maiusculo ou minusculo da classe de tabela vai ser sugerido automáticamente, essa linha é de fato responsável por colar as coisas feitas no create na list
                db.SaveChanges(); //Salva as mudanças feitas por nós
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Edit/5
        public ActionResult Edit (int id)
        {
            return View(db.USUARIOS.Where(a => a.ID == id).FirstOrDefault());
        }

        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Usuarios collection)
        {
            try
            {
                db.Update(collection);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            db.USUARIOS.Remove(db.USUARIOS.Where(a => a.ID == id).FirstOrDefault());
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}
