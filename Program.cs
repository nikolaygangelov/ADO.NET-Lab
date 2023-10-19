using System;
using System.Data.SqlClient;

namespace Ado.net
{
    public class Program
    {
        static void Main(string[] args)
        {
            //if authentication is needed
            //SqlCredential sqlCredential = new SqlCredential(username, password);
            
            //create connection between server and db with term "using" without brackets
            using SqlConnection sqlConnection = new SqlConnection(Config.ConnectionString);

            //open connection
            sqlConnection.Open();


            //query text
            string employeeCntQuery = @"SELECT COUNT(*) 
                                AS [EmployeeCount] 
                              FROM [Employees]";

            //command for execution of query text
            SqlCommand employeeCntCommand = new SqlCommand(employeeCntQuery, sqlConnection);

            //ExecuteScalar - method of SqlCommand object which returns one value
            int employeeCount = (int)employeeCntCommand.ExecuteScalar();

            string employeeInfoQuery = @"SELECT [FirstName],
		                                        [LastName],
		                                        [JobTitle]
                                           FROM [Employees]";

            SqlCommand employeeInfoCmd = new SqlCommand(employeeInfoQuery, sqlConnection);
            
            //ExecuteReader - method of SqlCommand object which returns many rows and columns as SqlDataReader type
            using SqlDataReader employeeInfoReader = employeeInfoCmd.ExecuteReader();

            //close connections regardless of "using"
            sqlConnection.Close();
            employeeInfoReader.Close();


        }
    }
}
