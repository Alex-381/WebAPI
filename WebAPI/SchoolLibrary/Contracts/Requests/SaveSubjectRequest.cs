﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Contracts.Requests
{
    public class SaveSubjectRequest
    {
        public int SubjectID { get; set; }
        public string SubjectName { get; set; }
    }
}
