using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameworkExample
{
    class Program
    {
        static void Main(string[] args)
        {
            LibraryMonicaEntities1 library = new LibraryMonicaEntities1();


            var books = library.Books.ToList();
            foreach(var book in books)
            {
                Console.WriteLine(book.Title);
            }

            var query = library.Books.ToList().Where(b => b.Price > 10);

            foreach(var book in query)
            {
                Console.WriteLine(book.Title + " has the price of: " + book.Price);
            }
                       

            Console.ReadKey();
        }
    }
}
