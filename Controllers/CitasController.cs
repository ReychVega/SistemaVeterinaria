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

            List<ICita> citas = new List<ICita>();
            //aqui debemos traer la lista de la bd

            return citas;
        }


        public ActionResult ProgramarCita()
        {
       
            return View();
        }

        [HttpPost]
        public ActionResult ProgramarCita(string Descripcion, DateTime Fecha, string tipoCita)
        {
            if (string.IsNullOrWhiteSpace(Descripcion))
            {
                ModelState.AddModelError("Descripcion", "La descripción no puede estar vacía.");
            }

            if (Fecha < DateTime.Now)
            {
                ModelState.AddModelError("Fecha", "La fecha no se encuentra disponible para una cita");
            }

            if (!ModelState.IsValid)
            {
                return View("Error"); 
            }

            try
            {

                CitaFactory factory = ObtenerFabrica(tipoCita);

                if (factory == null)
                {
                    return HttpNotFound("Tipo de cita no válido");
                }

                ICita cita = factory.CrearCita();
                cita.Descripcion = Descripcion;
                cita.Fecha = Fecha;
                cita.Programar();
                // Guardamos en la BD

                return View("CitaProgramada", cita);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hubo un error al programar la cita.");
                return View("Error"); 
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

    }
}