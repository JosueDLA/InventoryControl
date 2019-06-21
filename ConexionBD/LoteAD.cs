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
    public class LoteAD
    {
        Conexion conectar;

        public DataTable SelectLote()
        {
            conectar = new Conexion();
            DataTable tabla = new DataTable();

            conectar.AbrirConexion();
            string strConsulta = string.Format("select l.Id_Lote, l.Id_Entrada_Detalle, m.Nombre Medicamento, l.Cantidad_Actual, l.Precio_Unitario, l.Fecha_Vencimiento, b.Nombre Bodega from Lote l, Medicamento m, Bodega b where l.Id_Medicamento=m.Id_Medicamento and l.Id_Bodega=b.Id_Bodega and l.Cantidad_Actual>0;");
            SqlDataAdapter consulta = new SqlDataAdapter(strConsulta, conectar.conectar);
            consulta.Fill(tabla);
            conectar.CerrarConexion();

            return tabla;
        }

    }
}
