using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cExpediente
    {
        // Declaro las variables a utilizar en la Expediente
        private static cExpediente instancia;
        private Modelo_Entidades.GCIEntidades oModelo_Entidades;

        decimal suma = 0;
        decimal valor_1;
        decimal valor_2;
        decimal valor_3;
        decimal valor_4;
        decimal valor_5;

        List<Modelo_Entidades.Liquidacion> Lista;
        Modelo_Entidades.Expediente miExpediente;

        // Aplico el patrón de diseño Singleton a la Expediente
        public static cExpediente ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cExpediente();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cExpediente()
        {
            oModelo_Entidades = Modelo_Entidades.GCIEntidades.ObtenerInstancia();
        }

        // Obtener las Expedientees
        public List<Modelo_Entidades.Expediente> ObtenerExpedientes()
        {
            return oModelo_Entidades.Expedientes.ToList();
        }

        // Elimino a un Expediente
        //public void EliminarExpediente(Modelo_Entidades.Expediente oExpediente)
        //{
        //    oModelo_Entidades.DeleteObject(oExpediente);
        //    oModelo_Entidades.SaveChanges();
        //}

        // Agrego un Expediente
        public void AgregarExpediente(Modelo_Entidades.Expediente oExpediente)
        {
            oExpediente.Alta(oExpediente);
        }

        // Modifico un Expediente
        public void ModificarExpediente(Modelo_Entidades.Expediente oExpediente)
        {
            oExpediente.Modificacion(oExpediente);
        }

        // Metodo de filtrado para todos los exoedientes
        public List<Modelo_Entidades.Expediente> FiltrarExpedientes(string profesional, string comitente, string obra, string tarea)
        {
            // Declaro las variables a utilizar en este método
            Controladora.cProfesional cProfesional;
            cProfesional = Controladora.cProfesional.ObtenerInstancia();

            // 1º busco al profesional
            Modelo_Entidades.Profesional oProfesional = cProfesional.ObtenerProfesional(Convert.ToInt32(profesional));

            var Consulta = from oExpediente in oModelo_Entidades.Expedientes.ToList()
                           select oExpediente;

            if (profesional != "0")
            {
                Consulta = Consulta.Where(oExpediente => oExpediente.Profesionales.Contains(oProfesional));
            }

            if (comitente != "0")
            {
                Consulta = Consulta.Where(oExpediente => oExpediente.Comitente.razon_social.Contains(comitente));
            }

            if (obra != "0")
            {
                switch (obra)
                {
                    case ("Obras de Ingenieria"):
                    Consulta = Consulta.Where(oExpediente => oExpediente.GetType().ToString() == "Modelo_Entidades.OI");
                    break;
                    case ("Fuerza Electromotriz"):
                    Consulta = Consulta.Where(oExpediente => oExpediente.GetType().ToString() == "Modelo_Entidades.FE");
                    break;
                    case ("Honorario Mínimo"):
                    Consulta = Consulta.Where(oExpediente => oExpediente.GetType().ToString() == "Modelo_Entidades.HM");
                    break;
                }                
            }

            if (tarea != "0")
            {
                Consulta = Consulta.Where(oExpediente => oExpediente.Tarea.descripcion.Contains(tarea));
            }

            return (List<Modelo_Entidades.Expediente>)Consulta.ToList();
        }

        // Declaro el método que va a modificar y a devolver un expediente
        public List<Modelo_Entidades.Liquidacion> LiquidarExpediente(Modelo_Entidades.Expediente oExpediente)
        {
            miExpediente = oExpediente;
            //miExpediente.CambiarExpediente(miExpediente);
            Lista = miExpediente.Calcular_Valor(miExpediente.Liquidaciones.OrderBy(x => x.Id).ToList());
            return Lista;
        }

        // Declaro el método que va a calcular el coefinciente k para las obras de FE
        public decimal CalcularCoeficienteK(decimal hp, decimal bocas, decimal motores)
        {
            if (hp >= 0 && hp <= 5)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1.3m;
                }

                if (motores >5 && motores <= 10)
                {
                    return 1.48m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.59m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.65m;
                }

                if (motores > 50)
                {
                    return 1.69m;
                }
            }

            if (hp > 5 && hp <= 10)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1.28m;
                }

                if (motores > 5 && motores <= 10)
                {
                    return 1.46m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.56m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.62m;
                }

                if (motores > 50)
                {
                    return 1.66m;
                }
            }

            if (hp > 10 && hp <= 50)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1.25m;
                }

                if (motores > 5 && motores <= 10)
                {
                    return 1.43m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.53m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.59m;
                }

                if (motores > 50)
                {
                    return 1.63m;
                }
            }

            if (hp > 50 && hp <= 100)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1.21m;
                }

                if (motores > 5 && motores <= 10)
                {
                    return 1.38m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.48m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.54m;
                }

                if (motores > 50)
                {
                    return 1.58m;
                }
            }

            if (hp > 100 && hp <= 200)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1.16m;
                }

                if (motores > 5 && motores <= 10)
                {
                    return 1.32m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.41m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.47m;
                }

                if (motores > 50)
                {
                    return 1.51m;
                }
            }

            if (hp > 200 && hp <= 500)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1.09m;
                }

                if (motores > 5 && motores <= 10)
                {
                    return 1.24m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.33m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.38m;
                }

                if (motores > 50)
                {
                    return 1.41m;
                }
            }

            if (hp > 500)
            {
                if (motores >= 0 && motores <= 5)
                {
                    return 1m;
                }

                if (motores > 5 && motores <= 10)
                {
                    return 1.14m;
                }

                if (motores > 10 && motores <= 20)
                {
                    return 1.22m;
                }

                if (motores > 20 && motores <= 50)
                {
                    return 1.27m;
                }

                if (motores > 50)
                {
                    return 1.30m;
                }
            }

            return 0;
        }

        // Obtengo el valor para poder operar y calcular el total a liquidar
        public decimal CalcularTotalaLiquidar_OI(decimal valor_bruto)
        {
            decimal monto_obra = valor_bruto;

            // Los valores estan hardcodeados, pero habría que editarlos
            if ((36 * 1612) <= monto_obra)
            {
                valor_1 = (34 * 1612) * 0.07m;

                if ((valor_1 == (54 * 1612) * 0.07m) && (monto_obra - (36 * 1612)) >= (36 * 1612))
                {
                    valor_2 = (54 * 1612) * 0.065m;

                    if ((valor_2 == ((54 * 1612)) * 0.065m) && (monto_obra - (36 * 1612) - (54 * 1612)) >= (182 * 1612))
                    {
                        valor_3 = (182 * 1612) * 0.06m;

                        if ((valor_3 == ((182 * 1612)) * 0.06m) && (monto_obra - (36 * 1612) - (54 * 1612) - (182 * 1612)) >= (638 * 1612))
                        {
                            valor_4 = (638 * 1612) * 0.055m;

                            if ((valor_4 == ((638 * 1612)) * 0.055m))
                            {
                                valor_5 = (monto_obra - (36 * 1612) - (54 * 1612) - (182 * 1612) - (638 * 1612)) * 0.05m;
                            }

                            else
                            {
                                valor_5 = 0;
                            }
                        }

                        else
                        {
                            valor_4 = (monto_obra - (36 * 1612) - (54 * 1612) - (182 * 1612)) * 0.055m;
                        }
                    }

                    else
                    {
                        valor_3 = (monto_obra - (36 * 1612) - (54 * 1612)) * 0.06m;
                    }
                }

                else
                {
                    valor_2 = (monto_obra - (36 * 1612)) * 0.065m;
                }
            }

            else
            {
                valor_1 = monto_obra * 0.07m;
            }

            suma = valor_1 + valor_2 + valor_3 + valor_4 + valor_5;

            return suma;
        }

        // Obtener los expedientes de un profesional
        public List<Modelo_Entidades.Expediente> BuscarExpedientePorProfesional(Modelo_Entidades.Profesional oProfesional)
        {
            var Consulta = from oExpediente in oModelo_Entidades.Expedientes.ToList()
                           where oExpediente.Profesionales.Contains(oProfesional)
                           select oExpediente;
            return (List<Modelo_Entidades.Expediente>)Consulta.ToList();
        }

        // Obtener los expedientes de que estan aprobados (y listos para cobrar)
        public List<Modelo_Entidades.Expediente> BuscarExpedientesAprobados(Modelo_Entidades.Profesional oProfesional)
        {
            var Consulta = from oExpediente in oModelo_Entidades.Expedientes.ToList()
                           where oExpediente.estado == "Aprobado" && oExpediente.Profesionales.Contains(oProfesional)
                           select oExpediente;
            return (List<Modelo_Entidades.Expediente>)Consulta.ToList();
        }

        // Obtener los expedientes de que estan aprobados (y listos para cobrar)
        public Modelo_Entidades.Expediente BuscarExpedientePorNumero(int numero)
        {
            Modelo_Entidades.Expediente oExpediente = oModelo_Entidades.Expedientes.ToList().Find(delegate(Modelo_Entidades.Expediente fExpediente)
            {
                return fExpediente.numero == numero;
            });

            return oExpediente;
        }

        public List<Modelo_Entidades.Expediente> BuscarExpedientesAprobadosPorNumero(int numero)
        {
            var Consulta = from oExpediente in oModelo_Entidades.Expedientes.ToList()
                           where oExpediente.estado == "Aprobado" && oExpediente.numero == numero
                           select oExpediente;
            return (List<Modelo_Entidades.Expediente>)Consulta.ToList();
        }
    }
}
