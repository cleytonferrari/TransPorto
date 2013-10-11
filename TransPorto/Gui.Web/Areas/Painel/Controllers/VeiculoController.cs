using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    [Authorize]
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
            CarregarDiaDaSemana();
            CarregarEstatus();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Veiculo veiculo)
        {
            CarregarDiaDaSemana();
            CarregarEstatus();
            if (!ModelState.IsValid)
                return View(veiculo);
            Construtor<Veiculo>.AplicacaoVeiculo().Salvar(veiculo);
            return RedirectToAction("Index", "Veiculo");

        }

        public ActionResult Editar(string id)
        {
            CarregarDiaDaSemana();
            CarregarEstatus();
            var veiculo = Construtor<Veiculo>.AplicacaoVeiculo().ListarPorId(id);
            if (veiculo == null)
                return HttpNotFound();
            return View(veiculo);
        }

        [HttpPost]
        public ActionResult Editar(Veiculo veiculo)
        {
            CarregarDiaDaSemana();
            CarregarEstatus();
            if (!ModelState.IsValid)
                return View(veiculo);
            Construtor<Veiculo>.AplicacaoVeiculo().Salvar(veiculo);
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
        public ActionResult ConfirmarExcluir(Veiculo veiculo)
        {
            Construtor<Veiculo>.AplicacaoVeiculo().Excluir(veiculo.Id);
            return RedirectToAction("Index", "Veiculo");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<Veiculo>.AplicacaoVeiculo().ListarPorId(id));
        }

        public void CarregarDiaDaSemana()
        {
            var lista = new[]{
                new SelectListItem
                        {Text = "Segunda-Feira",Value = "Segunda-Feira",Selected = true},
                new SelectListItem()
                        {Text = "Terça-Feira",Value = "Terça-Feira"},
                        new SelectListItem()
                        {Text = "Quarta-Feira",Value = "Quarta-Feira"},
                        new SelectListItem()
                        {Text = "Quinta-Feira",Value = "Quinta-Feira"},
                        new SelectListItem()
                        {Text = "Sexta-Feira",Value = "Sexta-Feira"},
                        new SelectListItem()
                        {Text = "Sabado",Value = "Sabado"},
                        new SelectListItem()
                        {Text = "Domingo",Value = "Domingo"}
            };
            ViewBag.Disponivel = lista.Select(x => new SelectListItem { Text = x.Text, Value = x.Value });
        }

        public void CarregarEstatus()
        {
            var lista = new[]
                        {
                            new SelectListItem{Text = "Sim",Value = "Sim"},
                            new SelectListItem{Text = "Não",Value = "Não"}
                        };
            ViewBag.Estatus = lista.Select(x => new SelectListItem {Text = x.Text, Value = x.Value});
        }
    }
}
