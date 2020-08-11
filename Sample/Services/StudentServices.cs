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
    public class StudentServices : IStudentServices
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        
        public StudentServices(SampleContext context, ILogger<StudentServices> logger)
        {
            _logger = logger;
            _unitOfWork = new UnitOfWork(context);

        }

        public async Task AddStudent(StudentDTO studentModel)
        {
            try
            {
                var classroom = await _unitOfWork.ClassroomRepository.GetAll()
                    .Where(c => c.ClassroomId == studentModel.ClassroomId)
                    .FirstOrDefaultAsync();

                if (classroom == null)
                {
                    throw new Exception("Classroom not found.");
                }

                var student = new Student()
                {
                    Address = studentModel.Address,
                    ClassroomId = studentModel.ClassroomId,
                    Name = studentModel.Name,
                    RegsisteredDate = DateTime.Now,
                };
                _unitOfWork.StudentRepository.Add(student);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }

        public async Task EditStudent(Student studentModel)
        {
            try
            {
                var student = await _unitOfWork.StudentRepository.GetAll()
                    .Where(s => s.StudentId == studentModel.StudentId)
                    .FirstOrDefaultAsync();
                if (student == null)
                {
                    throw new Exception("Student not found.");
                }
                var classroom = await _unitOfWork.ClassroomRepository.GetAll()
                    .Where(c => c.ClassroomId == studentModel.ClassroomId)
                    .FirstOrDefaultAsync();

                if (classroom == null)
                {
                    throw new Exception("Classroom not found.");
                }

                student.Name = studentModel.Name;
                student.Address = studentModel.Address;
                student.ClassroomId = studentModel.ClassroomId;

                _unitOfWork.StudentRepository.Edit(student);
                await _unitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }

        public async Task<List<Student>> GetStudentByClassroomId(Guid id)
        {
            try
            {
                var classroom = await _unitOfWork.ClassroomRepository.GetAll()
                    .Where(c => c.ClassroomId == id)
                    .FirstOrDefaultAsync();

                if (classroom == null)
                {
                    throw new Exception("Classroom not found.");
                }

                var result = await _unitOfWork.StudentRepository.GetAll()
                    .Where(s => s.ClassroomId == id)
                    .ToListAsync();

                return result;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }

        public async Task<Student> GetStudentById(Guid id)
        {
            try
            {

                var student = await _unitOfWork.StudentRepository.GetAll()
                    .Where(s => s.StudentId == id)
                    .FirstOrDefaultAsync();

                if (student == null)
                {
                    throw new Exception("Student not found.");
                }

                return student;
            }
            catch(Exception e)
            {
                _logger.LogError(e.Message, e);
                throw e;
            }
        }
    }
}
