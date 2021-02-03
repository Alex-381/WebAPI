using SchoolLibrary.Domain.Models;
using SchoolLibrary.Domain.Results;
using SchoolLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Services.Interface
{
    public interface ISubjectService
    {
        Task<List<SubjectDTO>> Get();

        Task<SubjectDTO> GetSubject(int SubjectID);

        Task<MessageResult> Save(SubjectDTO subject);

        Task<MessageResult> Delete(int SubjectID);
    }
}
