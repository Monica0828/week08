using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudBookApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a console app named CrudBookApp to connect to local database.
            //Use SQL parameters for that
            //Print the inserted id(Execute scalar with select identity)
            //Update a book(read id from console)
            //Delete a book(read id from console)
            //Select a book(read id from console)

            string connectionString = "Data Source=.;Initial Catalog=LibraryMonica;Integrated Security=True";
            SqlConnection connection = new SqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();

            Console.WriteLine("Please insert name of the book");
            string bookName = Console.ReadLine();
            SqlCommand insertCommand = new SqlCommand();
            insertCommand.Connection = connection;
            SqlParameter bookParameter = new SqlParameter();
            bookParameter.Value = bookName;
            bookParameter.ParameterName = "bookName";
            string insertStatement = @"INSERT INTO[dbo].[Book]
                                       ([Title]
                                       ,[PublisherId]
                                       ,[Year]
                                       ,[Price])
                                      VALUES
                                       (@booKName
                                       ,3
                                       ,2019
                                       ,30);
                                        Select CAST(scope_identity() as int)";
            insertCommand.CommandText = insertStatement;
            insertCommand.Parameters.Add(bookParameter);
            int id = (int)insertCommand.ExecuteScalar();
            Console.WriteLine(id);


            Console.WriteLine("Please insert id of the book for update");
            int bookId = Convert.ToInt32(Console.ReadLine());
            SqlCommand updateCommand = new SqlCommand();
            updateCommand.Connection = connection;
            SqlParameter bookParameter1 = new SqlParameter();
            bookParameter1.Value = bookId;
            bookParameter1.ParameterName = "bookId";
            string updateStatement = @"Update Book
                                        set year=2019 
                                        where bookId=@bookId";
            updateCommand.CommandText = updateStatement;

            updateCommand.Parameters.Add(bookParameter1);
            updateCommand.ExecuteNonQuery();
            Console.WriteLine("Update was done successfully\n");

            Console.WriteLine("Please insert id of the book for delete");
            int bookId2 = Convert.ToInt32(Console.ReadLine());
            SqlCommand deleteCommand = new SqlCommand();
            deleteCommand.Connection = connection;
            SqlParameter bookParameter2 = new SqlParameter();
            bookParameter2.Value = bookId2;
            bookParameter2.ParameterName = "bookId";
            string deleteStatement = @"Delete from BookAuthor where bookId=@bookId;
                                       Delete from Book where bookId=@bookId";
            deleteCommand.CommandText = deleteStatement;
            deleteCommand.Parameters.Add(bookParameter2);
            deleteCommand.ExecuteNonQuery();
            Console.WriteLine("Delete was done successfully");

            Console.WriteLine("Please insert id of the book for select");
            int bookId3 = Convert.ToInt32(Console.ReadLine());
            SqlParameter bookParameter3 = new SqlParameter();
            bookParameter3.Value = bookId3;
            bookParameter3.ParameterName = "bookId";
            SqlCommand dbCommand = new SqlCommand();
            dbCommand.Connection = connection;
            string selectStatement = "SELECT BookId, Title, PublisherId, Year, Price from Book where BookId=@bookId";
            dbCommand.CommandText = selectStatement;
            dbCommand.Parameters.Add(bookParameter3);
            SqlDataReader reader = dbCommand.ExecuteReader();
            Console.WriteLine("Selected book:");
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    string s = $"{reader[0]},{reader[1]}, {reader[2]}, {reader[3]}, {reader[4]}";
                    Console.WriteLine(s);
                }
            }
          
            reader.Close();

            Console.ReadKey();
        }
    }
}
