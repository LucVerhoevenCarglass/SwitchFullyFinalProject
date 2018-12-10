using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class SeedDataCampaign : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1dc4fe36-8cda-4469-ac06-6fea5af718bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9910976-4e52-4202-bcef-40034a0fca63"));

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("9083d1b4-57c4-43c1-bdd3-6b4be15e7a33"), new DateTime(2018, 12, 7, 14, 56, 46, 159, DateTimeKind.Local), "ClientSwinTake", "CommentSwinTake", "TestCampaignSwinTake", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("1106146d-4be5-40fc-a35f-e75468b0b6f5"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("2355d27e-9105-4e85-ad4a-3916192e962c"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("9083d1b4-57c4-43c1-bdd3-6b4be15e7a33"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1106146d-4be5-40fc-a35f-e75468b0b6f5"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2355d27e-9105-4e85-ad4a-3916192e962c"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("d9910976-4e52-4202-bcef-40034a0fca63"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("1dc4fe36-8cda-4469-ac06-6fea5af718bd"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" });
        }
    }
}
