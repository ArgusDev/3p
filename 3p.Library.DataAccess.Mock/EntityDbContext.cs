using System.Collections.Generic;
using _3p.Library.DataAccess.Entity;

namespace _3p.Library.DataAccess.Mock
{
    public class EntityDbContext: IEntityDbContext
    {
        public virtual ISet<Book> Books { get; set; }
        public virtual ISet<Student> Students { get; set; }
        public virtual ISet<BookAssignment> BookAssignments { get; set; }

        public EntityDbContext()
        {
            Books = Mock.Books.GetBooks();
            Students = Mock.Students.GetStudents();
            BookAssignments = Mock.BookAssignments.GetBookAssignments();
        }

        public void SaveChanges()
        {
            //persist data
        }
    }
}
