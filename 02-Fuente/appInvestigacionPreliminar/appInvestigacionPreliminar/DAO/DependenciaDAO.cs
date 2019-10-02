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
    public class DependenciaDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;
        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);
        //-----------------------------------------------------------------------------
        public DataTable ListarDependencia()
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_DEPENDENCIA_LISTAR", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }
        
        public string AgregarDependencia(string DESCRIPCION, string DIRECCION)
        {
            cn = cnx.Conectar();

            string mensaje = string.Empty;

            SqlTransaction tr = null;

            SqlCommand cmd = new SqlCommand("USP_DEPENDENCIA_INSERTAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
            cmd.Parameters.AddWithValue("@DIRECCION", DIRECCION);
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
        public string ActualizarDependencia(string ID, string DESCRIPCION,string DIRECCION)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_DEPENDENCIA_ACTUALIZAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@DESCRIPCION", DESCRIPCION);
            cmd.Parameters.AddWithValue("@DIRECCION", DIRECCION);
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
        public string EliminarDependencia(string ID)
        {
            cn = cnx.Conectar();

            string mensaje = string.Empty;

            SqlTransaction tr = null;

            SqlCommand cmd = new SqlCommand("USP_DEPENDENCIA_ELIMINAR", cn);
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
                mensaje =  "Registro eliminado";
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
