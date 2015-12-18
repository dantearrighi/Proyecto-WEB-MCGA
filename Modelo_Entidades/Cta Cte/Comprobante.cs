using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Comprobante
    {
        // Declaro las variables
        private Modelo_Entidades.GCIEntidades oModelo_Entidades = GCIEntidades.ObtenerInstancia();

        public void Alta(Modelo_Entidades.Comprobante oComprobante)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToComprobantes(oComprobante);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Comprobante oComprobante)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oComprobante);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
