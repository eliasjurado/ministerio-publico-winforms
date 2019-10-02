using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace appInvestigacionPreliminar.DAO
{
    public class FiscalDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;
        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);
        //-----------------------------------------------------------------------------

        public DataTable ListarFiscal()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_FISCAL_LISTAR", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }


        /*@NOMBRE VARCHAR (50)
        ,@SIGLAS VARCHAR(9)
        ,@CELULAR VARCHAR(9)
        ,@EMAIL VARCHAR(50)
        ,@CASILLAELECTRONICA VARCHAR(50)
        ,@DISTRITOFISCAL VARCHAR(50)
        ,@FISCALIA VARCHAR(50)
        ,@MODULO VARCHAR(50)
        ,@DESPACHO VARCHAR(50)
        ,@ABREVIATURA VARCHAR(50)
        ,@DIRECCIONPRO VARCHAR(300)*/

        public string ActualizarFiscal(
            string NOMBRE
            , string SIGLAS
            , string CELULAR
            , string EMAIL
            , string CASILLAELECTRONICA
            , string DISTRITOFISCAL
            , string FISCALIA
            , string MODULO
            , string DESPACHO
            , string ABREVIATURA
            , string DIRECCIONPRO
            )
        {
            cn = cnx.Conectar();

            string mensaje = string.Empty;

            SqlTransaction tr = null;

            SqlCommand cmd = new SqlCommand("USP_FISCAL_ACTUALIZAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@NOMBRE", NOMBRE);
            cmd.Parameters.AddWithValue("@SIGLAS", SIGLAS);
            cmd.Parameters.AddWithValue("@CELULAR", CELULAR);
            cmd.Parameters.AddWithValue("@EMAIL", EMAIL);
            cmd.Parameters.AddWithValue("@CASILLAELECTRONICA", CASILLAELECTRONICA);
            cmd.Parameters.AddWithValue("@DISTRITOFISCAL", DISTRITOFISCAL);
            cmd.Parameters.AddWithValue("@FISCALIA", FISCALIA);
            cmd.Parameters.AddWithValue("@MODULO", MODULO);
            cmd.Parameters.AddWithValue("@DESPACHO", DESPACHO);
            cmd.Parameters.AddWithValue("@ABREVIATURA", ABREVIATURA);
            cmd.Parameters.AddWithValue("@DIRECCIONPRO", DIRECCIONPRO);

            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Datos actualizados";
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
        
    }
}
