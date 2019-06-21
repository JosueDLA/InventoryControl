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
    public partial class Proveedor : System.Web.UI.Page
    {
        ProveedorAD proveedor;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridLoad();
            }
        }

        public void GridLoad()
        {
            proveedor = new ProveedorAD();
            grdProveedor.DataSource = proveedor.SelectProveedor();
            grdProveedor.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            proveedor = new ProveedorAD();

            string nombre = txtNombre.Text;
            int telefono = Convert.ToInt32(txtTelefono.Text);
            string correo = txtCorreo.Text;

            if (proveedor.InsertProveedor(nombre, telefono, correo))
            {
                //Response.Write("<script>window.alert('Institucion Creada')</script>");
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Ingreso Fallido')</script>");
            }
        }

        protected void grdProveedor_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdProveedor.EditIndex = e.NewEditIndex;
            GridLoad();
        }

        protected void grdProveedor_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            proveedor = new ProveedorAD();

            GridViewRow row = grdProveedor.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);
            TextBox nombre = (row.FindControl("txtEditNombre") as TextBox);
            TextBox telefono = (row.FindControl("txtEditTelefono") as TextBox);
            TextBox correo = (row.FindControl("txtEditCorreo") as TextBox);
            
            if (proveedor.UpdateProveedor(Convert.ToInt32(id.Text), nombre.Text, Convert.ToInt32(telefono.Text), correo.Text))
            {
                grdProveedor.EditIndex = -1;
                GridLoad();
            }
            else
            {
                grdProveedor.EditIndex = -1;
                GridLoad();
                Response.Write("<script>window.alert('Actualización Fallida')</script>");
            }
        }

        protected void grdProveedor_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdProveedor.EditIndex = -1;
            GridLoad();
        }

        protected void grdProveedor_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            proveedor = new ProveedorAD();

            GridViewRow row = grdProveedor.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);

            if (proveedor.DeleteProveedor(Convert.ToInt32(id.Text)))
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