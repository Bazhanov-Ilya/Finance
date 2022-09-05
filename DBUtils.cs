using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Finance {
    class DBUtils
    {
        public static string Connection()
        {
          

            string connString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\DBFinance.mdf;Integrated Security=True";
            return connString;
        }
    }
}
