using System.Data;
using Microsoft.Data.SqlClient;

namespace LibraryApp.Database
{
    public class DatabaseHelper
    {
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;Initial Catalog=LibraryDB;Integrated Security=True;TrustServerCertificate=True";

        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static DataTable ExecuteQuery(string query)
        {
            using var connection = GetConnection();
            using var adapter = new SqlDataAdapter(query, connection);
            var table = new DataTable();
            adapter.Fill(table);
            return table;
        }

        public static int ExecuteNonQuery(string query)
        {
            using var connection = GetConnection();
            using var command = new SqlCommand(query, connection);
            return command.ExecuteNonQuery();
        }

        public static object? ExecuteScalar(string query)
        {
            using var connection = GetConnection();
            using var command = new SqlCommand(query, connection);
            return command.ExecuteScalar();
        }
    }
}