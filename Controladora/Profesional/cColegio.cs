using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cColegio
    {
        // Declaro las variables a utilizar en la clase
        private static cColegio instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cColegio ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cColegio();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cColegio()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener los estados
        public List<Modelo_Entidades.Colegio> ObtenerColegios()
        {
            return oModelo_Entidades.Colegios.ToList();
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Colegio BuscarColegioPorDesc(string colegio)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Colegio oColegio = oModelo_Entidades.Colegios.ToList().Find(delegate(Modelo_Entidades.Colegio fColegio)
            {
                return fColegio.descripcion == colegio;
            });

            return oColegio;
        }
    }
}
