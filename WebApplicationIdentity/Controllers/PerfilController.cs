using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationIdentity.ViewModels;

namespace WebApplicationIdentity.Controllers
{
    public class PerfilController : Controller
    {
        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AlterarSenha(ViewModelAlterarSenha viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            TempData["Mensagem"] = "Senha alterada com sucesso.";
            return RedirectToAction("Index", "Home");
        }
    }
}