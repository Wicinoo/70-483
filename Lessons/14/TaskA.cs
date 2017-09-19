//Task A: Simple database.
//- Create a new database on your local sql server(localhost).
//- Create table Applicants with Id(int identity PK), Name(varchar(100)) and IsActive(bit).
//- Run script TaskAData.sql.
//- Write a code snippet to open the database and list all names ordered by the names.If an applicant is not active, add "(inactive)" suffix.
//- Save the console output and put it to the repository as TaskAOutput.png.

using System;
using System.Data.SqlClient;

namespace Lessons._14
{
    static class TaskA
    {
        public static void Run()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";


			using (var connection = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=ProgrammingInCSharp;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
			{
				connection.Open();
				var command = new SqlCommand("select * from dbo.Applicants ORDER BY Name", connection);

				SqlDataReader dataReader = command.ExecuteReader();


				while (dataReader.Read())
				{
					Console.WriteLine(String.Format("{0}{1}", dataReader["Name"], Convert.ToBoolean(dataReader["IsActive"]) ? String.Empty : "(inactive)"));
				}

			}
		 }
    }
}
