using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Descuento_Anual : Modificador
    {
        public Descuento_Anual(Cuota s): base(s)
        {
        }

        public override double Valor() // Es la operación que calcula el valor de una cuota anual. La cuota bimensual no tiene operaciones
        {
            return oCuota.Valor() - AlteradorAusar().valor_cuota;
        }
    }
}
