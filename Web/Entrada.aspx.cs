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
    public partial class Entrada : System.Web.UI.Page
    {
        EntradaAD entrada;
        protected void Page_Load(object sender, EventArgs e)
        {
            entrada = new EntradaAD();

            if (!IsPostBack)
            {
                GridLoad();

                entrada.DropInstitucion(ddlIdInstitucion);
                entrada.DropProveedor(ddlIdProveedor);
                entrada.DropMedicamento((DropDownList)grdEntradaDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
            }
        }

        public void GridLoad()
        {
            DataTable dt = new DataTable();
            DataRow dr = dt.NewRow();

            dt.Columns.Add(new DataColumn("Medicamento"));
            dt.Columns.Add(new DataColumn("Fecha"));
            dt.Columns.Add(new DataColumn("Cantidad"));
            dt.Columns.Add(new DataColumn("Precio"));
            dt.Columns.Add(new DataColumn("Editar"));
            dt.Columns.Add(new DataColumn("Eliminar"));

            dt.Rows.Add(dr);
            grdEntradaDetalle.DataSource = dt;
            grdEntradaDetalle.DataBind();
            Session["EntradaDetalle"] = dt;

            grdEntradaDetalle.Rows[0].Visible = false;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["EntradaDetalle"] as DataTable;
            entrada = new EntradaAD();

            string fecha = txtFecha.Text;
            int id_Proveedor = Convert.ToInt32(ddlIdProveedor.SelectedValue);
            int id_Institucion = Convert.ToInt32(ddlIdInstitucion.SelectedValue);

            int id = entrada.InsertEntrada(fecha, id_Proveedor, id_Institucion);
            
            if (id > 0)
            {
                for (int i = 1; i < dt.Rows.Count; i++)
                {
                    int medicamento = Convert.ToInt32(dt.Rows[i]["Medicamento"]);
                    int cantidad = Convert.ToInt32(dt.Rows[i]["Cantidad"]);
                    int precio = Convert.ToInt32(dt.Rows[i]["Precio"]);
                    string fechav = (string)dt.Rows[i]["Fecha"];
                    
                    if(!entrada.InsertEntradaDetalle(id, medicamento, cantidad, precio, fechav))
                    {
                        Response.Write("<script>window.alert('Entrada Detalle Fallida')</script>");
                    }
                }
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Entrada Fallida')</script>");
            }
        }

        protected void btnInsertar_Click(object sender, EventArgs e)
        {
            DataTable dt = Session["EntradaDetalle"] as DataTable;
            DataRow dr = dt.NewRow();

            dr["Medicamento"] = ((DropDownList)grdEntradaDetalle.FooterRow.FindControl("ddlInsertMedicamento")).SelectedValue;
            dr["Fecha"] = ((TextBox)grdEntradaDetalle.FooterRow.FindControl("txtInsertFecha")).Text;
            dr["Cantidad"] = ((TextBox)grdEntradaDetalle.FooterRow.FindControl("txtInsertCantidad")).Text;
            dr["Precio"] = ((TextBox)grdEntradaDetalle.FooterRow.FindControl("txtInsertPrecio")).Text;
            dr["Editar"] = string.Empty;
            dr["Eliminar"] = string.Empty;

            dt.Rows.Add(dr);
            grdEntradaDetalle.DataSource = dt;
            grdEntradaDetalle.DataBind();
            Session["EntradaDetalle"] = dt;

            grdEntradaDetalle.Rows[0].Visible = false;
            entrada.DropMedicamento((DropDownList)grdEntradaDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
        }

        protected void grdEntradaDetalle_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DataTable dt = Session["EntradaDetalle"] as DataTable;
            dt.Rows.RemoveAt(e.RowIndex);
            grdEntradaDetalle.DataSource = dt;
            grdEntradaDetalle.DataBind();

            grdEntradaDetalle.Rows[0].Visible = false;
            entrada.DropMedicamento((DropDownList)grdEntradaDetalle.FooterRow.FindControl("ddlInsertMedicamento"));
        }
    }
}