//Task B: Putting new record
//- Use the database from Task A.
//- Create a constraint for unique Name.
//- Write a simple program to let a user enter a new name.
//- Create a new applicant record with the name and list all names.Use a SQL-injection-safe approach.
//- Use a transaction.

using System;
using System.Data.SqlClient;
using System.Transactions;
namespace Lessons._14
{
    static class TaskB
    {
        public static void Run()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";

			var name = Console.ReadLine();

			using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProgrammingInCSharp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
			{
				connection.Open();
				
				using (var scope = new TransactionScope())
				{
					var command = new SqlCommand("INSERT INTO dbo.Applicants(Name, IsActive) VALUES(@Name, @IsActive)", connection);


					command.Parameters.AddWithValue("@Name", name);
					command.Parameters.AddWithValue("@IsActive", true);

					command.ExecuteNonQuery();

					scope.Complete();
				}
				
			}
			TaskA.Run();
		}
    }
}
