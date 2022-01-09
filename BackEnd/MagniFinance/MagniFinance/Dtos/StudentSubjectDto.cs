using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MagniFinance.Dtos
{
    public class StudentSubjectDto
    {
        public string name { get; set; }
        public int registration { get; set; }
        public string birthday { get; set; }
        public int grade { get; set; }
        public int subjectId { get; set; }
    }
}
