using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cComitente
    {
        // Declaro las variables a utilizar en la Comitente
        private static cComitente instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la Comitente
        public static cComitente ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cComitente();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cComitente()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener los comitentes
        public List<Modelo_Entidades.Comitente> ObtenerComitentes()
        {
            return oModelo_Entidades.Comitentes.ToList();
        }

        // Elimino a un Comitente
        public void EliminarComitente(Modelo_Entidades.Comitente oComitente)
        {
            oComitente.Baja(oComitente);
        }

        // Agrego un Comitente
        public void AgregarComitente(Modelo_Entidades.Comitente oComitente)
        {
            oComitente.Alta(oComitente);
        }

        // Modifico un Comitente
        public void ModificarComitente(Modelo_Entidades.Comitente oComitente)
        {
            oComitente.Modificacion(oComitente);
        }

        // Voy filtrando a los comitentes según la razón social
        public List<Modelo_Entidades.Comitente> FiltrarPorNyA(string nya)
        {
            var Consulta = from oComitente in oModelo_Entidades.Comitentes.ToList()
                           where oComitente.razon_social.Contains(nya)
                           select oComitente;
            return (List<Modelo_Entidades.Comitente>)Consulta.ToList();
        }

        // Valido que no exista un comitente por la razón social
        public Boolean ValidarComitente(string comitente)
        {
            Modelo_Entidades.Comitente oComitente = oModelo_Entidades.Comitentes.ToList().Find(delegate(Modelo_Entidades.Comitente fComitente)
            {
                return fComitente.razon_social == comitente;
            });

            if (oComitente == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public Modelo_Entidades.Comitente ObtenerComitente(int id)
        {
            Modelo_Entidades.Comitente oComitente = oModelo_Entidades.Comitentes.ToList().Find(delegate(Modelo_Entidades.Comitente fComitente)
            {
                return fComitente.Id == id;
            });

            return oComitente;
        }

        public Modelo_Entidades.Comitente ObtenerComitentePorDesc(string desc)
        {
            Modelo_Entidades.Comitente oComitente = oModelo_Entidades.Comitentes.ToList().Find(delegate(Modelo_Entidades.Comitente fComitente)
            {
                return fComitente.razon_social == desc;
            });

            return oComitente;
        }
    }
}
