using MagniFinance.Data;
using MagniFinance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinance.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CourseController : ControllerBase
    {
        private readonly ApplicationDbContext _context;


        public CourseController(ApplicationDbContext context)
            {
                _context = context;



            }
            [HttpGet]
            public async Task<ActionResult<IReadOnlyList<Courses>>> GetAll()
            {
                var courses = await _context.course.Include(c => c.subjects)
                .ToListAsync();
                return courses;
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Courses>> Getone(int id)
            {
                var college = await _context.course.Where(x => x.Id == id).Include(c => c.subjects).FirstOrDefaultAsync();
                return college;
            }


            [HttpPost("Add")]
            public async Task<ActionResult<IReadOnlyList<Courses>>> AddCourse(Courses course)
            {
                if (course == null ) return BadRequest("Course can not be null!");

            _context.course.Add(new Courses
            {
                name = course.name,
                Collegeid = course.Collegeid
                
            });
                await _context.SaveChangesAsync();
                return Ok("Course added");
            }
            [HttpPut("Update")]
            public async Task<ActionResult<IReadOnlyList<Courses>>> Update(Courses course)
            {
                if (course == null) return BadRequest("College can not be null!");
                var modified = await _context.course.Where(x => x.Id == course.Id).FirstOrDefaultAsync();
                modified.name = course.name;
                await _context.SaveChangesAsync();
                return Ok("Course Updated");
            }
            [HttpDelete("Delete/{id}")]
            public async Task<ActionResult<IReadOnlyList<Courses>>> Delete(int id)
            {
                var modified = await _context.course.Where(x => x.Id == id).FirstOrDefaultAsync();
                _context.course.Remove(modified);
                await _context.SaveChangesAsync();
                return Ok("College Deleted");
            }
        }
    
}
