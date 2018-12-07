using Swintake.domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Text;

namespace Swintake.services.Campaigns
{
    interface ICampaignService
    {
        Campaign CreateCampaign(Campaign campaign); //Is Save to repository
    }
}
