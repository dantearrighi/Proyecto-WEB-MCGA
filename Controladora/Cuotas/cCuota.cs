using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cCuota
    {
        // Declaro las variables a utilizar en la clase
        Modelo_Entidades.Cuota cuotacalaculada;
        private static cCuota instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cCuota ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cCuota();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cCuota()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Cuotaes
        public List<Modelo_Entidades.Cuota> ObtenerCuotas()
        {
            return oModelo_Entidades.Cuotas.ToList();
        }

        // Elimino a un Cuota
        public void EliminarCuota(Modelo_Entidades.Cuota oCuota)
        {
            oCuota.Baja(oCuota);
        }

        // Agrego un Cuota
        public void AgregarCuota(Modelo_Entidades.Cuota oCuota)
        {
            oCuota.Alta(oCuota);
        }

        // Modifico un Cuota
        public void ModificarCuota(Modelo_Entidades.Cuota oCuota)
        {
            oCuota.Modificacion(oCuota);
        }

        // Declaro el método que va a devolver el valor de una cuota según lo que le esté pidiendo
        public Modelo_Entidades.Cuota ObtenerValor_Tipo_Couta(Modelo_Entidades.Cuota oCuota)
        {
            if (oCuota.GetType().ToString() == "Modelo_Entidades.Anual") // Si es anual la "decoro" con un descuento
            {
                cuotacalaculada = new Modelo_Entidades.Descuento_Anual(oCuota);
            }

            else // Sino, devuelvo el valor normal de una cuota
            {
                cuotacalaculada = oCuota;
            }

            return cuotacalaculada;
        }

        // Declaro el método que va a devolver el valor de una cuota con los intereses aplicados
        public double ObtenerValor_Couta_Interes(Modelo_Entidades.Cuota oCuota, int dias)
        {
            cuotacalaculada = new Modelo_Entidades.Con_Recargo(oCuota, dias);

            return cuotacalaculada.Valor();
        }

        // Obtener las cuotas impagas de un profesional
        public List<Modelo_Entidades.Cuota> BuscarCuotasImpagasPorProfesional(int dni)
        {
            var Consulta = from oCuota in oModelo_Entidades.Cuotas.ToList()
                           where oCuota.Profesional.dni == dni && oCuota.estado == false
                           select oCuota;
            return (List<Modelo_Entidades.Cuota>)Consulta.ToList();
        }

        // Obtengo una cuota dado un profesional y la descripción
        public Modelo_Entidades.Cuota ObtenerCuota(string desc, int dni)
        {
            Modelo_Entidades.Cuota oCuota = oModelo_Entidades.Cuotas.ToList().Find(delegate(Modelo_Entidades.Cuota fCuota)
            {
                return fCuota.descripcion == desc && fCuota.Profesional.dni == dni;
            });

            return oCuota;
        }

        // Obtener las cuotas pagas de un profesional
        public List<Modelo_Entidades.Cuota> BuscarCuotasPagasPorProfesional(int dni)
        {
            var Consulta = from oCuota in oModelo_Entidades.Cuotas.ToList()
                           where oCuota.Profesional.dni == dni && oCuota.estado == true
                           select oCuota;
            return (List<Modelo_Entidades.Cuota>)Consulta.ToList();
        }

        // Obtener si el profesional pagó la cuota anual de ese año o la cuota que se le está queriendo generar para que no se la generen
        public bool ObtenerSiElProfPago(Modelo_Entidades.Profesional oProfesional, string cuota, string año)
        {
            Modelo_Entidades.Cuota oCuota = oModelo_Entidades.Cuotas.ToList().Find(delegate(Modelo_Entidades.Cuota fCuota)
            {
                if (fCuota.descripcion.Contains(cuota) || fCuota.descripcion.Contains("Cuota anual año " + año) == true)
                {
                    if (fCuota.Profesional == oProfesional)
                    {
                        if (fCuota.estado == true)
                        {
                            return true; // Si encuentra la cuota quiere decir que pagó, devuelvo un true y no la cobro, ya que quiere decir que encontró una cuota que cumple con todas las condiciones del where (es decir, que el profesional pagó la cuota anual o la bimensual que se está generando)
                        }
                    }
                }

                return false;
            });

            if (oCuota == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }
    }
}
