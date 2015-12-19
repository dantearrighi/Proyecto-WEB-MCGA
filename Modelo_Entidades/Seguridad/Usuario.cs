using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Usuario
    {
        Modelo_Entidades.WASSWebEntidades oModelo_Entidades;
        
        public override string ToString()
        {
            return (_nombre_apellido);
        }

        public void Alta(Modelo_Entidades.Usuario oUsuario)
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToUsuarios(oUsuario);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Usuario oUsuario)
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Usuarios", oUsuario);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
