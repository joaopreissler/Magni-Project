using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinance.Models
{
    public class Courses
    {
        [Key]
        public int Id { get; set; }
        public string name { get; set; }

        public int Collegeid { get; set; }
        public IEnumerable<Subjects> subjects {get; set;}
    }
}
