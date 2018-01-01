//Task A: Simple database.
//- Create a new database on your local sql server(localhost).
//- Create table Applicants with Id(int identity PK), Name(varchar(100)) and IsActive(bit).
//- Run script TaskAData.sql.
//- Write a code snippet to open the database and list all names ordered by the names.If an applicant is not active, add "(inactive)" suffix.
//- Save the console output and put it to the repository as TaskAOutput.png.

using System;
using System.Data;
using System.Data.SqlClient;

namespace Lessons._14
{
    static class TaskA
    {
        public static void Run()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = "localhost";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";
            sqlConnectionStringBuilder.IntegratedSecurity = true;

            PrintAllApplicants(sqlConnectionStringBuilder.ConnectionString);
        }

        public static void PrintAllApplicants(string connectionstring)
        {
            DataTable dataTable = new DataTable();
            string query = "SELECT NAME + CASE WHEN IsActive = 0 THEN 'InActive' ELSE '' END AS NAME  FROM Applicants ORDER BY NAME";
            using (var connection = new SqlConnection(connectionstring))
            {
                connection.Open();
                var command = new SqlCommand(query) { Connection = connection, CommandTimeout = 120 };
                var data = new SqlDataAdapter(command);
                data.Fill(dataTable);
                data.Dispose();
            }
            foreach (var row in dataTable.AsEnumerable())
            {
                Console.WriteLine(row["Name"]);
            }

        }
    }
}
