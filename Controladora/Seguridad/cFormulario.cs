using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cFormulario
    {
        // Declaración de variables a usar en la clase
        private static cFormulario instancia;
        private Modelo_Entidades.WASSWebEntidades oModelo_Entidades;

        //Aplico el patron de diseño Singleton para la clase cFormulario (cuando la solicitan desde otra)
        public static cFormulario ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cFormulario();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cFormulario()
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();
        }

        // Obtengo los formularios
        public List<Modelo_Entidades.Formulario> ObtenerFormularios()
        {
            return oModelo_Entidades.Formularios.ToList();
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Formulario BuscarFromularioPorDesc(string formulario)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Formulario oFormulario = oModelo_Entidades.Formularios.ToList().Find(delegate(Modelo_Entidades.Formulario fFormulario)
            {
                return fFormulario.nombredemuestra == formulario;
            });

            return oFormulario;
        }
    }
}
