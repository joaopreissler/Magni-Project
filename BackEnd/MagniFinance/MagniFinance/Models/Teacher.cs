using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MagniFinance.Models
{
    public class Teacher
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }
        public float salary { get; set; }
        [NotMapped]
        public int subjectid { get; set; }
    }
}