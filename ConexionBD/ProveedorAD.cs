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
    public class ProveedorAD
    {
        Conexion conectar;

        public DataTable SelectProveedor()
        {
            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("select Id_Proveedor, Nombre, Telefono, Correo from Proveedor;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public bool InsertProveedor(string nombre, int telefono, string correo)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Proveedor(Nombre, Telefono, Correo) values('"+nombre+"', "+telefono+", '"+correo+"');";
                SqlCommand command = new SqlCommand(sql);
                conectar.AbrirConexion();
                command.Connection = conectar.conectar;
                int exito = command.ExecuteNonQuery();
                conectar.CerrarConexion();
                return exito > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool UpdateProveedor(int id, string nombre, int telefono, string correo)
        {
            try
            {
                conectar = new Conexion();
                string sql = "update Proveedor set Nombre='"+nombre+"', Telefono="+telefono+", Correo='"+correo+"' where Id_Proveedor="+id+";";
                SqlCommand command = new SqlCommand(sql);
                conectar.AbrirConexion();
                command.Connection = conectar.conectar;
                int exito = command.ExecuteNonQuery();
                conectar.CerrarConexion();
                return exito > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool DeleteProveedor(int id)
        {
            try
            {
                conectar = new Conexion();
                string sql = "delete from Proveedor where Id_Proveedor="+id+";";
                SqlCommand command = new SqlCommand(sql);
                conectar.AbrirConexion();
                command.Connection = conectar.conectar;
                int exito = command.ExecuteNonQuery();
                conectar.CerrarConexion();
                return exito > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
