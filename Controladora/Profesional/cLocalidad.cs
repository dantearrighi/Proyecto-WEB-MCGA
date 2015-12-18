using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cLocalidad
    {
        // Declaro las variables a utilizar en la clase
        private static cLocalidad instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cLocalidad ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cLocalidad();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cLocalidad()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Localidad> ObtenerLocalidades()
        {
            return oModelo_Entidades.Localidades.ToList();
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Localidad BuscarLocalidadPorDesc(string localidad)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Localidad oLocalidad = oModelo_Entidades.Localidades.ToList().Find(delegate(Modelo_Entidades.Localidad fLocalidad)
            {
                return fLocalidad.nombre == localidad;
            });

            return oLocalidad;
        }
    }
}
