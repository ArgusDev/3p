using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataAccess.Entity
{
    public class Book: EntityBase
    {
        public string Authors { get; set; }
        public string Title { get; set; }
    }
}
