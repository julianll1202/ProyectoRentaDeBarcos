using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRentaDeBarcos
{
    public partial class InterfazV2 : Form
    {
        Validar v = new Validar();

        private List<Barco> mBarcos;
        private Barco mBarco;
        private BarcoConsultas mBarcoConsultas;

        private List<Cliente> mClientes;
        private Cliente mCliente;
        private ClienteConsultas mClienteConsultas;

        private List<Empleado> mEmpleados;
        private Empleado mEmpleado;
        private EmpleadoConsultas mEmpleadoConsultas;

        private List<Propietario> mPropietarios;
        private Propietario mPropietario;
        private PropietarioConsultas mPropietarioConsultas;

        private List<Renta> mRentas;
        private Renta mRenta;
        private RentaConsultas mRentaConsultas;

        private List<Tripulacion> mTripulaciones;
        private Tripulacion mTripulacion;
        private TripulacionConsultas mTripulacionConsultas;

        string num;
        string modelo;
        string nom;
        string cap, tar, anio, largo, prop;

        string ap, am, tel, email, st, col, cd, est, cp;
        string r, p;
        string c, b;
        string nume, car;
        DateTime fr, fi, ff;
        public InterfazV2()
        {
            InitializeComponent();
            mBarcos = new List<Barco>();
            mBarcoConsultas = new BarcoConsultas();
            mBarco = new Barco();

            cargarBarcos();

            mClientes = new List<Cliente>();
            mClienteConsultas = new ClienteConsultas();
            mCliente = new Cliente();

            cargarClientes();

            mEmpleados = new List<Empleado>();
            mEmpleadoConsultas = new EmpleadoConsultas();
            mEmpleado = new Empleado();

            cargarEmpleados();

            mPropietarios = new List<Propietario>();
            mPropietarioConsultas = new PropietarioConsultas();
            mPropietario = new Propietario();

            cargarPropietarios();

            mRentas = new List<Renta>();
            mRentaConsultas = new RentaConsultas();
            mRenta = new Renta();

            cargarRentas();

            mTripulaciones = new List<Tripulacion>();
            mTripulacionConsultas = new TripulacionConsultas();
            mTripulacion = new Tripulacion();

            cargarTripulaciones();
        }

        private void cargarBarcos(string filtro = "")
        {
            dataGridViewRegistro.Rows.Clear();
            dataGridViewRegistro.Refresh();
            mBarcos.Clear();
            mBarcos = mBarcoConsultas.getBarcos(filtro);

            for (int i = 0; i < mBarcos.Count(); i++)
            {
                dataGridViewRegistro.RowTemplate.Height = 20;
                dataGridViewRegistro.Rows.Add(
                    mBarcos[i].NumBarco,
                    mBarcos[i].propietario,
                    mBarcos[i].nombre,
                    mBarcos[i].modelo,
                    mBarcos[i].anio,
                    mBarcos[i].largo_Pies,
                    mBarcos[i].tarifaRenta,
                    mBarcos[i].capacidad,
                    mBarcos[i].ocupado);
            }
        }

        private void textBoxBuscar_TextChanged(object sender, EventArgs e)
        {
            cargarBarcos(textBoxBuscar.Text.Trim());
        }

        private void dataGridViewRegistro_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dataGridViewRegistro.Rows[e.RowIndex];
            num = Convert.ToString(fila.Cells["ColumnNum"].Value);
            prop = Convert.ToString(fila.Cells["ColumnPropietario"].Value);
            nom = Convert.ToString(fila.Cells["ColumnNombre"].Value);
            modelo = Convert.ToString(fila.Cells["ColumnModelo"].Value);
            anio = Convert.ToString(fila.Cells["ColumnAnio"].Value);
            largo = Convert.ToString(fila.Cells["ColumnLargo"].Value);
            tar = Convert.ToString(fila.Cells["ColumnTarifa"].Value);
            cap = Convert.ToString(fila.Cells["ColumnCapacidad"].Value);
        }

        private void cargarDatosBarco()
        {
            mBarco.NumBarco = int.Parse(num);
            mBarco.propietario = int.Parse(prop);
            mBarco.nombre = nom;
            mBarco.modelo = modelo;
            mBarco.anio = int.Parse(anio);
            mBarco.largo_Pies = int.Parse(largo);
            mBarco.tarifaRenta = float.Parse(tar);
            mBarco.capacidad = int.Parse(cap);
        }
        private void btn_Eliminar_Click(object sender, EventArgs e)
        {
            //cargar datos de la tupla a eliminar en el objeto barco
            cargarDatosBarco();

            if (MessageBox.Show("¿Desea eliminar el barco?", "Eliminar barco", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (mBarcoConsultas.eliminarBarco(mBarco))
                {
                    MessageBox.Show("Barco Eliminado");
                    cargarBarcos();
                }
            }
        }


        private void btn_Salir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void tb_propietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_anio_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_largoPies_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_tarifaRenta_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) ||

                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator

                )

                e.Handled = false;
            else
                e.Handled = true;
        }

        private void tb_capacidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_nombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        // ---------------------------Clientes--------------------------------------------

        private void tabClientes_Click(object sender, EventArgs e)
        {
            mClientes = new List<Cliente>();
            mClienteConsultas = new ClienteConsultas();
            mCliente = new Cliente();

            cargarClientes();

        }

        private void cargarClientes(string filtro = "")
        {
            dgv_registroClientes.Rows.Clear();
            dgv_registroClientes.Refresh();
            mClientes.Clear();
            mClientes = mClienteConsultas.getClientes(filtro);

            for (int i = 0; i < mClientes.Count(); i++)
            {
                dgv_registroClientes.RowTemplate.Height = 20;
                dgv_registroClientes.Rows.Add(
                    mClientes[i].NumCliente,
                    mClientes[i].nombreCliente,
                    mClientes[i].apellidoP,
                    mClientes[i].apellidoM,
                    mClientes[i].telefono,
                    mClientes[i].correo,
                    mClientes[i].ciudad,
                    mClientes[i].estado,
                    mClientes[i].calle,
                    mClientes[i].colonia,
                    mClientes[i].codigoPostal);
            }
        }

        private void tb_buscarClientes_TextChanged(object sender, EventArgs e)
        {
            cargarClientes(tb_buscarClientes.Text.Trim());
        }

        private void cargarDatosCliente()
        {
            mCliente.NumCliente = int.Parse(num);
            mCliente.nombreCliente = nom;
            mCliente.apellidoP = ap;
            mCliente.apellidoM = am;
            mCliente.telefono = tel;
            mCliente.correo = email;
            mCliente.ciudad = cd;
            mCliente.estado = est;
            mCliente.calle = st;
            mCliente.colonia = col;
            mCliente.codigoPostal = cp;
        }

        

        private void btn_actualizarCliente_Click(object sender, EventArgs e)
        {
            var form_act_cliente = new ActCliente(num,nom,ap,am,tel,email,st,col,cd,est,cp);
            form_act_cliente.ShowDialog();
        }

        private void dgv_registroClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dgv_registroClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroClientes.Rows[e.RowIndex];
            num = Convert.ToString(fila.Cells["ColumnNumCliente"].Value);
            nom = Convert.ToString(fila.Cells["nombre"].Value);
            ap = Convert.ToString(fila.Cells["apellidoP"].Value);
            am = Convert.ToString(fila.Cells["apellidoM"].Value);
            tel = Convert.ToString(fila.Cells["telefono"].Value);
            email = Convert.ToString(fila.Cells["correo"].Value);
            cd = Convert.ToString(fila.Cells["ciudad"].Value);
            est = Convert.ToString(fila.Cells["estado"].Value);
            st = Convert.ToString(fila.Cells["calle"].Value);
            col = Convert.ToString(fila.Cells["colonia"].Value);
            cp = Convert.ToString(fila.Cells["codigoPostal"].Value);
        }

        private void btn_eliminarCliente_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Desea eliminar el cliente?", "Eliminar cliente", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cargarDatosCliente();

                if (mClienteConsultas.eliminarCliente(mCliente))
                {
                    MessageBox.Show("Cliente Eliminado");
                    cargarClientes();
                    
                }
            }
        }
       
        private void btn_salirCliente_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void label29_Click(object sender, EventArgs e)
        {

        }


        private void tb_NombreCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_apellidoP_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_apellidoM_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_ciudad_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_colonia_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_estado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_telefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_codigoPostal_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        // ---------------------------Empleados--------------------------------------------

        private void cargarEmpleados(string filtro = "")
        {
            dgv_registroEmpleado.Rows.Clear();
            dgv_registroEmpleado.Refresh();
            mEmpleados.Clear();
            mEmpleados = mEmpleadoConsultas.getEmpleados(filtro);

            for (int i = 0; i < mEmpleados.Count(); i++)
            {
                dgv_registroEmpleado.RowTemplate.Height = 20;
                dgv_registroEmpleado.Rows.Add(
                    mEmpleados[i].NumEmpleado,
                    mEmpleados[i].nombreEmpleado,
                    mEmpleados[i].apellidoPEmpleado,
                    mEmpleados[i].apellidoMEmpleado,
                    mEmpleados[i].rfc,
                    mEmpleados[i].telefonoEmpleado,
                    mEmpleados[i].correoEmpleado,
                    mEmpleados[i].puesto);
            }
        }

        private void tb_buscarEmpleado_TextChanged(object sender, EventArgs e)
        {
            cargarEmpleados(tb_buscarEmpleado.Text.Trim());
        }

               
        private void cargarDatosEmpleado()
        {
            mEmpleado.NumEmpleado = int.Parse(num);
            mEmpleado.nombreEmpleado = nom;
            mEmpleado.apellidoPEmpleado = ap;
            mEmpleado.apellidoMEmpleado = am;
            mEmpleado.rfc = r;
            mEmpleado.telefonoEmpleado = tel;
            mEmpleado.correoEmpleado = email;
            mEmpleado.puesto = p;
        }

                
        private void dgv_registroEmpleado_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroEmpleado.Rows[e.RowIndex];
            num = Convert.ToString(fila.Cells["NumEmpleado"].Value);
            nom = Convert.ToString(fila.Cells["nombreEmpleado"].Value);
            ap = Convert.ToString(fila.Cells["apellidoPEmpleado"].Value);
            am = Convert.ToString(fila.Cells["apellidoMEmpleado"].Value);
           r = Convert.ToString(fila.Cells["rfc"].Value);
            tel = Convert.ToString(fila.Cells["telefonoEmpleado"].Value);
            email = Convert.ToString(fila.Cells["correoEmpleado"].Value);
            p = Convert.ToString(fila.Cells["puesto"].Value);
        }

        private void btn_eliminarEmpleado_Click(object sender, EventArgs e)
        {
          
            if (MessageBox.Show("¿Desea eliminar el empleado?", "Eliminar empleado", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cargarDatosEmpleado();

                if (mEmpleadoConsultas.eliminarEmpleado(mEmpleado))
                {
                    MessageBox.Show("Empleado Eliminado");
                    cargarEmpleados();
                    
                }
            }
        }
                
        private void btn_salirEmpleado_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tb_nombreEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_apellidoPEmpelado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_apellidoMEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_puesto_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_telefonoEmpleado_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        // ---------------------------Propietarios--------------------------------------------

        private void cargarPropietarios(string filtro = "")
        {
            dgv_registroPropietario.Rows.Clear();
            dgv_registroPropietario.Refresh();
            mPropietarios.Clear();
            mPropietarios = mPropietarioConsultas.getPropietarios(filtro);

            for (int i = 0; i < mPropietarios.Count(); i++)
            {
                dgv_registroPropietario.RowTemplate.Height = 20;
                dgv_registroPropietario.Rows.Add(
                    mPropietarios[i].IdPropietario,
                    mPropietarios[i].nombrePropietario,
                    mPropietarios[i].apellidoPPropietario,
                    mPropietarios[i].apellidoMPropietario,
                    mPropietarios[i].telefonoPropietario,
                    mPropietarios[i].correoPropietario);
            }
        }

        private void tb_buscarPropietario_TextChanged(object sender, EventArgs e)
        {
            cargarPropietarios(tb_buscarPropietario.Text.Trim());
        }

        private void btn_agregarPropietario_Click(object sender, EventArgs e)
        {
            var form_n_prop = new NuevoProp();
            form_n_prop.ShowDialog();
        }

        

        private void cargarDatosPropietario()
        {
            mPropietario.IdPropietario = int.Parse(num);
            mPropietario.nombrePropietario = nom;
            mPropietario.apellidoPPropietario = ap;
            mPropietario.apellidoMPropietario = am;
            mPropietario.telefonoPropietario = tel;
            mPropietario.correoPropietario = email;
        }

        

        private void btn_actualizarPropietario_Click(object sender, EventArgs e)
        {
            var form_act_prop = new ActProp(num, nom, ap, am, tel, email);
            form_act_prop.ShowDialog();
        }

        private void dgv_registroPropietario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroPropietario.Rows[e.RowIndex];
            num = Convert.ToString(fila.Cells["IdPropietario"].Value);
            nom = Convert.ToString(fila.Cells["nombrePropietario"].Value);
            ap = Convert.ToString(fila.Cells["apellidoPPropietario"].Value);
            am = Convert.ToString(fila.Cells["apellidoMPropietario"].Value);
            tel = Convert.ToString(fila.Cells["telefonoPropietario"].Value);
            email = Convert.ToString(fila.Cells["correoPropietario"].Value);
        }

        private void btn_eliminarPropietario_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("¿Desea eliminar el propietario?", "Eliminar propietario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cargarDatosPropietario();

                if (mPropietarioConsultas.eliminarPropietario(mPropietario))
                {
                    MessageBox.Show("Propietario Eliminado");
                    cargarPropietarios();
                   
                }
            }
        }
                
        private void btn_salirPropietario_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabRentas_Click(object sender, EventArgs e)
        {

        }

        private void label42_Click(object sender, EventArgs e)
        {

        }

        private void tb_nombrePropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_apellidoPPropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_apellidoMPropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void tb_telefonoPropietario_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        // ---------------------------Rentas--------------------------------------------

        private void cargarRentas(string filtro = "")
        {
            dgv_registroRentas.Rows.Clear();
            dgv_registroRentas.Refresh();
            mRentas.Clear();
            mRentas = mRentaConsultas.getRentas(filtro);

            for (int i = 0; i < mRentas.Count(); i++)
            {
                dgv_registroRentas.RowTemplate.Height = 20;
                dgv_registroRentas.Rows.Add(
                    mRentas[i].NumRenta,
                    mRentas[i].fechaRenta,
                    mRentas[i].fechaInicio,
                    mRentas[i].fechaFin,
                    mRentas[i].Cliente,
                    mRentas[i].Barco);
            }
        }

        private void tb_buscarRentas_TextChanged(object sender, EventArgs e)
        {
            cargarRentas(tb_buscarRentas.Text.Trim());
        }

        private void btn_agregarRenta_Click(object sender, EventArgs e)
        {
            var form_n_renta = new NuevaRenta();
            form_n_renta.ShowDialog();
        }
            
        private void cargarDatosRenta()
        {
            mRenta.NumRenta = int.Parse(num);
            mRenta.fechaRenta = fr;
            mRenta.fechaInicio = fi;
            mRenta.fechaFin = ff;
            mRenta.Cliente = int.Parse(c);
            mRenta.Barco = int.Parse(b);
        }

        private int getFolioRentaIfExist()
        {
            if (!num.Equals(""))
            {
                if (int.TryParse(num, out int folio))
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

        private void btn_actualizarRenta_Click(object sender, EventArgs e)
        {
            var form_act_renta = new ActRenta(num, fr, fi, ff, c, b);
            form_act_renta.ShowDialog();
        }

        private void dgv_registroRentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroRentas.Rows[e.RowIndex];
            num = Convert.ToString(fila.Cells["NumRenta"].Value);
            fr = Convert.ToDateTime(fila.Cells["fechaRenta"].Value);
            fi = Convert.ToDateTime(fila.Cells["fechaInicio"].Value);
            ff = Convert.ToDateTime(fila.Cells["fechaFin"].Value);
            c = Convert.ToString(fila.Cells["Cliente"].Value);
            b = Convert.ToString(fila.Cells["Barco"].Value);
        }

        private void btn_eliminarRenta_Click(object sender, EventArgs e)
        {
            cargarDatosRenta();

            if (getFolioRentaIfExist() == -1)
            {
                return;
            }

            if (MessageBox.Show("¿Desea eliminar la renta?", "Eliminar renta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                

                if (mRentaConsultas.eliminarRenta(mRenta))
                {
                    MessageBox.Show("Renta Eliminada");
                    cargarRentas();
                    
                }
            }
        }
                
        private void btn_salirRenta_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void tb_Cliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_Barco_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        // ---------------------------Tripulaciones--------------------------------------------

        private void cargarTripulaciones(string filtro = "")
        {
            dgv_registroT.Rows.Clear();
            dgv_registroT.Refresh();
            mTripulaciones.Clear();
            mTripulaciones = mTripulacionConsultas.getTripulaciones(filtro);

            for (int i = 0; i < mTripulaciones.Count(); i++)
            {
                dgv_registroT.RowTemplate.Height = 20;
                dgv_registroT.Rows.Add(
                    mTripulaciones[i].NumRentaT,
                    mTripulaciones[i].NumEmpleadoT,
                    mTripulaciones[i].cargo,
                    mTripulaciones[i].tarifa);
            }
        }

        private void tb_buscarT_TextChanged(object sender, EventArgs e)
        {
            cargarTripulaciones(tb_buscarT.Text.Trim());
        }

        private void btn_agregarT_Click(object sender, EventArgs e)
        {
            var form_n_trip = new NuevaTrip();
            form_n_trip.ShowDialog();

           
        }
                
        private void cargarDatosTripulacion()
        {
            mTripulacion.NumRentaT = getFolioTripulacionIfExist();
            mTripulacion.NumEmpleadoT = getFolioTripulacion2IfExist();
            mTripulacion.cargo = car;
            mTripulacion.tarifa = decimal.Parse(tar);
        }

        private int getFolioTripulacionIfExist()
        {
            if (!num.Equals(""))
            {
                if (int.TryParse(num, out int folio))
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

        private int getFolioTripulacion2IfExist()
        {
            if (!nume.Equals(""))
            {
                if (int.TryParse(nume, out int folio))
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

        private void btn_actualizarT_Click(object sender, EventArgs e)
        {
            var form_act_trip = new ActTrip(num, nume, car, tar);
            form_act_trip.ShowDialog();

            
        }

        private void dgv_registroT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroT.Rows[e.RowIndex];
            num = Convert.ToString(fila.Cells["NumRentaT"].Value);
            nume = Convert.ToString(fila.Cells["NumEmpleadoT"].Value);
            car = Convert.ToString(fila.Cells["cargo"].Value);
            tar = Convert.ToString(fila.Cells["tarifa"].Value);
        }

        private void btn_eliminarT_Click(object sender, EventArgs e)
        {
            if (getFolioTripulacionIfExist() == -1)
            {
                return;
            }

            if (getFolioTripulacion2IfExist() == -1)
            {
                return;
            }


            if (MessageBox.Show("¿Desea eliminar la tripulación?", "Eliminar tripulación", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cargarDatosTripulacion();

                if (mTripulacionConsultas.eliminarTripulacion(mTripulacion))
                {
                    MessageBox.Show("Tripulación Eliminada");
                    cargarTripulaciones();
                    
                }
            }
        }

        private void n_emp_btn_Click(object sender, EventArgs e)
        {
            var form_n_emp = new NuevoEmp();
            form_n_emp.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cargarTripulaciones();
        }

        private void act_btn_Click(object sender, EventArgs e)
        {
            var form_act_emp = new ActEmp(num, nom, ap, am, tel, email, r, p);
            form_act_emp.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cargarPropietarios();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            cargarRentas();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cargarEmpleados();
        }

       
        private void btn_salirT_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void InterfazV2_Load(object sender, EventArgs e)
        {

        }

        private void tb_numRentaT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_NumEmpleadoT_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloNumeros(e);
        }

        private void tb_cargo_KeyPress(object sender, KeyPressEventArgs e)
        {
            Validar.SoloLetras(e);
        }

        private void btn_Actualizar_Click(object sender, EventArgs e)
        {
            cargarBarcos();
        }

        private void ref_btn_Click(object sender, EventArgs e)
        {
            cargarClientes();
        }

        private void tb_tarifa_KeyPress(object sender, KeyPressEventArgs e)
        {
            CultureInfo cc = System.Threading.Thread.CurrentThread.CurrentCulture;

            if (char.IsNumber(e.KeyChar) ||

                e.KeyChar.ToString() == cc.NumberFormat.NumberDecimalSeparator

                )

                e.Handled = false;
            else
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form_n_cliente = new NuevoCliente();
            form_n_cliente.ShowDialog();
        }

        private void n_barco_Click(object sender, EventArgs e)
        {
            var form_nuevo_barco = new NuevoBarco();
            form_nuevo_barco.Show();
        }

        private void act_barco_Click(object sender, EventArgs e)
        {
            var form_act_barco = new ActBarco(num,nom,modelo,anio,prop,cap,tar,largo);
            form_act_barco.Show();
        }
    }
}