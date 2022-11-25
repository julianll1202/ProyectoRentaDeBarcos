using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class ClienteConsultas
    {
        private ConexionMySQL conexionMysql;
        private List<Cliente> mClientes;

        public ClienteConsultas()
        {
            conexionMysql = new ConexionMySQL();
            mClientes = new List<Cliente>();
            
        }

        

        public List<Cliente> getClientes(string filtro)
        {
            string QUERY = "SELECT * FROM clientes ";
            MySqlDataReader mReader = null;

            try
            {
                if (filtro != "")
                {
                    QUERY += " WHERE " +
                        "NumCliente LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "apellidoP LIKE '%" + filtro + "%' OR " +
                        "apellidoM LIKE '%" + filtro + "%' OR " +
                        "telefono LIKE '%" + filtro + "%' OR " +
                        "correo LIKE '%" + filtro + "%' OR " +
                        "ciudad LIKE '%" + filtro + "%' OR " +
                        "estado LIKE '%" + filtro + "%' OR " +
                        "calle LIKE '%" + filtro + "%' OR " +
                        "colonia LIKE '%" + filtro + "%' OR " +
                        "codigoPostal LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Cliente mCliente = null;

                while (mReader.Read())
                {
                    mCliente = new Cliente();
                    mCliente.NumCliente = mReader.GetInt16("NumCliente");
                    mCliente.nombreCliente = mReader.GetString("nombre");
                    mCliente.apellidoP = mReader.GetString("apellidoP");
                    mCliente.apellidoM = mReader.GetString("apellidoM");
                    mCliente.telefono = mReader.GetString("telefono");
                    mCliente.correo = mReader.GetString("correo");
                    mCliente.ciudad = mReader.GetString("ciudad");
                    mCliente.estado = mReader.GetString("estado");
                    mCliente.calle = mReader.GetString("calle");
                    mCliente.colonia = mReader.GetString("colonia");
                    mCliente.codigoPostal = mReader.GetString("codigoPostal");
                    mClientes.Add(mCliente);
                }

                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return mClientes;
        }

        public List<int> getClientesDisponibles()
        {
            List<int> clientes = new List<int>();
            string QUERY = "CALL getNumCliente();";
            MySqlDataReader mReader = null;
            try
            {
            MySqlCommand mComando = new MySqlCommand(QUERY);
            mComando.Connection = conexionMysql.GetConnection();
            mReader = mComando.ExecuteReader();

            while (mReader.Read())
            {
                clientes.Add(mReader.GetInt16("NumCliente"));
            }
            }
            catch(Exception)
            {
                throw;
            }

            return clientes;
                       
        }
        internal bool agregarCliente(Cliente mCliente)
        {
            string INSERT = "CALL nuevoCliente(@nombre, @apellidoP, @apellidoM, @telefono, @correo, @ciudad, @estado, @calle, @colonia, @codigoPostal);";

            MySqlCommand mCommandClient = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommandClient.Parameters.Add(new MySqlParameter("@nombre", mCliente.nombreCliente));
            mCommandClient.Parameters.Add(new MySqlParameter("@apellidoP", mCliente.apellidoP));
            mCommandClient.Parameters.Add(new MySqlParameter("@apellidoM", mCliente.apellidoM));
            mCommandClient.Parameters.Add(new MySqlParameter("@telefono", mCliente.telefono));
            mCommandClient.Parameters.Add(new MySqlParameter("@correo", mCliente.correo));
            mCommandClient.Parameters.Add(new MySqlParameter("@ciudad", mCliente.ciudad));
            mCommandClient.Parameters.Add(new MySqlParameter("@estado", mCliente.estado));
            mCommandClient.Parameters.Add(new MySqlParameter("@calle", mCliente.calle));
            mCommandClient.Parameters.Add(new MySqlParameter("@colonia", mCliente.colonia));
            mCommandClient.Parameters.Add(new MySqlParameter("@codigoPostal", mCliente.codigoPostal));

            return mCommandClient.ExecuteNonQuery() > 0;
        }

        internal bool modificarCliente(Cliente mCliente)
        {
            string UPDATE = "UPDATE clientes SET " +
                "nombre=@nombre, apellidoP=@apellidoP, apellidoM=@apellidoM, telefono=@telefono, correo=@correo, ciudad=@ciudad, estado=@estado" +
                ", calle=@calle,  colonia=@colonia, codigoPostal=@codigoPostal " +
                "WHERE NumCliente=@NumCliente;";

            MySqlCommand mCommandClient = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommandClient.Parameters.Add(new MySqlParameter("@nombre", mCliente.nombreCliente));
            mCommandClient.Parameters.Add(new MySqlParameter("@apellidoP", mCliente.apellidoP));
            mCommandClient.Parameters.Add(new MySqlParameter("@apellidoM", mCliente.apellidoM));
            mCommandClient.Parameters.Add(new MySqlParameter("@telefono", mCliente.telefono));
            mCommandClient.Parameters.Add(new MySqlParameter("@correo", mCliente.correo));
            mCommandClient.Parameters.Add(new MySqlParameter("@ciudad", mCliente.ciudad));
            mCommandClient.Parameters.Add(new MySqlParameter("@estado", mCliente.estado));
            mCommandClient.Parameters.Add(new MySqlParameter("@calle", mCliente.calle));
            mCommandClient.Parameters.Add(new MySqlParameter("@colonia", mCliente.colonia));
            mCommandClient.Parameters.Add(new MySqlParameter("@codigoPostal", mCliente.codigoPostal));
            mCommandClient.Parameters.Add(new MySqlParameter("@NumCliente", mCliente.NumCliente));

            return mCommandClient.ExecuteNonQuery() > 0;
        }

        internal bool eliminarCliente(Cliente mCliente)
        {
            string DELETE = "DELETE FROM clientes WHERE NumCliente=@NumCliente;";

            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@NumCliente", mCliente.NumCliente));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}
