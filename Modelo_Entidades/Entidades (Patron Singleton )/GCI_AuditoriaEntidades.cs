using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    public partial class GCI_AuditoriaContainer
    {
        private static GCI_AuditoriaContainer _Instancia;

        public static GCI_AuditoriaContainer ObtenerInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new GCI_AuditoriaContainer();
            }
            return _Instancia;
        }
    }
}
