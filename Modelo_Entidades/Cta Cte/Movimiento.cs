using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Movimiento
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public void Alta(Modelo_Entidades.Movimiento oMovimiento)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToMovimientos(oMovimiento);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Movimiento oMovimiento)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oMovimiento);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Movimiento oMovimiento)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Movimientos", oMovimiento);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
