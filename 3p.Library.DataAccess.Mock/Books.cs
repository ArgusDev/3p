using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3p.Library.DataAccess.Entity;

namespace _3p.Library.DataAccess.Mock
{
    public class Books
    {
        internal static ISet<Book> GetBooks()
        {
            return new HashSet<Book>
            {
                new Book {Id = 1, Title = "Entity Framework Core Cookbook", Authors = "Ricardo Peres" },
                new Book {Id = 2, Title = "Domain-driven design", Authors = "Eric J. Evans" },
                new Book {Id = 3, Title = "Programming ASP.NET Core", Authors = "Dino Esposito" }
            };
        }
    }
}
