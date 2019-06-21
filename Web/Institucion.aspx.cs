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
    public partial class _1_Institucion : System.Web.UI.Page
    {
        InstitucionAD institucion;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridLoad();
            }
        }

        public void GridLoad()
        {
            institucion = new InstitucionAD();
            grdInstitucion.DataSource = institucion.SelectInstitucion();
            grdInstitucion.DataBind();
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            institucion = new InstitucionAD();

            string nombre = txtNombre.Text;
            string ubicacion = txtUbicacion.Text;

            if (institucion.InsertInstitucion(nombre, ubicacion))
            {
                //Response.Write("<script>window.alert('Institucion Creada')</script>");
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Ingreso Fallido')</script>");
            }
        }

        protected void grdInstitucion_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdInstitucion.EditIndex = e.NewEditIndex;
            GridLoad();
        }

        protected void grdInstitucion_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            institucion = new InstitucionAD();

            GridViewRow row = grdInstitucion.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);
            TextBox nombre = (row.FindControl("txtEditNombre") as TextBox);
            TextBox ubicacion = (row.FindControl("txtEditUbicacion") as TextBox);

            if (institucion.UpdateInstitucion(Convert.ToInt32(id.Text), nombre.Text, ubicacion.Text))
            {
                grdInstitucion.EditIndex = -1;
                GridLoad();
            }
            else
            {
                grdInstitucion.EditIndex = -1;
                GridLoad();
                Response.Write("<script>window.alert('Actualización Fallida')</script>");
            }
        }

        protected void grdInstitucion_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdInstitucion.EditIndex = -1;
            GridLoad();
        }

        protected void grdInstitucion_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            institucion = new InstitucionAD();
            GridViewRow row = grdInstitucion.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);

            if (institucion.DeleteInstitucion(Convert.ToInt32(id.Text)))
            {
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('No Se Pudo Eliminar "+id+"')</script>");
            }
        }

    }
}