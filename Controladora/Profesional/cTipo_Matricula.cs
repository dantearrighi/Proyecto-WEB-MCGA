using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cTipo_Matricula
    {
        // Declaro las variables a utilizar en la clase
        private static cTipo_Matricula instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cTipo_Matricula ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cTipo_Matricula();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cTipo_Matricula()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener los estados
        public List<Modelo_Entidades.Tipo_Matricula> ObtenerTiposMatriculas()
        {
            return oModelo_Entidades.Tipos_Matriculas.ToList();
        }

        // Busco a un título por su decripcion
        public Modelo_Entidades.Tipo_Matricula BuscarTipoMatriculaPorDesc(string tipomatricula)
        {
            // Busca el grupo por la descripcion y lo devuelve.
            Modelo_Entidades.Tipo_Matricula oTipoMatricula = oModelo_Entidades.Tipos_Matriculas.ToList().Find(delegate(Modelo_Entidades.Tipo_Matricula fTipoMatricula)
            {
                return fTipoMatricula.descripcion == tipomatricula;
            });

            return oTipoMatricula;
        }
    }
}
