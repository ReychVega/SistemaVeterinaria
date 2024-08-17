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
            //aqui debemos traer la lista de la bd (solo para demostrar funcionalidad del modulo)

            return citas;
        }


        public ActionResult ProgramarCita()
        {
            //levantamos vista para programar una cita
            ViewBag.Animales = ObtenerAnimales();
            return View();
        }

        [HttpPost]
        public ActionResult ProgramarCita(string Descripcion, DateTime Fecha, string tipoCita, int clienteId, int animalId)
        {
            //revisamos que los datos no esten nulos
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
                ViewBag.Animales = ObtenerAnimales();
                return View(); 
            }

            try
            {
                //obtenemos nuestro obj. tipo cita, conforme al method factory patron. El cual crea el objeto basado en la caracteriztica de nuestro obj.
                //en este caso, del tipo de cita
                CitaFactory factory = ObtenerFabrica(tipoCita);

                if (factory == null)
                {
                    return HttpNotFound("Tipo de cita no válido");
                }


                //creamos nuestra cita y asignamos atributos para programar la cita correspondiente (enlazado a base de datos)
                ICita cita = factory.CrearCita();
                cita.ProgramarCita(Fecha, Descripcion, tipoCita, animalId, clienteId);
                return View("CitaProgramada", cita);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Hubo un error al programar la cita.");
                return View("Error"); 
            }
        }

        private List<Animal> ObtenerAnimales()
        {
            //retornamos de bd.


            return new List<Animal>();
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


        public ActionResult ObtenerInformacionCliente(int animalId)
        {
            var animal = ObtenerAnimales().FirstOrDefault(a => a.Id == animalId);
            if (animal != null)
            {
                var cliente = ObtenerClientes().FirstOrDefault(c => c.Id == animal.ClienteID);
                if (cliente != null)
                {
                    return PartialView("_InformacionCliente", cliente);
                }
            }
            return HttpNotFound();
        }

        private List<Cliente> ObtenerClientes()
        {

            //de la bd
            return new List<Cliente>();
        }




        //CitaProgramada: falta

        public ActionResult CitaProgramada()
        {
            //levantamos vista para ver una cita creada previamente
            return View();
        }
    }
}