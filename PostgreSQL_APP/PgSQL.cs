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
        #region Initialize
        NpgsqlConnection dbConnection = null;
        NpgsqlCommand command = null;
        string connParam = null;

        public PgSQL(string connectionString)
        {
            connParam = connectionString;
            //dbConnection = new NpgsqlConnection(connParam);
        }
        #endregion

        #region GetTable
        public DataTable OutTable(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                //dbConnection = new NpgsqlConnection(connParam);
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

        public DataTable OutTable()
        {
            DataTable dt = new DataTable();
            try
            {
                dbConnection.Open();
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

        public DataTable GetEditRecord(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                //dbConnection = new NpgsqlConnection(connParam);
                dbConnection.Open();
                command = new NpgsqlCommand();
                command.Connection = dbConnection;
                command.CommandType = CommandType.Text;
                command.CommandText = query;
                NpgsqlDataAdapter dbDataAdapter = new NpgsqlDataAdapter(command);
                DataSet ds = new DataSet();
                dbDataAdapter.Fill(ds);
                dt = ds.Tables[0];
            }
            catch (Exception p)
            {
                throw new Exception(p.Message);
            }
            finally
            {
                dbConnection.Close();
            }
            return dt;
        }
        #endregion

        #region Params

        public NpgsqlCommand SetParamsBook(string procName, string name, string publ, string pubDate, int pgCount, int id = -1)
        {
            //dbConnection = new NpgsqlConnection(connParam);
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
            return command;
        }

        public NpgsqlCommand SetParamsLocation(string procName, int authorId, int bookId, int shelfId, int count, int id = -1)
        {
           // dbConnection = new NpgsqlConnection(connParam);
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
            return command;
        }

        public NpgsqlCommand SetParamsAuthor(string procName, string firstname, string name, string patronymic, string city, int id = -1)
        {
            //dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Transaction = transaction;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@fn", NpgsqlTypes.NpgsqlDbType.Varchar, firstname);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@p", NpgsqlTypes.NpgsqlDbType.Varchar, patronymic);
            command.Parameters.AddWithValue("@c", NpgsqlTypes.NpgsqlDbType.Varchar, city);
            return command;
        }

        public NpgsqlCommand SetParamsBookShelf(string procName, string name, string position, int id = -1)
        {
            //dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@p", NpgsqlTypes.NpgsqlDbType.Varchar, position);
            return command;
        }
        public NpgsqlCommand SetParamsPublishing(string procName, string name, string city, int id = -1)
        {
           // dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            if (id != -1)
                command.Parameters.AddWithValue("@i", NpgsqlTypes.NpgsqlDbType.Integer, id);
            command.Parameters.AddWithValue("@n", NpgsqlTypes.NpgsqlDbType.Varchar, name);
            command.Parameters.AddWithValue("@c", NpgsqlTypes.NpgsqlDbType.Varchar, city);
            return command;
        }

        public NpgsqlCommand SetParamsShowAuthor(string procName, int limit, int offset)
        {
            //dbConnection = new NpgsqlConnection(connParam);
            command = new NpgsqlCommand();
            command.Connection = dbConnection;
            command.CommandType = CommandType.StoredProcedure;
            command.CommandText = procName;
            command.Parameters.AddWithValue("@lim", NpgsqlTypes.NpgsqlDbType.Integer, limit);
            command.Parameters.AddWithValue("@off", NpgsqlTypes.NpgsqlDbType.Integer, offset);
            return command;
        }
        #endregion

        #region Connection
        public bool OpenConnetion()
        {
            //dbConnection = new NpgsqlConnection(connParam);
            if (dbConnection != null)
            {
                dbConnection.Open();
                return true;
            }
            else return false;
        }

        public void CloseConnection()
        {
            if (dbConnection != null)
            {
                dbConnection.Close();
            }
            
        }

        public void Connect()
        {
            //NpgsqlConnection con = null;
            try
            {
                dbConnection = new NpgsqlConnection(connParam);
                dbConnection.Open();
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
        #endregion

        #region Query
        public void Query(string procName)
        {
            try
            {
                //dbConnection = new NpgsqlConnection(connParam);
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

        public void QueryWithTransaction()
        {
            if (dbConnection != null & command != null)
            {
                try
                {
                    command.Transaction = transaction;
                    command.Prepare();
                    command.ExecuteNonQuery();
                }
                catch (Exception p)
                {
                    throw new Exception(p.Message);
                }
            }
        }

        public void EditVersionOfRecord(int id)
        {
            try
            {
                //dbConnection = new NpgsqlConnection(connParam);
                command = new NpgsqlCommand();
                command.Connection = dbConnection;
                command.CommandText = "update \"Author\" set version=(select version from \"Author\" where id=@id)+1 where id=@id";
                command.Parameters.AddWithValue("@id", NpgsqlTypes.NpgsqlDbType.Integer, id);
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
        #endregion

        #region Transaction
        NpgsqlTransaction transaction = null;

        public void StartTransaction(int id)
        {
            if (dbConnection != null)
            {
                if(OpenConnetion())
                     transaction = dbConnection.BeginTransaction(IsolationLevel.RepeatableRead);
                NpgsqlCommand com = new NpgsqlCommand("select * from \"Author\" where id=" + id + "for update nowait", dbConnection, transaction);
                //com.CommandTimeout = 1;
                try
                {
                    com.ExecuteNonQuery();
                }
                catch
                {
                    throw new Exception("Строка изменяется другим пользователем");
                }
            }
            else throw new Exception("Отсутствует подключение!");
        }

        public void RollBackTransaction()
        {
            if(transaction != null)
            {
                transaction.Rollback();
                CloseConnection();
            }
        }

        public void CompleteTransaction()
        {
            if (dbConnection != null || transaction != null)
            { 
                transaction.Commit();
                CloseConnection();
               // dbConnection.BeginTransaction();
            }
            else throw new Exception("Отсутствует подключение!");
        }
        #endregion
    }
}
