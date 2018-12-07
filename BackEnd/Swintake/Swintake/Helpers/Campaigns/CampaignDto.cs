using Swintake.domain.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Swintake.api.Helpers.Campaigns
{
    public class CampaignDto
    {
        public string Id { get; set; } // veranderd van Guid naar string, wat is de impact?
        public string Name { get; set; }
        public string Client { get; set; }
        public CampaignStatus Status { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime ClassStartDate { get; set; }
        public string Comment { get; set; }

        //public CampaignDto(string id, string name, string client, CampaignStatus status, DateTime startDate, DateTime classStartDate, string comment)
        //{
        //    Id = id;
        //    Name = name;
        //    Client = client;
        //    Status = status;
        //    StartDate = startDate;
        //    ClassStartDate = classStartDate;
        //    Comment = comment;
        //}
    }
}
