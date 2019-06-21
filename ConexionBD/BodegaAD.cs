using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace ConexionBD
{
    public class BodegaAD
    {
        Conexion conectar;
        InstitucionAD institucion;

        public DataTable SelectBodega()
        {
            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("select b.Id_Bodega, b.Nombre, b.Principal, Id_Bodega_Superior, i.Nombre 'Institucion' from Bodega b, Institucion i where b.Id_Institucion = i.Id_Institucion;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public bool InsertBodega(string nombre, int principal, int id_Bodega_Superior, int id_Institucion)
        {
            try
            {
                conectar = new Conexion();
                string sql;
                if (id_Bodega_Superior == 0)
                {
                    sql = "insert into Bodega(Nombre, Principal, Id_Bodega_Superior, Id_Institucion) values('" + nombre + "', " + principal + ", null, " + id_Institucion + ");";
                }
                else
                {
                    sql = "insert into Bodega(Nombre, Principal, Id_Bodega_Superior, Id_Institucion) values('" + nombre + "', " + principal + ", " + id_Bodega_Superior + ", " + id_Institucion + ");";
                }
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

        public bool UpdateBodega(int id, string nombre)
        {
            try
            {
                conectar = new Conexion();
                string sql = "update Bodega set Nombre='" + nombre + "' where Id_Bodega=" + id + ";";
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

        public bool DeleteBodega(int id)
        {
            try
            {
                conectar = new Conexion();
                string sql = "delete from Bodega where Id_Bodega=" + id + ";";
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

        public void DropBodega(DropDownList drop)
        {
            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("N/A");
            drop.Items[0].Value = "0";
            drop.DataSource = SelectBodega();
            drop.DataTextField = "Nombre";
            drop.DataValueField = "Id_Bodega";
            drop.DataBind();
        }

        public void DropInstitucion(DropDownList drop)
        {
            institucion = new InstitucionAD();

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("Seleccione Una Institución");
            drop.Items[0].Value = "0";
            drop.DataSource = institucion.SelectInstitucion();
            drop.DataTextField = "Nombre";
            drop.DataValueField = "ID";
            drop.DataBind();
        }
    }
}
