using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeletePublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a console app: DeletePublisherApp
            //Read the publisher id from console
            //Delete the publisher with a stored procedure
            //Create a stored procedure named DeletePubliser -has a param(publisher id). In this stored procedure: 
            //Delete all the books for a publisher
            //Delete the publisher
            //        }
            string connectionString = "Data Source=.;Initial Catalog=LibraryMonica;Integrated Security=True";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
           
            SqlCommand comanda = new SqlCommand
            {
                Connection = connection,
                CommandText = "DeletePubliserSP",
                CommandType = CommandType.StoredProcedure
            };

            Console.Write("Please insert id of the publisher");
            comanda.Parameters.AddWithValue("@publisherId", Console.ReadLine());
            comanda.ExecuteNonQuery();

        }
    }
}
