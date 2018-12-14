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
                throw new EntityNotValidException("campaign is null", campaign);
            }

            if (campaign.Id == null
                || campaign.Id == Guid.Empty
                || string.IsNullOrWhiteSpace(campaign.Name)
                || string.IsNullOrWhiteSpace(campaign.Client)
                || campaign.Status != CampaignStatus.Active
                || campaign.ClassStartDate < campaign.StartDate)
            {
                throw new EntityNotValidException("some fields of campaign are invalid", campaign);
            }

            // ok, save
            _campaignRepository.Save(campaign);

            return campaign;
        }

        public IEnumerable<Campaign> GetAllCampaigns()
        {
            return _campaignRepository.GetAll();
        }

        public Campaign GetCampaignByID(string id)
        {
            return _campaignRepository.Get(new Guid(id));
        }
    }
}
