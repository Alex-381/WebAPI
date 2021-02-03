using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Contracts.Requests
{
    public class AddSubjectRequest
    {
        public int StudentID { get; set; }
        public int SubjectID { get; set; }
    }
}
