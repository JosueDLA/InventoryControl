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
    public partial class Devolucion : System.Web.UI.Page
    {
        DevolucionAD devolucion;
        protected void Page_Load(object sender, EventArgs e)
        {
            devolucion = new DevolucionAD();

            if (!IsPostBack)
            {
                GridLoad();

                devolucion.DropBodega(ddlBodegaOrigen);
                devolucion.DropProveedor(ddlProveedor);
                devolucion.DropMedicamento((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
                devolucion.DropLote((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertLote"));
            }
        }

        public void GridLoad()
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();

            dt.Columns.Add(new DataColumn("Medicamento"));
            dt.Columns.Add(new DataColumn("Lote"));
            dt.Columns.Add(new DataColumn("Cantidad"));
            dt.Columns.Add(new DataColumn("Motivo"));
            dt.Columns.Add(new DataColumn("Eliminar"));

            dt.Rows.Add(dr);
            grdDevolucionDetalle.DataSource = dt;
            grdDevolucionDetalle.DataBind();
            Session["DevolucionDetalle"] = dt;

            grdDevolucionDetalle.Rows[0].Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["DevolucionDetalle"] as DataTable;
            devolucion = new DevolucionAD();

            string fecha = txtFecha.Text;
            int idBodegaOrigen = Convert.ToInt32(ddlBodegaOrigen.SelectedValue);
            int idProveedor = Convert.ToInt32(ddlProveedor.SelectedValue);

            int id = devolucion.InsertDevolucion(fecha, idBodegaOrigen, idProveedor);

            if (id > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    int idMedicamento = Convert.ToInt32(dt.Rows[i]["Medicamento"]);
                    int idLote = Convert.ToInt32(dt.Rows[i]["Lote"]);
                    int cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);
                    string motivo = (string)dt.Rows[i]["Motivo"];

                    if (!devolucion.InsertDevolucionDetalle(id, idMedicamento, idLote, cantidad, motivo))
                    {
                        Response.Write("<script>window.alert('Devolucion Detalle Fallida')</script>");
                    }
                }
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Devolucion Fallida')</script>");
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["DevolucionDetalle"] as DataTable;
            DataRow dr = dt.NewRow();

            dr["Medicamento"] = ((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertMedicamento")).SelectedValue;
            dr["Lote"] = ((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertLote")).SelectedValue;
            dr["Cantidad"] = ((TextBox)grdDevolucionDetalle.FooterRow.FindControl("txtInsertCantidad")).Text;
            dr["Motivo"] = ((TextBox)grdDevolucionDetalle.FooterRow.FindControl("txtInsertMotivo")).Text;
            dr["Eliminar"] = string.Empty;

            dt.Rows.Add(dr);
            grdDevolucionDetalle.DataSource = dt;
            grdDevolucionDetalle.DataBind();
            Session["DevolucionDetalle"] = dt;

            grdDevolucionDetalle.Rows[0].Visible = false;
            devolucion.DropMedicamento((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
            devolucion.DropLote((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertLote"));
        }

        protected void grdDevolucionDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = Session["DevolucionDetalle"] as DataTable;
            dt.Rows.RemoveAt(e.RowIndex);
            grdDevolucionDetalle.DataSource = dt;
            grdDevolucionDetalle.DataBind();

            grdDevolucionDetalle.Rows[0].Visible = false;
            devolucion.DropMedicamento((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
            devolucion.DropLote((DropDownList)grdDevolucionDetalle.FooterRow.FindControl("ddlInsertLote"));
        }
    }
}