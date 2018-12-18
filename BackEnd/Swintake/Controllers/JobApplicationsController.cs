using Microsoft.AspNetCore.Authorization;
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
            var newJobApplication = _jobApplicationMapper.ToNewDomain(jobApplicationDto);
            var two = _jobApplicationService.AddJobApplication(newJobApplication);
            var three = _jobApplicationMapper.ToDto(two);

            return Created($"api/jobapplication/{newJobApplication.Id}", three);
        }

        [HttpGet("{id}")]
        public ActionResult<JobApplicationDto> GetById(string id)
        {
            var candidate = _jobApplicationService.GetJobApplicationById(id);
            return _jobApplicationMapper.ToDto(candidate);
        }

        [HttpGet]
        public ActionResult<JobApplicationDto> GetAll()
        {
            return null;
        }
    }
}