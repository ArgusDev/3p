using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataContract.Book
{
    public class OverdueBookInfoDto : Dto
    {
        public virtual int BookAssignementId { get; set; }
        public virtual int BookId { get; set; }
        public virtual string BookDescription { get; set; }

        public virtual int TakenByStudentId { get; set; }
        public virtual string TakenByStudentName { get; set; }

        public virtual DateTime ExpectedReturnDate { get; set; }
    }
}
