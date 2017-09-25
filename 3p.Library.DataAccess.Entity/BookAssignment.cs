using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataAccess.Entity
{
    public class BookAssignment: EntityBase
    {
        public int BookId { get; set; }
        public int StudentId { get; set; }
        public DateTime TakenDate { get; set; }
        public DateTime ExpectedReturnedDate { get; set; }
        public DateTime? ReturnedDate { get; set; }

        //Navigation properties
        //public virtual Book Book { get; set; }
        //public virtual Student Student { get; set; }

    }
}
