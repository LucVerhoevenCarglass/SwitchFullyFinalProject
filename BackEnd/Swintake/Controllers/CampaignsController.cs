using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swintake.api.Helpers.Campaigns;
using Swintake.services.Campaigns;

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
        public ActionResult<CampaignDto> CreateCampaign([FromBody] CreateCampaignDto createCampaignDto)
        {
            var newCampaign = _campaignMapper.ToDto(
                     _campaignService.AddCampaign(
                        _campaignMapper.toNewDomain(createCampaignDto)));

            return Created($"api/campaign/{newCampaign.Id}", newCampaign);
        }

        // GET: api/Campaign
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET: api/Campaign/5
        //[HttpGet("{id}", Name = "Get")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

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
