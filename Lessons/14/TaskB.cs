//Task B: Putting new record
//- Use the database from Task A.
//- Create a constraint for unique Name.
//- Write a simple program to let a user enter a new name.
//- Create a new applicant record with the name and list all names.Use a SQL-injection-safe approach.
//- Use a transaction.

using System;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace Lessons._14
{
    static class TaskB
    {
        public static void Run()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";
            sqlConnectionStringBuilder.IntegratedSecurity = true;

            AddNewName(sqlConnectionStringBuilder.ConnectionString);
            TaskA.PrintAllApplicants(sqlConnectionStringBuilder.ConnectionString);
        }

        private static void AddNewName(string connectionString)
        {
            Console.WriteLine("Enter new user name ...");

            Console.WriteLine("Username:");
            var username = Console.ReadLine();

            AddName(username, connectionString);

            Console.WriteLine("User added");
        }

        private static void AddName(string name, string connectionstring)
        {
            string query = "INSERT INTO Applicants(Name, IsActive) VALUES(@Name, 1)";
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                using (TransactionScope scope = new TransactionScope())
                {
                    var command = new SqlCommand(query) { Connection = connection, CommandTimeout = 120 };
                    command.Parameters.Add("@Name", SqlDbType.NVarChar);
                    command.Parameters["@Name"].Value = name;
                    command.ExecuteNonQuery();
                    scope.Complete();
                }
            }
        }
    }
}
