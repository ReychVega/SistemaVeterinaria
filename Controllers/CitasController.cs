using SistemaVeterinaria.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SistemaVeterinaria.Controllers
{
    // Definimos el controlador CitasController que hereda de Controller
    public class CitasController : Controller
    {
        // Creamos una instancia del contexto de la base de datos
        private VeterinariaContext db = new VeterinariaContext();

        // Acción para mostrar la lista de citas
        public ActionResult Index()
        {
            // Obtenemos todas las citas de la base de datos y las convertimos a una lista
            var citas = db.Citas.ToList();
            // Retornamos la vista con la lista de citas
            return View(citas);
        }

        // Acción para mostrar la vista de programación de citas
        public ActionResult ProgramarCita()
        {
            // Levantamos la vista para programar una cita
            return View();
        }

        // Acción para manejar el POST de la programación de citas
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
                // Obtenemos la fábrica correspondiente al tipo de cita
                CitaFactory factory = ObtenerFabrica(tipoCita);

                // Si la fábrica es nula, retornamos un error 404
                if (factory == null)
                {
                    return HttpNotFound("Tipo de cita no válido");
                }

                // Verificamos si ya existe una cita con la misma fecha y hora
                bool citaExistente = db.Citas.Any(c => c.Fecha == fecha);
                if (citaExistente)
                {
                    // Si existe una cita, agregamos un error al ModelState y retornamos la vista
                    ModelState.AddModelError("", "Ya existe una cita programada para esta fecha y hora.");
                    return View();
                }

                // Creamos una nueva cita usando la fábrica
                ICita cita = factory.CrearCita();
                // Programamos la cita y obtenemos el ID de la cita creada
                int idCita = cita.ProgramarCita(descripcion, tipoCita, dni, primerApellido, segundoApellido, nombre, email, telefono, mascotaNombre, fecha);

                // Buscamos la cita en la base de datos usando el ID
                Cita citaModelo = db.Citas.Find(idCita);

                // Si la cita no se encuentra, retornamos un error 404
                if (citaModelo == null)
                {
                    return HttpNotFound("Cita no encontrada");
                }

                // Retornamos la vista de cita programada con el modelo de la cita
                return View("CitaProgramada", citaModelo);
            }
            catch (Exception ex)
            {
                // Manejar excepciones y agregar un error al ModelState
                ModelState.AddModelError("", "Ocurrió un error al programar la cita.");
                return View();
            }
        }

        // Método privado para obtener la fábrica correspondiente al tipo de cita
        private CitaFactory ObtenerFabrica(string tipoCita)
        {
            // Usamos un switch para determinar la fábrica a usar
            switch (tipoCita)
            {
                case "Consulta":
                    return new ConsultaFactory();
                case "Vacunacion":
                    return new VacunacionFactory();
                default:
                    // Si el tipo de cita no es válido, retornamos null
                    return null;
            }
        }

        // Acción para mostrar la vista de cita programada
        public ActionResult CitaProgramada(Cita cita)
        {
            // Si la cita es nula, retornamos un error 400
            if (cita == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Cita no válida");
            }

            // Retornamos la vista con el modelo de la cita
            return View(cita);
        }
    }
}
