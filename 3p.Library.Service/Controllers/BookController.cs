using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using _3p.Library.DataContract.Book;
using _3p.Library.DataContract.Book.Criteria;
using _3p.Library.DataContract.Interface;

namespace _3p.Library.Service.Controllers
{
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IBookManager _bookManager;

        public BookController(IBookManager bookManager)
        {
            _bookManager = bookManager;
        }

        /// <summary>
        /// Gets list of all books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IEnumerable<BookInfoDto> Get()
        {
            return _bookManager.GetAllBooksInfo();
        }

        /// <summary>
        /// Gets list of overdue books
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("[action]")]
        public IEnumerable<OverdueBookInfoDto> GetOverdueBooks()
        {
            return _bookManager.GetOverdueBooks();
        }

        /// <summary>
        /// Assign a book to a student
        /// </summary>
        [HttpPost]
        [Route("[action]")]
        public void AssignBook([FromBody]AssignBookCriteriaDto assignBookCriteriaDto)
        {
            _bookManager.AssignBook(assignBookCriteriaDto);
        }

        [HttpPost]
        [Route("[action]")]
        public void ExtendExpectedReturnDate([FromBody]ExtendExpectedReturnDateCriteriaDto extendExpectedReturnDateCriteriaDto)
        {
            _bookManager.ExtendExpectedReturnDate(extendExpectedReturnDateCriteriaDto);
        }
    }
}
