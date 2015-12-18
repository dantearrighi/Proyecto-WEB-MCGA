using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class OI : Expediente
    {
        public override List<Modelo_Entidades.Liquidacion> Calcular_Valor(List<Modelo_Entidades.Liquidacion> ListaLiquidaciones)
        {
            ListaLiquidaciones.ElementAt(0).importe = ListaLiquidaciones.ElementAt(0).importe * 0.10m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(1).importe = ListaLiquidaciones.ElementAt(1).importe * 0.45m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(2).importe = ListaLiquidaciones.ElementAt(2).importe * 0.55m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(3).importe = ListaLiquidaciones.ElementAt(3).importe * 0.45m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(4).importe = ListaLiquidaciones.ElementAt(4).importe * 0.135m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(5).importe = ListaLiquidaciones.ElementAt(5).importe * 0.002m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(6).importe = ListaLiquidaciones.ElementAt(6).importe * 0.585m; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(7).importe = ListaLiquidaciones.ElementAt(7).importe * 0.45m; // Esta harcodeado, pero hay que definirlo en 1 variable

            return ListaLiquidaciones;
        }
    }
}
