using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Servicios;


namespace Presentacion.Controllers
{
    public class HomeController : Controller
    {
        ServiciosEstudiante service = new ServiciosEstudiante();

        
        
        public ActionResult Index()
        {
            var estudiantes = service.SelectEstudiante();
            return View(estudiantes);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(string nombre, Nullable<int> edad, int matricula, int fechaNacimiento, int provincia)
        {
            service.InsertEstudiante(nombre, edad, matricula, fechaNacimiento, provincia);
            return RedirectToAction("Index");
        }

       public ActionResult Edit(int estudianteId)
        {
            var estudiante = service.SelectEstudiante(estudianteId);
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Edit(Nullable<int> estudianteId, string nombre, Nullable<int> edad, int matricula, int fechaNacimiento, int provincia)
        {
            service.EditEstudiante(estudianteId, nombre, edad, fechaNacimiento, matricula, provincia);
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int estudianteId)
        {
            var estudiante = service.SelectEstudiante(estudianteId);
            return View(estudiante);
            
        }

        [HttpPost]
        public ActionResult Delete(Nullable<int> estudianteId)
        {
            service.DeleteEstudiante(estudianteId);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int estudianteId)
        {
            var estudiante = service.SelectEstudiante(estudianteId);
            return View(estudiante);
        }

        [HttpPost]
        public ActionResult Details (Nullable<int> estudianteId, string nombre, Nullable<int> edad, int matricula, int fechaNacimiento, int provincia)
        {
            service.EditEstudiante(estudianteId, nombre, edad, fechaNacimiento, matricula, provincia);
            return RedirectToAction("Index");
        }





    }
}