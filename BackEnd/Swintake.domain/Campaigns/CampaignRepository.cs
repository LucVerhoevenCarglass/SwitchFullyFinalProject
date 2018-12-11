﻿using Swintake.domain.Data;
using System;
using System.Collections.Generic;
using System.Text;

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
