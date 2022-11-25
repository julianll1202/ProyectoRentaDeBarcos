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
    public partial class NuevoProp : Form
    {
        private Propietario mPropietario = new Propietario();
        private PropietarioConsultas mPropietarioConsultas = new PropietarioConsultas();

        public NuevoProp()
        {
            InitializeComponent();
        }

        private void LimpiarCamposPropietarios()
        {
            tb_nombre.Text = "";
            tb_ap.Text = "";
            tb_am.Text = "";
            tb_tel.Text = "";
            tb_correo.Text = "";
        }

        private void cargarDatosPropietario()
        {
            mPropietario.IdPropietario = -1;
            mPropietario.nombrePropietario = tb_nombre.Text.Trim();
            mPropietario.apellidoPPropietario = tb_ap.Text.Trim();
            mPropietario.apellidoMPropietario = tb_am.Text.Trim();
            mPropietario.telefonoPropietario = tb_tel.Text.Trim();
            mPropietario.correoPropietario = tb_correo.Text.Trim();
        }

        private void tb_tel_TextChanged(object sender, EventArgs e)
        {

        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosPropietario();

            if (mPropietarioConsultas.agregarPropietario(mPropietario))
            {
                MessageBox.Show("Propietario Agregado");
                LimpiarCamposPropietarios();
                this.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
