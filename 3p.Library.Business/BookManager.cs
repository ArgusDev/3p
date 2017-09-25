using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using _3p.Library.DataAccess.Entity;
using _3p.Library.DataContract.Book;
using _3p.Library.DataContract.Book.Criteria;
using _3p.Library.DataContract.Interface;

namespace _3p.Library.Business
{
    public class BookManager: IBookManager
    {
        private const int DEFAULT_BOOK_ASSIGNEMENT_DAYS = 30;

        private readonly IEntityDbContext _entityDbContext;

        public BookManager(IEntityDbContext entityDbContext)
        {
            _entityDbContext = entityDbContext;
        }

        public IEnumerable<BookInfoDto> GetAllBooksInfo()
        {
            return _entityDbContext.Books.Select(
                b => new BookInfoDto {BookDescription = $"'{b.Title}' by {b.Authors}"});
        }

        public IEnumerable<OverdueBookInfoDto> GetOverdueBooks()
        {
            return _entityDbContext.BookAssignments
                .Where(ba => ba.ExpectedReturnedDate < DateTime.Today && ba.ReturnedDate == null)
                .Join(_entityDbContext.Books, ba => ba.BookId, b => b.Id, (ba, b) => new { BookAssignment = ba, Book = b})
                .Join(_entityDbContext.Students, j => j.BookAssignment.StudentId, s => s.Id, (ba, s) => new { BookAssignment = ba.BookAssignment, Book = ba.Book, Student = s})
                .Select(
                    j => new OverdueBookInfoDto
                    {
                        BookId = j.Book.Id,
                        BookDescription = $"'{j.Book.Title}' by {j.Book.Authors}",
                        TakenByStudentId = j.Student.Id,
                        TakenByStudentName = $"{j.Student.FirstName} {j.Student.LastName}",
                        ExpectedReturnDate = j.BookAssignment.ExpectedReturnedDate
                    });
        }

        public void AssignBook(AssignBookCriteriaDto assignBookCriteriaDto)
        {
            if (assignBookCriteriaDto == null)
                throw new ArgumentNullException();

            if (_entityDbContext.BookAssignments.Any(ba => ba.BookId == assignBookCriteriaDto.BookId && ba.ReturnedDate == null))
                throw new DataException("This book is already taken.");

            _entityDbContext.BookAssignments.Add(
                new BookAssignment
                {
                    BookId = assignBookCriteriaDto.BookId,
                    StudentId = assignBookCriteriaDto.StudentId,
                    TakenDate = DateTime.Today,
                    ExpectedReturnedDate = DateTime.Today.AddDays(DEFAULT_BOOK_ASSIGNEMENT_DAYS)
                });

            _entityDbContext.SaveChanges();
        }

        public void ExtendExpectedReturnDate(ExtendExpectedReturnDateCriteriaDto extendExpectedReturnDateDto)
        {
            if (extendExpectedReturnDateDto == null)
                throw new ArgumentNullException();

            BookAssignment bookAssignment =
                _entityDbContext.BookAssignments.SingleOrDefault(ba => ba.Id == extendExpectedReturnDateDto.BookAssignementId);

            if (bookAssignment == null)
                throw new DataException($"BookAssignments with id '{extendExpectedReturnDateDto.BookAssignementId}' does not exist");

            if (bookAssignment.ReturnedDate != null)
                throw new DataException("This book is already returned.");

            bookAssignment.ExpectedReturnedDate = extendExpectedReturnDateDto.ExpectedReturnDate;

            _entityDbContext.SaveChanges();
        }
    }
}
