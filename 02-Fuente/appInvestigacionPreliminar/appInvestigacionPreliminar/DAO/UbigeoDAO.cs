using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace appInvestigacionPreliminar.DAO
{
    public class UbigeoDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;

        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);

        //Metodos

        public DataTable ListarDepartamento()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_UBIGEO_LISTARDEPARTAMENTO", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }

        public DataTable ListarProvincia(string Departamento)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_UBIGEO_LISTARPROVINCIA", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@PL_DEPARTAMENTO", Departamento);
            dap.Fill(dtb);

            return dtb;
        }

        public DataTable ListarDistrito(string Provincia)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_UBIGEO_LISTARDISTRITO", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@PL_PROVINCIA", Provincia);
            dap.Fill(dtb);

            return dtb;
        }
    }
}
