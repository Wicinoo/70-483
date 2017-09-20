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
            Console.WriteLine("Input Name");
            var name = Console.ReadLine();
            Console.WriteLine("Input IsActive (0/1)");
            var isActiveInput = Console.ReadLine();
            bool isActive = false;
            isActive = isActiveInput.Equals("1");
            var task = InsertApplicant(name, isActive);

            task.Wait();

            var select = new NameSelect();
            var taskSelect = select.SelectAplicantsAsync();
            taskSelect.Wait();

        }

        private static async System.Threading.Tasks.Task InsertApplicant(string name, bool isActive)
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"FIK\SQLEXPRESS";
            sqlConnectionStringBuilder.InitialCatalog = "Test14";
            sqlConnectionStringBuilder.IntegratedSecurity = true;

            using (TransactionScope transactionScope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var success = true;
                try
                {
                    using (SqlConnection connection = new SqlConnection(sqlConnectionStringBuilder.ToString()))
                    {

                        await connection.OpenAsync();
                        //SqlCommand command = new SqlCommand("SELECT * FROM Test14.dbo.Applicants order by Name desc");
                        SqlCommand command = new SqlCommand("INSERT INTO Applicants(Name, IsActive) values (@name, @isActive) ", connection);
                        command.Parameters.AddWithValue("@name", name);
                        command.Parameters.AddWithValue("@isActive", isActive);
                        int rows = await command.ExecuteNonQueryAsync();
                        Console.WriteLine("rows:{0}", rows);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    success = false;
                }
                if (success) transactionScope.Complete();
            }
        }
    }
}

