using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace examenParcial.Controllers
{
    public class HomeController : Controller
    {


        Models.PredioEntities cnx;
        public HomeController()
        {
            cnx = new Models.PredioEntities();
        }

        public ActionResult Mantenedor()
        {

            return View();
        }


        public ActionResult Guardar(int diio, string nombre, string sexo, string raza, int edad, string tipo, string rebaño)
        {
            examenParcial.Models.Vaca vaca = new examenParcial.Models.Vaca()
            {
                diio = diio,
                nombre = nombre,
                edad = edad,
                raza = raza,
                sexo = sexo,
                tipo = tipo,
                rebaño = rebaño
            };

            cnx.Vaca.Add(vaca);
            cnx.SaveChanges();

            return View("ListadoBovina", ObtenerListadoVacas());
        }

        private List<examenParcial.Models.Vaca> ObtenerListadoVacas()
        {
            return cnx.Vaca.ToList();

        }
        public ActionResult ListadoBovina()
        {

            return View(ObtenerListadoVacas());


        }



        public ActionResult FichaBovina(int diio)
        {
            return View(Identificar(diio));

        }
        public ActionResult Ver(int diio)
        {
            Models.Vaca vaca = Identificar(diio);
            if (vaca != null)
            {
                return View("FichaBovina", Identificar(diio));
            }
            return View("ListaBovina", ObtenerListadoVacas());
        }


        private examenParcial.Models.Vaca Identificar(int diio)
        {
            examenParcial.Models.Vaca animal = new Models.Vaca();

            foreach (Models.Vaca vaca in cnx.Vaca.ToList())
            {
                if (vaca.diio == diio)
                {
                    animal = vaca;
                }
            }
            return animal;
        }
        public ActionResult editar(int diio)
        {
            return null;
        }
    }
}