using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinance.Models
{
    public class Grades
    {
        [Key]

        public int id { get; set; }

        public int subjectid { get; set; }
        public int studentid { get; set; }
        public float grade { get; set; }
    }
}
