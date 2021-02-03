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
    public class StudentRepository
    {
        public async Task<List<StudentDTO>> Get()
        {
            var ctx = new DatabaseContext();

            var students = await ctx.Students
                .Select(s => new StudentDTO()
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    DateOfBirth = s.DateOfBirth,
                    StartYear = s.StartYear,
                    Address = new AddressDTO()
                    {
                        AddressID = s.Address.AddressID,
                        AddressLine1 = s.Address.AddressLine1,
                        AddressLine2 = s.Address.AddressLine2,
                        City = s.Address.City,
                        Province = s.Address.Province,
                        PostalCode = s.Address.PostalCode,
                    },
                    Guardian = new GuardianDTO()
                    {
                        FirstName = s.Guardian.FirstName,
                        LastName = s.Guardian.LastName
                    }
                }).ToListAsync();
            return students;
        }

        public async Task<StudentDTO> GetStudent(int StudentID)
        {
            var ctx = new DatabaseContext();

            var student = await ctx.Students
                .Where(s => s.StudentID == StudentID)
                .Select(s => new StudentDTO()
                {
                    StudentID = s.StudentID,
                    FirstName = s.FirstName,
                    LastName = s.LastName,
                    DateOfBirth = s.DateOfBirth,
                    StartYear = s.StartYear,
                    Address = new AddressDTO()
                    {
                        AddressID = s.Address.AddressID,
                        AddressLine1 = s.Address.AddressLine1,
                        AddressLine2 = s.Address.AddressLine2,
                        City = s.Address.City,
                        Province = s.Address.Province,
                        PostalCode = s.Address.PostalCode,
                    },
                    Guardian = new GuardianDTO()
                    {
                        FirstName = s.Guardian.FirstName,
                        LastName = s.Guardian.LastName
                    }
                }).FirstOrDefaultAsync();
            return student;
        }

        public async Task<List<SubjectDTO>> GetSubjects(int StudentID)
        {
            var ctx = new DatabaseContext();

            var subjects = await ctx.Students.Where(student => student.StudentID == StudentID)
                .SelectMany(student => student.Subjects,
                (student, subject) => new SubjectDTO
                {
                    SubjectID = subject.SubjectID,
                    SubjectName = subject.SubjectName
                }).ToListAsync();
            return subjects;
        }

        public async Task<MessageResult> Save(StudentDTO request)
        {
            var result = new MessageResult();

            try
            {
                var ctx = new DatabaseContext();

                var address = new Address();
                var guardian = new Guardian();

                var student = ctx.Students.SingleOrDefault(s => s.StudentID == request.StudentID);

                // edit/add address
                if (student != null && student.Address != null)
                {
                    address.AddressLine1 = request.Address.AddressLine1;
                    address.AddressLine2 = request.Address.AddressLine2;
                    address.City = request.Address.City;
                    address.Province = request.Address.Province;
                    address.PostalCode = request.Address.PostalCode;
                }
                else
                {
                    address = new Address()
                    {
                        AddressLine1 = request.Address.AddressLine1,
                        AddressLine2 = request.Address.AddressLine2,
                        City = request.Address.City,
                        Province = request.Address.Province,
                        PostalCode = request.Address.PostalCode
                    };
                }

                // edit/add guardian
                if (student != null && student.Guardian != null)
                {
                    guardian.FirstName = request.Guardian.FirstName;
                    guardian.LastName = request.Guardian.LastName;
                }
                else
                {
                    guardian = new Guardian()
                    {
                        FirstName = request.Guardian.FirstName,
                        LastName = request.Guardian.LastName
                    };
                }

                if (student != null)
                {
                    student.FirstName = request.FirstName;
                    student.LastName = request.LastName;
                    student.DateOfBirth = request.DateOfBirth;
                    student.StartYear = request.StartYear;
                    student.Address = address;
                    student.Guardian = guardian;
                }
                else
                {
                    ctx.Students.Add(new Student()
                    {
                        FirstName = request.FirstName,
                        LastName = request.LastName,
                        DateOfBirth = request.DateOfBirth,
                        StartYear = request.StartYear,
                        Address = address,
                        Guardian = guardian
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

        public async Task<MessageResult> Delete(int StudentID)
        {
            var result = new MessageResult();

            try
            {
                var ctx = new DatabaseContext();

                var student = ctx.Students.SingleOrDefault(s => s.StudentID == StudentID);
                var address = ctx.Addresses.SingleOrDefault(a => a.AddressID == student.Address.AddressID);
                var guardian = ctx.Guardians.SingleOrDefault(g => g.GuardianID == student.Guardian.GuardianID);

                ctx.Students.Remove(student);
                ctx.Addresses.Remove(address);
                ctx.Guardians.Remove(guardian);

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

        public async Task<MessageResult> AddSubject(int StudentID, int SubjectID)
        {
            var result = new MessageResult();

            try
            {
                var ctx = new DatabaseContext();

                var student = new Student { StudentID = StudentID };
                ctx.Students.Add(student);
                ctx.Students.Attach(student);

                var subject = new Subject { SubjectID = SubjectID };
                ctx.Subjects.Add(subject);
                ctx.Subjects.Attach(subject);

                student.Subjects = new List<Subject>();
                student.Subjects.Add(subject);

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

        public async Task<MessageResult> DeleteSubject(int StudentID, int SubjectID)
        {
            var result = new MessageResult();

            try
            {
                var ctx = new DatabaseContext();

                var student = ctx.Students.Include(x => x.Subjects).Single(x => x.StudentID == StudentID);

                ctx.Students.Attach(student);
                var subjectToDelete = student.Subjects.Find(x => x.SubjectID == SubjectID);
                if (subjectToDelete != null)
                {
                    student.Subjects.Remove(subjectToDelete);
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
    }
}
