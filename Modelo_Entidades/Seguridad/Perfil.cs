using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Perfil
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public void Alta(Modelo_Entidades.Perfil oPerfil)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.Perfiles.AddObject(oPerfil);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Perfil oPerfil)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.Perfiles.DeleteObject(oPerfil);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
