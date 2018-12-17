using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class CreateDatabase_and_inheritanceSelectionStep : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaigns",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 60, nullable: true),
                    Client = table.Column<string>(maxLength: 60, nullable: true),
                    Status = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    ClassStartDate = table.Column<DateTime>(nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaigns", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Candidates",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(maxLength: 60, nullable: true),
                    LastName = table.Column<string>(maxLength: 60, nullable: true),
                    Email = table.Column<string>(maxLength: 100, nullable: true),
                    PhoneNumber = table.Column<string>(maxLength: 20, nullable: true),
                    GitHubUsername = table.Column<string>(maxLength: 100, nullable: true),
                    LinkedIn = table.Column<string>(maxLength: 200, nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Candidates", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SelectionStep",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 90, nullable: true),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionStep", x => x.Id);
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

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandidateId = table.Column<Guid>(nullable: false),
                    CampaignId = table.Column<Guid>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobApplications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_JobApplications_Campaigns_CampaignId",
                        column: x => x.CampaignId,
                        principalTable: "Campaigns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_JobApplications_Candidates_CandidateId",
                        column: x => x.CandidateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("da62dab3-73b8-41b3-8972-2fcc55c3689d"), new DateTime(2018, 12, 17, 14, 21, 38, 693, DateTimeKind.Local), "CM", "cm comment", "Java academy 2019", new DateTime(2018, 12, 17, 14, 21, 38, 698, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[] { new Guid("64431092-fdff-4000-b495-c13bcf9a3aeb"), "", "gwen.jamroziak@cegeka.com", "Gween", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472697959" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("863dd40e-2a7e-44a4-8db8-6bb5dcdf21dc"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("ca8f09b6-e727-40f9-8945-f3959308b096"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CampaignId",
                table: "JobApplications",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CandidateId",
                table: "JobApplications",
                column: "CandidateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DropTable(
                name: "SelectionStep");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Candidates");
        }
    }
}
