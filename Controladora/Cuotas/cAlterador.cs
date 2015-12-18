using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cAlterador
    {
        // Declaro las variables a utilizar en la clase
        private static cAlterador instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cAlterador ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cAlterador();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cAlterador()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtengo el 1º y único alterador de los valores de las matrículas
        public Modelo_Entidades.Alterador ObtenerAlterador()
        {
            Modelo_Entidades.Alterador oAlterador = oModelo_Entidades.Alteradores.ToList().Find(delegate(Modelo_Entidades.Alterador fAlterador)
            {
                return fAlterador.id == 1;
            });

            return oAlterador;
        }

        // Modificar a la alteración
        public void Modificacion(Modelo_Entidades.Alterador oAlterador)
        {
            oAlterador.Modificacion(oAlterador);
        }
    }
}
