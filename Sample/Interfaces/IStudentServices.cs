using Sample.DTOs;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Interfaces
{
    public interface IStudentServices
    {
        Task<Student> GetStudentById(Guid id);
        Task<List<Student>> GetStudentByClassroomId(Guid id);
        Task AddStudent(StudentDTO studentModel);
        Task EditStudent(Student studentModel);
    }
}
