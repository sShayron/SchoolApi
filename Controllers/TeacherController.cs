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
    public class TeacherController : ControllerBase
    {
        public IRepository _repo { get; }

        public TeacherController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetTeachersAsync(true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }



        [HttpGet("{TeacherId}")]
        public async Task<IActionResult> GetById(int TeacherId)
        {
            try
            {
                var result = await _repo.GetTeacherAsyncById(TeacherId, true);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Save(Teacher model)
        {
            try
            {
                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/teacher/{model.Id}", model);
                }
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        [HttpPut("{TeacherId}")]
        public async Task<IActionResult> Update(int TeacherId, Teacher model)
        {
            try
            {
                var teacher = await _repo.GetTeacherAsyncById(TeacherId, false);

                if (teacher == null)
                {
                    return NotFound();
                }
                _repo.Update(model);

                if (await _repo.SaveChangesAsync())
                {
                    teacher = await _repo.GetTeacherAsyncById(TeacherId, true);
                    return Created($"/api/teacher/{model.Id}", teacher);
                }
                return Ok();
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpDelete("{TeacherId}")]
        public async Task<IActionResult> Delete(int TeacherId)
        {
            try
            {
                var teacher = await _repo.GetTeacherAsyncById(TeacherId, false);

                if (teacher == null)
                {
                    return NotFound();
                }

                _repo.Delete(teacher);

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