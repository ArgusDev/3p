using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3p.Library.DataAccess.Entity;

namespace _3p.Library.DataAccess.Mock
{
    public class BookAssignments
    {
        internal static ISet<BookAssignment> GetBookAssignments()
        {
            return new HashSet<BookAssignment>
            {
                //returned book
                new BookAssignment {Id = 1, BookId = 1, StudentId = 1, TakenDate = new DateTime(2017, 1, 1), ExpectedReturnedDate = new DateTime(2017, 2, 1), ReturnedDate = new DateTime(2017, 1, 31)},

                //returned overdue book
                new BookAssignment {Id = 2, BookId = 2, StudentId = 1, TakenDate = new DateTime(2017, 1, 1), ExpectedReturnedDate = new DateTime(2017, 2, 1), ReturnedDate = new DateTime(2017, 2, 4)},

                //overdue book
                new BookAssignment {Id = 3, BookId = 1, StudentId = 2, TakenDate = new DateTime(2017, 3, 1), ExpectedReturnedDate = new DateTime(2017, 4, 1), ReturnedDate = null},

                //taken but not overdue book
                new BookAssignment {Id = 4, BookId = 2, StudentId = 2, TakenDate = new DateTime(2017, 9, 1), ExpectedReturnedDate = DateTime.Now.AddDays(30), ReturnedDate = null}
            };
        }
    }
}
