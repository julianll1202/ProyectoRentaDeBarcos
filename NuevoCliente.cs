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
    public partial class NuevoCliente : Form
    {
        private Cliente mCliente = new Cliente();
        private ClienteConsultas mClienteConsultas = new ClienteConsultas();
        public NuevoCliente()
        {
            InitializeComponent();
        }

        private void LimpiarCamposClientes()
        {
            tb_nombre.Text = "";
            tb_ap.Text = "";
            tb_am.Text = "";
            tb_tel.Text = "";
            tb_correo.Text = "";
            tb_ciudad.Text = "";
            tb_estado.Text = "";
            tb_calle.Text = "";
            tb_col.Text = "";
            tb_cp.Text = "";
        }

        private void cargarDatosCliente()
        {
            mCliente.NumCliente = -1;
            mCliente.nombreCliente = tb_nombre.Text.Trim();
            mCliente.apellidoP = tb_ap.Text.Trim();
            mCliente.apellidoM = tb_am.Text.Trim();
            mCliente.telefono = tb_tel.Text.Trim();
            mCliente.correo = tb_correo.Text.Trim();
            mCliente.ciudad = tb_ciudad.Text.Trim();
            mCliente.estado = tb_estado.Text.Trim();
            mCliente.calle = tb_calle.Text.Trim();
            mCliente.colonia = tb_col.Text.Trim();
            mCliente.codigoPostal = tb_cp.Text.Trim();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void NuevoCliente_Load(object sender, EventArgs e)
        {

        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosCliente();

            if (mClienteConsultas.agregarCliente(mCliente))
            {
                MessageBox.Show("Cliente Agregado");
                LimpiarCamposClientes();
                this.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
