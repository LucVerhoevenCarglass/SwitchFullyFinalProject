using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain;
using Swintake.domain.Campaigns;
using Swintake.infrastructure.Exceptions;

namespace Swintake.services.Campaigns
{
    public class CampaignService : ICampaignService
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignService(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public Campaign AddCampaign(Campaign campaign)
        {
            if (campaign == null)
            {
                throw new EntityNotValidException("campaign is null", campaign);
            }

            // TODO: Put this check inside of the Campaign itself (business logic inside of the domain model)
            // You're asking if the candidate is valid (e.g. IsValidForCreation)
            if (campaign.Id == null
                || campaign.Id == Guid.Empty
                || string.IsNullOrWhiteSpace(campaign.Name)
                || string.IsNullOrWhiteSpace(campaign.Client)
                || campaign.Status != CampaignStatus.Active
                || campaign.ClassStartDate < campaign.StartDate)
            {
                throw new EntityNotValidException("some fields of campaign are invalid", campaign);
            }

            _campaignRepository.Save(campaign);

            return campaign;
        }

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            return _campaignRepository.GetAll();
        }

        public Campaign GetCampaignByID(string id)
        {
            var campaign = _campaignRepository.Get(new Guid(id));
            if(campaign == null)
            {
                throw new EntityNotFoundException("Id not Found", "campaign", new Guid(id));
            }
            return campaign;
        }
    }
}
