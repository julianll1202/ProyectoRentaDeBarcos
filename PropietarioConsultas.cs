using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class PropietarioConsultas
    {
        private ConexionMySQL conexionMysql;
        private List<Propietario> mPropietarios;

        public PropietarioConsultas()
        {
            conexionMysql = new ConexionMySQL();
            mPropietarios = new List<Propietario>();
        }

        public List<Propietario> getPropietarios(string filtro)
        {
            string QUERY = "SELECT * FROM propietarios ";
            MySqlDataReader mReader = null;

            try
            {
                if (filtro != "")
                {
                    QUERY += " WHERE " +
                        "IdPropietario LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "apellidoP LIKE '%" + filtro + "%' OR " +
                        "apellidoM LIKE '%" + filtro + "%' OR " +
                        "telefono LIKE '%" + filtro + "%' OR " +
                        "correo LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Propietario mPropietario = null;

                while (mReader.Read())
                {
                    mPropietario = new Propietario();
                    mPropietario.IdPropietario = mReader.GetInt16("IdPropietario");
                    mPropietario.nombrePropietario = mReader.GetString("nombre");
                    mPropietario.apellidoPPropietario = mReader.GetString("apellidoP");
                    mPropietario.apellidoMPropietario = mReader.GetString("apellidoM");
                    mPropietario.telefonoPropietario = mReader.GetString("telefono");
                    mPropietario.correoPropietario = mReader.GetString("correo");
                    mPropietarios.Add(mPropietario);
                }

                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return mPropietarios;
        }

        internal bool agregarPropietario(Propietario mPropietario)
        {
            string INSERT = "INSERT INTO propietarios(nombre, apellidoP, apellidoM, telefono, correo) " +
                "values (@nombre, @apellidoP, @apellidoM, @telefono, @correo);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@nombre", mPropietario.nombrePropietario));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoP", mPropietario.apellidoPPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoM", mPropietario.apellidoMPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@telefono", mPropietario.telefonoPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@correo", mPropietario.correoPropietario));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool modificarPropietario(Propietario mPropietario)
        {
            string UPDATE = "UPDATE propietarios SET " +
                "nombre=@nombre, apellidoP=@apellidoP, apellidoM=@apellidoM, telefono=@telefono, correo=@correo " +
                "WHERE IdPropietario=@IdPropietario;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@nombre", mPropietario.nombrePropietario));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoP", mPropietario.apellidoPPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@apellidoM", mPropietario.apellidoMPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@telefono", mPropietario.telefonoPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@correo", mPropietario.correoPropietario));
            mCommand.Parameters.Add(new MySqlParameter("@IdPropietario", mPropietario.IdPropietario));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarPropietario(Propietario mPropietario)
        {
            string DELETE = "DELETE FROM propietarios WHERE IdPropietario=@IdPropietario;";

            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@IdPropietario", mPropietario.IdPropietario));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}