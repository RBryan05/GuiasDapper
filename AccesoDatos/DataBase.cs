using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos
{
    public class DataBase
    {
        private static string Conexion
        {
            get
            {
                return ConfigurationManager
                    .ConnectionStrings["BRRRR"]
                    .ConnectionString;
            }
        }

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection cadena = new SqlConnection(Conexion);
            cadena.Open();
            return cadena;
        }
    }
}
