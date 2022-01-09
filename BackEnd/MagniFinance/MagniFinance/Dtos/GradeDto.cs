using MagniFinance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinance.Dtos
{
    public class GradeDto
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public Teacher teacher { get; set; }
        public int CoursesId { get; set; }
        public IEnumerable<Students> students { get; set; }
        [NotMapped]
        public float grade { get; set; }
    }
}
