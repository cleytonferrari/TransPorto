using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gui.Web.Areas.Painel.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        //
        // GET: /Painel/Home/

        public ActionResult Index()
        {
            return View();
        }

    }
}
