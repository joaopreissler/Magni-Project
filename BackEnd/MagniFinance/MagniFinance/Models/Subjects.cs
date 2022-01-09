using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinance.Models
{
    public class Subjects
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