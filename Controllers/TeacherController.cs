using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SchoolApi.Controllers
{
    [Route("ap/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        public TeacherController()
        {

        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{ProfessorId}")]
        public IActionResult GetById()
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Save()
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Update()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}