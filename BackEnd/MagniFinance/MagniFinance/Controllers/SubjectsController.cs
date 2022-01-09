using MagniFinance.Data;
using MagniFinance.Dtos;
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
    public class SubjectsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public SubjectsController(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<Subjects>> GetAll()
        {
            var subjects = await _context.subject.Include(u => u.students).Include(u => u.teacher).ToListAsync();

            foreach (Subjects subject in subjects)
            {
                foreach(Students student in subject.students)
                {
                    student.subjects = null;
                }
                
            }
            return Ok(subjects);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subjects>> Getone(int id)
        {
             var subjects = await _context.subject.Where(x => x.id == id).Include(u => u.students).Include(u => u.teacher).SingleAsync();

            foreach (Students student in subjects.students)
            {
                student.subjects = null;
            }
            return subjects;
        }
       
       [HttpPost("student/Add")]
        public async Task<ActionResult> Add(SubjectStudentDto data)
        {
            var subject = await _context.subject.Where(x => x.id == data.subjectId).FirstOrDefaultAsync();

            var student = await _context.student.Where(x => x.id == data.studentId).ToListAsync();
            subject.students = student;
            _context.subject.Update(subject);

            await _context.SaveChangesAsync();
            return Ok();
        }
        [HttpPost("Add")]
        public async Task<ActionResult<IReadOnlyList<College>>> AddCollege(Subjects subject)
        {
            if (subject == null || subject.name == null) return BadRequest("College can not be null!");

            _context.subject.Add(subject);
            await _context.SaveChangesAsync();
            return Ok("College added");
        }
        [HttpPost("AddTeacher")]
        public async Task<ActionResult<Teacher>> AddTeacher(Subjects subject)
        {
            if (subject.teacher != null)
            {
                var modified = await _context.subject.Where(x => x.id == subject.id).FirstOrDefaultAsync();
                modified.teacher = subject.teacher;

            }


            await _context.SaveChangesAsync();
            return Ok("Teacher added");
        }
        [HttpPut("Update")]
        public async Task<ActionResult<IReadOnlyList<Subjects>>> Update(Subjects subjects)
        {
            if (subjects == null) return BadRequest("College can not be null!");
            var modified = await _context.subject.Where(x => x.id == subjects.id).FirstOrDefaultAsync();
            modified.name = subjects.name;
            await _context.SaveChangesAsync();
            return Ok("Course Updated");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<IReadOnlyList<Subjects>>> Delete(int id)
        {
            var modified = await _context.subject.Where(x => x.id == id).FirstOrDefaultAsync();
            _context.subject.Remove(modified);
            await _context.SaveChangesAsync();
            return Ok("College Deleted");
        }
    }
}
