using ProjetoSGP.Aplicacao;
using ProjetoSGP.Models;
using System;
using System.Web.Mvc;

namespace ProjetoSGP.Controllers
{
    public class AtividadeController : Controller
    {
        // GET: Atividade
        public ActionResult Index()
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.Select();
            return View(atividade);
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Atividade atividade)
        {
            if (ModelState.IsValid) //Verfica se os dados são válidos.
            {
                //Condiciona o valor do status com base nas datas de início e término
                if (atividade.DataInicio < DateTime.Now)
                {
                    atividade.Status = "Amarelo";
                }
                else if (atividade.DataInicio > DateTime.Now && atividade.DataTermino > DateTime.Now)
                {
                    atividade.Status = "Verde";
                }
                else if(atividade.DataTermino < DateTime.Now)
                {
                    atividade.Status = "Vermelho";
                }

                var date = Convert.ToDateTime(atividade.DataTermino) - Convert.ToDateTime(atividade.DataInicio); //date recebe a doferenca das datas definidas no formulário
                atividade.Duracao = date.Days;


                var appAtividade = new AtividadeAplicacao();
                appAtividade.Insert(atividade);

                return RedirectToAction("Index"); //Redireciona para a Action especificada
            }

            return View(atividade);
        }

        public ActionResult Excluir(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.ListaPorID(id);
            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ExcluirConfirmado(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            appAtividade.Deletar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.ListaPorID(id);

            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(Atividade atividade)
        {
            if (ModelState.IsValid)
            {
                var appAtividade = new AtividadeAplicacao();
                appAtividade.Update(atividade);
                return RedirectToAction("Index");
            }

            return View(atividade);
        }

        public ActionResult Detalhar(int id)
        {
            var appAtividade = new AtividadeAplicacao();
            var atividade = appAtividade.ListaPorID(id);

            if (atividade == null)
            {
                return HttpNotFound();
            }
            return View(atividade);
        }

    }
}