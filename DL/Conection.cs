using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace DL
{
    public class Conection
    {
        public static string Connection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["conexion"].ToString();
            return connectionString;
        }
    }
}
