using SchoolLibrary.Domain.Context;
using SchoolLibrary.Domain.Models;
using SchoolLibrary.Domain.Results;
using SchoolLibrary.DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolLibrary.Domain.Repository
{
    public class SubjectRepository
    {
        public async Task<List<SubjectDTO>> Get()
        {
            var ctx = new DatabaseContext();

            var result = await ctx.Subjects
                .Select(s => new SubjectDTO()
                {
                    SubjectID = s.SubjectID,
                    SubjectName = s.SubjectName
                }).ToListAsync();
            return result;
        }

        public async Task<SubjectDTO> GetSubject(int SubjectID)
        {
            var ctx = new DatabaseContext();

            var subject = await ctx.Subjects
                .Where(s => s.SubjectID == SubjectID)
                .Select(s => new SubjectDTO()
                {
                    SubjectID = s.SubjectID,
                    SubjectName = s.SubjectName
                }).FirstOrDefaultAsync();
            return subject;
        }

        public async Task<MessageResult> Save(SubjectDTO request)
        {
            var result = new MessageResult();

            try
            {
                var ctx = new DatabaseContext();

                var subject = ctx.Subjects.SingleOrDefault(s => s.SubjectID == request.SubjectID);
                if (subject != null)
                {
                    subject.SubjectName = request.SubjectName;
                }
                else
                {
                    ctx.Subjects.Add(new Subject()
                    {
                        SubjectName = request.SubjectName
                    });
                }
                await ctx.SaveChangesAsync();

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }

        public async Task<MessageResult> Delete(int SubjectID)
        {
            var result = new MessageResult();

            try
            {
                var ctx = new DatabaseContext();

                var subject = ctx.Subjects.SingleOrDefault(s => s.SubjectID == SubjectID);
                ctx.Subjects.Remove(subject);

                await ctx.SaveChangesAsync();

                result.IsSuccess = true;
            }
            catch (Exception ex)
            {
                result.IsSuccess = false;
                result.ErrorMessage = ex.Message;
            }

            return result;
        }
    }
}
