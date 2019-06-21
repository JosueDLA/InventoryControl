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
    public class MedicamentoAD
    {
        Conexion conectar;
        
        public DataTable SelectMedicamento()
        {
            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("select Id_Medicamento, Nombre, Minimo, Maximo from Medicamento;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public bool InsertMedicamento(string nombre, int minimio, int maximo)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Medicamento(Nombre, Minimo, Maximo) values('"+nombre+"', "+minimio+", "+maximo+");";
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

        public bool UpdateMedicamento(int id, string nombre, int minimo, int maximo)
        {
            try
            {
                conectar = new Conexion();
                string sql = "update Medicamento set Nombre='"+nombre+"', Minimo="+minimo+", Maximo="+maximo+" where Id_Medicamento="+id+";";
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

        public bool DeleteMedicamento(int id)
        {
            try
            {
                conectar = new Conexion();
                string sql = "delete from Medicamento where Id_Medicamento="+id+";";
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
