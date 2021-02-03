using SchoolLibrary.Domain.Models;
using SchoolLibrary.Domain.Repository;
using SchoolLibrary.Domain.Results;
using SchoolLibrary.DTO;
using SchoolLibrary.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Services.Service
{
    public class StudentService : IStudentService
    {
        public async Task<List<StudentDTO>> Get()
        {
            var repository = new StudentRepository();
            return await repository.Get();
        }

        public async Task<StudentDTO> GetStudent(int StudentID)
        {
            var repository = new StudentRepository();
            return await repository.GetStudent(StudentID);
        }

        public async Task<List<SubjectDTO>> GetSubjects(int StudentID)
        {
            var repository = new StudentRepository();
            return await repository.GetSubjects(StudentID);
        }

        public async Task<MessageResult> Save(StudentDTO student)
        {
            var repository = new StudentRepository();
            return await repository.Save(student);
        }

        public async Task<MessageResult> Delete(int StudentID)
        {
            var repository = new StudentRepository();
            return await repository.Delete(StudentID);
        }

        public async Task<MessageResult> AddSubject(int StudentID, int SubjectID)
        {
            var repository = new StudentRepository();
            return await repository.AddSubject(StudentID, SubjectID);
        }

        public async Task<MessageResult> DeleteSubject(int StudentID, int SubjectID)
        {
            var repository = new StudentRepository();
            return await repository.DeleteSubject(StudentID, SubjectID);
        }
    }
}
