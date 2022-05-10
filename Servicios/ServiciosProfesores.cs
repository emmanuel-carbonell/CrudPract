using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Servicios
{
    public class ServiciosProfesores
    {
        MedicalConsultationsAppEntities datos = new MedicalConsultationsAppEntities();

        public void InsertProfesores(int codigo, string nombre, string apellido, int fechaNacimiento, int area)
        {
            datos.SP_INSERTA_Profesores(codigo, nombre, apellido, fechaNacimiento, area);

        }

        public void EditProfesores(int profesoresId, int codigo, string nombre, string apellido, int fechaNacimiento, int area)
        {
            datos.SPU_UPDATE_Profesores(profesoresId, codigo, nombre, apellido, fechaNacimiento, area);
        }

        public void DeleteProfesores(Nullable<int> profesoresId)
        {
            datos.SP_DELETE_Profesores(profesoresId);
        }

        public List<Profesores> SelectProfesores()
        {
            var listaProf = datos.SP_SELECT_Profesores();

            return MapList(listaProf.ToList());
        }

        public Profesores SelectProfesores(int ProfesoresId)
        {
            var profesores = SelectProfesores();

            return profesores.FirstOrDefault(i => i.ProfesoresId == ProfesoresId);
        }

        public List<Profesores> GetEmptyView()
        {
            return new List<Profesores>
            {
                new Profesores
                {
                 
                }
            };
        }

        private List<Profesores> MapList(List<SP_SELECT_Profesores_Result> source)
        {
            var profesores = new List<Profesores>();
            foreach (var prof in source)
            {
                var profesor = MapItem(prof);
                profesores.Add(profesor);
            }
       
            return profesores;
        }

        private Profesores MapItem(SP_SELECT_Profesores_Result item)
        {

            
            return new Profesores
            {
                ProfesoresId = item.ProfesoresId,
                Codigo = item.Codigo,
                Nombre = item.Nombre,
                Apellido = item.Apellido,
                FechaNacimiento = item.FechaNacimiento,
                Area = item.Area

            };

        }

    }
}
