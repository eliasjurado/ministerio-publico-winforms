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
    public class CarpetaDAO
    {
        //Conexion para métodos
        private ConexionBD cnx = new ConexionBD();
        private SqlConnection cn;
        //Conexion para cargar combos
        private SqlConnection cn1 = new SqlConnection
            (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);
        //-----------------------------------------------------------------------------
        //LISTADO
        public DataTable Listar()
        {
            cn = cnx.Conectar();

            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTAR", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);

            return dtb;
        }

        //-----------------------------------------------------------------------------
        //FILTROS
        public DataTable ListarXNroCarpeta(string ID)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXID", cn1);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@ID", ID);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarXFechaIngreso(DateTime DESDE,DateTime HASTA)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXFECHAINGRESO", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@DESDE", DESDE);
            dap.SelectCommand.Parameters.AddWithValue("@HASTA", HASTA);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarXDelito(string DELITO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXDELITO", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@DELITO", DELITO);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarXDependenciaOrigen(string IDDEPENDENCIAORIGEN)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXDEPENDENCIAORIGEN", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDDEPENDENCIAORIGEN", IDDEPENDENCIAORIGEN);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarXSede(string IDSEDE)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXSEDE", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDSEDE", IDSEDE);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarXDependenciaDestino(string IDDEPENDENCIADESTINO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXDEPENDENCIADESTINO", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDDEPENDENCIADESTINO", IDDEPENDENCIADESTINO);
            dap.Fill(dtb);

            return dtb;
        }
        public DataTable ListarXEstado(string IDESTADO)
        {
            DataTable dtb = new DataTable();

            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARXESTADO", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.SelectCommand.Parameters.AddWithValue("@IDESTADO", IDESTADO);
            dap.Fill(dtb);

            return dtb;
        }
        //-----------------------------------------------------------------------------
        //ALERTAS
        public DataTable ListarAlerta15()
        {
            cn = cnx.Conectar();
            DataTable dtb = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARALERTA15DIAS", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);
            return dtb;
        }

        public DataTable ListarAlerta30()
        {
            cn = cnx.Conectar();
            DataTable dtb = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARALERTA30DIAS", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);
            return dtb;
        }
        public DataTable ListarAlerta60()
        {
            cn = cnx.Conectar();
            DataTable dtb = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARALERTA60DIAS", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);
            return dtb;
        }
        public DataTable ListarAlerta180()
        {
            cn = cnx.Conectar();
            DataTable dtb = new DataTable();
            SqlDataAdapter dap = new SqlDataAdapter
                ("USP_CARPETA_LISTARALERTA180DIAS", cn);
            dap.SelectCommand.CommandType = CommandType.StoredProcedure;
            dap.Fill(dtb);
            return dtb;
        }
        //-----------------------------------------------------------------------------
        //TRANSACCIONES
        public string IngresarCarpeta(string ID, string CASO, DateTime FECHAINGRESO, string IDDEPENDENCIAORIGEN,string OFICIOORIGEN)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_CARPETA_INGRESAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@CASO", CASO);
            cmd.Parameters.AddWithValue("@FECHAINGRESO", FECHAINGRESO);
            cmd.Parameters.AddWithValue("@IDDEPENDENCIAORIGEN", IDDEPENDENCIAORIGEN);
            cmd.Parameters.AddWithValue("@OFICIOORIGEN", OFICIOORIGEN);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = " Carpeta ingresada";
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

        public string EliminarCarpeta(string ID)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_CARPETA_ELIMINAR", cn);
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
                mensaje = " Carpeta eliminada";
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

        public string IngresarCarpetaSujetoProcesal(string IDCARPETA, string IDDET, string NOMBRES, string TIPOSUJETOPROCESAL, string TIPODOCIDENTIDAD, string NRODOCIDENTIDAD)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_CARPETASUJETOPROCESAL_INGRESAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDET", IDDET);
            cmd.Parameters.AddWithValue("@NOMBRES", NOMBRES);
            cmd.Parameters.AddWithValue("@TIPOSUJETOPROCESAL", TIPOSUJETOPROCESAL);
            cmd.Parameters.AddWithValue("@TIPODOCIDENTIDAD", TIPODOCIDENTIDAD);
            cmd.Parameters.AddWithValue("@NRODOCIDENTIDAD", NRODOCIDENTIDAD);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = " Sujetos procesales ingresados";
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

        public string CalificarCarpeta(string ID, string IDSEDE, string IDDEPENDENCIADESTINO, DateTime FECHAINIINV, DateTime FECHAFININV, string DIASINV)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_CARPETA_CALIFICAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ID", ID);
            cmd.Parameters.AddWithValue("@IDSEDE", IDSEDE);
            cmd.Parameters.AddWithValue("@IDDEPENDENCIADESTINO", IDDEPENDENCIADESTINO);
            cmd.Parameters.AddWithValue("@FECHAINIINV", FECHAINIINV);
            cmd.Parameters.AddWithValue("@FECHAFININV", FECHAFININV);
            cmd.Parameters.AddWithValue("@DIASINV", DIASINV);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Carpeta calificada";
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

        public string CalificarCarpetaDelito(string IDCARPETA, string IDDET, string ARTICULO, string GENERICO, string SUBGENERICO, string ESPECIFICO, string INCISO, string CITA, string TIPODELITO)
        {
            cn = cnx.Conectar();
            string mensaje = string.Empty;
            SqlTransaction tr = null;
            SqlCommand cmd = new SqlCommand("USP_CARPETADELITO_CALIFICAR", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@IDCARPETA", IDCARPETA);
            cmd.Parameters.AddWithValue("@IDDET", IDDET);
            cmd.Parameters.AddWithValue("@ARTICULO", ARTICULO);
            cmd.Parameters.AddWithValue("@GENERICO", GENERICO);
            cmd.Parameters.AddWithValue("@SUBGENERICO", SUBGENERICO);
            cmd.Parameters.AddWithValue("@ESPECIFICO", ESPECIFICO);
            cmd.Parameters.AddWithValue("@INCISO", INCISO);
            cmd.Parameters.AddWithValue("@CITA", CITA);
            cmd.Parameters.AddWithValue("@TIPODELITO", TIPODELITO);
            int q = 0;
            try
            {
                cn.Open();
                tr = cn.BeginTransaction(IsolationLevel.Serializable);
                cmd.Transaction = tr;
                q = cmd.ExecuteNonQuery();
                tr.Commit();
                mensaje = "Delito Ingresado";
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
