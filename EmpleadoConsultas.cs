using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class EmpleadoConsultas
    {
        private ConexionMySQL conexionMysql;
        private List<Empleado> mEmpleados;

        public EmpleadoConsultas()
        {
            conexionMysql = new ConexionMySQL();
            mEmpleados = new List<Empleado>();
        }

        public List<Empleado> getEmpleados(string filtro)
        {
            string QUERY = "SELECT * FROM empleados ";
            MySqlDataReader mReader = null;

            try
            {
                if (filtro != "")
                {
                    QUERY += " WHERE " +
                        "NumEmpleado LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "apellidoP LIKE '%" + filtro + "%' OR " +
                        "apellidoM LIKE '%" + filtro + "%' OR " +
                        "rfc LIKE '%" + filtro + "%' OR " +
                        "telefono LIKE '%" + filtro + "%' OR " +
                        "correo LIKE '%" + filtro + "%' OR " +
                        "puesto LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Empleado mEmpleado = null;

                while (mReader.Read())
                {
                    mEmpleado = new Empleado();
                    mEmpleado.NumEmpleado = mReader.GetInt16("NumEmpleado");
                    mEmpleado.nombreEmpleado = mReader.GetString("nombre");
                    mEmpleado.apellidoPEmpleado = mReader.GetString("apellidoP");
                    mEmpleado.apellidoMEmpleado = mReader.GetString("apellidoM");
                    mEmpleado.rfc = mReader.GetString("rfc");
                    mEmpleado.telefonoEmpleado = mReader.GetString("telefono");
                    mEmpleado.correoEmpleado = mReader.GetString("correo");
                    mEmpleado.puesto = mReader.GetString("puesto");
                    mEmpleados.Add(mEmpleado);
                }

                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return mEmpleados;
        }

        internal bool agregarEmpleado(Empleado mEmpleado)
        {
            string INSERT = "CALL nuevoEmpleado(@nombre, @apellidoP, @apellidoM, @rfc, @telefono, @correo, @puesto);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@nombre", mEmpleado.nombreEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoP", mEmpleado.apellidoPEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoM", mEmpleado.apellidoMEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@rfc", mEmpleado.rfc));
            mCommand.Parameters.Add(new MySqlParameter("@telefono", mEmpleado.telefonoEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@correo", mEmpleado.correoEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@puesto", mEmpleado.puesto));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool modificarEmpleado(Empleado mEmpleado)
        {
            string UPDATE = "UPDATE empleados SET " +
                "nombre=@nombre, apellidoP=@apellidoP, apellidoM=@apellidoM, rfc=@rfc, telefono=@telefono, correo=@correo, puesto=@puesto " +
                "WHERE NumEmpleado=@NumEmpleado;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@nombre", mEmpleado.nombreEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoP", mEmpleado.apellidoPEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoM", mEmpleado.apellidoMEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@rfc", mEmpleado.rfc));
            mCommand.Parameters.Add(new MySqlParameter("@telefono", mEmpleado.telefonoEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@correo", mEmpleado.correoEmpleado));
            mCommand.Parameters.Add(new MySqlParameter("@puesto", mEmpleado.puesto));
            mCommand.Parameters.Add(new MySqlParameter("@NumEmpleado", mEmpleado.NumEmpleado));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarEmpleado(Empleado mEmpleado)
        {
            string DELETE = "DELETE FROM empleados WHERE NumEmpleado=@NumEmpleado;";

            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@NumEmpleado", mEmpleado.NumEmpleado));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
