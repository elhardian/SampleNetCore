using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.DTOs
{
    public class StudentDTO
    {
        public string Name { get; set; }

        public string Address { get; set; }

        public Guid ClassroomId { get; set; }
    }
}
