using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Sample.DTOs;
using Sample.Interfaces;
using Sample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sample.Services
{
    public class ClassroomServices : IClassroomServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public ClassroomServices(SampleContext context, ILogger<ClassroomServices> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(context);
        }

        public async Task CreateClassroom(ClassroomDTO classroomModel)
        {
            try
            {
                if(_unitOfWork.ClassroomRepository.IsExist(c => c.Name == classroomModel.Name))
                {
                    throw new Exception("Classroom already exists.");
                }
                var classroom = new Classroom()
                {
                    Description = classroomModel.Description,
                    Name = classroomModel.Name,
                };
                _unitOfWork.ClassroomRepository.Add(classroom);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }

        public async Task<List<Classroom>> GetClassrooms()
        {
            try
            {
                var result = await _unitOfWork.ClassroomRepository.GetAll()
                    .ToListAsync();
                return result;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }
    }
}
