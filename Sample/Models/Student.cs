using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Student
    {
        public Guid StudentId { get; set; }

        public string Name { get; set; }

        public DateTime RegsisteredDate { get; set; }

        public string Address { get; set; }

        public Guid ClassroomId { get; set; }
        public Classroom Classroom { get; set; }
    }
}
