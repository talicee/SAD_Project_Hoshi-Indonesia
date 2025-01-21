using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALP_Hoshi
{
    public static class DatabaseConnection
    {
        private static MySqlConnection sqlConnect;

        //buat konek ke smua form 
        public static MySqlConnection Connection
        {
            get
            {
                if (sqlConnect == null)
                {
                    sqlConnect = new MySqlConnection(
                        $"server=.;" +
                        $"uid=;;" +
                        $"pwd=" +
                        $"database=");

                }
                return sqlConnect;
            }
        }
    }

}
