using AutoMapper;
using Business;
using Business.DTO;
using Business.Interface;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
using WebApplicationIdentity.ViewModels;

namespace WebApplicationIdentity.Controllers
{
    public class AutenticacaoController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUsuarioBusiness _usuarioBusiness;
        public AutenticacaoController(
            IMapper mapper,
            IUsuarioBusiness usuarioBusiness)
        {
            _mapper = mapper;
            _usuarioBusiness = usuarioBusiness;
        }

        public ActionResult Cadastrar()
        {
            return View();
        }


        [HttpPost]
        public ActionResult Cadastrar(ViewModelUsuario viewModel)
        {
            if (!ModelState.IsValid)
                return View(viewModel);

            _usuarioBusiness.Add(_mapper.Map<UsuarioDTO>(viewModel));

            TempData["Mensagem"] = "Cadastro realizado com sucesso. Efetue login.";
            return RedirectToAction("Login");
        }

        public ActionResult Listar()
        {
            return Json(new
            {
                Nome = "Bonfadão",
                Idade = 35
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Login(string ReturnUrl)
        {
            var viewModelLogin = new ViewModelLogin
            {
                UrlRetorno = ReturnUrl
            };

            return View(viewModelLogin);
        }

        [HttpPost]
        public ActionResult Login(ViewModelLogin viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var usuario = _usuarioBusiness.List().FirstOrDefault(u => u.Login == viewModel.Login);

            if (usuario == null)
            {
                ModelState.AddModelError("Login", "Login Incorreto");
                return View(viewModel);
            }
             
            if (usuario.Login != viewModel.Login)
            {
                ModelState.AddModelError("Login", "Login Incorreto");
                return View(viewModel);
            }

            if (usuario.Senha != viewModel.Senha)
            {
                ModelState.AddModelError("Senha", "Senha incorreta");
                return View(viewModel);
            }

            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name,usuario.Nome),
                new Claim("Login", usuario.Login)
            }, "ApplicationCookie");

            Request.GetOwinContext().Authentication.SignIn(identity);

            if (!String.IsNullOrWhiteSpace(viewModel.UrlRetorno) || Url.IsLocalUrl(viewModel.UrlRetorno))
                return Redirect(viewModel.UrlRetorno);
            else
                return RedirectToAction("Index", "Home");
        }

        public ActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
            return RedirectToAction("Index", "Home");
        }

    }
}