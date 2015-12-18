using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class FE: Expediente
    {
        decimal suma = 0;
        decimal valor_1;
        decimal valor_2;
        decimal valor_3;
        decimal valor_4;
        decimal valor_5;
        decimal valor_6;

        public override List<Modelo_Entidades.Liquidacion> Calcular_Valor(List<Modelo_Entidades.Liquidacion> ListaLiquidaciones)
        {
            ListaLiquidaciones.ElementAt(0).importe = ListaLiquidaciones.ElementAt(0).importe * ListaLiquidaciones.ElementAt(0).cantidad * 1612; // Esta harcodeado, pero hay que definirlo en 1 variable
            ListaLiquidaciones.ElementAt(1).importe = ListaLiquidaciones.ElementAt(1).importe * ListaLiquidaciones.ElementAt(0).cantidad * 1612; // Esta harcodeado, pero hay que definirlo en 1 variable
            
            // Calculo el total para la liquidación
            decimal monto_obra = ListaLiquidaciones.ElementAt(2).importe;

            // Los valores estan hardcodeados, pero habría que editarlos
            if ((34*1612) <= monto_obra)
            {
                valor_1 = (34*1612) * 0.02m;

                if ((valor_1 == (34 * 1612) * 0.02m) && (monto_obra - (34 * 1612)) >= (34 * 1612))
                {
                    valor_2 = (34 * 1612) * 0.018m;

                    if ((valor_2 == ((34 * 1612)) * 0.018m) && (monto_obra - (34 * 1612) - (34 * 1612)) >= (67 * 1612))
                    {
                        valor_3 = (67 * 1612) * 0.015m;

                        if ((valor_3 == ((67 * 1612)) * 0.018m) && (monto_obra - (34 * 1612) - (34 * 1612) - (67 * 1612)) >= (202 * 1612))
                        {
                            valor_4 = (202 * 1612) * 0.0125m;

                            if ((valor_4 == ((202 * 1612)) * 0.0125m) && (monto_obra - (34 * 1612) - (34 * 1612) - (67 * 1612) - (202 * 1612)) >= (337 * 1612))
                            {
                                valor_5 = (337 * 1612) * 0.01m;

                                if ((valor_5 == ((337 * 1612)) * 0.01m))
                                {
                                    valor_6 = (monto_obra - (34 * 1612) - (34 * 1612) - (67 * 1612) - (202 * 1612) - (337 * 1612)) * 0.0075m;
                                }

                                else
                                {
                                    valor_6 = 0;
                                }
                            }

                            else
                            {
                                valor_5 = (monto_obra - (34 * 1612) - (34 * 1612) - (67 * 1612) - (202 * 1612)) * 0.01m;
                            }
                        }

                        else
                        {
                            valor_4 = (monto_obra - (34 * 1612) - (34 * 1612) - (67 * 1612)) * 0.0125m;
                        }
                    }

                    else
                    {
                        valor_3 = (monto_obra - (34 * 1612) - (34 * 1612)) * 0.015m;
                    }
                }

                else
                {
                    valor_2 = (monto_obra - (34 * 1612)) * 0.018m;
                }
            }

            else
            {
                valor_1 = monto_obra * 0.02m;
            }

            suma = valor_1 + valor_2 + valor_3 + valor_4 + valor_5 + valor_6;

            ListaLiquidaciones.ElementAt(2).importe = suma;

            return ListaLiquidaciones;
        }
    }
}
