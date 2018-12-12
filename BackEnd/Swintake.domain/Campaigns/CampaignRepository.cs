using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Swintake.domain.Campaigns
{
    public class CampaignRepository : IRepository<Campaign>
    {
        // fields en constructor
        private readonly SwintakeContext _context;

        //protected CampaignRepository() { }

        public CampaignRepository(SwintakeContext context)
        {
            _context = context;
        }

        // methodes
        public Campaign Get(Guid entityId)
        {
            return _context.Campaigns.SingleOrDefault(campaign => campaign.Id == entityId);
        }

        public IList<Campaign> GetAll()
        {
            throw new NotImplementedException();
        }

        public Campaign Save(Campaign campaign)
        {
            _context.Campaigns.Add(campaign); 
            _context.SaveChanges();
            return campaign;
        }

        public Campaign Update(Campaign entity)
        {
            throw new NotImplementedException();
        }
    }
}
