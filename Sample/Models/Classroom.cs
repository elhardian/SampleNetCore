using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Models
{
    public class Classroom
    {
        [Key]
        public Guid ClassroomId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
