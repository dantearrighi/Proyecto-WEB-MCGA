using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cUniversidad
    {
        // Declaro las variables a utilizar en la clase
        private static cUniversidad instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cUniversidad ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cUniversidad();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cUniversidad()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Universidad> ObtenerUniversidades()
        {
            return oModelo_Entidades.Universidades.ToList();
        }

        public Modelo_Entidades.Universidad ObtenerUnivPorDesc(string universidad)
        {
            Modelo_Entidades.Universidad oUniversidad = oModelo_Entidades.Universidades.ToList().Find(delegate(Modelo_Entidades.Universidad fUniversidad)
            {
                return fUniversidad.descripcion == universidad;
            });

            return oUniversidad;
        }
    }
}
