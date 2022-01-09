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
    public class GradesController : Controller
    {
        private readonly ApplicationDbContext _context;


        public GradesController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("fetch/{id}")]
        public ActionResult<Subjects> GradesSubject(int id)
        {
            var subjects =  _context.subject
                .Include(u => u.students)
                .Include(u => u.teacher)
                .Where(x => x.id == id).ToList();
            foreach (Subjects subject in subjects)
            {
                foreach (Students student in subject.students)
                {
                    student.subjects = null;
                    var grade = _context.grade.Where(x => x.studentid == student.id && x.subjectid == subject.id).FirstOrDefault();
                    student.grade = grade.grade;
                }
            }
                        
            return Ok(subjects);
        }
        [HttpGet("Students/{id}")]
        public ActionResult<Subjects> GradesStudents(int id)
        {
            var students = _context.student
                .Include(u => u.subjects)
                .Where(x => x.id == id).ToList();
            foreach (Students student in students)
            {
                foreach (Subjects subject in student.subjects)
                {
                    subject.students = null;
                    var grade = _context.grade.Where(x => x.studentid == id && x.subjectid == subject.id).FirstOrDefault();
                    subject.grade = grade.grade;
                }
            }

            return Ok(students);
        }
        [HttpPost("Add")]
        public async Task<ActionResult<Grades>> Add(Grades data)
        {
            var grade = _context.grade.AddAsync(new Grades
            {
                subjectid = data.subjectid,
                studentid = data.studentid,
                grade = data.grade
            });
            var student = _context.student.Where(x => x.id == data.studentid).FirstOrDefault();
            student.grade = data.grade;
            await _context.SaveChangesAsync();
            
            return Ok(grade);
        }
        [HttpPut("Update")]
        public async Task<ActionResult<Grades>> Update(Grades data)
        {
            var grade = _context.grade.Where(x => x.studentid == data.studentid && x.subjectid == data.subjectid).FirstOrDefault();
            grade.grade = data.grade;
            var student = _context.student.Where(x => x.id == data.studentid).FirstOrDefault();
            student.grade = data.grade;
            

            await _context.SaveChangesAsync();
            return Ok(grade);
        }
   

    }
}
