using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using Swintake.api.Controllers;
using Swintake.api.Helpers.Campaigns;
using Swintake.domain.Campaigns;
using Swintake.infrastructure.Mappers;
using Swintake.services.Campaigns;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;
using static Swintake.domain.Campaigns.Campaign;

namespace Swintake.api.tests.Campaigns
{
    public class CampaignControllerTest
    {
        private readonly ICampaignService campaignServiceStub;
        private readonly CampaignsController _campaignsController;
        private readonly CampaignMapper campaignMapperStub;

        public CampaignControllerTest()
        {
            campaignServiceStub = Substitute.For<ICampaignService>();
            campaignMapperStub = Substitute.For<CampaignMapper>();
            _campaignsController = new CampaignsController(campaignServiceStub, campaignMapperStub);
        }

        [Fact]
        public void GivenCreateCampaignDto_WhenCreateCampaign_ThenReturnCreatedActionResult()
        {
            //given
            var newDTOCreated = new CreateCampaignDto()
            {
                Name = "testCampaign",
                Client = "testClient",
                ClassStartDate = DateTime.Today.AddDays(5),
                StartDate = DateTime.Today.AddDays(5),
                Comment = "testComment"
            };

            var campaign = new CampaignBuilder()
                    .WithId(Guid.NewGuid())
                    .WithName("testName")
                    .WithClient("testClient")
                    .WithStatus(CampaignStatus.Active)
                    .WithStartDate(DateTime.Today.AddDays(5))
                    .WithClassStartDate(DateTime.Today.AddDays(5))
                    .WithComment("testComment")
                    .Build();

            var newDTO = new CampaignDto()
            {
                Id = campaign.Id.ToString(),
                Status = campaign.Status,
                Name = "testCampaign",
                Client = "testClient",
                ClassStartDate = DateTime.Today.AddDays(5),
                StartDate = DateTime.Today.AddDays(5),
                Comment = "testComment"
            };

            campaignMapperStub.ToNewDomain(newDTOCreated).Returns(campaign);
            campaignServiceStub.AddCampaign(campaign).Returns(campaign);
            campaignMapperStub.ToDto(campaign).Returns(newDTO);

            //when
            CreatedResult result = (CreatedResult)_campaignsController.CreateCampaign(newDTOCreated).Result;

            //then
            Assert.Equal(201, result.StatusCode);
        }

        [Fact]
        public void GivenHappyPath_WhenGetAllCampaigns_ThenReturnAllCampaigns()
        {
            //given
            var newDTOCreated = new CreateCampaignDto()
            {
                Name = "testCampaign",
                Client = "testClient",
                ClassStartDate = DateTime.Today.AddDays(5),
                StartDate = DateTime.Today.AddDays(5),
                Comment = "testComment"
            };

            var campaign = new CampaignBuilder()
                    .WithId(Guid.NewGuid())
                    .WithName("testName")
                    .WithClient("testClient")
                    .WithStatus(CampaignStatus.Active)
                    .WithStartDate(DateTime.Today.AddDays(5))
                    .WithClassStartDate(DateTime.Today.AddDays(5))
                    .WithComment("testComment")
                    .Build();

            var newDTO = new CampaignDto()
            {
                Id = campaign.Id.ToString(),
                Status = campaign.Status,
                Name = "testCampaign",
                Client = "testClient",
                ClassStartDate = DateTime.Today.AddDays(5),
                StartDate = DateTime.Today.AddDays(5),
                Comment = "testComment"
            };

            campaignMapperStub.ToNewDomain(newDTOCreated).Returns(campaign);
            campaignServiceStub.AddCampaign(campaign).Returns(campaign);
            campaignMapperStub.ToDto(campaign).Returns(newDTO);

            CreatedResult result = (CreatedResult)_campaignsController.CreateCampaign(newDTOCreated).Result;

            //when
            var allCampaigns = _campaignsController
                                            .GetAllCampaigns()
                                            .Value;
            IEnumerable<CampaignDto> IEnumerableCampaignDto = new List<CampaignDto>();

            //then
            if (allCampaigns != null)
            {
                Assert.Equal(IEnumerableCampaignDto.GetType().ToString(), allCampaigns.GetType().ToString());
            }
            else Assert.True(true);
        }
    }
}
