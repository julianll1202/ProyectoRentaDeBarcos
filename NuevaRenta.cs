using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRentaDeBarcos
{
    public partial class NuevaRenta : Form
    {
        private Renta mRenta = new Renta();
        private RentaConsultas mRentaConsultas = new RentaConsultas();

        private ClienteConsultas mClienteConsultas = new ClienteConsultas();
        private BarcoConsultas mBarcoConsultas = new BarcoConsultas();
   
        List<int> clientes, barcos;

       

        public NuevaRenta()
        {
            InitializeComponent();
            
        }

        private void cargarDatosRenta()
        {
            mRenta.NumRenta = -1;
            mRenta.fechaInicio = fecha_in.Value;
            mRenta.fechaFin = fecha_fin.Value;
            mRenta.Cliente = int.Parse(lb_clientes.Text);
            mRenta.Barco = int.Parse(lb_barcos.Text);
        }
        private void label_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void fecha_in_ValueChanged(object sender, EventArgs e)
        {

        }

        private void NuevaRenta_Load(object sender, EventArgs e)
        {
            fecha_in.CustomFormat = "yyyy-MM-dd";
            fecha_in.Format = DateTimePickerFormat.Custom;

            fecha_fin.CustomFormat = "yyyy-MM-dd";
            fecha_fin.Format = DateTimePickerFormat.Custom;

            cargar_lb();

        }

        private void cargar_lb() 
        {
            clientes = mClienteConsultas.getClientesDisponibles();
            barcos = mBarcoConsultas.getBarcosDisponibles();
            lb_clientes.Items.Clear();
            lb_barcos.Items.Clear();

            foreach(int c in clientes)
            {
                lb_clientes.Items.Add(c);
            }

            foreach(int b in barcos)
            {
                lb_barcos.Items.Add(b);
            }
                 
        }


        private void agregar_btn_Click(object sender, EventArgs e)
        {
            label1.Text = lb_clientes.Text;
            cargarDatosRenta();

            if (mRentaConsultas.agregarRenta(mRenta))
            {
                MessageBox.Show("Renta Agregado");
                this.Close();
            }
        }
    }
}
