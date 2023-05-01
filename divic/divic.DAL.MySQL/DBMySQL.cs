using COMMON.Interfaces;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.MySQL
{
    public class DBMySQL : IDB
    {
        private MySqlConnection conexion;
        public string Error { get; private set; }

        public DBMySQL()
        {
            string server = "localhost";
            string port = "3306";
            string database = "divic_data";
            string uid = "Good_Divic";
            string password = "5Kd#8@p*";
            conexion = new MySqlConnection(string.Format("SERVER={0}; PORT={1}; DATABASE={2}; UID={3}; password={4}; Convert Zero Datetime=True; ", server, port, database, uid, password));
            AbrirConexion();
            Error = "";
        }

        public bool Comando(string command)
        {
            try
            {
                MySqlCommand cmd = new(command, conexion);
                cmd.ExecuteNonQuery();
                Error = "";
                return true;
            }
            catch (Exception ex)
            {

                Error = ex.Message;
                return false;
            }
        }

        public object Consulta(string consulta)
        {
            try
            {
                MySqlCommand cmd = new(consulta, conexion);
                MySqlDataReader reader = cmd.ExecuteReader();
                Error = "";
                return reader;
            }
            catch (Exception ex)
            {
                Error= ex.Message;
                return null;
            }
        }


        public void AbrirConexion()
        {
            try
            {
                conexion.Open();
                Error = "";

            }
            catch (Exception ex)
            {

                Error = ex.Message;

            }
        }

        public void CerrarConexion()
        {
            if (conexion.State == System.Data.ConnectionState.Open)
            {
                conexion.Close();
            }
        }

        public MySqlConnection ObtenerConexion()
        {
            return conexion;
        }

    }
}
