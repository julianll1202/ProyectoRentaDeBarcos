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
    public partial class NuevoBarco : Form
    {
        private Barco mBarco = new Barco();
        private BarcoConsultas mBarcoConsultas = new BarcoConsultas();
        public NuevoBarco()
        {
            InitializeComponent();
        }
        private void btn_Agregar_Click(object sender, EventArgs e)
        {
            cargarDatosBarco();

            if (mBarcoConsultas.agregarBarco(mBarco))
            {
                MessageBox.Show("Barco Agregado");
                LimpiarCampos();
            }
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
            mBarco.NumBarco = -1;
            mBarco.propietario = int.Parse(tb_prop.Text.Trim());
            mBarco.nombre = tb_nombre.Text.Trim();
            mBarco.modelo = tb_modelo.Text.Trim();
            mBarco.anio = int.Parse(tb_anio.Text.Trim());
            mBarco.largo_Pies = int.Parse(tb_largo.Text.Trim());
            mBarco.tarifaRenta = float.Parse(tb_tarifa.Text.Trim());
            mBarco.capacidad = int.Parse(tb_cap.Text.Trim());
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosBarco();

            if (mBarcoConsultas.agregarBarco(mBarco))
            {
                MessageBox.Show("Barco Agregado");
                LimpiarCampos();
            }
        }

        private void NuevoBarco_Load(object sender, EventArgs e)
        {

        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
