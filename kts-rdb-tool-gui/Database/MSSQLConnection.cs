
using System.Data;
using Microsoft.Data.SqlClient;

namespace KtsRdbTool.Database
{
    public class MSSQLConnection
    {
        private string Host { get; set; }
        private string Username { get; set; }
        private string Password { get; set; }
        private string Database { get; set; }
        private SqlConnection Connection
        {
            get
            {
                SqlConnection conn = new SqlConnection();
                conn.ConnectionString =
                  "Data Source=" + Host + ";" +
                  "Initial Catalog=" + Database + ";" +
                  "User id=" + Username + ";" +
                  "Password=" + Password + ";" +
                  "Encrypt=False;";
                return conn;
            }
        }

        public MSSQLConnection(string host, string username, string password, string database)
        {
            this.Host = host;
            this.Username = username;
            this.Password = password;
            this.Database = database;
        }

        public DataTable fetchQuery(string query)
        {
            DataTable data = new DataTable();
            SqlConnection conn = Connection;
            SqlCommand cmd = new SqlCommand(query, conn);
            conn.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(data);
            conn.Close();
            da.Dispose();
            return data;
        }
    }
}
