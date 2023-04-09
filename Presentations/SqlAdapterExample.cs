using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentations
{
    public class SqlAdapterExample
    {
        public void SelectStatement()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = "SELECT FirstName, LastName FROM Users";

            using SqlCommand command = new SqlCommand(sql, connection);
            using SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Console.WriteLine($"{reader["FirstName"]} {reader["LastName"]}");
            }
        }

        public void UpdateStatement()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = "INSERT INTO Users (FirstName, LastName) VALUES (@FirstName, @LastName)";
            SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@FirstName", "John");
            command.Parameters.AddWithValue("@LastName", "Doe");
            command.ExecuteNonQuery();


        }

        public void UpdateStatementWithTransaction()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();
            try
            {
                string sql = "INSERT INTO Users (FirstName, LastName) VALUES (@FirstName, @LastName)";

                using SqlCommand command = new SqlCommand(sql, connection, transaction);

                command.Parameters.AddWithValue("@FirstName", "John");
                command.Parameters.AddWithValue("@LastName", "Doe");
                command.ExecuteNonQuery();


                transaction.Commit();
            }
            catch (Exception)
            {
                transaction.Rollback();
            }
        }

        public void DeleteStatement()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            string sql = "DELETE FROM Users WHERE FirstName = @FirstName AND LastName = @LastName";
            using SqlCommand command = new SqlCommand(sql, connection);

            command.Parameters.AddWithValue("@FirstName", "John");
            command.Parameters.AddWithValue("@LastName", "Doe");
            command.ExecuteNonQuery();
        }
    }
}
