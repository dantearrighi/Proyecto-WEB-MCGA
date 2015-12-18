using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Auditoria_Log
    {
        Modelo_Entidades.GCI_AuditoriaContainer oModelo_Entidades;

        public void Alta(Modelo_Entidades.Auditoria_Log oAuditoria)
        {
            oModelo_Entidades = Modelo_Entidades.GCI_AuditoriaContainer.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToAuditorias_Log(oAuditoria);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Formatear()
        {
            oModelo_Entidades = Modelo_Entidades.GCI_AuditoriaContainer.ObtenerInstancia();

            try
            {
                foreach (Modelo_Entidades.Auditoria_Log oAuditoria in oModelo_Entidades.Auditorias_Log)
                {
                    oModelo_Entidades.DeleteObject(oAuditoria);
                }

                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Baja(Modelo_Entidades.Auditoria_Log oAuditoria)
        {
            oModelo_Entidades = Modelo_Entidades.GCI_AuditoriaContainer.ObtenerInstancia();

            try
            {
                oModelo_Entidades.Auditorias_Log.DeleteObject(oAuditoria);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }
    }
}
