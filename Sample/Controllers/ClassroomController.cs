using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sample.DTOs;
using Sample.Interfaces;

namespace Sample.Controllers
{
    [Route("api/classroom")]
    [ApiController]
    public class ClassroomController : ControllerBase
    {
        private readonly IClassroomServices _classroomServices;

        public ClassroomController(IClassroomServices classroomServices)
        {
            _classroomServices = classroomServices;
        }

        // contoh request URL http://localhost:5000/api/classroom/create dengan method POST
        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> CreateClassroom(ClassroomDTO classroomModel)
        {
            try
            {
                await _classroomServices.CreateClassroom(classroomModel);
                return Ok();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetClassrooms()
        {
            try
            {
                var result = await _classroomServices.GetClassrooms();
                return Ok(result);
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
