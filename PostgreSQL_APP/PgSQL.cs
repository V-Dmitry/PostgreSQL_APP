using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;

namespace PostgreSQL_APP
{
    class PgSQL
    {

        string server = null;
        string port = null;
        string name = null;
        string password = null;
        string connParam = null;

        public PgSQL(string connectionString)
        {
            connParam = connectionString;
        }

        public DataTable OutTable(string query)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection dbConnection = new NpgsqlConnection(connParam);
            dbConnection.Open();
            NpgsqlCommand command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = query;
            NpgsqlDataAdapter dbDataAdapter = new NpgsqlDataAdapter(command);
            DataSet ds = new DataSet();
            dbDataAdapter.Fill(ds);
            dt = ds.Tables[0];
            dbConnection.Close();
            return dt;
        }

        public void Query(string query)
        {
            NpgsqlConnection con = new NpgsqlConnection(connParam);
            NpgsqlCommand com = new NpgsqlCommand();
            com.Connection = con;
            com.CommandType = CommandType.StoredProcedure;
            com.CommandText = query;
            con.Open();
            com.ExecuteReader();
            con.Close();
        }

        public void Connect()
        {
            NpgsqlConnection con = new NpgsqlConnection(connParam);
            con.Open();
            con.Close();
        }
    }
}
