using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConexionBD;
using System.Data;

namespace Web
{
    public partial class Salida : System.Web.UI.Page
    {
        SalidaAD salida;
        protected void Page_Load(object sender, EventArgs e)
        {
            salida = new SalidaAD();

            if (!IsPostBack)
            {
                GridLoad();

                salida.DropBodega(ddlBodegaOrigen);
                salida.DropBodega(ddlBodegaDestino);
                salida.DropMedicamento((DropDownList)grdSalidaDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
            }
        }

        public void GridLoad()
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();

            dt.Columns.Add(new DataColumn("Medicamento"));
            dt.Columns.Add(new DataColumn("Cantidad"));
            dt.Columns.Add(new DataColumn("Eliminar"));

            dt.Rows.Add(dr);
            grdSalidaDetalle.DataSource = dt;
            grdSalidaDetalle.DataBind();
            Session["SalidaDetalle"] = dt;

            grdSalidaDetalle.Rows[0].Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["SalidaDetalle"] as DataTable;
            salida = new SalidaAD();

            string fecha = txtFecha.Text;
            int idBodegaOrigen = Convert.ToInt32(ddlBodegaOrigen.SelectedValue);
            int idBodegaDestino = Convert.ToInt32(ddlBodegaDestino.SelectedValue);

            int id = salida.InsertSalida(fecha, idBodegaOrigen, idBodegaDestino);

            if (id > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    int medicamento = Convert.ToInt32(dt.Rows[i]["Medicamento"]);
                    int cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);

                    if (!salida.InsertSalidaDetalle(id, medicamento, cantidad))
                    {
                        Response.Write("<script>window.alert('Salida Detalle Fallida')</script>");
                    }
                }
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Salida Fallida')</script>");
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["SalidaDetalle"] as DataTable;
            DataRow dr = dt.NewRow();

            dr["Medicamento"] = ((DropDownList)grdSalidaDetalle.FooterRow.FindControl("ddlInsertMedicamento")).SelectedValue;
            dr["Cantidad"] = ((TextBox)grdSalidaDetalle.FooterRow.FindControl("txtInsertCantidad")).Text;
            dr["Eliminar"] = string.Empty;

            dt.Rows.Add(dr);
            grdSalidaDetalle.DataSource = dt;
            grdSalidaDetalle.DataBind();
            Session["SalidaDetalle"] = dt;

            grdSalidaDetalle.Rows[0].Visible = false;
            salida.DropMedicamento((DropDownList)grdSalidaDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
        }

        protected void grdSalidaDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = Session["SalidaDetalle"] as DataTable;
            dt.Rows.RemoveAt(e.RowIndex);
            grdSalidaDetalle.DataSource = dt;
            grdSalidaDetalle.DataBind();

            grdSalidaDetalle.Rows[0].Visible = false;
            salida.DropMedicamento((DropDownList)grdSalidaDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
        }
    }
}