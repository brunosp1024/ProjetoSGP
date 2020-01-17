using ProjetoSGP.Aplicacao;
using ProjetoSGP.Models;
using System.Web.Mvc;

namespace ProjetoSGP.Controllers
{
    public class RecursoController : Controller
    {
        // GET: Recurso
        public ActionResult Index()
        {
            var AppRecurso = new RecursoAplicacao();
            var recurso = AppRecurso.Select();
            return View(recurso);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                var AppRecurso = new RecursoAplicacao();
                AppRecurso.Insert(recurso);
                return RedirectToAction("Index");
            }

            return View(recurso);
        }

        public ActionResult Excluir(int id) //Rever esse codigo.
        {
            var AppRecurso = new RecursoAplicacao();
            var recurso = AppRecurso.ListaPorID(id);
            if(recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id) //Rever esse codigo.
        {
            var AppRecurso = new RecursoAplicacao();
            AppRecurso.Deletar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var AppRecurso = new RecursoAplicacao();
            var recurso = AppRecurso.ListaPorID(id);

            if(recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Recurso recurso)
        {
            if (ModelState.IsValid)
            {
                var appRecurso = new RecursoAplicacao();
                appRecurso.Update(recurso);
                return RedirectToAction("Index");
            }

            return View(recurso);
        }

        public ActionResult Detalhar(int id)
        {
            var AppRecurso = new RecursoAplicacao();
            var recurso = AppRecurso.ListaPorID(id);

            if (recurso == null)
            {
                return HttpNotFound();
            }
            return View(recurso);
        }

    }
}