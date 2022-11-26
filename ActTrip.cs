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
    public partial class ActTrip : Form
    {
        private Tripulacion mTripulacion = new Tripulacion();
        private TripulacionConsultas mTripulacionConsultas = new TripulacionConsultas();

        private RentaConsultas mRentaConsultas = new RentaConsultas();
        private EmpleadoConsultas mEmpleadoConsultas = new EmpleadoConsultas();

        public string numRenta { get; set; }
        public string numEmp { get; set; }
        public string cargo { get; set; }
        public string tarifa { get; set; }
        public ActTrip(string numRenta, string numEmp, string cargo, string tarifa)
        {
            InitializeComponent();

            this.numRenta= numRenta;
            this.numEmp= numEmp;
            this.cargo= cargo;
            this.tarifa= tarifa;
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
                //usar un if
            }

            foreach (int e in empleados)
            {
                lb_empleados.Items.Add(e);
            }

            int rindex = lb_rentas.Items.IndexOf(int.Parse(numRenta));
            int eindex = lb_empleados.Items.IndexOf(int.Parse(numEmp));

            lb_rentas.SetSelected(rindex, true);
            lb_empleados.SetSelected(eindex, true);

        }
        private void ActTrip_Load(object sender, EventArgs e)
        {
            cargar_lb();
            tb_cargo.Text = cargo;
            tb_tarifa.Text = tarifa;
        }

        private void agregar_btn_Click(object sender, EventArgs e)
        {
            cargarDatosTripulacion();
            
            if (mTripulacionConsultas.modificarTripulacion(mTripulacion))
            {
                MessageBox.Show("Tripulación Modificada");
                this.Close();

            }
        }

        private void cancel_btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
