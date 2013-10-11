using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    [Authorize]
    public class PassageiroController : Controller
    {
        //
        // GET: /Painel/Passageiro/

        public ActionResult Index()
        {
            return View(Construtor<Passageiro>.AplicacaoPassageiro().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            CarregarBuscarOuNao();
            CarregarCompanhias();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Passageiro passageiro)
        {
            CarregarBuscarOuNao();
            CarregarCompanhias();
            if (!ModelState.IsValid)
                return View(passageiro);
            Construtor<Passageiro>.AplicacaoPassageiro().Salvar(passageiro);
            return RedirectToAction("Index", "Passageiro");

        }

        public ActionResult Editar(string id)
        {
            CarregarBuscarOuNao();
            CarregarCompanhias();
            var passageiro = Construtor<Passageiro>.AplicacaoPassageiro().ListarPorId(id);
            if (passageiro == null)
                return HttpNotFound();
            return View(passageiro);
        }

        [HttpPost]
        public ActionResult Editar(Passageiro passageiro)
        {
            CarregarBuscarOuNao();
            CarregarCompanhias();
            if (!ModelState.IsValid)
                return View(passageiro);
            Construtor<Passageiro>.AplicacaoPassageiro().Salvar(passageiro);
            return RedirectToAction("Index", "Passageiro");
        }

        public ActionResult Excluir(string id)
        {
            var passageiro = Construtor<Passageiro>.AplicacaoPassageiro().ListarPorId(id);
            if (passageiro == null)
                return HttpNotFound();
            return View(passageiro);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(Passageiro passageiro)
        {
            Construtor<Passageiro>.AplicacaoPassageiro().Excluir(passageiro.Id);
            return RedirectToAction("Index", "Passageiro");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<Passageiro>.AplicacaoPassageiro().ListarPorId(id));
        }
        public void CarregarCompanhias()
        {
            var lista = new[]
                        {
                            new SelectListItem{Text = "Gol",Value = "Gol"},
                            new SelectListItem{Text = "Tam",Value = "Tam"},
                            new SelectListItem{Text = "Trip",Value = "Trip"},
                            new SelectListItem{Text = "Azul",Value = "Azul"},
                            new SelectListItem{Text = "Delta",Value = "Delta"},
                            new SelectListItem{Text = "Avianca",Value = "Avianca"}
                        };
            ViewBag.CompanhiasAereas = lista.Select(x => new SelectListItem { Text = x.Text, Value = x.Value });
        }
        public void CarregarBuscarOuNao()
        {
            var lista = new[]
                        {
                            new SelectListItem{Text = "Sim",Value = "Sim"},
                            new SelectListItem{Text = "Não",Value = "Não"}
                        };
            ViewBag.Buscar = lista.Select(x => new SelectListItem { Text = x.Text, Value = x.Value });
        }
    }
}
