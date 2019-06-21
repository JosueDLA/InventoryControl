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
    public partial class Lote : System.Web.UI.Page
    {
        LoteAD lote;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GridLoad();
            }
        }

        public void GridLoad()
        {
            lote = new LoteAD();
            grdLote.DataSource = lote.SelectLote();
            grdLote.DataBind();
        }
    }
}