using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Servicios
{
    public class ServiciosAulas
    {
        MedicalConsultationsAppEntities datos = new MedicalConsultationsAppEntities();

        public void InsertAula(string nombre, string capacidad)
        {
            datos.SP_INSERTA_Aulas( nombre,  capacidad);

        }

        public void EditAula(Nullable<int> aulasId, string nombre, string capacidad)
        {
            datos.SPU_UPDATE_Aulas(aulasId, nombre, capacidad);
        }

        public void DeleteAula(Nullable<int> AulasId)
        {
            datos.SP_DELETE_Aulas(AulasId);
        }

        public List<Aulas> SelectAula ()
        {
            var listaAul = datos.SP_SELECT_Aulas();

            return MapList(listaAul.ToList());
        }

        public Aulas SelectAula(int AulasId)
        {
            var aulas = SelectAula();

            return aulas.FirstOrDefault(i => i.AulasId == AulasId);
        }

        public List<Aulas> GetEmptyView()
        {
            return new List<Aulas>
            {
                new Aulas
                {
                   
                }
            };
        }

        private List<Aulas> MapList(List<SP_SELECT_Aulas_Result> source)
        {
            var aulas = new List<Aulas>();
            foreach (var aul in source)
            {
                var aula = MapItem(aul);
                aulas.Add(aula);
            }
            return aulas;
        }

        private Aulas MapItem(SP_SELECT_Aulas_Result item)
        {


            return new Aulas
            {
            
                Nombre = item.Nombre,
                Capacidad = item.Capacidad,
             

            };
        }

    }
}


