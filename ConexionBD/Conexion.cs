using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace ConexionBD
{
    public class Conexion
    {
        private String contenido = @"Data Source=localhost\SQLEXPRESS; Initial Catalog=Test; Persist Security Info=True; User ID=Xaman; Password=xaman; Context Connection=False";
        public SqlConnection conectar = new SqlConnection();
        public SqlDataAdapter adaptador = new SqlDataAdapter();


        public void AbrirConexion()
        {
            string sConn;
            sConn = contenido;
            conectar = new SqlConnection();
            conectar.ConnectionString = sConn;

            try
            {
                conectar.Open();
                Console.WriteLine("Conexión Exitosa");
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex + "Fallo en la Conexión");
                throw;
            }
        }

        public void CerrarConexion()
        {
            if (conectar.State == System.Data.ConnectionState.Open)
            {
                conectar.Close();
            }
        }
    }
}
