using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Auditoria_Log
    {
        Modelo_Entidades.WASSWeb_AuditoriaContainer oModelo_Entidades;

        public void Alta(Modelo_Entidades.Auditoria_Log oLog)
        {
            oModelo_Entidades = Modelo_Entidades.WASSWeb_AuditoriaContainer.ObtenerInstancia();

            try
            {
                oModelo_Entidades.AddToAuditorias_Log(oLog);
                oModelo_Entidades.SaveChanges();
            }

            catch { }
        }

        public void Formatear()
        {
            throw new NotImplementedException();
        }

        public void Baja(Auditoria_Log oAuditoria)
        {
            throw new NotImplementedException();
        }
    }
}
