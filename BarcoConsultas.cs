using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoRentaDeBarcos
{
    internal class BarcoConsultas
    {
        private ConexionMySQL conexionMysql;
        private List<Barco> mBarcos;

        public BarcoConsultas() 
        {
            conexionMysql = new ConexionMySQL();
            mBarcos = new List<Barco>();
        }

        public List<Barco> getBarcos(string filtro)
        {
            string QUERY = "SELECT * FROM barcos ";
            MySqlDataReader mReader = null;

            try
            {
                if (filtro != "") 
                {
                    QUERY += " WHERE " +
                        "NumBarco LIKE '%" + filtro + "%' OR " +
                        "propietario LIKE '%" + filtro + "%' OR " +
                        "nombre LIKE '%" + filtro + "%' OR " +
                        "modelo LIKE '%" + filtro + "%' OR " +
                        "anio LIKE '%" + filtro + "%' OR " +
                        "largo_Pies LIKE '%" + filtro + "%' OR " +
                        "tarifaRenta LIKE '%" + filtro + "%' OR " +
                        "capacidad LIKE '%" + filtro + "%' OR " +
                        "ocupado LIKE '%" + filtro + "%';";
                }

                MySqlCommand mComando = new MySqlCommand(QUERY);
                mComando.Connection = conexionMysql.GetConnection();
                mReader = mComando.ExecuteReader();

                Barco mBarco = null;

                while (mReader.Read()) 
                {
                    mBarco = new Barco();
                    mBarco.NumBarco = mReader.GetInt16("NumBarco");
                    mBarco.propietario = mReader.GetInt16("propietario");
                    mBarco.nombre = mReader.GetString("nombre");
                    mBarco.modelo = mReader.GetString("modelo");
                    mBarco.anio = mReader.GetInt16("anio");
                    mBarco.largo_Pies = mReader.GetInt16("largo_Pies");
                    mBarco.tarifaRenta = mReader.GetFloat("tarifaRenta");
                    mBarco.capacidad = mReader.GetInt16("capacidad");
                    mBarco.ocupado = mReader.GetInt16("ocupado");
                    mBarcos.Add(mBarco);
                }

                mReader.Close();

            }
            catch (Exception)
            {
                throw;
            }

            return mBarcos;
        }

        internal bool agregarBarco(Barco mBarco)
        {
            string INSERT = "CALL nuevoBarco(@propietario, @nombre, @modelo, @anio, @largo_Pies, @tarifaRenta, @capacidad);";

            MySqlCommand mCommand = new MySqlCommand(INSERT, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@propietario", mBarco.propietario));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mBarco.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@modelo", mBarco.modelo));
            mCommand.Parameters.Add(new MySqlParameter("@anio", mBarco.anio));
            mCommand.Parameters.Add(new MySqlParameter("@largo_Pies", mBarco.largo_Pies));
            mCommand.Parameters.Add(new MySqlParameter("@tarifaRenta", mBarco.tarifaRenta));
            mCommand.Parameters.Add(new MySqlParameter("@capacidad", mBarco.capacidad));
            

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool modificarBarco(Barco mBarco)
        {
            string UPDATE = "UPDATE barcos SET " +
                "propietario=@propietario, nombre=@nombre, modelo=@modelo, anio=@anio, largo_Pies=@largo_Pies, tarifaRenta=@tarifaRenta, capacidad=@capacidad" +
                ", ocupado=@ocupado "+
                "WHERE NumBarco=@NumBarco;";

            MySqlCommand mCommand = new MySqlCommand(UPDATE, conexionMysql.GetConnection());

            mCommand.Parameters.Add(new MySqlParameter("@propietario", mBarco.propietario));
            mCommand.Parameters.Add(new MySqlParameter("@nombre", mBarco.nombre));
            mCommand.Parameters.Add(new MySqlParameter("@modelo", mBarco.modelo));
            mCommand.Parameters.Add(new MySqlParameter("@anio", mBarco.anio));
            mCommand.Parameters.Add(new MySqlParameter("@largo_Pies", mBarco.largo_Pies));
            mCommand.Parameters.Add(new MySqlParameter("@tarifaRenta", mBarco.tarifaRenta));
            mCommand.Parameters.Add(new MySqlParameter("@capacidad", mBarco.capacidad));
            mCommand.Parameters.Add(new MySqlParameter("@ocupado", mBarco.ocupado));
            mCommand.Parameters.Add(new MySqlParameter("@NumBarco", mBarco.NumBarco));

            return mCommand.ExecuteNonQuery() > 0;
        }

        internal bool eliminarBarco(Barco mBarco)
        {
            string DELETE = "DELETE FROM barcos WHERE NumBarco=@NumBarco;";

            MySqlCommand mCommand = new MySqlCommand(DELETE, conexionMysql.GetConnection());
            mCommand.Parameters.Add(new MySqlParameter("@NumBarco", mBarco.NumBarco));

            return mCommand.ExecuteNonQuery() > 0;
        }
    }
}