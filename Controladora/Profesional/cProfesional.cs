using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cProfesional
    {
        // Declaro las variables a utilizar en la clase
        private static cProfesional instancia;
        private Modelo_Entidades.WASSWebEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cProfesional ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cProfesional();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cProfesional()
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();
        }

        // Dar de alta a un nuevo profesional
        public void Alta(Modelo_Entidades.Profesional oProfesional)
        {
            oProfesional.Alta(oProfesional);
        }

        // Modificar a un profesional
        public void Modificacion(Modelo_Entidades.Profesional oProfesional)
        {
            oProfesional.Modificacion(oProfesional);
        }

        // Obtener los profesionales
        public List<Modelo_Entidades.Profesional> ObtenerProfesionales()
        {
            return oModelo_Entidades.Profesionales.ToList();
        }

        // Voy filtrando a los profesionales según el DNI introducido
        public List<Modelo_Entidades.Profesional> FiltrarPorDNI(string dni)
        {
            var Consulta = from oProfesional in oModelo_Entidades.Profesionales.ToList()
                           where oProfesional.dni.ToString().StartsWith(dni)
                           select oProfesional;
            return (List<Modelo_Entidades.Profesional>)Consulta.ToList();
        }

        

        // Voy filtrando a los profesionales según el apellido y nombre introducido
        public List<Modelo_Entidades.Profesional> FiltrarPorNyA(string nya)
        {
            var Consulta = from oProfesional in oModelo_Entidades.Profesionales.ToList()
                           where oProfesional.nombre_apellido.Contains(nya)
                           select oProfesional;
            return (List<Modelo_Entidades.Profesional>)Consulta.ToList();
        }

        // Valido que un profesional no exista
        public Boolean ValidarProfesional(int prof_dni)
        {
            Modelo_Entidades.Profesional oProfesional = oModelo_Entidades.Profesionales.ToList().Find(delegate(Modelo_Entidades.Profesional fProfesional)
            {
                return fProfesional.dni == prof_dni;
            });

            if (oProfesional == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Obtengo un profesional dado su dni
        public Modelo_Entidades.Profesional ObtenerProfesional(int dni)
        {
            Modelo_Entidades.Profesional oProfesional = oModelo_Entidades.Profesionales.ToList().Find(delegate(Modelo_Entidades.Profesional fProfesional)
            {
                return fProfesional.dni == dni;
            });

            return oProfesional;
        }

      

  

      
    
    }
}
