using SistemaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVeterinaria.Controllers
{
    public class CitasController : Controller
    {
        private VeterinariaContext db = new VeterinariaContext(); 

        public ActionResult Index()
        {
            var citas = db.Citas.ToList(); 
            return View(citas); 
        }

        public ActionResult ProgramarCita()
        {
            //levantamos vista para programar una cita
            return View();
        }

        [HttpPost]
        public ActionResult ProgramarCita(string descripcion,
        string tipoCita,
        string dni,
        string primerApellido,
        string segundoApellido,
        string nombre,
        string email,
        string telefono,
        string mascotaNombre,
        DateTime fecha)
        {
            try
            {
                CitaFactory factory = ObtenerFabrica(tipoCita);

                if (factory == null)
                {
                    return HttpNotFound("Tipo de cita no válido");
                }

                // Verificar si ya existe una cita con la misma fecha y hora
                bool citaExistente = db.Citas.Any(c => c.Fecha == fecha);
                if (citaExistente)
                {
                    ModelState.AddModelError("", "Ya existe una cita programada para esta fecha y hora.");
                    return View();
                }


                ICita cita = factory.CrearCita();
                int idCita = cita.ProgramarCita(descripcion, tipoCita, dni, primerApellido, segundoApellido, nombre, email, telefono, mascotaNombre, fecha);

                Cita citaModelo = db.Citas.Find(idCita);

                if (citaModelo == null)
                {
                    return HttpNotFound("Cita no encontrada");
                }

                return View("CitaProgramada", citaModelo);
            }
            catch (Exception ex)
            {
                // Manejar excepciones
                ModelState.AddModelError("", "Ocurrió un error al programar la cita.");
                return View();
            }
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


        //CitaProgramada: falta

        public ActionResult CitaProgramada(Cita cita)
        {
            if (cita == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cita no válida");
            }

            return View(cita);
        }

    }
}