using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS___prestamos.Modelos
{
    abstract class Telefono
    {
        public abstract string Number { get; set; }
        public bool isTelNumber(string valor)
        {
            if (valor.Length == 10)
                return true;
            else
                return false;
        }
    }
}
