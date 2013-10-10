using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    public class MotoristaController : Controller
    {
        //
        // GET: /Painel/motorista/

        public ActionResult Index()
        {
            return View(Construtor<Motorista>.AplicacaoMotorista().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Motorista motorista)
        {
            if (!ModelState.IsValid)
                return View(motorista);
            Construtor<Motorista>.AplicacaoMotorista().Salvar(motorista);
            return RedirectToAction("Index", "Motorista");

        }

        public ActionResult Editar(string id)
        {
            var motorista = Construtor<Motorista>.AplicacaoMotorista().ListarPorId(id);
            if (motorista == null)
                return HttpNotFound();
            return View(motorista);
        }

        [HttpPost]
        public ActionResult Editar(Motorista motorista)
        {
            if (!ModelState.IsValid)
                return View(motorista);
            Construtor<Motorista>.AplicacaoMotorista().Salvar(motorista);
            return RedirectToAction("Index", "Motorista");
        }

        public ActionResult Excluir(string id)
        {
            var motorista = Construtor<Motorista>.AplicacaoMotorista().ListarPorId(id);
            if (motorista == null)
                return HttpNotFound();
            return View(motorista);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(Motorista motorista)
        {
            Construtor<Motorista>.AplicacaoMotorista().Excluir(motorista.Id);
            return RedirectToAction("Index", "Motorista");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<Motorista>.AplicacaoMotorista().ListarPorId(id));
        }
    }
}
