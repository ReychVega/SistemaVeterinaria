using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVeterinaria.Controllers
{
    // Definimos el controlador HomeController que hereda de Controller
    public class HomeController : Controller
    {
        // Acción para mostrar la vista principal (Index)
        public ActionResult Index()
        {
            // Retornamos la vista correspondiente a la acción Index
            return View();
        }

        // Acción para mostrar la vista de "About" (Acerca de)
        public ActionResult About()
        {
            // Asignamos un mensaje a la propiedad ViewBag.Message
            ViewBag.Message = "Your application description page.";

            // Retornamos la vista correspondiente a la acción About
            return View();
        }

        // Acción para mostrar la vista de "Contact" (Contacto)
        public ActionResult Contact()
        {
            // Asignamos un mensaje a la propiedad ViewBag.Message
            ViewBag.Message = "Your contact page.";

            // Retornamos la vista correspondiente a la acción Contact
            return View();
        }
    }
}
