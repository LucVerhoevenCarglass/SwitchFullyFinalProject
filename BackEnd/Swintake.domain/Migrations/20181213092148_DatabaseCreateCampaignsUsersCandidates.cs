using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class DatabaseCreateCampaignsUsersCandidates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("e0575baf-7260-4d05-bb12-756120477627"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("9581fb30-ae4b-4966-8e67-20bbeba5b502"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("173388dd-e132-4b1d-89de-a47bb8cbef55"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("f7eb5e13-9c13-49f7-8275-1990ef98586b"));

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("7c221b99-908a-4b26-868f-0228f3da0568"), new DateTime(2018, 12, 13, 10, 21, 48, 356, DateTimeKind.Local), "CM", "cm comment", "Java academy 2019", new DateTime(2018, 12, 13, 10, 21, 48, 358, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[] { new Guid("44356fa8-3995-459f-927a-976e1dfee43d"), "gwen.jamroziak@cegeka.com", "Gween", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472697959" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("92869497-6e3b-42d6-b904-6b2362d9c957"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("db84d51c-840a-4c5b-8ce1-2a2821e5565c"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("7c221b99-908a-4b26-868f-0228f3da0568"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("44356fa8-3995-459f-927a-976e1dfee43d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("92869497-6e3b-42d6-b904-6b2362d9c957"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("db84d51c-840a-4c5b-8ce1-2a2821e5565c"));

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("e0575baf-7260-4d05-bb12-756120477627"), new DateTime(2018, 12, 13, 10, 14, 11, 551, DateTimeKind.Local), "CM", "cm comment", "Java academy 2019", new DateTime(2018, 12, 13, 10, 14, 11, 552, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[] { new Guid("9581fb30-ae4b-4966-8e67-20bbeba5b502"), "gwen.jamroziak@cegeka.com", "Gween", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472697959" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("173388dd-e132-4b1d-89de-a47bb8cbef55"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("f7eb5e13-9c13-49f7-8275-1990ef98586b"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });
        }
    }
}
