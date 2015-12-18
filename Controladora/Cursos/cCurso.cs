using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cCurso
    {
        // Declaro las variables a utilizar en la clase
        private static cCurso instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cCurso ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cCurso();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cCurso()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Cursoes
        public List<Modelo_Entidades.Curso> ObtenerCursos()
        {
            return oModelo_Entidades.Cursos.ToList();
        }

        // Elimino a un titulo
        public void EliminarCurso(Modelo_Entidades.Curso oCurso)
        {
            oModelo_Entidades.DeleteObject(oCurso);
            oModelo_Entidades.SaveChanges();
        }

        // Agrego un titulo
        public void AgregarCurso(Modelo_Entidades.Curso oCurso)
        {
            oModelo_Entidades.AddToCursos(oCurso);
            oModelo_Entidades.SaveChanges();
        }

        // Modifico un titulo
        public void ModificarCurso(Modelo_Entidades.Curso oCurso)
        {
            oModelo_Entidades.ApplyCurrentValues("Cursos", oCurso);
            oModelo_Entidades.SaveChanges();
        }

        // Obtengo un curso dado su id
        public Modelo_Entidades.Curso ObtenerCurso(int id)
        {
            Modelo_Entidades.Curso oCurso = oModelo_Entidades.Cursos.ToList().Find(delegate(Modelo_Entidades.Curso fCurso)
            {
                return fCurso.id == id;
            });

            return oCurso;
        }

        // Obtener todos los cursos de una comision
        public List<Modelo_Entidades.Curso> ObtenerCursoPorComision(int id)
        {
            var Consulta = from oCurso in oModelo_Entidades.Cursos.ToList()
                           where oCurso.Comision.id == id
                           select oCurso;
            return (List<Modelo_Entidades.Curso>)Consulta.ToList();
        }
    }
}
