using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Servicios
{
    public class ServiciosEstudiante
    {
        MedicalConsultationsAppEntities datos = new MedicalConsultationsAppEntities();

        public void InsertEstudiante(string nombre, Nullable<int> edad, int matricula, int fechaNacimiento, int provincia)
        {
            datos.SP_INSERTA_ESTUDIANTE(nombre, edad, matricula, fechaNacimiento, provincia);

        }

        public void EditEstudiante(Nullable<int> estudianteId, string nombre, Nullable<int> edad, int matricula, int fechaNacimiento, int provincia)
        {
            datos.SPU_UPDATE_ESTUDIANTE(estudianteId, nombre, edad, matricula, fechaNacimiento,  provincia);
        }

        public void DeleteEstudiante(Nullable<int> estudianteId)
        {
            datos.SP_DELETE_ESTUDIANTE(estudianteId);
        }

        public List<ESTUDIANTE> SelectEstudiante()
        {
            var listaEst = datos.SP_SELECT_ESTUDIANTE();

            return MapList(listaEst.ToList());
        }

        public ESTUDIANTE SelectEstudiante(int estudianteId)
        {
            var estudiantes = SelectEstudiante();

            return estudiantes.FirstOrDefault(i => i.EstudianteId == estudianteId);
        }

        public List<ESTUDIANTE> GetEmptyView()
        {
            return new List<ESTUDIANTE>
            {
                new ESTUDIANTE
                {
                    Nombre = "EMMANUEL"
                }
            };
        }

        private List<ESTUDIANTE> MapList(List<SP_SELECT_ESTUDIANTE_Result> source)
        {
            var estudiantes =  new List<ESTUDIANTE>();
            foreach(var est in source)
            {
                var estudiante = MapItem(est);
                estudiantes.Add(estudiante);
            }
            return estudiantes;
        }

        private ESTUDIANTE MapItem(SP_SELECT_ESTUDIANTE_Result item)
        {


            return new ESTUDIANTE
            {
                EstudianteId = item.EstudianteId,
                Nombre = item.Nombre,
                Edad = item.Edad,
               FechaNacimiento = item.FechaNacimiento,
               Matricula = item.Matricula,
               Provincia = item.Provincia
               
            };
       
            
            // hacer eso para cada objeto de la lista 
            // crea un for each por cada elemento que viene de la funcion del mapeo 
    }

    }
}
