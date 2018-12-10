using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain;
using Swintake.domain.Campaigns;

namespace Swintake.services.Campaigns
{
    public class CampaignService : ICampaignService
    {
        // constructor
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignService(IRepository<Campaign> campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        // methode
        public Campaign AddCampaign(Campaign campaign)
        {
            // controle
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
                throw new Exception("some fields of campaign are invalid");
            }

            // ok, save
            _campaignRepository.Save(campaign);
            return campaign;
        }
    }
}
