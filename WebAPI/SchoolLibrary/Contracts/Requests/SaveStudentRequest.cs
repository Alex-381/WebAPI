using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Contracts.Requests
{
    public class SaveStudentRequest
    {
        public int StudentID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int StartYear { get; set; }
        public SaveAddressRequest Address { get; set; }
        public SaveGuardianRequest Guardian { get; set; }
    }
}
