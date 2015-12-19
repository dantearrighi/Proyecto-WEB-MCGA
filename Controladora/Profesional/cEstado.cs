using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cEstado
    {
        // Declaro las variables a utilizar en la clase
        private static cEstado instancia;
        private Modelo_Entidades.WASSWebEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cEstado ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cEstado();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cEstado()
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();
        }

        // Obtener los estados
        public List<Modelo_Entidades.Estado> ObtenerEstados()
        {
            return oModelo_Entidades.Estados.ToList();
        }

        // Obtener el estado "Habilitado"
        public Modelo_Entidades.Estado ObtenerEstadoHabilitado()
        {
            Modelo_Entidades.Estado oEstado = oModelo_Entidades.Estados.ToList().Find(delegate(Modelo_Entidades.Estado fEstado)
            {
                return fEstado.descripcion == "Habilitado";
            });

            return oEstado;
        }

        // Obtener el estado "No Habilitado"
        public Modelo_Entidades.Estado ObtenerEstadoNoHabilitado()
        {
            Modelo_Entidades.Estado oEstado = oModelo_Entidades.Estados.ToList().Find(delegate(Modelo_Entidades.Estado fEstado)
            {
                return fEstado.descripcion == "No Habilitado";
            });

            return oEstado;
        }

        // Obtener el estado "Baja"
        public Modelo_Entidades.Estado ObtenerEstadoBaja()
        {
            Modelo_Entidades.Estado oEstado = oModelo_Entidades.Estados.ToList().Find(delegate(Modelo_Entidades.Estado fEstado)
            {
                return fEstado.descripcion == "Baja";
            });

            return oEstado;
        }
    }
}
