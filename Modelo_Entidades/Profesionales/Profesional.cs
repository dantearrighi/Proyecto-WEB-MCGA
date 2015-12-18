using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Profesional
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public override string ToString()
        {
            return (_nombre_apellido);
        }

        public void Alta(Modelo_Entidades.Profesional oProfesional)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToProfesionales(oProfesional);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Profesional oProfesional)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Profesionales", oProfesional);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
