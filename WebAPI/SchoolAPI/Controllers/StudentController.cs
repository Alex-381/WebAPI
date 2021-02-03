using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SchoolLibrary.Contracts.Requests;
using SchoolLibrary.Domain.Models;
using SchoolLibrary.DTO;
using SchoolLibrary.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _IStudentService;

        public StudentController(IStudentService iStudentService)
        {
            _IStudentService = iStudentService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _IStudentService.Get();
            return Ok(result);
        }

        [HttpGet("{StudentID:int}")]
        public async Task<IActionResult> GetStudent(int StudentID)
        {
            var result = await _IStudentService.GetStudent(StudentID);
            return Ok(result);
        }

        [HttpGet("Subjects/{StudentID:int}")]
        public async Task<IActionResult> GetSubjects(int StudentID)
        {
            var result = await _IStudentService.GetSubjects(StudentID);
            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveStudentRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var student = new StudentDTO()
                {
                    StudentID = request.StudentID,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateOfBirth = request.DateOfBirth,
                    StartYear = request.StartYear,
                    Address = new AddressDTO()
                    {
                        AddressID = request.Address.AddressID,
                        AddressLine1 = request.Address.AddressLine1,
                        AddressLine2 = request.Address.AddressLine2,
                        City = request.Address.City,
                        Province = request.Address.Province,
                        PostalCode = request.Address.PostalCode
                    },
                    Guardian = new GuardianDTO()
                    {
                        GuardianID = request.Guardian.GuardianID,
                        FirstName = request.Guardian.FirstName,
                        LastName = request.Guardian.LastName
                    }
                };

                var result = await _IStudentService.Save(student);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Delete/{StudentID:int}")]
        public async Task<IActionResult> Delete(int StudentID)
        {
            var result = await _IStudentService.Delete(StudentID);
            return Ok(result);
        }

        [HttpPost("AddSubject")]
        public async Task<IActionResult> AddSubject([FromBody] AddSubjectRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _IStudentService.AddSubject(request.StudentID, request.SubjectID);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpPost("DeleteSubject")]
        public async Task<IActionResult> DeleteSubject([FromBody] AddSubjectRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var result = await _IStudentService.DeleteSubject(request.StudentID, request.SubjectID);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }
    }
}
