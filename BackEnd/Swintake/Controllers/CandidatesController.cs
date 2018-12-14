using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.Candidates;
using Swintake.domain.Candidates;
using Swintake.infrastructure.Exceptions;
using Swintake.services.Candidates;
using System;
using System.Collections.Generic;

namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly CandidateMapper _candidateMapper;
        private readonly ICandidateService _candidateService;

        public CandidatesController(ICandidateService candidateService, CandidateMapper candidateMapper)
        {
            _candidateMapper = candidateMapper;
            _candidateService = candidateService;
        }
        
        // POST: api/Campaign
        [HttpPost]
        public ActionResult<CandidateDto> CreateCandidate([FromBody] CandidateDto candidateDto)
        {
            try
            {
                var newcandidate = _candidateMapper.ToDto(
                         _candidateService.AddCandidate(
                            _candidateMapper.ToDomain(candidateDto)));

                return Created($"api/candidate/{newcandidate.Id}", newcandidate);
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

        [HttpGet("{id}")]
        public ActionResult<CandidateDto> GetById(string id)
        {
            try
            {
                var candidate = _candidateService.GetCandidateById(id);
                return _candidateMapper.ToDto(candidate);
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

        [HttpGet]
        public ActionResult<List<CandidateDto>> GetAll()
        {
            try
            {
                var candidatesDomain = _candidateService.GetAllCandidates();

                var candidatesDto = new List<CandidateDto>();

                foreach (var candidate in candidatesDomain)
                {
                    var candidateDto = _candidateMapper.ToDto(candidate);
                    candidatesDto.Add(candidateDto);
                }

                return candidatesDto;
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