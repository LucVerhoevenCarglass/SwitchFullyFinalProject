using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class DatabaseCreateCampaignsUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordHashed = table.Column<string>(nullable: true),
                    AppliedSalt = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("4d816abf-d7dd-4c5e-bef6-a1b2356194f1"), new DateTime(2018, 12, 13, 8, 27, 23, 903, DateTimeKind.Local), "ClientSwinTake", "CommentSwinTake", "TestCampaignSwinTake", new DateTime(2018, 12, 13, 8, 27, 23, 905, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("9d8b8fdf-1018-438d-80c8-67a986b89acc"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("ac82a251-24f0-4ac0-975e-c463e6e90c6f"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
