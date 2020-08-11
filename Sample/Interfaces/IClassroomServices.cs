using Sample.DTOs;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Interfaces
{
    public interface IClassroomServices
    {
        Task CreateClassroom(ClassroomDTO classroomModel);
        Task<List<Classroom>> GetClassrooms();
    }
}
