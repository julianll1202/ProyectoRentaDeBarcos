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
    public partial class NuevoEmp : Form
    {
        private Empleado mEmpleado = new Empleado();
        private EmpleadoConsultas mEmpConsultas = new EmpleadoConsultas();
        public NuevoEmp()
        {
            InitializeComponent();
        }

        private void LimpiarCamposEmpleados()
        {
            
            tb_nombre.Text = "";
            tb_ap.Text = "";
            tb_am.Text = "";
            tb_rfc.Text = "";
            tb_tel.Text = "";
            tb_correo.Text = "";
            tb_puesto.Text = "";
        }

        private void cargarDatosEmpleado()
        {
            tb_rfc.Text = tb_rfc.Text.ToUpper();

            mEmpleado.NumEmpleado = -1;
            mEmpleado.nombreEmpleado = tb_nombre.Text.Trim();
            mEmpleado.apellidoPEmpleado = tb_ap.Text.Trim();
            mEmpleado.apellidoMEmpleado = tb_am.Text.Trim();
            mEmpleado.rfc = tb_rfc.Text.Trim();
            mEmpleado.telefonoEmpleado = tb_tel.Text.Trim();
            mEmpleado.correoEmpleado = tb_correo.Text.Trim();
            mEmpleado.puesto = tb_puesto.Text.Trim();
        }
        private void NuevoEmp_Load(object sender, EventArgs e)
        {

        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosEmpleado();

            if (mEmpConsultas.agregarEmpleado(mEmpleado))
            {
                MessageBox.Show("Empleado Agregado");
                LimpiarCamposEmpleados();
                this.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
