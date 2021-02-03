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
    public class SubjectController : ControllerBase
    {
        private readonly ISubjectService _ISubjectService;

        public SubjectController(ISubjectService iSubjectService)
        {
            _ISubjectService = iSubjectService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _ISubjectService.Get();
            return Ok(result);
        }

        [HttpGet("{SubjectID:int}")]
        public async Task<IActionResult> GetStudent(int SubjectID)
        {
            var result = await _ISubjectService.GetSubject(SubjectID);
            return Ok(result);
        }

        [HttpPost("Save")]
        public async Task<IActionResult> Save([FromBody] SaveSubjectRequest request)
        {
            if (request == null)
            {
                return BadRequest();
            }

            try
            {
                var subject = new SubjectDTO()
                {
                    SubjectID = request.SubjectID,
                    SubjectName = request.SubjectName
                };

                var result = await _ISubjectService.Save(subject);
                return Ok(result);
            }
            catch
            {
                return StatusCode(500);
            }
        }

        [HttpGet("Delete/{SubjectID:int}")]
        public async Task<IActionResult> Delete(int SubjectID)
        {
            var result = await _ISubjectService.Delete(SubjectID);
            return Ok(result);
        }
    }
}
