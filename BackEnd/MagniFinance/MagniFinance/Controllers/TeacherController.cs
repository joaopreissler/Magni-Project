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
    public class TeacherController : Controller
    {
        private readonly ApplicationDbContext _context;


        public TeacherController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Teacher>>> GetAll()
        {
            var courses = await _context.teacher.ToListAsync();
            return courses;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Teacher>> Getone(int id)
        {
            var teacher = await _context.teacher.Where(x => x.id == id).FirstOrDefaultAsync();
            return teacher;
        }
       

        [HttpPost("Add")]
        public async Task<ActionResult<IReadOnlyList<Students>>> AddStudent(Teacher teacher)
        {
            if (teacher == null) return BadRequest("Course can not be null!");

             _context.teacher.Add(new Teacher
            {
                name = teacher.name,
                birthday = teacher.birthday,
                salary = teacher.salary
            });
            await _context.SaveChangesAsync();
            var Subjects = await _context.subject.Where(x => x.id == teacher.subjectid).FirstOrDefaultAsync();
            var newteacher = await _context.teacher.Where(x => x.name == teacher.name).FirstOrDefaultAsync();
            Subjects.teacher = newteacher;
            await _context.SaveChangesAsync();
            return Ok("Teacher added");
        }
        [HttpPut("Update")]
        public async Task<ActionResult<IReadOnlyList<Teacher>>> Update(Teacher teacher)
        {
            if (teacher == null) return BadRequest("College can not be null!");
            var modified = await _context.teacher.Where(x => x.id == teacher.id).FirstOrDefaultAsync();
            modified.name = teacher.name;
            
            await _context.SaveChangesAsync();
            return Ok("Teacher Credentials Updated");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<IReadOnlyList<Teacher>>> Delete(int id)
        {
            var modified = await _context.teacher.Where(x => x.id == id).FirstOrDefaultAsync();
            _context.teacher.Remove(modified);
            await _context.SaveChangesAsync();
            return Ok("Teacher Deleted");
        }
    }
}
