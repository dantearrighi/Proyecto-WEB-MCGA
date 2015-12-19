using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class WASSWebEntidades
    {
        private static WASSWebEntidades _Instancia;

            public static WASSWebEntidades ObtenerInstancia()
            {
                if (_Instancia == null)
                {
                    _Instancia = new WASSWebEntidades();
                }
                return _Instancia;
            }
    }
}
