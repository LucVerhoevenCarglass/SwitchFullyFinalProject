using Microsoft.EntityFrameworkCore;
using Swintake.domain.Users;
using System;
using System.Collections.Generic;
using Swintake.domain.Campaigns;

namespace Swintake.domain.Data
{
    class SwintakeContextData
    {
        //internal User reinout = new UserBuilder()
        //    .WithEmail("reinout@switchfully.com")
        //    .WithFirstName("Reinout")
        //    .WithUserSecurity(new UserSecurity("WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=", "F1e3n6zNR75LhUd5K73T/g=="))
        //    .Build();
       
        //internal User niels = new UserBuilder()
        //    .WithEmail("niels@switchfully.com")
        //    .WithFirstName("Niels")
        //    .WithUserSecurity(new UserSecurity("TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=", "rODZhnBsLGRP908sBZiXzg=="))
        //    .Build();

        internal Campaign campain1 = new Campaign.CampaignBuilder()
            .WithId(Guid.NewGuid())
            .WithClient("ClientSwinTake")
            .WithClassStartDate(DateTime.Now)
            .WithStartDate(DateTime.Now)
            .WithComment("CommentSwinTake")
            .WithName("TestCampaignSwinTake")
            .WithStatus(CampaignStatus.Active).Build();
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
                    PasswordHashedAndSalted = "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=",
                    AppliedSalt = "rODZhnBsLGRP908sBZiXzg==",
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

            modelbuilder.Entity<Campaign>(camp => { camp.HasData(seedData.campain1); });
        }
    }
}
