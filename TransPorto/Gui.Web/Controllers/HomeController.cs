using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Aplicacao;
using Dominio;
using GUI.Web.Models;

namespace Gui.Web.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(ViewModelLogin usuario, string returnUrl = "")
        {
            //Validando
            if (ModelState.IsValid)
            {
                var usuarioValido = Construtor<Usuario>.AplicacaoUsuario().Logar(usuario.Login, usuario.Senha);
                //Se for valido
                //Ira criar sessão do usuario logado
                if (usuarioValido != null)
                {
                    FormsAuthentication.SetAuthCookie(usuarioValido.Login, false);
                }
                /*
                 * Se o Usuario tentar acessa uma URL Valida e não estiver logado este If ira pega essa URL
                 * Solicita o login, apos logar redireciona o admin pra URL que o mesmo tentou acessar
                 */
                if (Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }
                return RedirectToAction("Index", "Home", new { Area = "Painel" });
            }
            ViewBag.Menssage = "Usuário ou senha não confere";
            //Se não for valido
            return View();
        }

    }
}
