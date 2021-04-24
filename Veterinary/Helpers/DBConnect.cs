using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace Veterinary.Helpers
{
    public class DBConnect
    {
        public SqlConnection Connect()
        {
            string cnnStr = "";
            SqlConnection conn = new SqlConnection(cnnStr);
            if (conn.State != ConnectionState.Open)
            {
                conn.Open();
            }
            return conn;
        }
    }
}