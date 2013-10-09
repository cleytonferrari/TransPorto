using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Aplicacao;
using Dominio;

namespace Gui.Web.Areas.Painel.Controllers
{
    public class UsuarioController : Controller
    {
        //
        // GET: /Painel/Usuario/

        public ActionResult Index()
        {
            return View(Construtor<Usuario>.AplicacaoUsuario().ListarTodos());
        }

        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);
            Construtor<Usuario>.AplicacaoUsuario().Salvar(usuario);
            return RedirectToAction("Index", "Usuario");

        }

        public ActionResult Editar(string id)
        {
            var usuario = Construtor<Usuario>.AplicacaoUsuario().ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();
            return View(usuario);
        }

        [HttpPost]
        public ActionResult Editar(Usuario usuario)
        {
            if (!ModelState.IsValid)
                return View(usuario);
            Construtor<Usuario>.AplicacaoUsuario().Salvar(usuario);
            return RedirectToAction("Index", "Usuario");
        }

        public ActionResult Excluir(string id)
        {
            var usuario = Construtor<Usuario>.AplicacaoUsuario().ListarPorId(id);
            if (usuario == null)
                return HttpNotFound();
            return View(usuario);
        }

        [HttpPost, ActionName("Excluir")]
        public ActionResult ConfirmarExcluir(Usuario usuario)
        {
            Construtor<Usuario>.AplicacaoUsuario().Excluir(usuario.Id);
            return RedirectToAction("Index", "Usuario");
        }

    }
}
