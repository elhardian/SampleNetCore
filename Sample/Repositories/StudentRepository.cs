using Microsoft.EntityFrameworkCore;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}
