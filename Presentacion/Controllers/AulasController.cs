using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Servicios;


namespace Presentacion.Controllers
{
    public class AulasController : Controller
    {
        ServiciosAulas service = new ServiciosAulas();



        public ActionResult Index()
        {
            var aulas = service.SelectAula();
            return View(aulas);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create( string nombre, string capacidad)
        {
            service.InsertAula( nombre, capacidad);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int AulasId)
        {
            var aula = service.SelectAula(AulasId);
            return View(aula);
        }

        [HttpPost]
        public ActionResult Edit(int aulasId, string nombre, string capacidad)
        {
            service.EditAula(aulasId, nombre, capacidad);
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int AulasId)
        {
            var aula = service.SelectAula(AulasId);
            return View(aula);

        }

        [HttpPost]
        public ActionResult Delete(Nullable<int> AulasId)
        {
            service.DeleteAula(AulasId);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int AulasId)
        {
            var aula = service.SelectAula(AulasId);
            return View(aula);
        }

        [HttpPost]
        public ActionResult Details(int aulasId, string nombre, string capacidad)
        {
            service.EditAula( aulasId, nombre, capacidad);
            return RedirectToAction("Index");
        }





    }
}