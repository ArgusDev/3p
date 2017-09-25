using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataContract.Book.Criteria
{
    public class ExtendExpectedReturnDateCriteriaDto: Dto
    {
        public virtual int BookAssignementId { get; set; }
        public virtual DateTime ExpectedReturnDate { get; set; }
    }
}
