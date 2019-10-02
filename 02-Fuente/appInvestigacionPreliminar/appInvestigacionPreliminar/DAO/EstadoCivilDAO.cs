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
    public class EstadoCivilDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;

        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);

        //Metodos
        public DataTable ListarEstadoCivil()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_ESTADOCIVIL_LISTAR", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }
    }
}
