using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class CreatingCampaignTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b406cf0-614a-4cdd-b9ff-d4ca1afc72f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cce969a1-3baf-4ef5-a6f9-5ff5dcdaa260"));

            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Client = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ClassStartDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("d9910976-4e52-4202-bcef-40034a0fca63"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("1dc4fe36-8cda-4469-ac06-6fea5af718bd"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("1dc4fe36-8cda-4469-ac06-6fea5af718bd"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("d9910976-4e52-4202-bcef-40034a0fca63"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("9b406cf0-614a-4cdd-b9ff-d4ca1afc72f3"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("cce969a1-3baf-4ef5-a6f9-5ff5dcdaa260"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" });
        }
    }
}
