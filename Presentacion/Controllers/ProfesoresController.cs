using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Servicios;

namespace Presentacion.Controllers
{
        public class ProfesoresController : Controller
        {
            ServiciosProfesores service = new ServiciosProfesores();



            public ActionResult Index()
            {
                var profesores = service.SelectProfesores();
                return View(profesores);
            }
            public ActionResult Create()
            {
                return View();
            }

            [HttpPost]
            public ActionResult Create( int codigo, string nombre, string apellido, int fechaNacimiento, int area)
            {
                service.InsertProfesores(codigo, nombre, apellido, fechaNacimiento, area);
                return RedirectToAction("Index");
            }

            public ActionResult Edit(int ProfesoresId)
            {
                var profesor = service.SelectProfesores(ProfesoresId);
                return View(profesor);
            }

            [HttpPost]
            public ActionResult Edit(int profesoresId, int codigo, string nombre, string apellido, int fechaNacimiento, int area)
            {
                service.EditProfesores(profesoresId, codigo, nombre, apellido, fechaNacimiento, area);
                return RedirectToAction("Index");
            }



            public ActionResult Delete(int profesoresId)
            {
                var profesor = service.SelectProfesores(profesoresId);
                return View(profesor);

            }

            [HttpPost]
            public ActionResult Delete(Nullable<int> ProfesoresId)
            {
                service.DeleteProfesores(ProfesoresId);
                return RedirectToAction("Index");
            }


            public ActionResult Details(int ProfesoresId)
            {
                var profesor = service.SelectProfesores(ProfesoresId);
                return View(profesor);
            }

            [HttpPost]
            public ActionResult Details(int profesoresId, int codigo, string nombre, string apellido, int fechaNacimiento, int area)
            {
                service.EditProfesores(profesoresId, codigo, nombre, apellido, fechaNacimiento, area);
                return RedirectToAction("Index");
            }
        }
    }