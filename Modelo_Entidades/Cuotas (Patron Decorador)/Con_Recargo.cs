using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Con_Recargo : Modificador
    {
        int dias_ok;

        public Con_Recargo(Cuota s, int dias): base(s)
        {
            dias_ok = dias;
        }

        public override double Valor() 
        {
            if (AlteradorAusar().dias_gracias < dias_ok)
            {
                return oCuota.Valor() + (oCuota.Valor() * AlteradorAusar().porcentaje_recargo * (dias_ok - AlteradorAusar().dias_gracias));
            }

            else
            {
                return oCuota.Valor();
            }
        }
    }
}
