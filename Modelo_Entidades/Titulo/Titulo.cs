using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Titulo
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;
    
        public override string ToString()
        {
            return (_descripcion);
        }

        public void Alta(Modelo_Entidades.Titulo oTitulo)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToTitulos(oTitulo);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Titulo oTitulo)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oTitulo);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Titulo oTitulo)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Titulos", oTitulo);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
