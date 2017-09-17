//Task B: Putting new record
//- Use the database from Task A.
//- Create a constraint for unique Name.
//- Write a simple program to let a user enter a new name.
//- Create a new applicant record with the name and list all names.Use a SQL-injection-safe approach.
//- Use a transaction.

using System;
using System.Data.SqlClient;

namespace Lessons._14
{
    static class TaskB
    {
        public static void Run()
        {
            var sqlConnectionStringBuilder = new SqlConnectionStringBuilder();
            sqlConnectionStringBuilder.DataSource = @"(localdb)\v11.0";
            sqlConnectionStringBuilder.InitialCatalog = "ProgrammingInCSharp";
            
            //TODO the stuff
        }
    }
}
