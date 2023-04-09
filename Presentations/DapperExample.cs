using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Presentations
{
    public class DapperExample
    {
        public void SelectStatement()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            IEnumerable<User> users = connection.Query<User>("SELECT FirstName, LastName FROM Users");
            foreach (User user in users)
            {
                Console.WriteLine($"{user.FirstName} {user.LastName}");
            }
        }

        public void UpdateStatement()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Execute("INSERT INTO Users (FirstName, LastName) VALUES (@FirstName, @LastName)", new { FirstName = "John", LastName = "Doe" });
        }

        public void UpdateStatementWithTransaction()
        {
            string connectionString = "Connection String";
            using SqlConnection connection = new SqlConnection(connectionString);

            connection.Open();

            using SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                connection.Execute("INSERT INTO Users (FirstName, LastName) VALUES (@FirstName, @LastName)",
                    new { FirstName = "John", LastName = "Doe" }, transaction);
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

            connection.Execute("DELETE FROM Users WHERE FirstName = @FirstName", new { FirstName = "John" });
        }
    }

    public class User
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
