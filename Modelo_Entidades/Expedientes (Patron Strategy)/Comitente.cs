using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Comitente
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public override string ToString()
        {
            return (_razon_social);
        }

        public void Alta(Modelo_Entidades.Comitente oComitente)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToComitentes(oComitente);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Comitente oComitente)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oComitente);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Comitente oComitente)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Comitentes", oComitente);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
