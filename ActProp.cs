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
    public partial class ActProp : Form
    {
        public string numProp { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string tel { get; set; }
        public string correo { get; set; }

        private Propietario mPropietario = new Propietario();
        private PropietarioConsultas mPropietarioConsultas = new PropietarioConsultas();
        public ActProp(string num, string nom, string ap, string am, string tel, string email)
        {
            InitializeComponent();

            this.numProp = num;
            this.nombre = nom;
            this.apellidoP = ap;
            this.apellidoM = am;
            this.tel = tel;
            this.correo = email;
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
            mPropietario.IdPropietario = int.Parse(tb_numProp.Text);
            mPropietario.nombrePropietario = tb_nombre.Text.Trim();
            mPropietario.apellidoPPropietario = tb_ap.Text.Trim();
            mPropietario.apellidoMPropietario = tb_am.Text.Trim();
            mPropietario.telefonoPropietario = tb_tel.Text.Trim();
            mPropietario.correoPropietario = tb_correo.Text.Trim();
        }

        private int getFolioPropietarioIfExist()
        {
            if (!tb_numProp.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_numProp.Text.Trim(), out int folio))
                {
                    return folio;
                }
                else return -1;
            }
            else
            {
                return -1;
            }
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void ActProp_Load(object sender, EventArgs e)
        {
            tb_numProp.Text = numProp;
            tb_nombre.Text = nombre;
            tb_ap.Text = apellidoP;
            tb_am.Text = apellidoM;
            tb_tel.Text = tel;
            tb_correo.Text = correo;
            
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosPropietario();

            if (mPropietarioConsultas.modificarPropietario(mPropietario))
            {
                MessageBox.Show("Propietario Modificado");
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
