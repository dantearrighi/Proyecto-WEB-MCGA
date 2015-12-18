using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cModalidad
    {
        // Declaro las variables a utilizar en la clase
        private static cModalidad instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cModalidad ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cModalidad();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cModalidad()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Modalidad> ObtenerModalidades()
        {
            return oModelo_Entidades.Modalidades.ToList();
        }

        public Modelo_Entidades.Modalidad ObtenerModalidadPorDesc(string modalidad)
        {
            Modelo_Entidades.Modalidad oModalidad = oModelo_Entidades.Modalidades.ToList().Find(delegate(Modelo_Entidades.Modalidad fModalidad)
            {
                return fModalidad.descripcion == modalidad;
            });

            return oModalidad;
        }
    }
}
