using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
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
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Passageiro passageiro)
        {
            if (!ModelState.IsValid)
                return View(passageiro);
            Construtor<Passageiro>.AplicacaoPassageiro().Salvar(passageiro);
            return RedirectToAction("Index", "Passageiro");

        }

        public ActionResult Editar(string id)
        {
            var passageiro = Construtor<Passageiro>.AplicacaoPassageiro().ListarPorId(id);
            if (passageiro == null)
                return HttpNotFound();
            return View(passageiro);
        }

        [HttpPost]
        public ActionResult Editar(Passageiro passageiro)
        {
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
    }
}
