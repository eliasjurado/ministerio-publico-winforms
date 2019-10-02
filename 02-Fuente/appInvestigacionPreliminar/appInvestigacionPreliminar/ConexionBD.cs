using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data.SqlClient;

namespace appInvestigacionPreliminar
{
    public class ConexionBD
    {
        public SqlConnection Conectar()
        {
            SqlConnection cn;

            cn = new SqlConnection
                (ConfigurationManager.ConnectionStrings["cadenaconexion"].ConnectionString);

            return cn;
        }
    }
}
