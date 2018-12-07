using Swintake.domain.Campaigns;
using Swintake.infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Campaigns
{
    public class CampaignMapper : Mapper<CampaignDto, Campaign>
    {
        public override Campaign ToDomain(CampaignDto dtoObject)
        {
            return Campaign.CampaignBuilder.NewCampaign()
                .WithId(string.IsNullOrWhiteSpace(dtoObject.Id) ? new Guid() : new Guid(dtoObject.Id)) //replaced Guid.empty by new Guid()
                .WithName(dtoObject.Name)
                .WithClient(dtoObject.Client)
                .WithStatus(dtoObject.Status)
                .WithStartDate(dtoObject.StartDate)
                .WithClassStartDate(dtoObject.ClassStartDate)
                .WithComment(dtoObject.Comment)
                .Build();

            //return new Campaign(
            //        dtoObject.Name,
            //        dtoObject.Client,
            //        dtoObject.Status,
            //        dtoObject.StartDate,
            //        dtoObject.ClassStartDate,
            //        dtoObject.Comment
            //        );
        }

        public override CampaignDto ToDto(Campaign domainObject)
        {
            return new CampaignDto
            {
                Id = domainObject.Id.ToString(),
                Name = domainObject.Name,
                Client = domainObject.Client,
                Status = domainObject.Status,
                StartDate = domainObject.StartDate,
                ClassStartDate = domainObject.ClassStartDate,
                Comment = domainObject.Comment
            };
        }
    }
}
