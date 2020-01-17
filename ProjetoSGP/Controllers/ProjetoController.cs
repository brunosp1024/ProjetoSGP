using ProjetoSGP.Aplicacao;
using ProjetoSGP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSGP.Controllers
{
    public class ProjetoController : Controller
    {
        // GET: Projeto
        public ActionResult Index()
        {
            var appProjeto = new ProjetoAplicacao();
            var projeto = appProjeto.Select();
            return View(projeto);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                var appProjeto = new ProjetoAplicacao();
                appProjeto.Insert(projeto);
                return RedirectToAction("Index");
            }

            return View(projeto);
        }

        public ActionResult Excluir(int id) //Rever esse codigo.
        {
            var appProjeto = new ProjetoAplicacao();
            var projeto = appProjeto.ListaPorID(id);
            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id) //Rever esse codigo.
        {
            var appProjeto = new ProjetoAplicacao();
            appProjeto.Deletar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var appProjeto = new ProjetoAplicacao();
            var projeto = appProjeto.ListaPorID(id);

            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Projeto projeto)
        {
            if (ModelState.IsValid)
            {
                var appProjeto = new ProjetoAplicacao();
                appProjeto.Update(projeto);
                return RedirectToAction("Index");
            }

            return View(projeto);
        }

        public ActionResult Detalhar(int id)
        {
            var appProjeto = new ProjetoAplicacao();
            var projeto = appProjeto.ListaPorID(id);

            if (projeto == null)
            {
                return HttpNotFound();
            }
            return View(projeto);
        }

    }
}