using SistemaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SistemaVeterinaria.Controllers
{
    public class CitasController : Controller
    {

        public ActionResult Index()
        {
            List<ICita> citas = ObtenerListaDeCitas();

            return View(citas);
        }

        private List<ICita> ObtenerListaDeCitas(){
           
            List<ICita> citas = new List<ICita>
                {
                    new ConsultaFactory().CrearCita(),
                    new VacunacionFactory().CrearCita()
                };

            return citas;
        }


        public ActionResult ProgramarCita(string tipoCita)
        {
            CitaFactory factory = ObtenerFabrica(tipoCita);

            if (factory == null)
            {
                return HttpNotFound("Tipo de cita no válido");
            }

            ICita cita = factory.CrearCita();
            cita.Programar();

            return View(cita);
        }

        private CitaFactory ObtenerFabrica(string tipoCita)
        {
            switch (tipoCita)
            {
                case "Consulta":
                    return new ConsultaFactory();
                case "Vacunacion":
                    return new VacunacionFactory();
                default:
                    return null;
            }
        }
    }
}