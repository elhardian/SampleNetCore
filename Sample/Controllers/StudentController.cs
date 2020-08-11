using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOs;
using Sample.Interfaces;
using Sample.Models;

namespace Sample.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentServices _studentServices;
        public StudentController(IStudentServices studentServices)
        {
            _studentServices = studentServices;
        }

        [HttpPost]
        public async Task<IActionResult> AddNewstudent([FromBody]StudentDTO studentModel)
        {
            try
            {
                await _studentServices.AddStudent(studentModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        //Contoh Request URL http://localhost:5000/api/student/iweiwe-asodosd-ajsds-a9912a
        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetStudentById(Guid id)
        {
            try
            {
                var result = await _studentServices.GetStudentById(id);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        // contoh request URL  http://localhost:5000/api/student?id=iweiwe-asodosd-ajsds-a9912a
        [HttpGet]
        public async Task<IActionResult> GetStudentByClassroom(Guid? id)
        {
            try
            {
                if(id == null)
                {
                    throw new Exception("classroom cannot be null");
                }
                var result =await _studentServices.GetStudentByClassroomId(id.Value);
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(Student studentModel)
        {
            try
            {
                await _studentServices.EditStudent(studentModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
