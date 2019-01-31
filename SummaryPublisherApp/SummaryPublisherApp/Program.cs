using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryPublisherApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a new console app named SummaryPublisherApp.Here print to console:
            //Number of rows from the Publisher table(Execute scalar)
            //Top 10 publishers(Id, Name)(SQL Data Reader)
            //Number of books for each publisher (Publiher Name, Number of Books)
            //The total price for books for a publisher

            string connectionString = "Data Source=.;Initial Catalog=LibraryMonica;Integrated Security=True";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand dbCommand = new SqlCommand();
            dbCommand.Connection = connection;

            string selectStatement = "SELECT COUNT(*) FROM Publisher";
            dbCommand.CommandText = selectStatement;
            int number = (int)dbCommand.ExecuteScalar();
            Console.WriteLine("Number of rows: \n"+ number);

            string selectStatement2 = "SELECT TOP 10 Publisher_Id, Name FROM Publisher";
            dbCommand.CommandText = selectStatement2;
            SqlDataReader reader = dbCommand.ExecuteReader();
            Console.WriteLine("\n Top 10 Publishers:");

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string s = $"{reader[0]},{reader[1]}";
                    Console.WriteLine(s);
                }
            }
            reader.Close();

            string joinStatement = @"SELECT p.name, count(b.BookId) as book_cnt
                                     FROM BOOK B
                                    JOIN PUBLISHER P on b.publisherId=p.publisher_ID 
                                    group by p.name";
            dbCommand.CommandText = joinStatement;
            reader = dbCommand.ExecuteReader();
            Console.WriteLine("\n Publisher Name and number of books:");
            if (reader.HasRows)
            {
                while (reader.Read())
                {           
                    string s = $"{reader[0]},{reader[1]}";
                    Console.WriteLine(s);
                }
            }
            reader.Close();

            string joinStatement2 = @"SELECT p.name, sum(b.price) as book_cnt
                                     FROM BOOK B
                                    JOIN PUBLISHER P on b.publisherId=p.publisher_ID 
                                    group by p.name";
            dbCommand.CommandText = joinStatement2;

            reader = dbCommand.ExecuteReader();
            Console.WriteLine("\n Publisher Name and price of books:");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string s = $"{reader[0]},{reader[1]}";
                    Console.WriteLine(s);
                }
            }
            connection.Close();
            
            Console.ReadKey();
        }
    }
}
