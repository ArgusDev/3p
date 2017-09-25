using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataContract.Book
{
    public class OverdueBookInfoDto : Dto
    {
        public int BookAssignementId { get; set; }
        public int BookId { get; set; }
        public string BookDescription { get; set; }

        public int TakenByStudentId { get; set; }
        public string TakenByStudentName { get; set; }

        public DateTime ExpectedReturnDate { get; set; }
    }
}
