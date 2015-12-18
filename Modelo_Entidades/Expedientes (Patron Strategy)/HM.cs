using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class HM : Expediente
    {
        public override List<Modelo_Entidades.Liquidacion> Calcular_Valor(List<Modelo_Entidades.Liquidacion> ListaLiquidaciones)
        {
            ListaLiquidaciones.ElementAt(0).importe = ListaLiquidaciones.ElementAt(0).importe * ListaLiquidaciones.ElementAt(0).cantidad * 1612;
            ListaLiquidaciones.ElementAt(1).importe = ListaLiquidaciones.ElementAt(1).importe * ListaLiquidaciones.ElementAt(0).cantidad * 1612;
            return ListaLiquidaciones;
        }
    }
}
