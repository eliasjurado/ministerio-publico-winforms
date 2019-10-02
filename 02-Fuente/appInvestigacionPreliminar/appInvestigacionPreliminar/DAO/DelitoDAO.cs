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
    public class DelitoDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;

        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);

        //Metodos
        public DataTable ListarDelitoXID(string IDCARPETA)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETADELITO_LISTARDELITOXID", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarAgravanteXID(string IDCARPETA)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETADELITO_LISTARAGRAVANTEXID", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.Fill(dtb);

            return dtb;
        }
        //Listar Tipo de Delito
        public DataTable ListarTipoDelito()
        {
            cn = cnx.Conectar();

            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_TIPODELITO_LISTAR", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }
    }

}
