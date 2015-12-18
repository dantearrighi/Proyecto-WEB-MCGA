using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cPermiso
    {
         // Declaración de variables a usar en la clase
        private static cPermiso instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        //Aplico el patron de diseño Singleton para la clase cPermiso (cuando la solicitan desde otra)
        public static cPermiso ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cPermiso();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cPermiso()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtengo los permisos
        public List<Modelo_Entidades.Permiso> ObtenerPermisos()
        {
            return oModelo_Entidades.Permisos.ToList();
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Permiso BuscarPermisoPorDesc(string permiso)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Permiso oPermiso = oModelo_Entidades.Permisos.ToList().Find(delegate(Modelo_Entidades.Permiso fPermiso)
            {
                return fPermiso.descripcion == permiso;
            });

            return oPermiso;
        }
    }
}
