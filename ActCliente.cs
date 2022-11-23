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
    public partial class ActCliente : Form
    {
        public string numCliente { get; set; }
        public string nombre { get; set; }
        public string apellidoP { get; set; }
        public string apellidoM { get; set; }
        public string tel { get; set; }
        public string correo { get; set; }
        public string calle { get; set; }
        public string colonia { get; set; }
        public string ciudad { get; set; }
        public string estado { get; set; }
        public string codigoP { get; set; }

        private Cliente mCliente = new Cliente();
        private ClienteConsultas mClienteConsultas = new ClienteConsultas();
        public ActCliente(string num, string nom, string ap, string am, string tel, string email, string calle, string col,
                string cd, string est, string cp)
        {
            InitializeComponent();

            this.numCliente= num;
            this.nombre = nom;
            this.apellidoP = ap;
            this.apellidoM = am;
            this.tel = tel;
            this.correo = email;
            this.calle = calle;
            this.colonia = col;
            this.ciudad = cd;
            this.estado = est;
            this.codigoP= cp;
        }

        private void cargarDatosCliente()
        {
            mCliente.NumCliente = getFolioClienteIfExist();
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

        private int getFolioClienteIfExist()
        {
            if (!tb_numCliente.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_numCliente.Text.Trim(), out int folio))
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
        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosCliente();

            if (mClienteConsultas.modificarCliente(mCliente))
            {
                MessageBox.Show("Cliente Modificado");
                this.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ActCliente_Load(object sender, EventArgs e)
        {
            tb_numCliente.Text = numCliente;
            tb_nombre.Text = nombre;
            tb_ap.Text = apellidoP;
            tb_am.Text = apellidoM;
            tb_tel.Text = tel;
            tb_correo.Text = correo;
            tb_calle.Text = calle;
            tb_col.Text = colonia;
            tb_ciudad.Text= ciudad;
            tb_estado.Text = estado;
            tb_cp.Text = codigoP;

        }
    }
}
