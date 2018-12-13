using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MDS___prestamos.Modelos;
using MDS___prestamos.Controlador;
using MDS___prestamos.Vistas;

namespace MDS___prestamos
{
    public partial class Form1 : Form
    {
        Dependiente asesor; //Controlador
        public Form1()
        {
            Opciones entrada = new Opciones();
            InitializeComponent();
            //cliente = new Usuario();
            asesor = new Dependiente();
            asesor.Pedido = new Prestamo();
            asesor.Pedido.Registro = new FechasPago();
            asesor.Pedido.Persona = new Usuario();
            //asesor.Cliente = new Usuario();
            //proceso = new Prestamo();proceso.Registro = new FechasPago();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd/MM/yyyy";
            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "dd/MM/yyyy";
            dateTimePicker3.Format = DateTimePickerFormat.Custom;
            dateTimePicker3.CustomFormat = "dd/MM/yyyy";
        }
        //Verifica con el controlador los datos ingresados para el prestamo
        private void button1_Click(object sender, EventArgs e)
        {
            TelCasa tcasa=new TelCasa();
            TelMovil tmovil = new TelMovil();
            tcasa.Number = textBox5.Text;
            tmovil.Number = textBox6.Text;
            asesor.Pedido.Persona.TCasa = tcasa; asesor.Pedido.Persona.TMovil = tmovil;
            asesor.Pedido.Persona.ID = textBox1.Text;
            asesor.Pedido.Persona.Nombre = textBox2.Text;
            asesor.Pedido.Persona.APaterno = textBox3.Text;
            asesor.Pedido.Persona.AMaterno = textBox4.Text;
            asesor.Pedido.Registro.Fecha = DateTime.ParseExact(dateTimePicker1.Text, "dd/MM/yyyy", null);
            if (textBox7.Text.Length > 0)
                asesor.Pedido.Importe = Convert.ToDouble(textBox7.Text);
            else
                asesor.Pedido.Importe = 0;
            //asesor.Pedido = proceso;
            //asesor.Pedido.Persona = cliente;

            string errores = asesor.verifyUser();
            errores = asesor.verifyLoan();
            if (errores.Length>0)
                MessageBox.Show(errores+ asesor.Pedido.Registro.ToString()+"\n"+asesor.FechaSistema.ToString());
            else
            {
                textBox5.Text = asesor.Pedido.Persona.TCasa.Number;
                textBox6.Text = asesor.Pedido.Persona.TMovil.Number;
                button2.Enabled = true;dateTimePicker2.Enabled = true;
            }
                
        }
        //Verifica con el controlador la fecha de autorizacion
        private void button2_Click(object sender, EventArgs e)
        {
            FechasPago author = new FechasPago();
            author.Fecha=DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", null);
            //MessageBox.Show(asesor.Pedido.Registro.Fecha.ToString() + "; " + author.Fecha.ToString()+"; "+asesor.Pedido.Edo);
            asesor.Pedido.Author = author;
            if (asesor.Pedido.Edo != 'N')
                MessageBox.Show("Error en la fecha de autorizacion.");
            else
            {
                numericUpDown1.Enabled = true;textBox8.Enabled = true;
                textBox9.Enabled = true;button3.Enabled = true;dateTimePicker3.Enabled = true;
                FechasPago entrega = new FechasPago();
                entrega.Fecha = DateTime.ParseExact(dateTimePicker2.Text, "dd/MM/yyyy", null);
                entrega = entrega + 7;
                dateTimePicker3.Value = entrega.Fecha;
                CalculatePay();
            }
        }
        //Calcula los pagos segun interes y mensualidades
        private void CalculatePay()
        {
            double pago = asesor.Pedido.Importe + asesor.Pedido.Importe * Convert.ToDouble(textBox8.Text) / 100;
            pago = pago / (double)(numericUpDown1.Value);
            textBox9.Text = pago.ToString();
            textBox10.Text = Convert.ToString(Convert.ToDouble(textBox9.Text) * (double)(numericUpDown1.Value));
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            CalculatePay();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            if (textBox8.Text.Length > 0)
            {
                CalculatePay();
            }
        }
        //Calcula las fechas de los pagos
        private void button3_Click(object sender, EventArgs e)
        {
            FechasPago mes;
            mes = new FechasPago();
            mes.Fecha = DateTime.ParseExact(dateTimePicker3.Text, "dd/MM/yyyy", null);
            List<FechasPago> Listado = new List<FechasPago>();
            asesor.Pedido.LosPagos = Listado;
            for (Int16 j = 0; j < numericUpDown1.Value; j++)
            {
                mes = mes + 30;
                FechasPago elPago = new FechasPago(mes.Fecha.Year,mes.Fecha.Month,mes.Fecha.Day);
                asesor.Pedido.LosPagos.Add(elPago);
                listBox1.Items.Add(elPago.Fecha.ToString());
            }
            asesor.Pedido.Porcentaje = Convert.ToDouble(textBox8.Text);
            FechasPago pivote = new FechasPago();
            asesor.Pedido.Entrega = new FechasPago();
            asesor.Pedido.Entrega.Fecha = DateTime.ParseExact(dateTimePicker3.Text, "dd/MM/yyyy", null);
        }
    }
}
