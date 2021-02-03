using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Contracts.Requests
{
    public class SaveGuardianRequest
    {
        public int GuardianID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
