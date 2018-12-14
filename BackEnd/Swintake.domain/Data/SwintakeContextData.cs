using Microsoft.EntityFrameworkCore;
using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using Swintake.domain.Campaigns;
using Swintake.domain.Candidates;

namespace Swintake.domain.Data
{
    class SwintakeContextData
    {
       internal Campaign dotNetClass = new Campaign.CampaignBuilder()
            .WithId(Guid.NewGuid())
            .WithName("Java academy 2019")
            .WithClient("CM")
            .WithClassStartDate(DateTime.Now)
            .WithStartDate(DateTime.Now)
            .WithComment("cm comment")
            .WithStatus(CampaignStatus.Active).Build();

        internal Candidate gwen = new CandidateBuilder()
            .WithId(Guid.NewGuid())
            .WithFirstName("Gween")
            .WithLastName("Jamroziak")
            .WithPhoneNumber("0472697959")
            .WithEmail("gwen.jamroziak@cegeka.com")
            .WithGitHubUsername("gwenjamroziak")
            .WithLinkedIn("gwenjamroziak")
            .WithComment("")
            .Build();
    }

    public partial class SwintakeContext
    {
        protected void SeedData(ModelBuilder modelbuilder)
        {
            var seedData = new SwintakeContextData();

            var idReinout = Guid.NewGuid();
            modelbuilder.Entity<User>(u =>
            {
                u.HasData(new
                {
                    Id = idReinout,
                    FirstName = "Reinout",
                    Email = "reinout@switchfully.com"
                });
                u.OwnsOne(us => us.UserSecurity).HasData(new
                {
                    PasswordHashedAndSalted = "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=",
                    AppliedSalt = "NgBFEGiYlnKAVlAkBj6Qkg==",
                    UserId = idReinout
                });   
            });

            var idNiels = Guid.NewGuid();
            modelbuilder.Entity<User>(u =>
            {
                u.HasData(new
                {
                    Id = idNiels,
                    FirstName = "Niels",
                    Email = "niels@switchfully.com"
                });
                u.OwnsOne(us => us.UserSecurity).HasData(new
                {
                    PasswordHashedAndSalted = "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=",
                    AppliedSalt = "rODZhnBsLGRP908sBZiXzg==",
                    UserId = idNiels
                });   
            });

            modelbuilder.Entity<Campaign>(camp => { camp.HasData(seedData.dotNetClass); });
            modelbuilder.Entity<Candidate>(cand => { cand.HasData(seedData.gwen); });
        }
    }
}
