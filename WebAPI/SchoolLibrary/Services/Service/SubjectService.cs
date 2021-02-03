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
    public class SubjectService : ISubjectService
    {
        public async Task<List<SubjectDTO>> Get()
        {
            var repository = new SubjectRepository();
            return await repository.Get();
        }

        public async Task<SubjectDTO> GetSubject(int SubjectID)
        {
            var repository = new SubjectRepository();
            return await repository.GetSubject(SubjectID);
        }

        public async Task<MessageResult> Save(SubjectDTO subject)
        {
            var repository = new SubjectRepository();
            return await repository.Save(subject);
        }

        public async Task<MessageResult> Delete(int SubjectID)
        {
            var repository = new SubjectRepository();
            return await repository.Delete(SubjectID);
        }
    }
}
