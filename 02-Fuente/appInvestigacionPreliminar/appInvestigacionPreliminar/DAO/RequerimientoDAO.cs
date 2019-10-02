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
    class RequerimientoDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;
        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);
        //Metodos
        public string CodigoRequerimiento(string IDCARPETA)
        {
            cn = cnx.Conectar();
            string codigo = string.Empty;
            SqlCommand cmd = new SqlCommand
                ("USP_REQUERIMIENTO_CODIGO", cn);
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
        public string IngresarRequerimientoIncautacion(string IDCARPETA, string IDREQUERIMIENTO, DateTime FECHAEMISION)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_REQUERIMIENTOINCAUTACION_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            cmd.Parameters.AddWithValue("@FECHAEMISION", FECHAEMISION);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = " Requerimiento de incautación ingresado";
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
        public string IngresarRequerimientoPrisionPreventiva(string IDCARPETA, string IDREQUERIMIENTO, DateTime FECHAEMISION,string PENAMIN,string PENAMAX,string PENAREQ)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_REQUERIMIENTOPRISIONPREVENTIVA_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            cmd.Parameters.AddWithValue("@FECHAEMISION", FECHAEMISION);
            cmd.Parameters.AddWithValue("@PENAMIN", PENAMIN);
            cmd.Parameters.AddWithValue("@PENAMAX", PENAMAX);
            cmd.Parameters.AddWithValue("@PENAREQ", PENAREQ);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = " Requerimiento de prisión preventiva ingresado";
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

        public string IngresarRequerimientoParte1(string IDCARPETA, string IDREQUERIMIENTO, string IDPARTE1, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_REQUERIMIENTOPARTE1_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
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
        public string IngresarRequerimientoParte2(string IDCARPETA, string IDREQUERIMIENTO, string IDPARTE2, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_REQUERIMIENTOPARTE2_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
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
        public string IngresarRequerimientoParte3(string IDCARPETA, string IDREQUERIMIENTO, string IDPARTE3, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_REQUERIMIENTOPARTE3_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
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
        public string IngresarRequerimientoParte4(string IDCARPETA, string IDREQUERIMIENTO, string IDPARTE4, string PARRAFO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_REQUERIMIENTOPARTE4_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            cmd.Parameters.AddWithValue("@IDPARTE4", IDPARTE4);
            cmd.Parameters.AddWithValue("@PARRAFO", PARRAFO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Parte4 agregado";
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
        public DataTable ListarParte1XIDyRequerimiento(string IDCARPETA, string IDREQUERIMIENTO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_REQUERIMIENTOPARTE1_LISTARXCARPETAYREQUERIMIENTO", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarParte2XIDyRequerimiento(string IDCARPETA, string IDREQUERIMIENTO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_REQUERIMIENTOPARTE2_LISTARXCARPETAYREQUERIMIENTO", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarParte3XIDyRequerimiento(string IDCARPETA, string IDREQUERIMIENTO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_REQUERIMIENTOPARTE3_LISTARXCARPETAYREQUERIMIENTO", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarParte4XIDyRequerimiento(string IDCARPETA, string IDREQUERIMIENTO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_REQUERIMIENTOPARTE4_LISTARXCARPETAYREQUERIMIENTO", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            dap.SelectCommand.Parameters.AddWithValue("@IDREQUERIMIENTO", IDREQUERIMIENTO);
            dap.Fill(dtb);

            return dtb;
        }
    }
}
