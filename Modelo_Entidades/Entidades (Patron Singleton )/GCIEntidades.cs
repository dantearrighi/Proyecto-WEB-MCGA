using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class GCIEntidades
    {
        private static GCIEntidades _Instancia;

            public static GCIEntidades ObtenerInstancia()
            {
                if (_Instancia == null)
                {
                    _Instancia = new GCIEntidades();
                }
                return _Instancia;
            }
    }
}
