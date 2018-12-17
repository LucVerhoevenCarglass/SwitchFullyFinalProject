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
    [Authorize]
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
        public ActionResult<JobApplicationDto> GetById(string id)
        {
            return _jobApplicationMapper.ToDto( _jobApplicationService.GetById(id));
        }

        [HttpPut]
        [Route("reject id:string")]
        public ActionResult RejectById(string id)
        {
            var jobApplicationToReject = _jobApplicationService.GetById(id);

            _jobApplicationService.RejectJob(jobApplicationToReject);

            return Ok();
        }

        [HttpGet]
        public ActionResult<IEnumerable<JobApplicationDto>> GetAll()
        {
            var allJobApps = _jobApplicationService.GetJobApplications()
                  .Select(jobApp => _jobApplicationMapper.ToDto(jobApp));
            return Ok(allJobApps.ToList());
        }

 
    }
}