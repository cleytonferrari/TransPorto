using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    public class VeiculoController : Controller
    {
        //
        // GET: /Painel/Veiculo/

        public ActionResult Index()
        {
            return View(Construtor<Veiculo>.AplicacaoVeiculo().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Veiculo veiculo)
        {
            if (!ModelState.IsValid)
                return View(veiculo);
            Construtor<Veiculo>.AplicacaoVeiculo().Salvar(veiculo);
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
        public ActionResult Editar(Veiculo veiculo)
        {
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
    }
}
