using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cAsistencia
    {
        // Declaro las variables a utilizar en la Asistencia
        private static cAsistencia instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la Asistencia
        public static cAsistencia ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cAsistencia();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cAsistencia()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Asistenciaes
        public List<Modelo_Entidades.Asistencia> ObtenerAsistencias()
        {
            return oModelo_Entidades.Asistencias.ToList();
        }

        // Elimino a un Asistencia
        public void EliminarAsistencia(Modelo_Entidades.Asistencia oAsistencia)
        {
            oModelo_Entidades.DeleteObject(oAsistencia);
            oModelo_Entidades.SaveChanges();
        }

        // Agrego un Asistencia
        public void AgregarAsistencia(Modelo_Entidades.Asistencia oAsistencia)
        {
            oModelo_Entidades.AddToAsistencias(oAsistencia);
            oModelo_Entidades.SaveChanges();
        }

        // Modifico un Asistencia
        public void ModificarAsistencia(Modelo_Entidades.Asistencia oAsistencia)
        {
            oModelo_Entidades.ApplyCurrentValues("Asistencias", oAsistencia);
            oModelo_Entidades.SaveChanges();
        }

        // Obtengo un Asistencia dado su id
        public Modelo_Entidades.Asistencia ObtenerAsistencia(int id)
        {
            Modelo_Entidades.Asistencia oAsistencia = oModelo_Entidades.Asistencias.ToList().Find(delegate(Modelo_Entidades.Asistencia fAsistencia)
            {
                return fAsistencia.id == id;
            });

            return oAsistencia;
        }

        // Obtengo un Asistencia por le profesinal y la clase
        public Modelo_Entidades.Asistencia ObtenerAsistenciaPorProfyCurso(int dni, int curso_id)
        {
            Modelo_Entidades.Asistencia oAsistencia = oModelo_Entidades.Asistencias.ToList().Find(delegate(Modelo_Entidades.Asistencia fAsistencia)
            {
                return fAsistencia.Profesional.dni == dni && fAsistencia.Clase.Curso.id == curso_id;
            });

            return oAsistencia;
        }

        // Obtener todos las asistencias de un curso
        public List<Modelo_Entidades.Asistencia> ObtenerAsistenciasPorCurso(int id)
        {
            var Consulta = from oAsistencia in oModelo_Entidades.Asistencias.ToList()
                           where oAsistencia.Clase.Curso.id == id
                           select oAsistencia;
            return (List<Modelo_Entidades.Asistencia>)Consulta.ToList();
        }

        // Obtengo la cantidad de asistencias de un profesional dado un curso
        public List<Modelo_Entidades.Asistencia> ObtenerAsistenciasPorCursoyProfesional(int dni, int curso_id)
        {
            var Consulta = from oAsistencia in oModelo_Entidades.Asistencias.ToList()
                           where oAsistencia.Clase.Curso.id == curso_id && oAsistencia.Profesional.dni == dni && oAsistencia.presente == true
                           select oAsistencia;
            return (List<Modelo_Entidades.Asistencia>)Consulta.ToList();
        }

        // Obtengo la cantidad de asistencias de un clase dado un curso
        public List<Modelo_Entidades.Asistencia> ObtenerAsistenciasPorClaseyCurso(int clase_id, int curso_id)
        {
            var Consulta = from oAsistencia in oModelo_Entidades.Asistencias.ToList()
                           where oAsistencia.Clase.Curso.id == curso_id && oAsistencia.Clase.id == clase_id && oAsistencia.presente == true
                           select oAsistencia;
            return (List<Modelo_Entidades.Asistencia>)Consulta.ToList();
        }
    }
}
