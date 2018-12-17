﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.Campaigns;
using Swintake.domain.Campaigns;
using Swintake.services.Campaigns;
using System.Collections.Generic;


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
            var newCampaign = _campaignMapper.ToDto(
                     _campaignService.AddCampaign(
                        _campaignMapper.ToNewDomain(createCampaignDto)));

            return Created($"api/campaign/{newCampaign.Id}", newCampaign);
        }

        // GET: api/Campaign
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<CampaignDto>> GetAllCampaigns()
        {
            IEnumerable<Campaign> campaigns = _campaignService.GetAllCampaigns();

            // TODO: THIS (MAP MULTIPLE DTOS) CAN BE PLACED INSIDE OF THE CAMPAIGNMAPPER
            List<CampaignDto> campaignDtos = new List<CampaignDto>();
            foreach (Campaign campaign in campaigns)
            {
                CampaignDto campaignDto = _campaignMapper.ToDto(campaign);
                campaignDtos.Add(campaignDto);
            }

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

    }
}
