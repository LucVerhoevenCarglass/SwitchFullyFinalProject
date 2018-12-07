using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.domain.Campaigns
{
    public class CampaignRepository : IRepository<Campaign>
    {
        private readonly SwintakeContext _context;
        protected CampaignRepository() { }

        protected CampaignRepository(SwintakeContext context)
        {
            _context = context;
        }

        public Campaign Get(Guid entityId)
        {
            throw new NotImplementedException();
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
