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
    public interface IStudentService
    {
        Task<List<StudentDTO>> Get();

        Task<StudentDTO> GetStudent(int StudentID);

        Task<List<SubjectDTO>> GetSubjects(int StudentID);

        Task<MessageResult> Save(StudentDTO student);

        Task<MessageResult> Delete(int StudentID);

        Task<MessageResult> AddSubject(int StudentID, int SubjectID);

        Task<MessageResult> DeleteSubject(int StudentID, int SubjectID);
    }
}
