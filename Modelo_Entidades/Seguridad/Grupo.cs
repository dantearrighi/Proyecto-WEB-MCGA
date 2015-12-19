using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Grupo
    {
        Modelo_Entidades.WASSWebEntidades oModelo_Entidades;

        public override string ToString()
        {
            return (_descripcion);
        }

        public void Alta(Modelo_Entidades.Grupo oGrupo)
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToGrupos(oGrupo);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Grupo oGrupo)
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oGrupo);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Grupo oGrupo)
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Grupos", oGrupo);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
