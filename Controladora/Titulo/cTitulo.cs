using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cTitulo
    {
        // Declaro las variables a utilizar en la clase
        private static cTitulo instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cTitulo ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cTitulo();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cTitulo()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Elimino a un titulo
        public void EliminarTitulo(Modelo_Entidades.Titulo oTitulo)
        {
            oTitulo.Baja(oTitulo);
        }

        // Agrego un titulo
        public void AgregarTitulo(Modelo_Entidades.Titulo oTitulo)
        {
            oTitulo.Alta(oTitulo);
        }

        // Modifico un titulo
        public void ModificarTitulo(Modelo_Entidades.Titulo oTitulo)
        {
            oTitulo.Modificacion(oTitulo);
        }

        // Obtener los titulos
        public List<Modelo_Entidades.Titulo> ObtenerTitulos()
        {
            return oModelo_Entidades.Titulos.ToList();
        }

        // Valido que no exista un titulo igual
        public Boolean ValidarTitulo(string oTit)
        {
            Modelo_Entidades.Titulo oTitulo = oModelo_Entidades.Titulos.ToList().Find(delegate(Modelo_Entidades.Titulo fTitulo)
            {
                return fTitulo.descripcion == oTit;
            });

            if (oTitulo == null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        // Obtener todos los titulos dada una universidad
        public List<Modelo_Entidades.Titulo> BuscarTitulosPorUni(Modelo_Entidades.Universidad oUniversidad)
        {
            var Consulta = from oTitulo in oModelo_Entidades.Titulos.ToList()
                           where oTitulo.Universidad.Equals(oUniversidad)
                           select oTitulo;
            return (List<Modelo_Entidades.Titulo>)Consulta.ToList();
        }

        // Obtengo un titulo dada su universidad
        public Modelo_Entidades.Titulo ObtenerTituloPorUniversidad(Modelo_Entidades.Universidad oUniversidad)
        {
            Modelo_Entidades.Titulo oTitulo = oModelo_Entidades.Titulos.ToList().Find(delegate(Modelo_Entidades.Titulo fTitulo)
            {
                return fTitulo.Universidad == oUniversidad;
            });

            return oTitulo;
        }

        // Obtengo un titulo dada su descripcion
        public Modelo_Entidades.Titulo ObtenerTituloPorDesc(string titulo)
        {
            Modelo_Entidades.Titulo oTitulo = oModelo_Entidades.Titulos.ToList().Find(delegate(Modelo_Entidades.Titulo fTitulo)
            {
                return fTitulo.descripcion == titulo;
            });

            return oTitulo;
        }

        // Obtengo un titulo dada su id
        public Modelo_Entidades.Titulo ObtenerTituloPorID(int titulo)
        {
            Modelo_Entidades.Titulo oTitulo = oModelo_Entidades.Titulos.ToList().Find(delegate(Modelo_Entidades.Titulo fTitulo)
            {
                return fTitulo.id == titulo;
            });

            return oTitulo;
        }

        // Metodo de validación general para todos los titulos
        public List<Modelo_Entidades.Titulo> FiltrarTitulos(string universidad, string especialidad)
        {
            var Consulta = from oTitulo in oModelo_Entidades.Titulos.ToList()
                           select oTitulo;

            if (universidad != "0")
            {
                Consulta = Consulta.Where(oTitulo => oTitulo.Universidad.descripcion == universidad);
            }

            if (especialidad != "0")
            {
                Consulta = Consulta.Where(oTitulo => oTitulo.Especialidad.descripcion == especialidad);
            }

            return (List<Modelo_Entidades.Titulo>)Consulta.ToList();
        }
    }
}
