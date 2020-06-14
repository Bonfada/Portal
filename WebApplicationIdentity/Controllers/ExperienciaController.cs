using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplicationIdentity.Controllers
{
    public class ExperienciaController : Controller
    {
        // GET: Experiencia
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Pdf()
        {
            return View();
        }

        public ActionResult Download()
        {
            return View();
        }
    }
}