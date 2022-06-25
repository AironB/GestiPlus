using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Threading.Tasks;
using GestiPlus.Security;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace GestiPlus.Database
{
    public class DbConnection
    {
        //private MySqlConnection _conn;
        private SqlConnection _conn;

        private string _connectionString = "";
        private string _db;
        private string _pass;

        private string _server;
        private string _user;

        //private SqlTransaction transaction;

        public void OpenConnection()
        {
            ConfigurationManager.AppSettings.AllKeys.Length.ToString();
            _server = ConfigurationManager.AppSettings.Get("Server");
            _db = ConfigurationManager.AppSettings.Get("Database");
            _user = ConfigurationManager.AppSettings.Get("Uid");
            _pass = Crypto.DecryptStringAes(ConfigurationManager.AppSettings.Get("Pwd"), Crypto.Cryptokey);

            //_connectionString = "Server=" + _server + ";Database=" + _db + ";Uid=" + _user + ";Pwd=" + _pass + ";";

            _connectionString = "Data Source=" + _server + ";Initial Catalog=" + _db + ";User id=" + _user +
                                ";Password=" + _pass + ";";

            _conn = new SqlConnection(_connectionString);
            _conn.Open();
        }

        public void CloseConnection()
        {
            _conn.Close();
        }

        public async void ExecuteQueryAsync(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            await cmd.ExecuteNonQueryAsync();
        }

        public int ExecuteQuery(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return cmd.ExecuteNonQuery();
        }

        public object ExecuteScalar(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            return cmd.ExecuteScalar();
        }

        public async Task<SqlDataReader> DataReaderAsync(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            var dr = await cmd.ExecuteReaderAsync();
            return dr;
        }

        public SqlDataReader DataReader(string query)
        {
            var cmd = new SqlCommand(query, _conn);
            var dr = cmd.ExecuteReader();
            return dr;
        }

        public DataSet DataSet(string query, string table)
        {
            var da = new SqlDataAdapter(query, _conn);
            var ds = new DataSet();
            da.Fill(ds, table);
            return ds;
        }

        public object ShowDataInGridView(string query)
        {
            var dr = new SqlDataAdapter(query, _conn);
            var ds = new DataSet();
            dr.Fill(ds);
            object dataum = ds.Tables[0];
            return dataum;
        }

        public bool ExecuteScript(string filePath)
        {
            var result = false;
            var error = false;
            var x = 0;
            var script = File.ReadAllText(filePath);

            var conn = new SqlConnection(_connectionString);

            //var server = new Server(new ServerConnection(conn));
            var server =
                new Server(new ServerConnection(new Microsoft.Data.SqlClient.SqlConnection(_connectionString)));

            try
            {
                x = server.ConnectionContext.ExecuteNonQuery(script);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                error = true;
            }

            if (!error && x != 0)
                result = true;

            return result;
        }
    }
}