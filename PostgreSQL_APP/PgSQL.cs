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
        NpgsqlConnection dbConnection = null;
        NpgsqlCommand command = null;
        string connParam = null;

        public PgSQL(string connectionString)
        {
            connParam = connectionString;
        }

        public DataTable OutTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                dbConnection = new NpgsqlConnection(connParam);
                dbConnection.Open();
                command = new NpgsqlCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = query;
                NpgsqlDataAdapter dbDataAdapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch(Exception p)
            {
                throw new Exception(p.Message);
            }
            finally
            {
                dbConnection.Close();
            }
            return dt;
        }

        public void SetParamsBook(string procName, string name, string publ, string pubDate, int pgCount, int id = -1)
        {
            dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@ph", NpgsqlTypes.NpgsqlDbType.Varchar, publ);
            command.Parameters.AddWithValue("@pd", NpgsqlTypes.NpgsqlDbType.Varchar, pubDate);
            command.Parameters.AddWithValue("@pc", NpgsqlTypes.NpgsqlDbType.Integer, pgCount);
        }

        public void SetParamsLocation(string procName, int authorId, int bookId, int shelfId, int count, int id = -1)
        {
            dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@bi", NpgsqlTypes.NpgsqlDbType.Integer, bookId);
            command.Parameters.AddWithValue("@ai", NpgsqlTypes.NpgsqlDbType.Integer, authorId);
            command.Parameters.AddWithValue("@si", NpgsqlTypes.NpgsqlDbType.Integer, shelfId);
            command.Parameters.AddWithValue("@c", NpgsqlTypes.NpgsqlDbType.Integer, count);
        }

        public void SetParamsAuthor(string procName, string firstname, string name, string patronymic, string city, int id = -1)
        {
            dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@fn", NpgsqlTypes.NpgsqlDbType.Varchar, firstname);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@p", NpgsqlTypes.NpgsqlDbType.Varchar, patronymic);
            command.Parameters.AddWithValue("@c", NpgsqlTypes.NpgsqlDbType.Varchar, city);
        }

        public void SetParamsBookShelf(string procName, string name, string position, int id = -1)
        {
            dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@p", NpgsqlTypes.NpgsqlDbType.Varchar, position);
        }
        public void SetParamsPublishing(string procName, string name, string city, int id = -1)
        {
            dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@c", NpgsqlTypes.NpgsqlDbType.Varchar, city);
        }

        public void Query(string procName)
        {
            try
            {
                dbConnection = new NpgsqlConnection(connParam);
                command = new NpgsqlCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.StoredProcedure;
                command.CommandText = procName;
                dbConnection.Open();
                command.Prepare();
                command.ExecuteNonQuery();
            }
            catch (Exception p)
            {
                throw new Exception(p.Message);
            }
            finally
            {
                dbConnection.Close();
            }
        }

        public void Query()
        {
            if (dbConnection != null & command != null)
            {
                try
                {
                    dbConnection.Open();
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                catch (Exception p)
                {
                    throw new Exception(p.Message);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }

        public DataTable OutTable2(string query)
        {
            DataTable dt = new DataTable();
            NpgsqlConnection dbConnection = null;
            try
            {
                dbConnection = new NpgsqlConnection(connParam);
                dbConnection.Open();
                NpgsqlCommand command = new NpgsqlCommand(query, dbConnection);
                NpgsqlDataAdapter dbDataAdapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception p)
            {
                MessageBox.Show(p.Message);
            }
            finally
            {
                dbConnection.Close();
            }
            return dt;
        }

        public void Connect()
        {
            NpgsqlConnection con = null;
            try
            {
                con = new NpgsqlConnection(connParam);
                con.Open();
            }
            catch(Exception p)
            {
                throw new Exception(p.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
