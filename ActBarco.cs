using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace ProyectoRentaDeBarcos
{
    
    public partial class ActBarco : Form
    {
        public string numBarco { get; set; }
        public string modelo { get; set; }
        public string noProp { get; set; }
        public string anio { get; set; }
        public string cap { get; set; }
        public string tarifa { get; set; }
        public string nombre { get; set; }
        public string largo { get; set; }

        private Barco mBarco = new Barco();
        private BarcoConsultas mBarcoConsultas = new BarcoConsultas();
        public ActBarco(string numBarco,string nombre, string modelo, string anio, string noProp, string cap, string tarifa, string largo)
        {
            InitializeComponent();

            this.numBarco = numBarco;
            this.modelo = modelo;
            this.nombre = nombre;
            this.anio = anio;
            this.noProp = noProp;
            this.cap = cap;
            this.tarifa = tarifa;
            this.largo = largo;
        }

        private void LimpiarCampos()
        {
            tb_prop.Text = "";
            tb_nombre.Text = "";
            tb_modelo.Text = "";
            tb_anio.Text = "";
            tb_largo.Text = "";
            tb_tarifa.Text = "";
            tb_cap.Text = "";
        }

        private void cargarDatosBarco()
        {
            mBarco.NumBarco = getFolioIfExist();
            mBarco.propietario = int.Parse(tb_prop.Text.Trim());
            mBarco.nombre = tb_nombre.Text.Trim();
            mBarco.modelo = tb_modelo.Text.Trim();
            mBarco.anio = int.Parse(tb_anio.Text.Trim());
            mBarco.largo_Pies = int.Parse(tb_largo.Text.Trim());
            mBarco.tarifaRenta = float.Parse(tb_tarifa.Text.Trim());
            mBarco.capacidad = int.Parse(tb_cap.Text.Trim());
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        private int getFolioIfExist()
        {
            if (!tb_numbarco.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_numbarco.Text.Trim(), out int folio))
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

        private void ActBarco_Load(object sender, EventArgs e)
        {
            tb_numbarco.Text = numBarco;
            tb_modelo.Text = modelo;
            tb_nombre.Text = nombre;
            tb_anio.Text = anio;
            tb_cap.Text= cap;
            tb_tarifa.Text = tarifa;
            tb_largo.Text = largo;
            tb_prop.Text = noProp;
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosBarco();

            if (mBarcoConsultas.modificarBarco(mBarco))
            {
                MessageBox.Show("Barco Modificado");
                LimpiarCampos();
                this.Close();
            }
            
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
