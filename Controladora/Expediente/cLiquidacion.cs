using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cLiquidacion
    {
        // Declaro las variables a utilizar en la Liquidacion
        private static cLiquidacion instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la Liquidacion
        public static cLiquidacion ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cLiquidacion();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cLiquidacion()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Liquidaciones
        public List<Modelo_Entidades.Liquidacion> ObtenerLiquidaciones()
        {
            return oModelo_Entidades.Liquidaciones.ToList();
        }

        // Elimino a un Liquidacion
        public void EliminarLiquidacion(Modelo_Entidades.Liquidacion oLiquidacion)
        {
            oLiquidacion.Baja(oLiquidacion);
        }

        // Agrego un Liquidacion
        public void AgregarLiquidacion(Modelo_Entidades.Liquidacion oLiquidacion)
        {
            oLiquidacion.Alta(oLiquidacion);
        }

        // Modifico un Liquidacion
        public void ModificarLiquidacion(Modelo_Entidades.Liquidacion oLiquidacion)
        {
            oLiquidacion.Modificacion(oLiquidacion);
        }

        // Obtengo una liquidacion dada su descripcion
        public Modelo_Entidades.Liquidacion ObtenerLiquidacion(string desc)
        {
            Modelo_Entidades.Liquidacion oLiquidacion = oModelo_Entidades.Liquidaciones.ToList().Find(delegate(Modelo_Entidades.Liquidacion fLiquidacion)
            {
                return fLiquidacion.tarea == desc;
            });

            return oLiquidacion;
        }
    }
}
