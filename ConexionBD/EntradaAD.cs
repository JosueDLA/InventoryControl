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
    public class EntradaAD
    {

        Conexion conectar;
        InstitucionAD institucion;
        ProveedorAD proveedor;
        MedicamentoAD medicamento;

        public DataTable SelectEntrada()
        {
            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("select Id_Entrada, Fecha, Id_Proveedor, Id_Institucion from Entrada;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

        public int InsertEntrada(string fecha, int id_Proveedor, int id_Institucion)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Entrada(Fecha, Id_Proveedor, Id_Institucion)OUTPUT inserted.Id_Entrada values('" + fecha + "', " + id_Proveedor + ", " + id_Institucion + ");";
                SqlCommand command = new SqlCommand(sql);
                conectar.AbrirConexion();
                command.Connection = conectar.conectar;
                int exito = Convert.ToInt32((string)command.ExecuteScalar().ToString());
                conectar.CerrarConexion();
                return exito;
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public bool InsertEntradaDetalle(int idEntrada, int medicamento, int cantidad, int precio, string fecha)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Entrada_Detalle(Id_Entrada, Id_Medicamento, Cantidad, Precio_Unitario, Fecha_Vencimiento) values("+idEntrada+", "+medicamento+", "+cantidad+", "+precio+",'"+fecha+"');";
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

        public void DropProveedor(DropDownList drop)
        {
            proveedor = new ProveedorAD();

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("Seleccione Un Proveedor");
            drop.Items[0].Value = "0";
            drop.DataSource = proveedor.SelectProveedor();
            drop.DataTextField = "Nombre";
            drop.DataValueField = "Id_Proveedor";
            drop.DataBind();
        }

        public void DropMedicamento(DropDownList drop)
        {
            medicamento = new MedicamentoAD();

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("Seleccione Un Medicamento");
            drop.Items[0].Value = "0";
            drop.DataSource = medicamento.SelectMedicamento();
            drop.DataTextField = "Nombre";
            drop.DataValueField = "Id_Medicamento";
            drop.DataBind();
        }

        /*public bool UpdateEntrada()
        {

        }

        public bool DeleteEntrada()
        {

        }*/

    }
}
