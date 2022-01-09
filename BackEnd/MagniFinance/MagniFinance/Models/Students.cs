using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MagniFinance.Models
{
    public class Students
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string birthday { get; set; }

        public int registration { get; set; }
        public float grade { get; set; }
        public IEnumerable<Subjects> subjects { get; set; }
    }
}