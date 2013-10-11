using System.Web.Mvc;
using Aplicacao;
using Dominio;


namespace Gui.Web.Areas.Painel.Controllers
{
    public class DiaController : Controller
    {
        //
        // GET: /Painel/Dia/

        public ActionResult Index()
        {
            return View(Construtor<DiaDaSemana>.Aplicacao().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(DiaDaSemana dia)
        {
            if (!ModelState.IsValid)
                return View();
            Construtor<DiaDaSemana>.Aplicacao().Salvar(dia);
            return RedirectToAction("Index","Dia");
        }

        public ActionResult Editar(string id)
        {
            var dia = Construtor<DiaDaSemana>.Aplicacao().ListarPorId(id);
            if (dia == null)
                return HttpNotFound();
            return View(dia);
        }

        [HttpPost]
        public ActionResult Editar(DiaDaSemana dia)
        {
            if (!ModelState.IsValid)
                return HttpNotFound();
            Construtor<DiaDaSemana>.Aplicacao().Salvar(dia);
            return RedirectToAction("Index", "Dia");
        }
        public ActionResult Excluir(string id)
        {
            var dia = Construtor<DiaDaSemana>.Aplicacao().ListarPorId(id);
            if (dia == null)
                return HttpNotFound();
            return View(dia);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(DiaDaSemana dia)
        {
            Construtor<DiaDaSemana>.Aplicacao().Excluir(dia.Id);
            return RedirectToAction("Index", "Dia");
        }

        public ActionResult Detalhes(string id)
        {
            return View(Construtor<DiaDaSemana>.Aplicacao().ListarPorId(id));
        }
    }
}
