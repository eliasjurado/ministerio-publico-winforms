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
    public class DisposicionDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;
        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);
        //Metodos
        public string CodigoDisposicion(string IDCARPETA)
        {
            cn = cnx.Conectar();
            string codigo = string.Empty;
            SqlCommand cmd = new SqlCommand
                ("USP_DISPOSICION_CODIGO", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            try
            {
                cn.Open();
                codigo = cmd.ExecuteScalar().ToString();
            }
            finally
            {
                cn.Close();
            }
            return codigo;
        }

        public string IngresarDisposicionApertura(string IDCARPETA, string IDDISPOSICION, DateTime FECHAEMISION)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DISPOSICIONAPERTURA_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            cmd.Parameters.AddWithValue("@FECHAEMISION", FECHAEMISION);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = " Disposición ingresada";
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

        public string IngresarDisposicion(string IDCARPETA, string IDDISPOSICION, DateTime FECHAEMISION, string ACTUADOS)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DISPOSICION_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            cmd.Parameters.AddWithValue("@FECHAEMISION", FECHAEMISION);
            cmd.Parameters.AddWithValue("@ACTUADOS", ACTUADOS);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = " Disposición ingresada";
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

        public string IngresarDisposicionParte1(string IDCARPETA, string IDDISPOSICION, string IDPARTE1, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DISPOSICIONPARTE1_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            cmd.Parameters.AddWithValue("@IDPARTE1", IDPARTE1);
            cmd.Parameters.AddWithValue("@PARRAFO", PARRAFO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Parte1 agregado";
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
        public string IngresarDisposicionParte2(string IDCARPETA, string IDDISPOSICION, string IDPARTE2, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DISPOSICIONPARTE2_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            cmd.Parameters.AddWithValue("@IDPARTE2", IDPARTE2);
            cmd.Parameters.AddWithValue("@PARRAFO", PARRAFO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Parte2 agregado";
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
        public string IngresarDisposicionParte3(string IDCARPETA, string IDDISPOSICION, string IDPARTE3, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DISPOSICIONPARTE3_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            cmd.Parameters.AddWithValue("@IDPARTE3", IDPARTE3);
            cmd.Parameters.AddWithValue("@PARRAFO", PARRAFO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Parte3 agregado";
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
        public DataTable ListarParte1XIDyDisposicion(string IDCARPETA, string IDDISPOSICION)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_DISPOSICIONPARTE1_LISTARXCARPETAYDISPOSICION", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarParte2XIDyDisposicion(string IDCARPETA, string IDDISPOSICION)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_DISPOSICIONPARTE2_LISTARXCARPETAYDISPOSICION", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarParte3XIDyDisposicion(string IDCARPETA, string IDDISPOSICION)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_DISPOSICIONPARTE3_LISTARXCARPETAYDISPOSICION", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDDISPOSICION", IDDISPOSICION);
            dap.Fill(dtb);

            return dtb;
        }
    }
}
