using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Servicios
{
    public class ServiciosEmpleadosAdm
    {
        MedicalConsultationsAppEntities datos = new MedicalConsultationsAppEntities();

        public void InsertEmpleadosAdm(int codigo, string nombre, string apellido, string fechaNacimiento, string departamento)
        {
            datos.SP_INSERTA_EmpleadosAdm(codigo, nombre, apellido, fechaNacimiento, departamento);

        }

        public void EditEmpleadosAdm(int empleadosAdmId,int codigo, string nombre, string apellido, string fechaNacimiento, string departamento)
        {
            datos.SPU_UPDATE_EmpleadosAdm(empleadosAdmId, codigo, nombre, apellido, fechaNacimiento, departamento);
        }

        public void DeleteEmpleadosAdm(Nullable<int> EmpleadosAdmId)
        {
            datos.SP_DELETE_EmpleadosAdm(EmpleadosAdmId);
        }

        public List<EmpleadosAdm> SelectEmpleadosAdm()
        {
            var listaEmp = datos.SP_SELECT_EmpleadosAdm();

            return MapList(listaEmp.ToList());
        }

        public EmpleadosAdm SelectEmpleadosAdm(int empleadosadmId)
        {
            var empleadosadm = SelectEmpleadosAdm();

            return empleadosadm.FirstOrDefault(i => i.EmpleadosAdmId == empleadosadmId);
        }

        public List<EmpleadosAdm> GetEmptyView()
        {
            return new List<EmpleadosAdm>
            {
                new EmpleadosAdm
                {
                    
                }
            };
        }

        private List<EmpleadosAdm> MapList(List<SP_SELECT_EmpleadosAdm_Result> source)
        {
            var empleadoadm = new List<EmpleadosAdm>();
            foreach (var empl in source)
            {
                var empleadosadm = MapItem(empl);
                empleadoadm.Add(empleadosadm);
            }
            return empleadoadm;
        }

        private EmpleadosAdm MapItem(SP_SELECT_EmpleadosAdm_Result item)
        {


            return new EmpleadosAdm
            {
                Codigo = item.Codigo,
                Nombre = item.Nombre,
                Apellido = item.Apellido,
                FechaNacimiento = item.FechaNacimiento,
                Departamento = item.Departamento

            };


         
        }

    }
}
