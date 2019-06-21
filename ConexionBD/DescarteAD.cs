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
    public class DescarteAD
    {
        Conexion conectar;
        MedicamentoAD medicamento;
        BodegaAD bodega;
        LoteAD lote;

        public int InsertDescarte(string fecha, int idBodegaOrigen)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Descarte(Fecha, Bodega_Origen)OUTPUT inserted.Id_Descarte values('" + fecha + "', " + idBodegaOrigen + ");";
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

        public bool InsertDescarteDetalle(int id, int idMedicamento, int idLote, int cantidad, string motivo)
        {
            try
            {
                conectar = new Conexion();
                string sql = "insert into Descarte_Detalle(Id_Descarte, Id_Medicamento, Id_Lote, Cantidad, Motivo) values(" + id + ", " + idMedicamento + ", " + idLote + ", " + cantidad + ", '" + motivo + "');";
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

        public void DropBodega(DropDownList drop)
        {
            bodega = new BodegaAD();

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("Seleccione Una Bodega");
            drop.Items[0].Value = "0";
            drop.DataSource = bodega.SelectBodega();
            drop.DataTextField = "Nombre";
            drop.DataValueField = "Id_Bodega";
            drop.DataBind();
        }

        public void DropLote(DropDownList drop)
        {
            lote = new LoteAD();

            drop.ClearSelection();
            drop.Items.Clear();
            drop.AppendDataBoundItems = true;
            drop.Items.Add("Seleccione Un Lote");
            drop.Items[0].Value = "0";
            drop.DataSource = lote.SelectLote();
            drop.DataTextField = "Id_Lote";
            drop.DataValueField = "Id_Lote";
            drop.DataBind();
        }
    }
}
