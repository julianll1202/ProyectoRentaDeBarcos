using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

namespace ProyectoRentaDeBarcos
{
    public partial class ActEmp : Form
    {
        public string numEmp { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string tel { get; set; }
        public string correo { get; set; }
        public string rfc { get; set; }
        public string puesto { get; set; }

        private Empleado mEmpleado = new Empleado();
        private EmpleadoConsultas mEmpConsultas = new EmpleadoConsultas();
        public ActEmp(string numEmp, string nombre, string ap, string am, 
            string tel, string correo, string rfc, string puesto)
        {
            InitializeComponent();

            this.numEmp = numEmp;
            this.nombre = nombre;
            this.apellidoP = ap;
            this.apellidoM = am;
            this.tel = tel;
            this.correo = correo;
            this.rfc = rfc;
            this.puesto = puesto;
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

            mEmpleado.NumEmpleado = int.Parse(tb_numEmp.Text);
            mEmpleado.nombreEmpleado = tb_nombre.Text.Trim();
            mEmpleado.apellidoPEmpleado = tb_ap.Text.Trim();
            mEmpleado.apellidoMEmpleado = tb_am.Text.Trim();
            mEmpleado.rfc = tb_rfc.Text.Trim();
            mEmpleado.telefonoEmpleado = tb_tel.Text.Trim();
            mEmpleado.correoEmpleado = tb_correo.Text.Trim();
            mEmpleado.puesto = tb_puesto.Text.Trim();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosEmpleado();

            if (mEmpConsultas.modificarEmpleado(mEmpleado))
            {
                MessageBox.Show("Empleado Modificado");
                LimpiarCamposEmpleados();
                this.Close();
            }
        }

        private void ActEmp_Load(object sender, EventArgs e)
        {
            tb_numEmp.Text = numEmp;
            tb_nombre.Text = nombre;
            tb_ap.Text = apellidoP;
            tb_am.Text = apellidoM;
            tb_rfc.Text = rfc;
            tb_tel.Text = tel;
            tb_correo.Text = correo;
            tb_puesto.Text = puesto;
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
