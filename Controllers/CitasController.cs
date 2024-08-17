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
            {                //obtenemos nuestro obj. tipo cita, conforme al method factory patron. El cual crea el objeto basado en la caracteriztica de nuestro obj.
                //en este caso, del tipo de cita
                CitaFactory factory = ObtenerFabrica(tipoCita);

                if (factory == null)
                {
                    return HttpNotFound("Tipo de cita no válido");
                }


                //creamos nuestra cita y asignamos atributos para programar la cita correspondiente (enlazado a base de datos)
                ICita cita = factory.CrearCita();
                            cita.ProgramarCita( descripcion,
                           tipoCita,
                           dni,
                           primerApellido,
                           segundoApellido,
                           nombre,
                           email,
                           telefono,
                          mascotaNombre,
                           fecha);
                return View("CitaProgramada", cita);
            }
            catch (Exception ex)
            {
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

        public ActionResult CitaProgramada()
        {
            //levantamos vista para ver una cita creada previamente
            return View();
        }
    }
}