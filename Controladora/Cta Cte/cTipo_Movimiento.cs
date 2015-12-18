using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cTipo_Movimiento
    {
        // Declaro las variables a utilizar en la clase
        private static cTipo_Movimiento instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cTipo_Movimiento ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cTipo_Movimiento();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cTipo_Movimiento()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtengo el tipo de movimiento "Deudor"
        public Modelo_Entidades.Tipo_Movimiento ObtenerMov_Deudor()
        {
            Modelo_Entidades.Tipo_Movimiento oTipo_Movimiento = oModelo_Entidades.Tipos_Movimientos.ToList().Find(delegate(Modelo_Entidades.Tipo_Movimiento fTipo_Movimiento)
            {
                return fTipo_Movimiento.descripcion == "Deudor";
            });

            return oTipo_Movimiento;
        }

        // Obtengo el tipo de movimiento "Acreedor"
        public Modelo_Entidades.Tipo_Movimiento ObtenerMov_Acreedor()
        {
            Modelo_Entidades.Tipo_Movimiento oTipo_Movimiento = oModelo_Entidades.Tipos_Movimientos.ToList().Find(delegate(Modelo_Entidades.Tipo_Movimiento fTipo_Movimiento)
            {
                return fTipo_Movimiento.descripcion == "Acreedor";
            });

            return oTipo_Movimiento;
        }
    }
}
