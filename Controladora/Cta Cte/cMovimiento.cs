using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cMovimiento
    {
        // Declaro las variables a utilizar en la clase
        private static cMovimiento instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cMovimiento ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cMovimiento();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cMovimiento()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Dar de alta a un nuevo movimiento
        public void Alta(Modelo_Entidades.Movimiento oMovimiento)
        {
            oMovimiento.Alta(oMovimiento);            
        }

        // Elimino a un Movimiento
        public void Baja(Modelo_Entidades.Movimiento oMovimiento)
        {
            oMovimiento.Baja(oMovimiento);            
        }

        // Modifico a un Movimiento
        public void ModificarMovimiento(Modelo_Entidades.Movimiento oMovimiento)
        {
            oMovimiento.Modificacion(oMovimiento);            
        }

        // Obtener los Movimientos
        public List<Modelo_Entidades.Movimiento> ObtenerMovimientos()
        {
            return oModelo_Entidades.Movimientos.ToList();
        }

        // Busco si ya existe un movimiento y devuelvo un true, si es que existe 
        public Boolean BuscarCuotaNormalGenerada(string desc)
        {
            Modelo_Entidades.Movimiento oMovimiento = oModelo_Entidades.Movimientos.ToList().Find(delegate(Modelo_Entidades.Movimiento fMovimiento)
            {
                return fMovimiento.descripcion == desc && fMovimiento.Tipo_Movimiento.id == 1 && fMovimiento.CtaCte.Profesional.Tipo_Matricula.descripcion == "Normal";
            });

            if (oMovimiento == null)
            {
                return false;
            }

            else
            {
                return true;
            }            
        }

        // Busco si ya existe un movimiento y devuelvo un true, si es que existe 
        public Boolean BuscarCuotaEnRelGenerada(string desc)
        {
            Modelo_Entidades.Movimiento oMovimiento = oModelo_Entidades.Movimientos.ToList().Find(delegate(Modelo_Entidades.Movimiento fMovimiento)
            {
                return fMovimiento.descripcion == desc && fMovimiento.Tipo_Movimiento.id == 1 && fMovimiento.CtaCte.Profesional.Tipo_Matricula.descripcion == "Relación de Dependencia";
            });

            if (oMovimiento == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // Busco si ya existe un movimiento y devuelvo un true, si es que existe 
        public Boolean BuscarCuotaEnReciprocidadGenerada(string desc)
        {
            Modelo_Entidades.Movimiento oMovimiento = oModelo_Entidades.Movimientos.ToList().Find(delegate(Modelo_Entidades.Movimiento fMovimiento)
            {
                return fMovimiento.descripcion == desc && fMovimiento.Tipo_Movimiento.id == 1 && fMovimiento.CtaCte.Profesional.Tipo_Matricula.descripcion == "Reciprocidad de Matrícula";
            });

            if (oMovimiento == null)
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        // Busco el movimiento deudor de una determianda cuota
        public Modelo_Entidades.Movimiento BuscarMovimientoPorCuotaYProf(string desc, int cta_cte)
        {
            Modelo_Entidades.Movimiento oMovimiento = oModelo_Entidades.Movimientos.ToList().Find(delegate(Modelo_Entidades.Movimiento fMovimiento)
            {
                return fMovimiento.descripcion == desc && fMovimiento.Tipo_Movimiento.id == 1 && fMovimiento.CtaCte.id == cta_cte;
            });

            return oMovimiento;
        }

        // Busco el movimiento deudor de una determianda cuota
        public Modelo_Entidades.Movimiento BuscarMovimientoPorDescCuota(string desc, string año)
        {
            Modelo_Entidades.Movimiento oMovimiento = oModelo_Entidades.Movimientos.ToList().Find(delegate(Modelo_Entidades.Movimiento fMovimiento)
            {
                return fMovimiento.descripcion.Contains(desc) && fMovimiento.descripcion.Contains(año) && fMovimiento.Tipo_Movimiento.id == 1;
            });

            return oMovimiento;
        }

        // Busco el movimiento deudor de un determiando expediente
        public Modelo_Entidades.Movimiento BuscarMovimientoPorDescExpte(int numero)
        {
            Modelo_Entidades.Movimiento oMovimiento = oModelo_Entidades.Movimientos.ToList().Find(delegate(Modelo_Entidades.Movimiento fMovimiento)
            {
                return fMovimiento.descripcion.Contains(numero.ToString()) && fMovimiento.Tipo_Movimiento.id == 1 && fMovimiento.descripcion.Contains("expediente");
            });

            return oMovimiento;
        }

        public List<Modelo_Entidades.Movimiento> BuscarMovimientosPorDescExpte(int numero)
        {
            var Consulta = from oMovimiento in oModelo_Entidades.Movimientos.ToList()
                           where oMovimiento.descripcion.Contains(numero.ToString()) && oMovimiento.Tipo_Movimiento.id == 1
                           select oMovimiento;
            return (List<Modelo_Entidades.Movimiento>)Consulta.ToList();
        }

        // Obtener todos los movimientos deudores que sean por un concepto de cuota
        public List<Modelo_Entidades.Movimiento> ObtenerDeudasPorCuotas(int cta_cte)
        {
            var Consulta = from oMovimiento in oModelo_Entidades.Movimientos.ToList()
                           where oMovimiento.CtaCte.id == cta_cte && oMovimiento.descripcion.Contains("Cuota") && oMovimiento.Tipo_Movimiento.id == 1
                           select oMovimiento;
            return (List<Modelo_Entidades.Movimiento>)Consulta.ToList();
        }

        // Obtener todos los movimientos acreedores que sean por un concepto de cuota
        public List<Modelo_Entidades.Movimiento> ObtenerCreditosPorCuotas(int cta_cte)
        {
            var Consulta = from oMovimiento in oModelo_Entidades.Movimientos.ToList()
                           where oMovimiento.CtaCte.id == cta_cte && oMovimiento.descripcion.Contains("Cuota") && oMovimiento.Tipo_Movimiento.id == 2
                           select oMovimiento;
            return (List<Modelo_Entidades.Movimiento>)Consulta.ToList();
        }
    }
}
