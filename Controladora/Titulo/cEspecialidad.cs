using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cEspecialidad
    {
        // Declaro las variables a utilizar en la clase
        private static cEspecialidad instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cEspecialidad ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cEspecialidad();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cEspecialidad()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Especialidad> ObtenerEspecialidades()
        {
            return oModelo_Entidades.Especialidades.ToList();
        }

        public Modelo_Entidades.Especialidad ObtenerEspecialidadPorDesc(string especialidad)
        {
            Modelo_Entidades.Especialidad oEspecialidad = oModelo_Entidades.Especialidades.ToList().Find(delegate(Modelo_Entidades.Especialidad fEspecialidad)
            {
                return fEspecialidad.descripcion == especialidad;
            });

            return oEspecialidad;
        }
    }
}
