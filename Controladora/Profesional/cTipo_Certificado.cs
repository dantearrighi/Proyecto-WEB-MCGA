using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cTipo_Certificado
    {
        // Declaro las variables a utilizar en la clase
        private static cTipo_Certificado instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cTipo_Certificado ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cTipo_Certificado();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cTipo_Certificado()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener los tipos de certificados
        public List<Modelo_Entidades.Tipo_Certificado> ObtenerTiposCertificados()
        {
            return oModelo_Entidades.Tipos_Certificados.ToList();
        }
    }
}
