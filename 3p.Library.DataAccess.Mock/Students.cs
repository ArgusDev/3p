using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3p.Library.DataAccess.Entity;

namespace _3p.Library.DataAccess.Mock
{
    public class Students
    {
        internal static ISet<Student> GetStudents()
        {
            return new HashSet<Student>
            {
                new Student {Id = 1, FirstName = "Tony", LastName = "Abbott"},
                new Student {Id = 2, FirstName = "Malcolm", LastName = "Turnbull"},
                new Student {Id = 3, FirstName = "John", LastName = "Howard" }
            };
        }
    }
}
