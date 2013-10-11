using System;
using System.Linq;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    [Authorize]
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
            CarregarMotoristas();
            CarregarVeiculos();
            CarregarPassageiros();
            CarregarOrigemDestino();
            CarregarHorarios();
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Agenda agenda)
        {
            CarregarMotoristas();
            CarregarVeiculos();
            CarregarPassageiros();
            CarregarOrigemDestino();
            CarregarHorarios();

            var agendar = new Agenda
            {
                Veiculo = new Veiculo
                {
                    Id = agenda.Veiculo.Id
                },
                Motorista = new Motorista
                {
                    Id = agenda.Motorista.Id
                },
                Passageiro = new Passageiro
                {
                    Id = agenda.Passageiro.Id
                },
                OrigemDestino = agenda.OrigemDestino,
                DataAgendada = agenda.DataAgendada,
                Horario = agenda.Horario,
            };

            if (!ModelState.IsValid)
                return View(agenda);

            var data = Convert.ToDateTime(agenda.DataAgendada);
            if (data >= DateTime.Now)
            {
                Construtor<Agenda>.AplicacaoAgenda().Salvar(agendar);
                return RedirectToAction("Index", "Agenda");
            }
            else {
                return View(agenda);
            }
        }

        public ActionResult Editar(string id)
        {
            CarregarOrigemDestino();
            CarregarMotoristas();
            CarregarVeiculos();
            CarregarPassageiros();
            CarregarHorarios();
            var agenda = Construtor<Agenda>.AplicacaoAgenda().ListarPorId(id);
            if (agenda == null)
                return HttpNotFound();
            return View(agenda);
        }

        [HttpPost]
        public ActionResult Editar(Agenda agenda)
        {
            CarregarOrigemDestino();
            CarregarMotoristas();
            CarregarVeiculos();
            CarregarPassageiros();
            CarregarHorarios();
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

        public void CarregarOrigemDestino()
        {
            var lista = new[]
                        {
                            new SelectListItem{Text = "Ariquemes - PVH",Value = "Ariquemes - PVH"},
                            new SelectListItem{Text = "PVH - Ariquemes",Value = "PVH - Ariquemes"}
                        };
            ViewBag.OrigemDestino = lista.Select(x => new SelectListItem { Text = x.Text, Value = x.Value });
        }

        public void CarregarMotoristas()
        {
            ViewBag.Motorista = Construtor<Motorista>.AplicacaoMotorista().ListarTodos().Select(x => new SelectListItem { Text = x.Nome, Value = x.Id });
        }

        public void CarregarVeiculos()
        {
            ViewBag.Veiculo = Construtor<Veiculo>.AplicacaoVeiculo().ListarTodos().Select(x => new SelectListItem { Text = x.Modelo, Value = x.Id });
        }

        public void CarregarPassageiros()
        {
            ViewBag.Passageiro = Construtor<Passageiro>.AplicacaoPassageiro().ListarTodos().Select(x => new SelectListItem { Text = x.Nome, Value = x.Id });
        }

        public void CarregarHorarios()
        {
            var lista = new[]
                        {
                            new SelectListItem{Text = "7:00",Value = "7:00"},
                            new SelectListItem{Text = "8:00",Value = "8:00"},
                            new SelectListItem{Text = "9:00",Value = "9:00"},
                            new SelectListItem{Text = "10:00",Value = "10:00"},
                            new SelectListItem{Text = "11:00",Value = "11:00"},
                            new SelectListItem{Text = "12:00",Value = "12:00"},
                            new SelectListItem{Text = "13:00",Value = "13:00"},
                            new SelectListItem{Text = "14:00",Value = "14:00"},
                            new SelectListItem{Text = "15:00",Value = "15:00"},
                            new SelectListItem{Text = "16:00",Value = "16:00"},
                            new SelectListItem{Text = "17:00",Value = "17:00"},
                            new SelectListItem{Text = "18:00",Value = "18:00"},
                            new SelectListItem{Text = "19:00",Value = "19:00"},
                            new SelectListItem{Text = "20:00",Value = "20:00"},
                            new SelectListItem{Text = "21:00",Value = "21:00"},
                            new SelectListItem{Text = "22:00",Value = "22:00"},
                            new SelectListItem{Text = "23:00",Value = "23:00"},
                            new SelectListItem{Text = "24:00",Value = "24:00"}
                        };
            ViewBag.Horario = lista.Select(x => new SelectListItem { Text = x.Text, Value = x.Value });
        }
        
    }
}
