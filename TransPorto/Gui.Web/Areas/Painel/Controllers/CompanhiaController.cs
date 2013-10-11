using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    public class CompanhiaController : Controller
    {
        //
        // GET: /Painel/Companhia/

        public ActionResult Index()
        {
            return View(Construtor<CompanhiasAereas>.AplicacaoCompanhia().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CompanhiasAereas companhia)
        {
            if (!ModelState.IsValid)
                return View();
            Construtor<CompanhiasAereas>.AplicacaoCompanhia().Salvar(companhia);
            return RedirectToAction("Index","Companhia");
        }

        public ActionResult Editar(string id)
        {
            var companhia = Construtor<CompanhiasAereas>.AplicacaoCompanhia().ListarPorId(id);
            if (companhia == null)
                return HttpNotFound();
            return View(companhia);
        }

        [HttpPost]
        public ActionResult Editar(CompanhiasAereas companhia)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();
            Construtor<CompanhiasAereas>.AplicacaoCompanhia().Salvar(companhia);
            return RedirectToAction("Index", "Companhia");
        }
        public ActionResult Excluir(string id)
        {
            var companhia = Construtor<CompanhiasAereas>.AplicacaoCompanhia().ListarPorId(id);
            if (companhia == null)
                return HttpNotFound();
            return View(companhia);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(CompanhiasAereas companhia)
        {
            Construtor<CompanhiasAereas>.AplicacaoCompanhia().Excluir(companhia.Id);
            return RedirectToAction("Index", "Companhia");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<CompanhiasAereas>.AplicacaoCompanhia().ListarPorId(id));
        }
    }
}
