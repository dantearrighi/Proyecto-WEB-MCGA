using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cVideo
    {
        // Declaro las variables a utilizar en la clase
        private static cVideo instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cVideo ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cVideo();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cVideo()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las provincias
        public List<Modelo_Entidades.Video> ObtenerVideoes()
        {
            return oModelo_Entidades.Videos.ToList();
        }

        // Voy filtrando a los profesionales según el DNI introducido
        public List<Modelo_Entidades.Video> FiltrarPorDesc(string desc)
        {
            var Consulta = from oVideo in oModelo_Entidades.Videos.ToList()
                           where oVideo.descripcion.Contains(desc)
                           select oVideo;
            return (List<Modelo_Entidades.Video>)Consulta.ToList();
        }
    }
}
