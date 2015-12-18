using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Matricula
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public override string ToString()
        {
            return (_icie);
        }

        public void Alta(Modelo_Entidades.Matricula oMatricula)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToMatriculas(oMatricula);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Matricula oMatricula)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Matriculas", oMatricula);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
