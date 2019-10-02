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
    public class SujetoProcesalDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;

        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);

        //Metodos
        public DataTable ListarTipoSujetoProcesal()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_TIPOSUJETOPROCESAL_LISTAR", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }
        public string IngresarSujetoProcesal(string NOMBRES)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_SUJETOPROCESAL_INGRESAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Sujeto Procesal Ingresado";
            }
            catch (Exception ex)
            {
                tr.Rollback();
                mensaje = ex.Message;
            }
            finally
            {
                cn.Close();
            }
            return mensaje;
        }


        public DataTable ListarAgraviadoXID(string IDCARPETA)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETASUJETOPROCESAL_LISTARAGRAVIADOXID", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.Fill(dtb);

            return dtb;
        }

        public DataTable ListarImputadoXID(string IDCARPETA)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETASUJETOPROCESAL_LISTARIMPUTADOXID", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.Fill(dtb);

            return dtb;
        }

        public DataTable ListarDenuncianteXID(string IDCARPETA)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETASUJETOPROCESAL_LISTARDENUNCIANTEXID", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.Fill(dtb);

            return dtb;
        }


    }
}
