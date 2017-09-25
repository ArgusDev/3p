using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataContract.Book.Criteria
{
    public class AssignBookCriteriaDto: Dto
    {
        public virtual int BookId { get; set; }
        public virtual int StudentId { get; set; }
    }
}
