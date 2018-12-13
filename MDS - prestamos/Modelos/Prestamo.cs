using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS___prestamos.Modelos
{
    class Prestamo
    {
        FechasPago author;
        FechasPago entrega;
        char edo;
        public Prestamo()
        {
            edo = 'N';  //estado normal si 'E' el prestamo tiene errores
        }
        public Int32 Numero { get; set; }
        public Usuario Persona { get; set; }
        public double Importe { get; set; }
        public FechasPago Registro { get; set; }
        public FechasPago Author {
            get { return author; }
            set {
                if (value >= Registro)
                {
                    FechasPago limite1 = new FechasPago(value.Fecha.Year, value.Fecha.Month, 1);
                    FechasPago limite2 = new FechasPago(value.Fecha.Year, value.Fecha.Month, 20);
                    if (value >= limite1 && value <= limite2)
                    {
                        author = value;
                        Edo = 'N';
                    }
                        
                    else
                        Edo = 'E';
                }
                else Edo = 'E';
            }
            }
        public FechasPago Entrega
        {
            get { return entrega; }
            set
            {
                        entrega = value;
                        Edo = 'N';
            }
        }
        public double Porcentaje { get; set; }
        public int Meses { get; set; }
        public List<FechasPago> LosPagos { get; set; }
        public char Edo { get { return edo; } set { edo = value; } }

    }
}
