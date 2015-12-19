using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Controladora
{
    public class cVerificacion
    {
        // Declaro las variables a utilizar en la clase
        private static cVerificacion instancia;
        private Modelo_Entidades.WASSWebEntidades oModelo_Entidades;

        // Aplico el patrón de diseño Singleton a la clase
        public static cVerificacion ObtenerInstancia()
        {
            if (instancia == null)
                instancia = new cVerificacion();

            return instancia;
        }

        // Coloco al constructor como privado.
        private cVerificacion()
        {
            oModelo_Entidades = Modelo_Entidades.WASSWebEntidades.ObtenerInstancia();
        }

        // Método para generar el dígito verificador
        public string AddCheckDigit(string number)
        {
            int Sum = 0;
            for (int i = number.Length - 1, Multiplier = 2; i >= 0; i--)
            {
                Sum += (int)char.GetNumericValue(number[i]) * Multiplier;

                if (++Multiplier == 8) Multiplier = 2;
            }
            string Validator = (11 - (Sum % 11)).ToString();

            if (Validator == "11") Validator = "0";
            else if (Validator == "10") Validator = "X";

            return Validator;
        }
    }
}
