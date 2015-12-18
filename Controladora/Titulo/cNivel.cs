using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cNivel
    {
        // Declaro las variables a utilizar en la clase
        private static cNivel instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cNivel ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cNivel();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cNivel()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Nivel> ObtenerNiveles()
        {
            return oModelo_Entidades.Niveles.ToList();
        }

        public Modelo_Entidades.Nivel ObtenerNivelPorDesc(string nivel)
        {
            Modelo_Entidades.Nivel oNivel = oModelo_Entidades.Niveles.ToList().Find(delegate(Modelo_Entidades.Nivel fNivel)
            {
                return fNivel.descripcion == nivel;
            });

            return oNivel;
        }
    }
}
