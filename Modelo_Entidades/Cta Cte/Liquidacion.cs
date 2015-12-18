using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Liquidacion
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public void Alta(Modelo_Entidades.Liquidacion oLiquidacion)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToLiquidaciones(oLiquidacion);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Liquidacion oLiquidacion)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oLiquidacion);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Liquidacion oLiquidacion)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Liquidaciones", oLiquidacion);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
