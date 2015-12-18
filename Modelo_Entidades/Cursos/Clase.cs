using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Modelo_Entidades
{
    partial class Clase
    {
        public override string ToString()
        {
            return (_fecha.ToShortDateString());
        }
    }
}
