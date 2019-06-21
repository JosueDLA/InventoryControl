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
    public partial class Descarte : System.Web.UI.Page
    {
        DescarteAD descarte;
        protected void Page_Load(object sender, EventArgs e)
        {
            descarte = new DescarteAD();

            if (!IsPostBack)
            {
                GridLoad();

                descarte.DropBodega(ddlBodegaOrigen);
                descarte.DropMedicamento((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
                descarte.DropLote((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertLote"));
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
            grdDescarteDetalle.DataSource = dt;
            grdDescarteDetalle.DataBind();
            Session["DescarteDetalle"] = dt;

            grdDescarteDetalle.Rows[0].Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["DescarteDetalle"] as DataTable;
            descarte = new DescarteAD();

            string fecha = txtFecha.Text;
            int idBodegaOrigen = Convert.ToInt32(ddlBodegaOrigen.SelectedValue);

            int id = descarte.InsertDescarte(fecha, idBodegaOrigen);

            if (id > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    int idMedicamento = Convert.ToInt32(dt.Rows[i]["Medicamento"]);
                    int idLote = Convert.ToInt32(dt.Rows[i]["Lote"]);
                    int cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);
                    string motivo = (string)dt.Rows[i]["Motivo"];

                    if (!descarte.InsertDescarteDetalle(id, idMedicamento, idLote, cantidad, motivo))
                    {
                        Response.Write("<script>window.alert('Descarte Detalle Fallido')</script>");
                    }
                }
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Descarte Fallido')</script>");
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["DescarteDetalle"] as DataTable;
            DataRow dr = dt.NewRow();

            dr["Medicamento"] = ((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertMedicamento")).SelectedValue;
            dr["Lote"] = ((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertLote")).SelectedValue;
            dr["Cantidad"] = ((TextBox)grdDescarteDetalle.FooterRow.FindControl("txtInsertCantidad")).Text;
            dr["Motivo"] = ((TextBox)grdDescarteDetalle.FooterRow.FindControl("txtInsertMotivo")).Text;
            dr["Eliminar"] = string.Empty;

            dt.Rows.Add(dr);
            grdDescarteDetalle.DataSource = dt;
            grdDescarteDetalle.DataBind();
            Session["DescarteDetalle"] = dt;

            grdDescarteDetalle.Rows[0].Visible = false;
            descarte.DropMedicamento((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
            descarte.DropLote((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertLote"));
        }

        protected void grdDescarteDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = Session["DescarteDetalle"] as DataTable;
            dt.Rows.RemoveAt(e.RowIndex);
            grdDescarteDetalle.DataSource = dt;
            grdDescarteDetalle.DataBind();

            grdDescarteDetalle.Rows[0].Visible = false;
            descarte.DropMedicamento((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
            descarte.DropLote((DropDownList)grdDescarteDetalle.FooterRow.FindControl("ddlInsertLote"));
        }
    }
}