
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Servicios;


namespace Presentacion.Controllers
{
    public class EmpleadosAdmController : Controller
    {
        ServiciosEmpleadosAdm service = new ServiciosEmpleadosAdm();



        public ActionResult Index()
        {
            var empleadosadm = service.SelectEmpleadosAdm();
            return View(empleadosadm);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(int codigo, string nombre, string apellido, string fechaNacimiento, string departamento)
        {
            service.InsertEmpleadosAdm(codigo, nombre, apellido, fechaNacimiento, departamento);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int empleadosadmId)
        {
            var empleadoadm = service.SelectEmpleadosAdm(empleadosadmId);
            return View(empleadoadm);
        }

        [HttpPost]
        public ActionResult Edit(int empleadosadmId, int codigo, string nombre, string apellido, string fechaNacimiento, string departamento)
        {
            service.EditEmpleadosAdm(empleadosadmId, codigo, nombre, apellido, fechaNacimiento, departamento);
            return RedirectToAction("Index");
        }



        public ActionResult Delete(int empleadosadmId)
        {
            var empleadoadm = service.SelectEmpleadosAdm(empleadosadmId);
            return View(empleadoadm);

        }

        [HttpPost]
        public ActionResult Delete(Nullable<int> empleadosadmId)
        {
            service.DeleteEmpleadosAdm(empleadosadmId);
            return RedirectToAction("Index");
        }


        public ActionResult Details(int empleadosadmId)
        {
            var empleadoadm = service.SelectEmpleadosAdm(empleadosadmId);
            return View(empleadoadm);
        }

        [HttpPost]
        public ActionResult Details(int empleadosadmId, int codigo, string nombre, string apellido, string fechaNacimiento, string departamento)
        {
            service.EditEmpleadosAdm(empleadosadmId , codigo, nombre, apellido, fechaNacimiento, departamento);
            return RedirectToAction("Index");
        }

    }
}