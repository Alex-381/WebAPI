using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibrary.Domain.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StartYear { get; set; }
        public List<Subject> Subjects { get; set; }
        public virtual Address Address { get; set; }
        public virtual Guardian Guardian { get; set; }
    }
}
