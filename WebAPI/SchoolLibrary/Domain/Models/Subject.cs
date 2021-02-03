using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibrary.Domain.Models
{
    public class Subject
    {
        public int SubjectID { get; set; }
        [Required]
        public string SubjectName { get; set; }
        public List<Student> Students { get; set; }
    }
}
