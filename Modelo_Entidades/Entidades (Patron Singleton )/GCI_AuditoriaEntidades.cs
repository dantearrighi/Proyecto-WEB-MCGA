using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class WASSWeb_AuditoriaContainer
    {
        private static WASSWeb_AuditoriaContainer _Instancia;

        public static WASSWeb_AuditoriaContainer ObtenerInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new WASSWeb_AuditoriaContainer();
            }
            return _Instancia;
        }
    }
}
