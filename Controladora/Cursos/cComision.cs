using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cComision
    {
        // Declaro las variables a utilizar en la clase
        private static cComision instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cComision ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cComision();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cComision()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las comisiones
        public List<Modelo_Entidades.Comision> ObtenerComisiones()
        {
            return oModelo_Entidades.Comisiones.ToList();
        }

        // Elimino a un titulo
        public void EliminarComision(Modelo_Entidades.Comision oComision)
        {
            oModelo_Entidades.DeleteObject(oComision);
            oModelo_Entidades.SaveChanges();
        }

        // Agrego un titulo
        public void AgregarComision(Modelo_Entidades.Comision oComision)
        {
            oModelo_Entidades.AddToComisiones(oComision);
            oModelo_Entidades.SaveChanges();
        }

        // Modifico un titulo
        public void ModificarComision(Modelo_Entidades.Comision oComision)
        {
            oModelo_Entidades.ApplyCurrentValues("Comisiones", oComision);
            oModelo_Entidades.SaveChanges();
        }

        // Obtener todos los titulos dada una universidad
        public string ObtenerTotalComisiones()
        {
            var Consulta = from oCom in oModelo_Entidades.Comisiones.ToList()
                           select new { oCom.dinero_asignado};

            var sum = Consulta.ToList().Select(c=>c.dinero_asignado).Sum().ToString();

            return (string)sum;
        }

        // Obtengo una comision dado su id
        public Modelo_Entidades.Comision ObtenerComision(int id)
        {
            Modelo_Entidades.Comision oComision = oModelo_Entidades.Comisiones.ToList().Find(delegate(Modelo_Entidades.Comision fComision)
            {
                return fComision.id == id;
            });

            return oComision;
        }

        // Obtengo una comision dado su descripcion
        public Modelo_Entidades.Comision ObtenerComisionPorDesc(string desc)
        {
            Modelo_Entidades.Comision oComision = oModelo_Entidades.Comisiones.ToList().Find(delegate(Modelo_Entidades.Comision fComision)
            {
                return fComision.descripcion == desc;
            });

            return oComision;
        }
    }
}
