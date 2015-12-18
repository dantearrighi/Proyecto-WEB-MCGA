using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cAuditoria
    {
        // Declaro las variables a utilizar en la clase
        private static cAuditoria instancia;
        private Modelo_Entidades.GCI_AuditoriaContainer oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cAuditoria ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cAuditoria();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cAuditoria()
        {
            oModelo_Entidades = Modelo_Entidades.GCI_AuditoriaContainer.ObtenerInstancia();
        }

        // Audito el login de un usuario y agrego la auditoria
        public void AuditarLogUsuario(Modelo_Entidades.Auditoria_Log oAuditoria)
        {
            oAuditoria.Alta(oAuditoria);
        }

        // Audito el login de un usuario y agrego la auditoria
        public void AuditarCuota(Modelo_Entidades.Auditoria_Cuota oCuota)
        {
            oCuota.Alta(oCuota);
        }

        // Obtener las auditorias
        public List<Modelo_Entidades.Auditoria_Log> ObtenerAuditorias()
        {
            return oModelo_Entidades.Auditorias_Log.ToList();
        }

        // Busco al usuario 
        public Modelo_Entidades.Auditoria_Log ObtenerAuditoria(int auditoria)
        {
            Modelo_Entidades.Auditoria_Log oAuditoria = oModelo_Entidades.Auditorias_Log.ToList().Find(delegate(Modelo_Entidades.Auditoria_Log fAuditoria)
            {
                return fAuditoria.id == auditoria;
            });

            return oAuditoria;
        }

        // Obtener las auditorias de la cuotas
        public List<Modelo_Entidades.Auditoria_Cuota> ObtenerAuditoriasCuotas()
        {
            return oModelo_Entidades.Auditorias_Cuotas.ToList();
        }

        // Obtengo las acciones de todas las auditorias
        public List<string> ObtenerAcciones()
        {
            var Consulta = from oAuditoria in oModelo_Entidades.Auditorias_Log.ToList()
                           group oAuditoria by oAuditoria.accion into Acciones
                           select Acciones.Key;
            return (List<string>)Consulta.ToList();
        }

        // Formateo de la tabla auditorias
        public void FormatearAuditorias()
        {
            Modelo_Entidades.Auditoria_Log oAuditoria = new Modelo_Entidades.Auditoria_Log();
            oAuditoria.Formatear();
        }

        // Elimino un registro de la tabla "Auditorias"
        public void BajaAuditoria(Modelo_Entidades.Auditoria_Log oAuditoria)
        {
            oAuditoria.Baja(oAuditoria);
        }

        // Metodo de filtrado general para todos las auditorias
        public List<Modelo_Entidades.Auditoria_Log> FiltrarAuditorias(string nya, string accion, string fecha_desde, string fecha_hasta)
        {
            var Consulta = from oAuditoria in oModelo_Entidades.Auditorias_Log.ToList()
                           select oAuditoria;

            if (nya != "0")
            {
                Consulta = Consulta.Where(oAuditoria => oAuditoria.usuario.Contains(nya));
            }

            if (accion != "0")
            {
                Consulta = Consulta.Where(oAuditoria => oAuditoria.accion == accion);
            }

            if (fecha_desde != "0")
            {
                Consulta = Consulta.Where(oAuditoria =>  oAuditoria.fecha > Convert.ToDateTime(fecha_desde) && oAuditoria.fecha < Convert.ToDateTime(fecha_hasta));
            }

            return (List<Modelo_Entidades.Auditoria_Log>)Consulta.ToList();
        }

        // Metodo de filtrado general para todos las auditorias de las cuotas
        public List<Modelo_Entidades.Auditoria_Cuota> FiltrarAuditoriasCuotas(string nya, string dni, string cuota)
        {
            var Consulta = from oAuditoria in oModelo_Entidades.Auditorias_Cuotas.ToList()
                           select oAuditoria;

            if (nya != "0")
            {
                Consulta = Consulta.Where(oAuditoria => oAuditoria.usuario.Contains(nya));
            }

            if (dni != "0")
            {
                Consulta = Consulta.Where(oAuditoria => oAuditoria.Profesional_dni.ToString() == dni);
            }

            if (cuota != "0")
            {
                Consulta = Consulta.Where(oAuditoria => oAuditoria.descripcion == cuota);
            }

            return (List<Modelo_Entidades.Auditoria_Cuota>)Consulta.ToList();
        }

    }
}
