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
    public partial class Medicamento : System.Web.UI.Page
    {
        MedicamentoAD medicamento;
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridLoad();
            }
        }

        public void GridLoad()
        {
            medicamento = new MedicamentoAD();
            grdMedicamento.DataSource = medicamento.SelectMedicamento();
            grdMedicamento.DataBind();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            medicamento = new MedicamentoAD();

            string nombre = txtNombre.Text;
            int minimo = Convert.ToInt32(txtMinimo.Text);
            int maximo = Convert.ToInt32(txtMaximo.Text);

            if (medicamento.InsertMedicamento(nombre, minimo, maximo))
            {
                //Response.Write("<script>window.alert('Institucion Creada')</script>");
                Response.Redirect(HttpContext.Current.Request.Url.AbsoluteUri);
            }
            else
            {
                Response.Write("<script>window.alert('Ingreso Fallido')</script>");
            }

        }

        protected void grdMedicamento_RowEditing(object sender, GridViewEditEventArgs e)
        {
            grdMedicamento.EditIndex = e.NewEditIndex;
            GridLoad();
        }

        protected void grdMedicamento_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            medicamento = new MedicamentoAD();

            GridViewRow row = grdMedicamento.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);
            TextBox nombre = (row.FindControl("txtEditNombre") as TextBox);
            TextBox minimo = (row.FindControl("txtEditMinimo") as TextBox);
            TextBox maximo = (row.FindControl("txtEditMaximo") as TextBox);

            
            if (medicamento.UpdateMedicamento(Convert.ToInt32(id.Text), nombre.Text, Convert.ToInt32(minimo.Text), Convert.ToInt32(maximo.Text)))
            {
                grdMedicamento.EditIndex = -1;
                GridLoad();
            }
            else
            {
                grdMedicamento.EditIndex = -1;
                GridLoad();
                Response.Write("<script>window.alert('Actualización Fallida')</script>");
            }
        }

        protected void grdMedicamento_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            grdMedicamento.EditIndex = -1;
            GridLoad();
        }

        protected void grdMedicamento_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            medicamento = new MedicamentoAD();

            GridViewRow row = grdMedicamento.Rows[e.RowIndex];
            Label id = (row.FindControl("lblID") as Label);

            if (medicamento.DeleteMedicamento(Convert.ToInt32(id.Text)))
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