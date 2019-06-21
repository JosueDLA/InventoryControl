using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ConexionBD;
using System.Data.SqlClient;

namespace Web
{
    public partial class Bodega : System.Web.UI.Page
    {
        BodegaAD bodega;

        protected void Page_Load(object sender, EventArgs e)
        {
            bodega = new BodegaAD();
            
            if (!IsPostBack)
            {
                GridLoad();

                bodega.DropBodega(ddlBodegaS);
                bodega.DropInstitucion(ddlInstitucion);
            }
        }

        public void GridLoad()
        {
            bodega = new BodegaAD();
            grdBodega.DataSource = bodega.SelectBodega();
            grdBodega.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            bodega = new BodegaAD();

            string nombre = txtNombre.Text;
            int principal = Convert.ToInt32(ddlPrincipal.SelectedValue);
            int bodegaS = Convert.ToInt32(ddlBodegaS.SelectedValue);
            int institucion = Convert.ToInt32(ddlInstitucion.SelectedValue);

            if (bodega.InsertBodega(nombre, principal, bodegaS, institucion))
            {
                //Response.Write("<script>window.alert('Institucion Creada')</script>");
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Ingreso Fallido')</script>");
            }
        }

        protected void grdBodega_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdBodega.EditIndex = e.NewEditIndex;
            GridLoad();
        }

        protected void grdBodega_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            bodega = new BodegaAD();
            
            GridViewRow row = grdBodega.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);
            TextBox nombre = (row.FindControl("txtEditNombre") as TextBox);
            
            if (bodega.UpdateBodega(Convert.ToInt32(id.Text), nombre.Text))
            {
                grdBodega.EditIndex = -1;
                GridLoad();
            }
            else
            {
                grdBodega.EditIndex = -1;
                GridLoad();
                Response.Write("<script>window.alert('Actualización Fallida')</script>");
            }
        }

        protected void grdBodega_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdBodega.EditIndex = -1;
            GridLoad();
        }

        protected void grdBodega_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            bodega = new BodegaAD();
            GridViewRow row = grdBodega.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);

            if(bodega.DeleteBodega(Convert.ToInt32(id.Text)))
            {
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('No Se Pudo Eliminar " + id + "')</script>");
            }
        }
    }
}