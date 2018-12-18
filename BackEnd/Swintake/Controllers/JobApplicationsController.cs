﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.JobApplications;
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
            var jobApplicationDto = _jobApplicationService.GetJobApplicationById(id);
            return _jobApplicationMapper.ToDto(jobApplicationDto);
        }

        [HttpGet]
        public ActionResult<JobApplicationDto> GetAll()
        {
            return null;
        }

        [HttpPut]
        [Route("nextStep/{id}")]
        public ActionResult<JobApplicationDto> UpdateJobApplication(string id, [FromBody] string comment = null)
        {
           return Ok(_jobApplicationMapper.ToDto(_jobApplicationService.GoToNextSelectionStepInSelectionProcess(id, comment)));
        }

    }
}