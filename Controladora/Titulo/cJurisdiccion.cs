using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cJurisdiccion
    {
        // Declaro las variables a utilizar en la clase
        private static cJurisdiccion instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cJurisdiccion ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cJurisdiccion();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cJurisdiccion()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Jurisdiccion> ObtenerJurisdicciones()
        {
            return oModelo_Entidades.Jurisdicciones.ToList();
        }

        public Modelo_Entidades.Jurisdiccion ObtenerJurisdiccionPorDesc(string jurdisccion)
        {
            Modelo_Entidades.Jurisdiccion oJurisdiccion = oModelo_Entidades.Jurisdicciones.ToList().Find(delegate(Modelo_Entidades.Jurisdiccion fJurisdiccion)
            {
                return fJurisdiccion.descripcion == jurdisccion;
            });

            return oJurisdiccion;
        }
    }
}
