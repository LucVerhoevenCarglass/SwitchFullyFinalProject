using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.JobApplications;
using Swintake.infrastructure.Exceptions;
using Swintake.services.JobApplications;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobApplicationsController : ControllerBase
    {
        private readonly IJobApplicationService _jobApplicationService;
        private readonly JobApplicationMapper _jobApplicationMapper;

        public JobApplicationsController(IJobApplicationService jobApplicationService, JobApplicationMapper jobApplicationMapper)
        {
            _jobApplicationService = jobApplicationService;
            _jobApplicationMapper = jobApplicationMapper;
        }

        [HttpPost]
        [Authorize]
        public ActionResult<JobApplicationDto> CreateJobApplication([FromBody] CreateJobApplicationDto jobApplicationDto)
        {
            var newJobApplication = _jobApplicationMapper.ToDto(
                _jobApplicationService.AddJobApplication(
                    _jobApplicationMapper.ToNewDomain(jobApplicationDto)));

            return Created($"api/jobapplication/{newJobApplication.Id}", newJobApplication);
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<JobApplicationDto> GetById(string id)
        {
            try
            {
                var candidate = _jobApplicationService.GetCandidateById(id);
                return _jobApplicationMapper.ToDto(candidate);
            }
            catch (EntityNotValidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}