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

            //TODO connect, read and print data from local database

        }
    }
}
