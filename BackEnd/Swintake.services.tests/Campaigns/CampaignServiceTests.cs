using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using NSubstitute;
using Swintake.domain;
using Swintake.domain.Campaigns;
using Swintake.services.Campaigns;
using Xunit;

namespace Swintake.services.tests.Campaigns
{
    public class CampaignServiceTests
    {
        private readonly CampaignService _campaignService;
        private readonly IRepository<Campaign> _campaignRepository;

        public CampaignServiceTests()
        {
            _campaignRepository = Substitute.For<IRepository<Campaign>>();
            _campaignService = new CampaignService(_campaignRepository);
        }

        internal Campaign TestCampaign = new Campaign.CampaignBuilder()
            .WithId(Guid.NewGuid())
            .WithClient("ClientSwinTake")
            .WithClassStartDate(DateTime.Today)
            .WithStartDate(DateTime.Today)
            .WithComment("CommentSwinTake")
            .WithName("TestCampaignSwinTake")
            .WithStatus(CampaignStatus.Active).Build();

        [Fact]
        public void CreateCampaign_HappyPath()
        {
            //given
            _campaignRepository.Save(TestCampaign);
            Campaign createdCompaign = _campaignService.AddCampaign(TestCampaign);
            Assert.NotNull(createdCompaign);
            Assert.NotEqual(createdCompaign.Id, Guid.Empty);
        }

        [Fact]
        public void CreateCampaign_givenCompaignThatIsNotValidForCreation_thenThrowException()
        {
            Campaign testCampaign2 = CloneObject(TestCampaign);
            testCampaign2.Name = string.Empty;
            Exception ex = Assert.Throws<Exception>(() => _campaignService.AddCampaign(testCampaign2));
            Assert.Contains("some fields of campaign are invalid", ex.Message);
        }

        private T CloneObject<T>(T obj)
        {
            DataContractSerializer dcSer = new DataContractSerializer(obj.GetType());
            MemoryStream memoryStream = new MemoryStream();
            dcSer.WriteObject(memoryStream, obj);
            memoryStream.Position = 0;
            T newObject = (T)dcSer.ReadObject(memoryStream);
            return newObject;
        }
    }
}
