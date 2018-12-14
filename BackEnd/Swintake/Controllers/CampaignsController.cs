using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.Campaigns;
using Swintake.api.Helpers.Candidates;
using Swintake.domain.Campaigns;
using Swintake.infrastructure.Exceptions;
using Swintake.services.Campaigns;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;


namespace Swintake.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignsController : ControllerBase
    {
        // dependency injection
        private readonly ICampaignService _campaignService;
        private readonly CampaignMapper _campaignMapper;

        public CampaignsController(ICampaignService campaignService, CampaignMapper campaignMapper)
        {
            _campaignService = campaignService;
            _campaignMapper = campaignMapper;
        }

        // POST: api/Campaign
        [HttpPost]
        [Authorize]
        public ActionResult<CampaignDto> CreateCampaign([FromBody] CreateCampaignDto createCampaignDto)
        {
            try
            {
                var newCampaign = _campaignMapper.ToDto(
                         _campaignService.AddCampaign(
                            _campaignMapper.ToNewDomain(createCampaignDto)));

                return Created($"api/campaign/{newCampaign.Id}", newCampaign);
            }
            catch(EntityNotValidException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Campaign
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<CampaignDto>> GetAllCampaigns()
        {
            //var allCompaigns = _campaignService.GetCampaigns()
            //    .Select(campaign => _campaignMapper.ToDto(campaign));
            //return ok(allCompaigns.ToList());

            //service gets domain items

            IEnumerable<Campaign> campaigns = _campaignService.GetAllCampaigns();

            //from domain to dto
            List<CampaignDto> campaignDtos = new List<CampaignDto>();

            foreach (Campaign campaign in campaigns)
            {
                //convert each campaign to dto
                CampaignDto campaignDto = _campaignMapper.ToDto(campaign);
                //add to to list
                campaignDtos.Add(campaignDto);
            }

            //return dto result
            return Ok(campaignDtos);
        }

        // GET: api/Campaign/5
        [HttpGet("{id}", Name = "Get")]
        [Authorize]
        public ActionResult<CampaignDto> Get(string id)
        {
            var campaign = _campaignService.GetCampaignByID(id);
            if (campaign == null)
            {
                return BadRequest("Id not found");
            }
            var campaignToReturn = _campaignMapper.ToDto(campaign);

            return Ok(campaignToReturn);
        }

        // PUT: api/Campaign/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

    }
}
