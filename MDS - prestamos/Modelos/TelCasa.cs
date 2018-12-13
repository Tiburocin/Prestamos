using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS___prestamos.Modelos
{
    class TelCasa: Telefono
    {
        private string number;
        public override string Number
        {
            get { return number; }
            set {
                if (isTelNumber(value))
                    number = "52" + value;
                else
                    number = "";
            }
        }
    }
}
