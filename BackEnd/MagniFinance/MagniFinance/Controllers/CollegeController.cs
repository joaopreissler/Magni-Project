using MagniFinance.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MagniFinance.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinanceProject.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class CollegeController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
       

        public CollegeController(ApplicationDbContext context)
        {
            _context = context;
            


        }
        [HttpGet]
        public async Task<IReadOnlyList<College>> GetAll()
        {
            var colleges = await _context.college
                .Include(c => c.courses)
                .ThenInclude(c => c.subjects)
                .ToListAsync();

          
            return colleges;
        }

        [HttpGet("{id}")]
        public async Task<College> Getone(int id)
        {
            var college = await _context.college.Where(x => x.id == id)
                .Include(c => c.courses)
                .ThenInclude(c => c.subjects)
                 .FirstOrDefaultAsync();
            return college;
        }


        [HttpPost("Add")]
        public async Task<ActionResult<IReadOnlyList<College>>> AddCollege(College college)
        {
            if (college == null || college.name == null) return BadRequest("College can not be null!");
            
            _context.college.Add(college);
            await _context.SaveChangesAsync();
            return Ok("College added");
        }
        [HttpPut("Update")]
        public async Task<ActionResult<IReadOnlyList<College>>> Update(College college)
        {
            if (college == null) return BadRequest("College can not be null!");
            var modified = await _context.college.Where(x => x.id == college.id).FirstOrDefaultAsync();
            modified.name = college.name; 
            await _context.SaveChangesAsync();
            return Ok("College Updated");
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<IReadOnlyList<College>>> Delete(int id)
        {
            var modified = await _context.college.Where(x => x.id == id).FirstOrDefaultAsync();
            _context.college.Remove(modified);
             await _context.SaveChangesAsync();
            return Ok("College Deleted");
        }
    }
}
