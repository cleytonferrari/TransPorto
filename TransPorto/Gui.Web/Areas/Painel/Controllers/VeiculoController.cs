using System.Collections.Generic;
using System.Diagnostics;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    public class VeiculoController : Controller
    {
        //
        // GET: /Painel/Passageiro/

        public ActionResult Index()
        {
            return View(Construtor<Veiculo>.AplicacaoVeiculo().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Veiculo passageiro)
        {
            if (!ModelState.IsValid)
                return View(passageiro);
            Construtor<Veiculo>.AplicacaoVeiculo().Salvar(passageiro);
            return RedirectToAction("Index", "Veiculo");

        }

        public ActionResult Editar(string id)
        {
            var veiculo = Construtor<Veiculo>.AplicacaoVeiculo().ListarPorId(id);
            if (veiculo == null)
                return HttpNotFound();
            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Editar(Veiculo passageiro)
        {
            if (!ModelState.IsValid)
                return View(passageiro);
            Construtor<Veiculo>.AplicacaoVeiculo().Salvar(passageiro);
            return RedirectToAction("Index", "Veiculo");
        }

        public ActionResult Excluir(string id)
        {
            var veiculo = Construtor<Veiculo>.AplicacaoVeiculo().ListarPorId(id);
            if (veiculo == null)
                return HttpNotFound();
            return View(veiculo);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(Veiculo passageiro)
        {
            Construtor<Veiculo>.AplicacaoVeiculo().Excluir(passageiro.Id);
            return RedirectToAction("Index", "Veiculo");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<Veiculo>.AplicacaoVeiculo().ListarPorId(id));
        }

        public void CarregarDiaDaSemana()
        {
            List<string> DiaDaSemana = new List<string>
                                       {
                                           "Segunda",
                                           "Terça",
                                           "Quarta",
                                           "Quinta",
                                           "Sexta",
                                           "Sabado",
                                           "Domingo"
                                       };
            ViewBag.ListaDeDias = DiaDaSemana;
        }
    }
}
