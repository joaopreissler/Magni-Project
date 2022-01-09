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
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext _context;


        public StudentsController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<Students>> GetAll()
        {
            var students = await _context.student
                .Include(u => u.subjects)
                .ToListAsync();
            
            foreach (Students student in students)
            {
                float[] average = new float[student.subjects.Count()];
                var control = 0;
                foreach (Subjects subject in student.subjects)
                {
                    subject.students = null;
                    var grade = _context.grade.Where(x => x.studentid == student.id && x.subjectid == subject.id).FirstOrDefault();
                    subject.grade = grade.grade;
                    average[control]= grade.grade;
                    control++;
                }
                if (student.subjects.Count() > 0)
                {
                    var result = average.Sum() / student.subjects.Count();
                    student.grade = result;
                }
                else
                {
                    var result = 0;
                    student.grade = result;
                }
                   
                
            }
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Students>> Getone(int id)
        {
            var students = await _context.student
                .Include(u => u.subjects)
                .Where(x => x.id == id).FirstOrDefaultAsync();

            foreach (Subjects subject in students.subjects) {
                subject.students = null;
            }
            return students;
        }

        [HttpPost("subjects/Add")]
        public async Task<ActionResult> AddStudentSubject(StudentSubjectDto data)
        {
            var student =  new Students
            {
                name = data.name,
                birthday = data.birthday,
                registration = data.registration,
                grade = data.grade

            };
            var subject = await _context.subject.Where(x => x.id == data.subjectId).ToListAsync();
            student.subjects = subject;
            _context.student.Add(student);
            
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost("Add")]
        public async Task<ActionResult<IReadOnlyList<Students>>> AddStudent(Students students)
        {
            if (students == null) return BadRequest("Course can not be null!");

            _context.student.Add(new Students
            {
                name = students.name,
                registration = students.registration,
                birthday = students.birthday,
                grade = students.grade
                
            });
            await _context.SaveChangesAsync();
            return Ok("Student added");
        }
        [HttpPost("Enroll")]
        public async Task<ActionResult<IReadOnlyList<SubjectStudentDto>>> EnrollStudent(SubjectStudentDto data)
        {   
            var subject = await _context.subject.Where(x => x.id == data.subjectId).FirstOrDefaultAsync();
            var student = await _context.student.Where(x => x.id == data.studentId).ToListAsync();
            subject.students = student;
            _context.grade.Add(new Grades
            {
                studentid = data.studentId,
                subjectid = data.subjectId,
                grade = 0
            });
            await _context.SaveChangesAsync();
            return Ok("Student added");
        }
        [HttpPut("Update")]
        public async Task<ActionResult<IReadOnlyList<Students>>> Update(Students students)
        {
            if (students == null) return BadRequest("College can not be null!");
            var modified = await _context.student.Where(x => x.id == students.id).FirstOrDefaultAsync();
            modified.name = students.name;
            modified.birthday = students.birthday;
            modified.registration = students.registration;
            modified.grade = students.grade;
            await _context.SaveChangesAsync();
            return Ok("Student Credentials Updated");
        }
        [HttpDelete("Delete")]
        public async Task<ActionResult<IReadOnlyList<Students>>> Delete(Students students)
        {
            if (students == null) return BadRequest("College can not be null!");
            var modified = await _context.student.Where(x => x.id == students.id).FirstOrDefaultAsync();
            modified.name = students.name;
            modified.birthday = students.birthday;
            modified.registration = students.registration;
            modified.grade = students.grade;
            await _context.SaveChangesAsync();
            return Ok("Student Credentials Updated");
        }


    }
}
