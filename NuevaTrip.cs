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
    public partial class NuevaTrip : Form
    {
        private Tripulacion mTripulacion = new Tripulacion();
        private TripulacionConsultas mTripulacionConsultas = new TripulacionConsultas();

        private RentaConsultas mRentaConsultas = new RentaConsultas();
        private EmpleadoConsultas mEmpleadoConsultas = new EmpleadoConsultas();

        public NuevaTrip()
        {
            InitializeComponent();
        }

        private void cargarDatosTripulacion()
        {
            mTripulacion.NumRentaT = int.Parse(lb_rentas.SelectedItem.ToString());
            mTripulacion.NumEmpleadoT = int.Parse(lb_empleados.SelectedItem.ToString());
            mTripulacion.cargo = tb_cargo.Text.Trim();
            mTripulacion.tarifa = decimal.Parse(tb_tarifa.Text.Trim());
        }

        private void cargar_lb()
        {
            List<int> rentas = mRentaConsultas.getNumRentas();
            List<int> empleados = mEmpleadoConsultas.getNumEmpleados();

            lb_rentas.Items.Clear();
            lb_empleados.Items.Clear();

            foreach (int r in rentas)
            {
                lb_rentas.Items.Add(r);
            }

            foreach (int e in empleados)
            {
                lb_empleados.Items.Add(e);
            }
            

        }
        private void NuevaTrip_Load(object sender, EventArgs e)
        {
            cargar_lb();
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosTripulacion();

            if (mTripulacionConsultas.agregarTripulacion(mTripulacion))
            {
                MessageBox.Show("Tripulación Agregada");
                this.Close();
            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
