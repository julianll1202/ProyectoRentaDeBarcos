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
            cargarDatosPropietario();

            if (mPropietarioConsultas.agregarPropietario(mPropietario))
            {
                MessageBox.Show("Propietario Agregado");
                cargarPropietarios();
                LimpiarCamposPropietarios();
            }
        }

        private void LimpiarCamposPropietarios()
        {
            tb_IdPropietario.Text = "";
            tb_nombrePropietario.Text = "";
            tb_apellidoPPropietario.Text = "";
            tb_apellidoMPropietario.Text = "";
            tb_telefonoPropietario.Text = "";
            tb_correoPropietario.Text = "";
        }

        private void cargarDatosPropietario()
        {
            mPropietario.IdPropietario = getFolioPropietarioIfExist();
            mPropietario.nombrePropietario = tb_nombrePropietario.Text.Trim();
            mPropietario.apellidoPPropietario = tb_apellidoPPropietario.Text.Trim();
            mPropietario.apellidoMPropietario = tb_apellidoMPropietario.Text.Trim();
            mPropietario.telefonoPropietario = tb_telefonoPropietario.Text.Trim();
            mPropietario.correoPropietario = tb_correoPropietario.Text.Trim();
        }

        private int getFolioPropietarioIfExist()
        {
            if (!tb_IdPropietario.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_IdPropietario.Text.Trim(), out int folio))
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

        private void btn_actualizarPropietario_Click(object sender, EventArgs e)
        {
            cargarDatosPropietario();

            if (mPropietarioConsultas.modificarPropietario(mPropietario))
            {
                MessageBox.Show("Propietario Modificado");
                cargarPropietarios();
                LimpiarCamposPropietarios();
            }
        }

        private void dgv_registroPropietario_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroPropietario.Rows[e.RowIndex];
            tb_IdPropietario.Text = Convert.ToString(fila.Cells["IdPropietario"].Value);
            tb_nombrePropietario.Text = Convert.ToString(fila.Cells["nombrePropietario"].Value);
            tb_apellidoPPropietario.Text = Convert.ToString(fila.Cells["apellidoPPropietario"].Value);
            tb_apellidoMPropietario.Text = Convert.ToString(fila.Cells["apellidoMPropietario"].Value);
            tb_telefonoPropietario.Text = Convert.ToString(fila.Cells["telefonoPropietario"].Value);
            tb_correoPropietario.Text = Convert.ToString(fila.Cells["correoPropietario"].Value);
        }

        private void btn_eliminarPropietario_Click(object sender, EventArgs e)
        {
            if (getFolioPropietarioIfExist() == -1)
            {
                return;
            }


            if (MessageBox.Show("¿Desea eliminar el propietario?", "Eliminar propietario", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cargarDatosPropietario();

                if (mPropietarioConsultas.eliminarPropietario(mPropietario))
                {
                    MessageBox.Show("Propietario Eliminado");
                    cargarPropietarios();
                    LimpiarCamposPropietarios();
                }
            }
        }

        private void btn_limpiarPropietario_Click(object sender, EventArgs e)
        {
            LimpiarCamposPropietarios();
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
            cargarDatosRenta();

            if (mRentaConsultas.agregarRenta(mRenta))
            {
                MessageBox.Show("Renta Agregado");
                cargarRentas();
                LimpiarCamposRentas();
            }
        }

        private void LimpiarCamposRentas()
        {
            tb_NumRenta.Text = "";
            tb_fechaRenta.Text = "";
            tb_fechaInicio.Text = "";
            tb_fechaFin.Text = "";
            tb_Cliente.Text = "";
            tb_Barco.Text = "";
        }

        private void cargarDatosRenta()
        {
            mRenta.NumRenta = getFolioRentaIfExist();
            mRenta.fechaRenta = tb_fechaRenta.Text.Trim();
            mRenta.fechaInicio = tb_fechaInicio.Text.Trim();
            mRenta.fechaFin = tb_fechaFin.Text.Trim();
            mRenta.Cliente = int.Parse(tb_Cliente.Text.Trim());
            mRenta.Barco = int.Parse(tb_Barco.Text.Trim());
        }

        private int getFolioRentaIfExist()
        {
            if (!tb_NumRenta.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_NumRenta.Text.Trim(), out int folio))
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
            cargarDatosRenta();

            if (mRentaConsultas.modificarRenta(mRenta))
            {
                MessageBox.Show("Renta Modificada");
                cargarRentas();
                LimpiarCamposRentas();
            }
        }

        private void dgv_registroRentas_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroRentas.Rows[e.RowIndex];
            tb_NumRenta.Text = Convert.ToString(fila.Cells["NumRenta"].Value);
            tb_fechaRenta.Text = Convert.ToString(fila.Cells["fechaRenta"].Value);
            tb_fechaInicio.Text = Convert.ToString(fila.Cells["fechaInicio"].Value);
            tb_fechaFin.Text = Convert.ToString(fila.Cells["fechaFin"].Value);
            tb_Cliente.Text = Convert.ToString(fila.Cells["Cliente"].Value);
            tb_Barco.Text = Convert.ToString(fila.Cells["Barco"].Value);
        }

        private void btn_eliminarRenta_Click(object sender, EventArgs e)
        {
            if (getFolioRentaIfExist() == -1)
            {
                return;
            }


            if (MessageBox.Show("¿Desea eliminar la renta?", "Eliminar renta", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                cargarDatosRenta();

                if (mRentaConsultas.eliminarRenta(mRenta))
                {
                    MessageBox.Show("Renta Eliminada");
                    cargarRentas();
                    LimpiarCamposRentas();
                }
            }
        }

        private void btn_limpiarRenta_Click(object sender, EventArgs e)
        {
            LimpiarCamposRentas();
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

            for (int i = 0; i < mRentas.Count(); i++)
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
            cargarDatosTripulacion();

            if (mTripulacionConsultas.agregarTripulacion(mTripulacion))
            {
                MessageBox.Show("Tripulación Agregada");
                cargarTripulaciones();
                LimpiarCamposTripulaciones();
            }
        }

        private void LimpiarCamposTripulaciones()
        {
            tb_NumRentaT.Text = "";
            tb_NumEmpleadoT.Text = "";
            tb_cargo.Text = "";
            tb_tarifa.Text = "";
        }

        private void cargarDatosTripulacion()
        {
            mTripulacion.NumRentaT = getFolioTripulacionIfExist();
            mTripulacion.NumEmpleadoT = getFolioTripulacion2IfExist();
            mTripulacion.cargo = tb_cargo.Text.Trim();
            mTripulacion.tarifa = decimal.Parse(tb_tarifa.Text.Trim());
        }

        private int getFolioTripulacionIfExist()
        {
            if (!tb_NumRentaT.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_NumRentaT.Text.Trim(), out int folio))
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
            if (!tb_NumEmpleadoT.Text.Trim().Equals(""))
            {
                if (int.TryParse(tb_NumEmpleadoT.Text.Trim(), out int folio))
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
            cargarDatosTripulacion();

            if (mTripulacionConsultas.modificarTripulacion(mTripulacion))
            {
                MessageBox.Show("Tripulación Modificada");
                cargarTripulaciones();
                LimpiarCamposTripulaciones();
            }
        }

        private void dgv_registroT_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow fila = dgv_registroT.Rows[e.RowIndex];
            tb_NumRentaT.Text = Convert.ToString(fila.Cells["NumRentaT"].Value);
            tb_NumEmpleadoT.Text = Convert.ToString(fila.Cells["NumEmpleadoT"].Value);
            tb_cargo.Text = Convert.ToString(fila.Cells["cargo"].Value);
            tb_tarifa.Text = Convert.ToString(fila.Cells["tarifa"].Value);
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
                    LimpiarCamposTripulaciones();
                }
            }
        }

        private void n_emp_btn_Click(object sender, EventArgs e)
        {
            var form_n_emp = new NuevoEmp();
            form_n_emp.ShowDialog();
        }

        private void act_btn_Click(object sender, EventArgs e)
        {
            var form_act_emp = new ActEmp(num, nom, ap, am, tel, email, r, p);
            form_act_emp.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            cargarEmpleados();
        }

        private void btn_limpiarT_Click(object sender, EventArgs e)
        {
            LimpiarCamposTripulaciones();
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