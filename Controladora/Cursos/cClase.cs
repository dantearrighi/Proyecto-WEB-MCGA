using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cClase
    {
        // Declaro las variables a utilizar en la clase
        private static cClase instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cClase ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cClase();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cClase()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Clasees
        public List<Modelo_Entidades.Clase> ObtenerClases()
        {
            return oModelo_Entidades.Clases.ToList();
        }

        // Elimino a un clase
        public void EliminarClase(Modelo_Entidades.Clase oClase)
        {
            oModelo_Entidades.DeleteObject(oClase);
            oModelo_Entidades.SaveChanges();
        }

        // Agrego un clase
        public void AgregarClase(Modelo_Entidades.Clase oClase)
        {
            oModelo_Entidades.AddToClases(oClase);
            oModelo_Entidades.SaveChanges();
        }

        // Modifico un clase
        public void ModificarClase(Modelo_Entidades.Clase oClase)
        {
            oModelo_Entidades.ApplyCurrentValues("Clases", oClase);
            oModelo_Entidades.SaveChanges();
        }

        // Obtengo un Clase dado su id
        public Modelo_Entidades.Clase ObtenerClase(int id)
        {
            Modelo_Entidades.Clase oClase = oModelo_Entidades.Clases.ToList().Find(delegate(Modelo_Entidades.Clase fClase)
            {
                return fClase.id == id;
            });

            return oClase;
        }

        // Obtener todos las clases de una curso
        public List<Modelo_Entidades.Clase> ObtenerClasesPorCurso(int id)
        {
            var Consulta = from oClase in oModelo_Entidades.Clases.ToList()
                           where oClase.Curso.id == id
                           select oClase;
            return (List<Modelo_Entidades.Clase>)Consulta.ToList();
        }

        // Obtener todos las clases de una curso
        public Modelo_Entidades.Clase Obtener1ClasePorCurso(int id)
        {
            Modelo_Entidades.Clase oClase = oModelo_Entidades.Clases.ToList().Find(delegate(Modelo_Entidades.Clase fClase)
            {
                return fClase.Curso.id == id;
            });

            return oClase;
        }
    }
}
