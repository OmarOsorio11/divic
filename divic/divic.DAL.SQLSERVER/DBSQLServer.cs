using COMMON.Interfaces;
using Microsoft.Data.SqlClient;

namespace DAL.SQLSERVER
{
    public class DBSQLServer : IDB
    {
        private SqlConnection conexion;
        public string Error { get; private set; }

        public DBSQLServer()
        {
            string server = "divicdata.mssql.somee.com";
            string port = "";
            string database = "divicdata";
            string uid = "omar24_SQLLogin_2";
            string password = "zfg5ks76js";

            conexion = new SqlConnection(string.Format("SERVER={0}; DATABASE={1}; UID={2}; password={3}; Encrypt=False;", server, database, uid, password));
            AbrirConexion();
            Error = "";
        }

        public bool Comando(string command)
        {
            try
            {
                SqlCommand cmd = new(command, conexion);
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
                SqlCommand cmd = new(consulta, conexion);
                SqlDataReader reader = cmd.ExecuteReader();
                Error = "";
                return reader;
            }
            catch (Exception ex)
            {
                Error = ex.Message;
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

        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }

    }
}
