using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class TripulacionConsultas
    {
        private ConexionMySQL conexionMysql;
        private List<Tripulacion> mTripulaciones;

        public TripulacionConsultas()
        {
            conexionMysql = new ConexionMySQL();
            mTripulaciones = new List<Tripulacion>();
        }

        public List<Tripulacion> getTripulaciones(string filtro)
        {
            string QUERY = "SELECT * FROM tripulaciones ";
            MySqlDataReader mReader = null;

            try
            {
                if (filtro != "")
                {
                    QUERY += " WHERE " +
                        "NumRenta LIKE '%" + filtro + "%' OR " +
                        "NumEmpleado LIKE '%" + filtro + "%' OR " +
                        "cargo LIKE '%" + filtro + "%' OR " +
                        "tarifa LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Tripulacion mTripulacion = null;

                while (mReader.Read())
                {
                    mTripulacion = new Tripulacion();
                    mTripulacion.NumRentaT = mReader.GetInt16("NumRenta");
                    mTripulacion.NumEmpleadoT = mReader.GetInt16("NumEmpleado");
                    mTripulacion.cargo = mReader.GetString("cargo");
                    mTripulacion.tarifa = mReader.GetDecimal("tarifa");
                    mTripulaciones.Add(mTripulacion);
                }

                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return mTripulaciones;
        }

        internal bool agregarTripulacion(Tripulacion mTripulacion)
        {
            string INSERT = "INSERT INTO tripulaciones(NumRenta, NumEmpleado, cargo, tarifa) " +
                "values (@NumRenta, @NumEmpleado, @cargo, @tarifa);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@NumRenta", mTripulacion.NumRentaT));
            mCommand.Parameters.Add(new MySqlParameter("@NumEmpleado", mTripulacion.NumEmpleadoT));
            mCommand.Parameters.Add(new MySqlParameter("@cargo", mTripulacion.cargo));
            mCommand.Parameters.Add(new MySqlParameter("@tarifa", mTripulacion.tarifa));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool modificarTripulacion(Tripulacion mTripulacion)
        {
            string UPDATE = "UPDATE tripulaciones SET " +
                "cargo=@cargo, tarifa=@tarifa " +
                "WHERE NumRenta=@NumRenta and NumEmpleado=@NumEmpleado;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@NumEmpleado", mTripulacion.NumEmpleadoT));
            mCommand.Parameters.Add(new MySqlParameter("@cargo", mTripulacion.cargo));
            mCommand.Parameters.Add(new MySqlParameter("@tarifa", mTripulacion.tarifa));
            mCommand.Parameters.Add(new MySqlParameter("@NumRenta", mTripulacion.NumRentaT));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarTripulacion(Tripulacion mTripulacion)
        {
            string DELETE = "DELETE FROM tripulaciones WHERE NumRenta=@NumRenta and NumEmpleado=@NumEmpleado;";

            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@NumRenta", mTripulacion.NumRentaT));
            mCommand.Parameters.Add(new MySqlParameter("@NumEmpleado", mTripulacion.NumEmpleadoT));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}