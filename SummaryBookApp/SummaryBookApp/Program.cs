using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummaryBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a console app named SummaryBookApp to connect to local database.Here print to console:
            //All the books that are published in 2010
            //The book that is published in the max year(can use multiple commands)
            //Top 10 books(Title, Year, Price)

            string connectionString = "Data Source=.;Initial Catalog=LibraryMonica;Integrated Security=True";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            SqlCommand dbCommand = new SqlCommand();
            dbCommand.Connection = connection;
            string selectStatement = "SELECT Title FROM Book where year=2010";
            dbCommand.CommandText = selectStatement;
            SqlDataReader reader = dbCommand.ExecuteReader();
            Console.WriteLine("Books that are published in 2010: \n");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string s = $"{reader[0]}";
                    Console.WriteLine(s);
                }
            }
            reader.Close();

            SqlCommand dbCommand2 = new SqlCommand();
            dbCommand2.Connection = connection;

            string selectStatement2 = "SELECT Max(year) FROM book";
            dbCommand2.CommandText = selectStatement2;
            int number = (int)dbCommand2.ExecuteScalar();
            Console.WriteLine("Max year is: "+ number );

            SqlCommand dbCommand3 = new SqlCommand();
            dbCommand3.Connection = connection;


            SqlParameter bookParameter = new SqlParameter();
            bookParameter.Value = number;
            bookParameter.ParameterName = "year";
            string selectStatement3 = "SELECT Title FROM Book where year=@year";
            dbCommand3.CommandText = selectStatement3;
            dbCommand3.Parameters.Add(bookParameter);
            SqlDataReader reader2 = dbCommand3.ExecuteReader();
            Console.WriteLine("Books that are published in "+ number +" : \n");
            if (reader2.HasRows)
            {
                while (reader2.Read())
                {
                    string s = $"{reader2[0]}";
                    Console.WriteLine(s);
                }
            }
            reader2.Close();

            SqlCommand dbCommand4 = new SqlCommand();
            dbCommand4.Connection = connection;

            string selectStatement4 = "SELECT TOP 10 Title, Year, Price FROM Book";
            dbCommand4.CommandText = selectStatement4;
            SqlDataReader reader3 = dbCommand4.ExecuteReader();
            Console.WriteLine("Top 10 Books: \n");

            if (reader3.HasRows)
            {
                while (reader3.Read())
                {
                    string s = $"{reader3[0]},{reader3[1]}, {reader3[2]}";
                    Console.WriteLine(s);
                }
            }
            reader3.Close();




            Console.ReadKey();

        }
    }
}
