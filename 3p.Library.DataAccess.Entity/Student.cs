using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3p.Library.DataAccess.Entity
{
    public class Student: EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
