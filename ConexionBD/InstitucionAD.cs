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
    public class InstitucionAD
    {

        Conexion conectar;

        public DataTable SelectInstitucion()
        {
            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("select Id_Institucion 'ID', Nombre, Ubicacion from Institucion;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public bool InsertInstitucion(string nombre, string ubicacion)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Institucion(Nombre, Ubicacion) values ('"+nombre+"', '"+ubicacion+"');";
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

        public bool UpdateInstitucion(int id, string nombre, string ubicacion)
        {
            try
            {
                conectar = new Conexion();
                string sql = "update Institucion set Nombre='"+nombre+"', Ubicacion='"+ubicacion+"' where Id_Institucion="+id+";";
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

        public bool DeleteInstitucion(int id)
        {
            try
            {
                conectar = new Conexion();
                string sql = "delete from Institucion where  Id_Institucion = "+id+";";
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
