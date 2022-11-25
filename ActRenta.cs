using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySqlX.XDevAPI;

namespace ProyectoRentaDeBarcos
{
    public partial class ActRenta : Form
    {
        private Renta mRenta = new Renta();
        private RentaConsultas mRentaConsultas = new RentaConsultas();

        private ClienteConsultas mClienteConsultas = new ClienteConsultas();
        private BarcoConsultas mBarcoConsultas = new BarcoConsultas();

        List<int> clientes, barcos;

        public string numRenta { get; set; }
        public DateTime fRenta { get; set; }
        public DateTime fInicio { get; set; }
        public DateTime fFin { get; set; }
        public string nCliente { get; set; }
        public string nBarco { get; set; }

        public ActRenta(string numRenta, DateTime fRenta, DateTime fInicio, DateTime fFin, string nCliente, string nBarco)
        {
            InitializeComponent();

            this.numRenta = numRenta;
            this.fRenta = fRenta;
            this.fInicio = fInicio;
            this.fFin = fFin;
            this.nCliente = nCliente;
            this.nBarco = nBarco;
        }

        
        private void cargarDatosRenta()
        {
            mRenta.NumRenta = int.Parse(numRenta);
            mRenta.fechaRenta = fRenta;
            mRenta.fechaInicio = fecha_in.Value;
            mRenta.fechaFin = fecha_fin.Value;
            mRenta.Cliente = int.Parse(tb_cliente.Text);
            mRenta.Barco = int.Parse(tb_barco.Text);
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosRenta();
            if (mRentaConsultas.modificarRenta(mRenta))
            {
                MessageBox.Show("Renta Modificada");
                this.Close();

            }
        }

        private void ActRenta_Load(object sender, EventArgs e)
        {
            fecha_in.CustomFormat = "yyyy-MM-dd";
            fecha_in.Format = DateTimePickerFormat.Custom;
            fecha_in.Value = fInicio;

            fecha_fin.CustomFormat = "yyyy-MM-dd";
            fecha_fin.Format = DateTimePickerFormat.Custom;
            fecha_fin.Value = fFin;

            tb_barco.Text = nBarco;
            tb_cliente.Text = nCliente;
        }
    }
}
