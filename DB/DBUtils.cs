using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Hotel
{
    class DBUtils
    {
        public static string Connection()
        {
            string datasource = @"HOME_NET\DEV";
            string database = "Hotel_Management_System";
            string username = "Hotel_adm";
            string password = "12345";

            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password;
            return connString;
        }
    }
}
