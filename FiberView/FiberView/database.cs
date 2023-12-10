using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace FiberView
{
    internal class database
    {
        static string server = "localhost";
        static string user = "root";
        static string password = "";
        static string Database = "fiberview";
        public static string con = "server = '" + server + "'; database = '" + Database + "'; user = '" + user + "'; password = '" + password + "';";
        public MySqlConnection connection = new MySqlConnection(con);
        public bool connect_db()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public bool close_db()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
    }
}

