using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Tarea
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        public override string ToString()
        {
            return (_descripcion);
        }

        public void Alta(Modelo_Entidades.Tarea oTarea)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToTareas(oTarea);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Tarea oTarea)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.DeleteObject(oTarea);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Tarea oTarea)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Tareas", oTarea);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
