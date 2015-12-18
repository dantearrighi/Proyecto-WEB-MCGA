using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cPlan
    {
        // Declaro las variables a utilizar en la clase
        private static cPlan instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cPlan ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cPlan();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cPlan()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Agrego un plan
        public void AgregarPlan(Modelo_Entidades.Plan oPlan)
        {
            oPlan.Alta(oPlan);
        }

        public Modelo_Entidades.Plan ObtenerPlanPorDesc(string plan)
        {
            Modelo_Entidades.Plan oPlan = oModelo_Entidades.Planes.ToList().Find(delegate(Modelo_Entidades.Plan fPlan)
            {
                return fPlan.año == plan;
            });

            return oPlan;
        }

        // Elimino a un plan
        public void EliminarPlan(Modelo_Entidades.Plan oPlan)
        {
            oPlan.Baja(oPlan);
        }

        // Modifico un plan
        public void ModificarPlan(Modelo_Entidades.Plan oPlan)
        {
            oPlan.Modificacion(oPlan);
        }

        // Obtener los planes
        public List<Modelo_Entidades.Plan> ObtenerPlanes()
        {
            return oModelo_Entidades.Planes.ToList();
        }

        // Valido que no un plan no tenga miembros asociados
        public Boolean ValidarPLanesTitulo(Modelo_Entidades.Plan oPla)
        {
            Modelo_Entidades.Plan oPlan = oModelo_Entidades.Planes.ToList().Find(delegate(Modelo_Entidades.Plan fPlan)
            {
                return fPlan == oPla;
            });

            if (oPlan.Legajos_Academicos.Count == 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
