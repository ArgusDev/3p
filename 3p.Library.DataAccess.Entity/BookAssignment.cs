using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataAccess.Entity
{
    public class BookAssignment: EntityBase
    {
        public virtual int BookId { get; set; }
        public virtual int StudentId { get; set; }
        public virtual DateTime TakenDate { get; set; }
        public virtual DateTime ExpectedReturnedDate { get; set; }
        public virtual DateTime? ReturnedDate { get; set; }

        //Navigation properties
        //public virtual Book Book { get; set; }
        //public virtual Student Student { get; set; }

    }
}
