using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cTarea
    {
        // Declaro las variables a utilizar en la Tarea
        private static cTarea instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la Tarea
        public static cTarea ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cTarea();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cTarea()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Tareaes
        public List<Modelo_Entidades.Tarea> ObtenerTareas()
        {
            return oModelo_Entidades.Tareas.ToList();
        }

        // Elimino a un Tarea
        public void EliminarTarea(Modelo_Entidades.Tarea oTarea)
        {
            oTarea.Baja(oTarea);
        }

        // Agrego un Tarea
        public void AgregarTarea(Modelo_Entidades.Tarea oTarea)
        {
            oTarea.Alta(oTarea);
        }

        public Modelo_Entidades.Tarea ObtenerTarea(int id)
        {
            Modelo_Entidades.Tarea oTarea = oModelo_Entidades.Tareas.ToList().Find(delegate(Modelo_Entidades.Tarea fTarea)
            {
                return fTarea.Id == id;
            });

            return oTarea;
        }

        public Modelo_Entidades.Tarea ObtenerTareaPorDesc(string desc)
        {
            Modelo_Entidades.Tarea oTarea = oModelo_Entidades.Tareas.ToList().Find(delegate(Modelo_Entidades.Tarea fTarea)
            {
                return fTarea.descripcion == desc;
            });

            return oTarea;
        }

        // Modifico un Tarea
        public void ModificarTarea(Modelo_Entidades.Tarea oTarea)
        {
            oTarea.Modificacion(oTarea);
        }

        // Obtener las tareas según la obra elegida
        public List<Modelo_Entidades.Tarea> BuscarTareasPorObra(string desc)
        {
            if (desc == "Fuerza Electromotriz")
            {
                desc = "Modelo_Entidades.FE";
            }

            if (desc == "Obras de Ingenieria")
            {
                desc = "Modelo_Entidades.OI";
            }

            if (desc == "Honorario Minimo")
            {
                desc = "Modelo_Entidades.HM";
            }

            var Consulta = from oExpediente in oModelo_Entidades.Expedientes.ToList()
                           where oExpediente.GetType().ToString() == desc
                           select oExpediente.Tarea;
            return (List<Modelo_Entidades.Tarea>)Consulta.ToList();
        }

        // Voy filtrando a las tareas según la descripción
        public List<Modelo_Entidades.Tarea> FiltrarPorDesc(string desc)
        {
            var Consulta = from oTarea in oModelo_Entidades.Tareas.ToList()
                           where oTarea.descripcion.Contains(desc)
                           select oTarea;
            return (List<Modelo_Entidades.Tarea>)Consulta.ToList();
        }

        // Valido que no exista un tarea dada la descripción
        public Boolean ValidarTarea(string tarea)
        {
            Modelo_Entidades.Tarea oTarea = oModelo_Entidades.Tareas.ToList().Find(delegate(Modelo_Entidades.Tarea fTarea)
            {
                return fTarea.descripcion == tarea;
            });

            if (oTarea == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
