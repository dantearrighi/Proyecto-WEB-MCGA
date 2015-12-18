using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public abstract partial class Expediente
    {
        Modelo_Entidades.GCIEntidades oModelo_Entidades;

        //private Modelo_Entidades.Expediente oExpediente;

        //public void CambiarExpediente(Expediente nuevoexpediente)
        //{
        //    this.oExpediente = nuevoexpediente;
        //}

        //public List<Modelo_Entidades.Liquidacion> Calcular()
        //{
        //    List<Modelo_Entidades.Liquidacion> ListaLiquidaciones = oExpediente.Liquidaciones.OrderBy(x => x.Id).ToList();
        //    ListaLiquidaciones = this.oExpediente.Calcular_Valor(ListaLiquidaciones);
        //    return ListaLiquidaciones;
        //}

        public abstract List<Modelo_Entidades.Liquidacion> Calcular_Valor(List<Modelo_Entidades.Liquidacion> ListaLiquidaciones);

        public void Alta(Modelo_Entidades.Expediente oExpediente)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToExpedientes(oExpediente);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Modificacion(Modelo_Entidades.Expediente oExpediente)
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();

            try
            {
                oModelo_Entidades.ApplyCurrentValues("Expedientes", oExpediente);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
