using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3p.Library.DataContract.Book;
using _3p.Library.DataContract.Book.Criteria;

namespace _3p.Library.DataContract.Interface
{
    public interface IBookManager
    {
        IEnumerable<BookInfoDto> GetAllBooksInfo();
        IEnumerable<OverdueBookInfoDto> GetOverdueBooks();
        void AssignBook(AssignBookCriteriaDto assignBookCriteriaDto);
        void ExtendExpectedReturnDate(ExtendExpectedReturnDateCriteriaDto extendExpectedReturnDateDto);
    }
}
