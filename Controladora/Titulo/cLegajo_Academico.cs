using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cLegajo_Academico
    {
        // Declaro las variables a utilizar en la clase
        private static cLegajo_Academico instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cLegajo_Academico ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cLegajo_Academico();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cLegajo_Academico()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener los legajos académicos
        public List<Modelo_Entidades.Legajo_Academico> ObtenerLegajos()
        {
            return oModelo_Entidades.Legajos_Academicos.ToList();
        }

        // Agrego un legajo academico
        public void AgregarLegajo(Modelo_Entidades.Legajo_Academico oLegajo_Academico)
        {
            oLegajo_Academico.Alta(oLegajo_Academico);
        }

        // Modifico un legajo academico
        public void Modificacion(Modelo_Entidades.Legajo_Academico oLegajo_Academico)
        {
            oLegajo_Academico.Modificacion(oLegajo_Academico);
        }

        // Elimino un legajo academico
        public void BajaLegajo(Modelo_Entidades.Legajo_Academico oLegajo_Academico)
        {
            oLegajo_Academico.Baja(oLegajo_Academico);
        }

        // Obtener todos los planes dada la descripción de un titulo
        public List<Modelo_Entidades.Plan> BuscarPlanesPorTit(Modelo_Entidades.Titulo oTitulo)
        {
            var Consulta = from oLegajo_Academico in oModelo_Entidades.Legajos_Academicos.ToList()
                           where oLegajo_Academico.Titulo == oTitulo
                           select oLegajo_Academico.Plan;
            return (List<Modelo_Entidades.Plan>)Consulta.Distinct().ToList();
        }

        // Valido que no exista un titulo con el mismo plan
        public Boolean ValidarPlandelTitulo(string plan)
        {
            Modelo_Entidades.Legajo_Academico oLegajo_Academico = oModelo_Entidades.Legajos_Academicos.ToList().Find(delegate(Modelo_Entidades.Legajo_Academico fLegajo_Academico)
            {
                return fLegajo_Academico.Plan.año == plan;
            });

            if (oLegajo_Academico == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Valido que no exista un titulo en los legajos para luego poder eliminarlo
        public Boolean ValidarPlanesdelTitulo(Modelo_Entidades.Titulo oTitulo)
        {
            Modelo_Entidades.Legajo_Academico oLegajo_Academico = oModelo_Entidades.Legajos_Academicos.ToList().Find(delegate(Modelo_Entidades.Legajo_Academico fLegajo_Academico)
            {
                return fLegajo_Academico.Titulo == oTitulo;
            });

            if (oTitulo.Legajos_Academicos.Count != 0)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Obtener el legajo academico dado un titulo y un plan
        public Modelo_Entidades.Legajo_Academico BuscarLegajoPorTityPlan(Modelo_Entidades.Titulo oTitulo, Modelo_Entidades.Plan oPlan)
        {
            Modelo_Entidades.Legajo_Academico oLegajo_Academico = oModelo_Entidades.Legajos_Academicos.ToList().Find(delegate(Modelo_Entidades.Legajo_Academico fLegajo_Academico)
            {
                return fLegajo_Academico.Plan == oPlan && fLegajo_Academico.Titulo == oTitulo;
            });

            return oLegajo_Academico;
        }

        // Obtener si el profesional tiene un título o no
        public bool ObtenerSiElProfTieneTit(Modelo_Entidades.Profesional oProfesional, int tit_id, int uni_id)
        {
            Modelo_Entidades.Matricula oMatricula = oModelo_Entidades.Matriculas.ToList().Find(delegate(Modelo_Entidades.Matricula fMatricula)
            {
                return fMatricula.Legajo_Academico.Titulo.Universidad.id == uni_id && fMatricula.Legajo_Academico.Titulo.id == tit_id && fMatricula.Profesional == oProfesional;
            });

            if (oMatricula == null)
            {
                return true; // Sino la encontró, devuelvo un true y la cargo
            }

            else
            {
                return false; // Si la encontró, devuelvo un false y no la cargo
            }
        }
    }
}
