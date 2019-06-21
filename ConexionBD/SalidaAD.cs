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
    public class SalidaAD
    {
        Conexion conectar;
        MedicamentoAD medicamento;
        BodegaAD bodega;

        public int InsertSalida(string fecha, int idBodegaOrigen, int idBodegaDestino)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Salida(Fecha, Id_Bodega_Origen, Id_Bodega_Destino)OUTPUT inserted.Id_Salida values('"+fecha+"', "+idBodegaOrigen+", "+idBodegaDestino+");";
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

        public bool InsertSalidaDetalle(int id, int idMedicamento, int cantidad)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Salida_Detalle(Id_Salida, Id_Medicamento, Cantidad) values("+id+", "+idMedicamento+", "+cantidad+");";
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
            bodega = new BodegaAD();

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("N/A");
            drop.Items[0].Value = "0";
            drop.DataSource = bodega.SelectBodega();
            drop.DataTextField = "Nombre";
            drop.DataValueField = "Id_Bodega";
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

    }
}
