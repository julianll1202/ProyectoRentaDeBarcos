using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoRentaDeBarcos
{
    internal class RentaConsultas
    {
        private ConexionMySQL conexionMysql;
        private List<Renta> mRentas;

        public RentaConsultas()
        {
            conexionMysql = new ConexionMySQL();
            mRentas = new List<Renta>();
        }

        public List<Renta> getRentas(string filtro)
        {
            string QUERY = "SELECT * FROM rentas;";
            MySqlDataReader mReader = null;

            try
            {
                
                if (filtro != "")
                {
                    QUERY += " WHERE " +
                        "NumRenta LIKE '%" + filtro + "%' OR " +
                        "fechaRenta LIKE '%" + filtro + "%' OR " +
                        "fechaInicio LIKE '%" + filtro + "%' OR " +
                        "fechaFin LIKE '%" + filtro + "%' OR " +
                        "Cliente LIKE '%" + filtro + "%' OR " +
                        "Barco LIKE '%" + filtro + "%';";
                }
                

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Renta mRenta = null;

                while (mReader.Read())
                {
                    mRenta = new Renta();
                    mRenta.NumRenta = mReader.GetInt16("NumRenta");
                    mRenta.fechaRenta = mReader.GetDateTime("fechaRenta");
                    mRenta.fechaInicio = mReader.GetDateTime("fechaInicio");
                    mRenta.fechaFin = mReader.GetDateTime("fechaFin");
                    mRenta.Cliente = mReader.GetInt16("Cliente");
                    mRenta.Barco = mReader.GetInt16("Barco");
                    mRentas.Add(mRenta);
                }

                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return mRentas;
        }

        internal bool agregarRenta(Renta mRenta)
        {
            string INSERT = "CALL nuevaRenta(@fechaInicio, @fechaFin, @Cliente, @Barco);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@fechaRenta", mRenta.fechaRenta));
            mCommand.Parameters.Add(new MySqlParameter("@fechaInicio", mRenta.fechaInicio));
            mCommand.Parameters.Add(new MySqlParameter("@fechaFin", mRenta.fechaFin));
            mCommand.Parameters.Add(new MySqlParameter("@Cliente", mRenta.Cliente));
            mCommand.Parameters.Add(new MySqlParameter("@Barco", mRenta.Barco));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool modificarRenta(Renta mRenta)
        {
            string UPDATE = "UPDATE rentas SET " +
                "fechaRenta=@fechaRenta, fechaInicio=@fechaInicio, fechaFin=@fechaFin, Cliente=@Cliente, Barco=@Barco " +
                "WHERE NumRenta=@NumRenta;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@fechaRenta", mRenta.fechaRenta));
            mCommand.Parameters.Add(new MySqlParameter("@fechaInicio", mRenta.fechaInicio));
            mCommand.Parameters.Add(new MySqlParameter("@fechaFin", mRenta.fechaFin));
            mCommand.Parameters.Add(new MySqlParameter("@Cliente", mRenta.Cliente));
            mCommand.Parameters.Add(new MySqlParameter("@Barco", mRenta.Barco));
            mCommand.Parameters.Add(new MySqlParameter("@NumRenta", mRenta.NumRenta));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarRenta(Renta mRenta)
        {
            string DELETE = "DELETE FROM rentas WHERE NumRenta=@NumRenta;";

            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@NumRenta", mRenta.NumRenta));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}