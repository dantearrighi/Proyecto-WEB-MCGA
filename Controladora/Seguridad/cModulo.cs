using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cModulo
    {
        // Declaración de variables a usar en la clase
        private static cModulo instancia;
        private Modelo_Entidades.WASSWebEntidades oModelo_Entidades;

        //Aplico el patron de diseño Singleton para la clase cModulo (cuando la solicitan desde otra)
        public static cModulo ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cModulo();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cModulo()
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();
        }

        // Obtengo los módulos
        public List<Modelo_Entidades.Modulo> ObtenerModulos()
        {
            return oModelo_Entidades.Modulos.ToList();
        }

        // Obtengo los formularios que pertenecen a un cierto modulo
        public List<Modelo_Entidades.Formulario> ObtenerFormulariosPorModulo(int modulo)
        {
            var Consulta = from oFormulario in oModelo_Entidades.Formularios.ToList()
                           where oFormulario.Modulo.id == modulo
                           group oFormulario by oFormulario into Formularios
                           select Formularios.Key;
            return (List<Modelo_Entidades.Formulario>)Consulta.ToList();
        }
    }
}
