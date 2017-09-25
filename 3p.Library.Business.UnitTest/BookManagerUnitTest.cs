using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using _3p.Library.DataContract.Interface;
using _3p.Library.Business;
using _3p.Library.DataAccess.Mock;
using _3p.Library.DataContract.Book;
using _3p.Library.DataContract.Book.Criteria;

namespace _3p.Library.Business.UnitTest
{
    [TestClass]
    public class BookManagerUnitTest
    {
        [TestMethod]
        public void GetAllBooksInfo_Should_Return_3_Books()
        {
            var bookManger = new BookManager(new EntityDbContext());

            IEnumerable<BookInfoDto> allBooks = bookManger.GetAllBooksInfo();

            Assert.IsNotNull(allBooks);
            Assert.AreEqual(3, allBooks.Count());
        }

        [TestMethod]
        public void GetOverdueBooks_Should_Return_1_Book()
        {
            var bookManger = new BookManager(new EntityDbContext());

            IEnumerable<OverdueBookInfoDto> overdueBooks = bookManger.GetOverdueBooks();

            Assert.IsNotNull(overdueBooks);
            Assert.AreEqual(1, overdueBooks.Count());
        }

        [TestMethod]
        public void AssignBook_Should_Add_BookAssignment()
        {
            var dbContext = new EntityDbContext();
            var bookManger = new BookManager(dbContext);
            int existingBookAssignmentsCount = dbContext.BookAssignments.Count;

            bookManger.AssignBook(
                new AssignBookCriteriaDto
                {
                    BookId = 3,
                    StudentId = 3
                });

            Assert.AreEqual(existingBookAssignmentsCount + 1, dbContext.BookAssignments.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(DataException), "This book is already taken.")]
        public void AssignBook_Should_Not_Add_BookAssignment_For_Assigned_Book()
        {
            var dbContext = new EntityDbContext();
            var bookManger = new BookManager(dbContext);

            bookManger.AssignBook(
                new AssignBookCriteriaDto
                {
                    BookId = 2,
                    StudentId = 3
                });
        }

        [TestMethod]
        public void ExtendExpectedReturnDate_Should_Extend_Date()
        {
            var dbContext = new EntityDbContext();
            var bookManger = new BookManager(dbContext);

            int bookAssignementId = 3;
            DateTime newReturnDate = DateTime.Now.AddDays(30);

            bookManger.ExtendExpectedReturnDate(
                new ExtendExpectedReturnDateCriteriaDto
                {
                    BookAssignementId = bookAssignementId,
                    ExpectedReturnDate = newReturnDate
                });

            DateTime updatedReturnDate = dbContext.BookAssignments.Single(a => a.Id == bookAssignementId).ExpectedReturnedDate;

            Assert.AreEqual(newReturnDate, updatedReturnDate);
        }

        [TestMethod]
        [ExpectedException(typeof(DataException), "This book is already returned.")]
        public void ExtendExpectedReturnDate_Should_Not_Extend_Date_For_Returned_Book()
        {
            var dbContext = new EntityDbContext();
            var bookManger = new BookManager(dbContext);

            int bookAssignementId = 2;
            DateTime newReturnDate = DateTime.Now.AddDays(30);

            bookManger.ExtendExpectedReturnDate(
                new ExtendExpectedReturnDateCriteriaDto
                {
                    BookAssignementId = bookAssignementId,
                    ExpectedReturnDate = newReturnDate
                });
        }

    }
}
