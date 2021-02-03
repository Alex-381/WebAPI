using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLibrary.Domain.Models
{
    public class Guardian
    {
        [ForeignKey("Student")]
        public int GuardianID { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual Student Student { get; set; }
    }
}
