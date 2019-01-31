using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsertPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=.;Initial Catalog=LibraryMonica;Integrated Security=True";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            Console.WriteLine("Please insert name of the Publisher");
            string publisherName = Console.ReadLine();
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;

            SqlParameter publisherParameter = new SqlParameter();
            publisherParameter.Value = publisherName;
            publisherParameter.ParameterName = "publisherName";

            string insertStatement = @"INSERT INTO[dbo].[Publisher]
                                       ([Name])
                                      VALUES
                                       (@publisherName);
                                Select CAST(scope_identity() as int)";

            insertCommand.CommandText = insertStatement;
            insertCommand.Parameters.Add(publisherParameter);

            int id = (int)insertCommand.ExecuteScalar();

            connection.Close();
            Console.WriteLine(id);
            Console.ReadKey();

        }
    }
}
