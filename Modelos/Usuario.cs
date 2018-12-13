using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS___prestamos.Modelos
{
    class Usuario
    {
        public string ID { get; set; }
        public string Nombre { get; set; }
        public string APaterno { get; set; }
        public string AMaterno { get; set; }
        public TelCasa TCasa { get; set; }
        public TelMovil TMovil { get; set; }
    }
}


