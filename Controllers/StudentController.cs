using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolApi.Data;
using SchoolApi.Models;

namespace SchoolApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        public IRepository _repo { get; }

        public StudentController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllStudentsAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{StudentId}")]
        public async Task<IActionResult> GetById(int StudentId)
        {
            try
            {
                var result = await _repo.GetStudentAsyncById(StudentId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("teacher/{TeacherId}")]
        public async Task<IActionResult> GetByTeacherId(int TeacherId)
        {
            try
            {
                var result = await _repo.GetStudentAsyncByTeacherId(TeacherId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpPost]
        public async Task<IActionResult> Save(Student model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/student/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        [HttpPut("{StudentId}")]
        public async Task<IActionResult> Update(int StudentId, Student model)
        {
            try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);

                if (student == null)
                {
                    return NotFound();
                }
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    student = await _repo.GetStudentAsyncById(StudentId, true);
                    return Created($"/api/student/{model.Id}", student);
                }
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{StudentId}")]
        public async Task<IActionResult> Delete(int StudentId)
        {
            try
            {
                var student = await _repo.GetStudentAsyncById(StudentId, false);

                if (student == null)
                {
                    return NotFound();
                }

                _repo.Delete(student);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }
    }
}