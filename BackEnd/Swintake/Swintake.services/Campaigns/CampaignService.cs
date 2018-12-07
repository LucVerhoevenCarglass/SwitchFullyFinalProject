using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain;
using Swintake.domain.Campaigns;

namespace Swintake.services.Campaigns
{
    class CampaignService : ICampaignService
    {
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignService(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public Campaign CreateCampaign(Campaign campaign)
        {
            //controle
            if (campaign == null)
            {
                throw new Exception("campaign is null");
            }

            if (campaign.Id == null
                || campaign.Id == Guid.Empty
                || string.IsNullOrWhiteSpace(campaign.Name)
                || string.IsNullOrWhiteSpace(campaign.Client)
                || campaign.Status != CampaignStatus.Active
                || campaign.StartDate < DateTime.Today
                || campaign.ClassStartDate < DateTime.Today)
            {
                throw new Exception("some field of campaign is invalid");
            }

            //ok save
            _campaignRepository.Save(campaign);
            return campaign;
        }
    }
}
