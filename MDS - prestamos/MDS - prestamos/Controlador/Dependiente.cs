using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MDS___prestamos.Modelos;

namespace MDS___prestamos.Controlador
{
    class Dependiente
    {
        //Usuario cliente;
        Prestamo pedido;
        FechasPago fechaSistema;
        double capital;
        double limite;
        char modo;

        public Dependiente()
        {
            DateTime NowTime = DateTime.Now;
            fechaSistema = new FechasPago();
            fechaSistema.Fecha = new DateTime(NowTime.Year, NowTime.Month, NowTime.Day);
            capital = 10000000;
            limite = 100000;
            modo = 'T';     //Todos los datos por default
        }

        //public Usuario Cliente { get { return cliente; } set { cliente = value; } }
        public Prestamo Pedido { get { return pedido; } set { pedido = value; } }
        public FechasPago FechaSistema { get { return fechaSistema; } }
        public double Capital { get { return capital; } }
        public double Limite { get { return limite; } }
        public char Modo { get { return modo; } set { modo = value; } }

        public string verifyUser()
        {
            string resulta="";
            if (pedido.Persona.ID.Length == 0)
                resulta = resulta + "No está definido la identificación del cliente\n";
            if (modo == 'T')
            {
                if (pedido.Persona.Nombre.Length == 0)
                    resulta = resulta + "No está definido el nombre del cliente\n";
                if (pedido.Persona.APaterno.Length == 0)
                    resulta = resulta + "No está definido el apellido paterno\n";
                if (pedido.Persona.APaterno.Length == 0)
                    resulta = resulta + "No está definido el apellido materno\n";
                if (pedido.Persona.TCasa.Number.Length == 0)
                    resulta = resulta + "Error en el teléfono de  casa\n";
                if (pedido.Persona.TMovil.Number.Length == 0)
                    resulta = resulta + "Error en el teléfono móvil\n";
            }
            return resulta;
        }
        public string verifyLoan()
        {
            string resulta = "";
            if(pedido.Importe<=0 || Capital-pedido.Importe<Limite)
                resulta = resulta + "Error el importe debe ser positivo mayor que cero o excede el límite\n";
            if(pedido.Registro<fechaSistema)
                resulta = resulta + "Error en la fecha de registro está fuera de rango\n";
            return resulta;
        }
    }
}
