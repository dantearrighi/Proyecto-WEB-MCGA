using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cCtaCte
    {
        // Declaro las variables a utilizar en la clase
        private static cCtaCte instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cCtaCte ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cCtaCte();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cCtaCte()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Modificar a una cta cte
        public void Modificacion(Modelo_Entidades.CtaCte oCtaCte)
        {
            oCtaCte.Modificacion(oCtaCte);
        }

    }
}
