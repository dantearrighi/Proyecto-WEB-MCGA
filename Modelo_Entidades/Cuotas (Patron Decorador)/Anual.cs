using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class Anual: Cuota
    {        
        public override double Valor()
        {
            Modelo_Entidades.Alterador oAlterador = AlteradorAusar();
            return (oAlterador.valor_cuota * 6);
        }
    }
}
