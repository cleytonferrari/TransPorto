using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    public class AgendaController : Controller
    {
        //
        // GET: /Painel/agenda/

        public ActionResult Index()
        {
            return View(Construtor<Motorista>.AplicacaoAgenda().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Agenda agenda)
        {
            if (!ModelState.IsValid)
                return View(agenda);
            Construtor<Agenda>.AplicacaoAgenda().Salvar(agenda);
            return RedirectToAction("Index", "Agenda");

        }

        public ActionResult Editar(string id)
        {
            var agenda = Construtor<Agenda>.AplicacaoAgenda().ListarPorId(id);
            if (agenda == null)
                return HttpNotFound();
            return View(agenda);
        }

        [HttpPost]
        public ActionResult Editar(Agenda agenda)
        {
            if (!ModelState.IsValid)
                return View(agenda);
            Construtor<Agenda>.AplicacaoAgenda().Salvar(agenda);
            return RedirectToAction("Index", "Agenda");
        }

        public ActionResult Excluir(string id)
        {
            var agenda = Construtor<Agenda>.AplicacaoAgenda().ListarPorId(id);
            if (agenda == null)
                return HttpNotFound();
            return View(agenda);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(Agenda agenda)
        {
            Construtor<Agenda>.AplicacaoAgenda().Excluir(agenda.Id);
            return RedirectToAction("Index", "Agenda");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<Agenda>.AplicacaoAgenda().ListarPorId(id));
        }
    }
}
