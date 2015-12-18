using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cDocente
    {
        // Declaro las variables a utilizar en la clase
        private static cDocente instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cDocente ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cDocente();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cDocente()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener los Docentes
        public List<Modelo_Entidades.Docente> ObtenerDocentes()
        {
            return oModelo_Entidades.Docentes.ToList();
        }

        // Elimino a un Docentes
        public void EliminarDocente(Modelo_Entidades.Docente oDocente)
        {
            oModelo_Entidades.DeleteObject(oDocente);
            oModelo_Entidades.SaveChanges();
        }

        // Agrego un Docentes
        public void AgregarDocente(Modelo_Entidades.Docente oDocente)
        {
            oModelo_Entidades.AddToDocentes(oDocente);
            oModelo_Entidades.SaveChanges();
        }

        // Modifico un Docentes
        public void ModificarDocente(Modelo_Entidades.Docente oDocente)
        {
            oModelo_Entidades.ApplyCurrentValues("Docentes", oDocente);
            oModelo_Entidades.SaveChanges();
        }

        // Obtengo un Docentes dada su id
        public Modelo_Entidades.Docente ObtenerDocente(int id)
        {
            Modelo_Entidades.Docente oDocente = oModelo_Entidades.Docentes.ToList().Find(delegate(Modelo_Entidades.Docente fDocente)
            {
                return fDocente.id == id;
            });

            return oDocente;
        }

        // Obtengo un Docentes dada su nombre y apellido
        public Modelo_Entidades.Docente ObtenerDocentePorNombre(string nya)
        {
            Modelo_Entidades.Docente oDocente = oModelo_Entidades.Docentes.ToList().Find(delegate(Modelo_Entidades.Docente fDocente)
            {
                return fDocente.nombre_apellido == nya;
            });

            return oDocente;
        }
    }
}
