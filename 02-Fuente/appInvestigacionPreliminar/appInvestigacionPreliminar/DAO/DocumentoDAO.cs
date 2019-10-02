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
    public class DocumentoDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;
        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);
        //Metodos
        public DataTable ListarTipoDocumento()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_TIPODOCUMENTO_LISTAR", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarDocumento()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_DOCUMENTO_LISTAR", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }

        public string AgregarDocumento(string DESCRIPCION, string IDTIPODOCUMENTO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DOCUMENTO_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
            cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", IDTIPODOCUMENTO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Registro creado";
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
        public string ActualizarDocumento(string ID, string DESCRIPCION, string IDTIPODOCUMENTO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DOCUMENTO_ACTUALIZAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
            cmd.Parameters.AddWithValue("@IDTIPODOCUMENTO", IDTIPODOCUMENTO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Registro actualizado";
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
        public string EliminarDocumento(string ID)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DOCUMENTO_ELIMINAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Registro eliminado";
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
        //public string AgregarTipoDocumento(string ID, string DESCRIPCION)
        //{
        //    cn = cnx.Conectar();
        //    string mensaje = string.Empty;
        //    SqlTransaction tr = null;
        //    SqlCommand cmd = new SqlCommand("USP_TIPODOCUMENTO_INSERTAR", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
        //    int q = 0;
        //    try
        //    {
        //        cn.Open();
        //        tr = cn.BeginTransaction(IsolationLevel.Serializable);
        //        cmd.Transaction = tr;
        //        q = cmd.ExecuteNonQuery();
        //        tr.Commit();
        //        mensaje = "Registro creado";
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        mensaje = ex.Message;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    return mensaje;
        //}
        //public string ActualizarTipoDocumento(string ID, string DESCRIPCION)
        //{
        //    cn = cnx.Conectar();
        //    string mensaje = string.Empty;
        //    SqlTransaction tr = null;
        //    SqlCommand cmd = new SqlCommand("USP_TIPODOCUMENTO_ACTUALIZAR", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
        //    int q = 0;
        //    try
        //    {
        //        cn.Open();
        //        tr = cn.BeginTransaction(IsolationLevel.Serializable);
        //        cmd.Transaction = tr;
        //        q = cmd.ExecuteNonQuery();
        //        tr.Commit();
        //        mensaje = "Registro actualizado";
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        mensaje = ex.Message;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    return mensaje;
        //}
        //public string EliminarTipoDocumento(string ID)
        //{
        //    cn = cnx.Conectar();
        //    string mensaje = string.Empty;
        //    SqlTransaction tr = null;
        //    SqlCommand cmd = new SqlCommand("USP_TIPODOCUMENTO_ELIMINAR", cn);
        //    cmd.CommandType = CommandType.StoredProcedure;
        //    cmd.Parameters.AddWithValue("@ID", ID);
        //    int q = 0;
        //    try
        //    {
        //        cn.Open();
        //        tr = cn.BeginTransaction(IsolationLevel.Serializable);
        //        cmd.Transaction = tr;
        //        q = cmd.ExecuteNonQuery();
        //        tr.Commit();
        //        mensaje = "Registro eliminado";
        //    }
        //    catch (Exception ex)
        //    {
        //        tr.Rollback();
        //        mensaje = ex.Message;
        //    }
        //    finally
        //    {
        //        cn.Close();
        //    }
        //    return mensaje;
        //}

    }
}
