using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lessons.Anothers.SQL
{
    public class TransactionScopeAndIsolation
    {
        private static string connectionString;

        public static void Run()
        {//7 1 5 10 8 9 3 4
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("proc1", connection);

            SqlTransaction transaction = connection.BeginTransaction(System.Data.IsolationLevel.RepeatableRead);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
                transaction.Commit();
            }
            catch 
            {
                transaction.Rollback();
            }
            finally
            {
                command.Dispose();
                connection.Dispose();
            }

        }
    }
}
