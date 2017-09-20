//Task A: Simple database.
//- Create a new database on your local sql server(localhost).
//- Create table Applicants with Id(int identity PK), Name(varchar(100)) and IsActive(bit).
//- Run script TaskAData.sql.
//- Write a code snippet to open the database and list all names ordered by the names.If an applicant is not active, add "(inactive)" suffix.
//- Save the console output and put it to the repository as TaskAOutput.png.

using System;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System.Configuration;

namespace Lessons._14
{
    static class TaskA
    {
        public static void Run()
        {
            var nameSelect = new NameSelect();
            nameSelect.SelectAplicantsSyn();

            Console.WriteLine();

            var task = nameSelect.SelectAplicantsAsync();
            task.Wait();
        }     
    }


    public class NameSelect
    {
        public void SelectAplicantsSyn()
        {
            string connectionString =ConfigurationManager.ConnectionStrings["Test14"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT * FROM dbo.Applicants order by Name", connection);
                SqlDataReader dataReader = command.ExecuteReader();

                string inactiveFormat = "Name: {0} (inactive)";
                string activeFormat = "Name: {0}";
                while (dataReader.Read())
                {
                    if (((bool)dataReader["IsActive"] == true))
                    {
                        Console.WriteLine(activeFormat, dataReader["Name"]);
                    }
                    else
                    {
                        Console.WriteLine(inactiveFormat, dataReader["Name"]);

                    }
                }
                dataReader.Close();
            }

        }

        public async Task SelectAplicantsAsync()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"FIK\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "Test14";
            sqlConnectionStringBuilder.IntegratedSecurity = true;
            using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ToString()))
            {
                
                await connection.OpenAsync();
                //SqlCommand command = new SqlCommand("SELECT * FROM Test14.dbo.Applicants order by Name desc");
                SqlCommand command = new SqlCommand("SELECT * FROM Applicants order by Name", connection);

                SqlDataReader dataReader = await command.ExecuteReaderAsync();

                string inactiveFormat = "Name: {0} (inactive)";
                string activeFormat = "Name: {0}";

                while (await dataReader.ReadAsync())
                {
                    if (((bool)dataReader["IsActive"] == true))
                    {
                        Console.WriteLine(activeFormat, dataReader["Name"]);
                    }
                    else
                    {
                        Console.WriteLine(inactiveFormat, dataReader["Name"]);

                    }
                }
                dataReader.Close();
            }
        }
    }
}