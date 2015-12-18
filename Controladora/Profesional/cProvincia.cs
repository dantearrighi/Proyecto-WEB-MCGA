using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cProvincia
    {
        // Declaro las variables a utilizar en la clase
        private static cProvincia instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cProvincia ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cProvincia();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cProvincia()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Provincia> ObtenerProvincias()
        {
            return oModelo_Entidades.Provincias.ToList();
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Provincia BuscarProvinciaPorDesc(string provincia)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Provincia oProvincia = oModelo_Entidades.Provincias.ToList().Find(delegate(Modelo_Entidades.Provincia fProvincia)
            {
                return fProvincia.nombre == provincia;
            });

            return oProvincia;
        }
    }
}
