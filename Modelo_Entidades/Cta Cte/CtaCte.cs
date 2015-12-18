using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class CtaCte
    {
        // Declaro las variables
        private Modelo_Entidades.GCIEntidades oModelo_Entidades = GCIEntidades.ObtenerInstancia();

        public void Modificacion(Modelo_Entidades.CtaCte oCtaCte)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("CtasCtes", oCtaCte);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
