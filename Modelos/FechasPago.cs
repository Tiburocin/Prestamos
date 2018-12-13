using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MDS___prestamos.Modelos
{
    class FechasPago
    {
        private DateTime fecha;

        public DateTime Fecha
        {
            get { return fecha; }
            set { fecha = value; }
        }

        public FechasPago()
        {

        }

        public FechasPago(Int32 year, Int32 month, Int32 day)
        {
            fecha = new DateTime(year, month, day);
        }
        public static FechasPago operator +(FechasPago operando, Int16 incremento)
        {
            FechasPago resultado = new FechasPago();
            resultado.Fecha=operando.Fecha.AddDays(incremento);
            return resultado;
        }
        public static bool operator ==(FechasPago operando1, FechasPago operando2)
        {
            return (DateTime.Compare(operando1.Fecha, operando2.Fecha) == 0);
        }
        public static bool operator !=(FechasPago operando1, FechasPago operando2)
        {
            return !(DateTime.Compare(operando1.Fecha, operando2.Fecha) == 0);
        }
        public static bool operator <(FechasPago operando1, FechasPago operando2)
        {
            return (DateTime.Compare(operando1.Fecha, operando2.Fecha) < 0);
        }
        public static bool operator >(FechasPago operando1, FechasPago operando2)
        {
            return (DateTime.Compare(operando1.Fecha, operando2.Fecha) > 0);
        }
        public static bool operator <=(FechasPago operando1, FechasPago operando2)
        {
            return (DateTime.Compare(operando1.Fecha, operando2.Fecha) < 0) || DateTime.Compare(operando1.Fecha, operando2.Fecha) == 0;
        }
        public static bool operator >=(FechasPago operando1, FechasPago operando2)
        {
            return (DateTime.Compare(operando1.Fecha, operando2.Fecha) > 0) || DateTime.Compare(operando1.Fecha, operando2.Fecha) == 0;
        }

    }
}
