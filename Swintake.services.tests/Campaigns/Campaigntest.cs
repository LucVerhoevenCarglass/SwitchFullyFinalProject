using System;
using System.Collections.Generic;
using System.Text;
using Swintake.domain.Campaigns;
using Xunit;

namespace Swintake.services.tests.Campaigns
{
    public class Campaigntest
    {
        [Fact]
        public void test()
        {
            Campaign.CampaignBuilder campaignBuilder = new Campaign.CampaignBuilder();

            Campaign campaign = new Campaign();
        }

    }
}
