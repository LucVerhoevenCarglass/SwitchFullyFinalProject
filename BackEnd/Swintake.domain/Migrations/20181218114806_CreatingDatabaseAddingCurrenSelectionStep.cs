using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class CreatingDatabaseAddingCurrenSelectionStep : Migration
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
                    CurrentSelectionStepJobApplicationId = table.Column<Guid>(nullable: true),
                    CurrentSelectionStepDescription = table.Column<string>(nullable: true),
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

            migrationBuilder.CreateTable(
                name: "SelectionStep",
                columns: table => new
                {
                    JobApplicationId = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(maxLength: 90, nullable: false),
                    Comment = table.Column<string>(maxLength: 500, nullable: true),
                    Discriminator = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelectionStep", x => new { x.JobApplicationId, x.Description });
                    table.ForeignKey(
                        name: "FK_SelectionStep_JobApplications_JobApplicationId",
                        column: x => x.JobApplicationId,
                        principalTable: "JobApplications",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("956faf4a-2925-49c2-a68b-34bdd8bead72"), new DateTime(2018, 12, 18, 12, 48, 4, 461, DateTimeKind.Local), "CM", "cm comment", "Java academy 2019", new DateTime(2018, 12, 18, 12, 48, 4, 466, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[] { new Guid("7683a833-cbd1-47f2-9ee0-6eb6288bac26"), "", "gwen.jamroziak@cegeka.com", "Gween", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472697959" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("7845252f-0010-4d38-99b4-e4a63038db1c"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("2e5e828b-c8e5-4e13-b366-4f2562e38d00"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CampaignId",
                table: "JobApplications",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CandidateId",
                table: "JobApplications",
                column: "CandidateId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CurrentSelectionStepJobApplicationId_CurrentSelectionStepDescription",
                table: "JobApplications",
                columns: new[] { "CurrentSelectionStepJobApplicationId", "CurrentSelectionStepDescription" });

            migrationBuilder.AddForeignKey(
                name: "FK_JobApplications_SelectionStep_CurrentSelectionStepJobApplicationId_CurrentSelectionStepDescription",
                table: "JobApplications",
                columns: new[] { "CurrentSelectionStepJobApplicationId", "CurrentSelectionStepDescription" },
                principalTable: "SelectionStep",
                principalColumns: new[] { "JobApplicationId", "Description" },
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Campaigns_CampaignId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_Candidates_CandidateId",
                table: "JobApplications");

            migrationBuilder.DropForeignKey(
                name: "FK_JobApplications_SelectionStep_CurrentSelectionStepJobApplicationId_CurrentSelectionStepDescription",
                table: "JobApplications");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Campaigns");

            migrationBuilder.DropTable(
                name: "Candidates");

            migrationBuilder.DropTable(
                name: "SelectionStep");

            migrationBuilder.DropTable(
                name: "JobApplications");
        }
    }
}
