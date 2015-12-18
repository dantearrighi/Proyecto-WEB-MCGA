using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Auditoria_Cuota
    {
        Modelo_Entidades.GCI_AuditoriaContainer oModelo_Entidades;

        public void Alta(Modelo_Entidades.Auditoria_Cuota oCuota)
        {
            oModelo_Entidades = Modelo_Entidades.GCI_AuditoriaContainer.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToAuditorias_Cuotas(oCuota);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
