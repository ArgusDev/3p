using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataAccess.Entity
{
    public interface IEntityDbContext
    {
        ISet<Book> Books { get; set; }
        ISet<Student> Students { get; set; }
        ISet<BookAssignment> BookAssignments { get; set; }

        void SaveChanges();
    }
}
