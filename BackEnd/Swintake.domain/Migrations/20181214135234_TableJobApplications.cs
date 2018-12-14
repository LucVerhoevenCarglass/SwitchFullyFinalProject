using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class TableJobApplications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("6036a9cf-5e00-444e-a667-3686117aeb51"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("3df88c71-79d7-4acb-b4f2-cec2dfe4a08b"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("45c15f36-ce71-47af-8f17-008fc832a595"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("ef84e4e1-3f54-42d9-bc72-8c0e39137006"));

            migrationBuilder.CreateTable(
                name: "JobApplications",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CandiDateId = table.Column<Guid>(nullable: false),
                    CampaignId = table.Column<Guid>(nullable: false),
                    CreationTime = table.Column<DateTime>(nullable: false),
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
                        name: "FK_JobApplications_Candidates_CandiDateId",
                        column: x => x.CandiDateId,
                        principalTable: "Candidates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("ae833db4-61ac-4461-b0fe-b1f77b2f60af"), new DateTime(2018, 12, 14, 14, 52, 33, 424, DateTimeKind.Local), "CM", "cm comment", "Java academy 2019", new DateTime(2018, 12, 14, 14, 52, 33, 426, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[] { new Guid("c617423f-398a-443d-b599-98041acf5246"), "", "gwen.jamroziak@cegeka.com", "Gween", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472697959" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("e323746a-1209-4e40-928f-9e9a5ed441e6"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("8d5a1d5d-3485-49ca-9a9d-0d150d549ec2"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CampaignId",
                table: "JobApplications",
                column: "CampaignId");

            migrationBuilder.CreateIndex(
                name: "IX_JobApplications_CandiDateId",
                table: "JobApplications",
                column: "CandiDateId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "JobApplications");

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("ae833db4-61ac-4461-b0fe-b1f77b2f60af"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("c617423f-398a-443d-b599-98041acf5246"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("8d5a1d5d-3485-49ca-9a9d-0d150d549ec2"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("e323746a-1209-4e40-928f-9e9a5ed441e6"));

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[] { new Guid("6036a9cf-5e00-444e-a667-3686117aeb51"), new DateTime(2018, 12, 14, 13, 10, 12, 968, DateTimeKind.Local), "CM", "cm comment", "Java academy 2019", new DateTime(2018, 12, 14, 13, 10, 12, 970, DateTimeKind.Local), 1 });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[] { new Guid("3df88c71-79d7-4acb-b4f2-cec2dfe4a08b"), "", "gwen.jamroziak@cegeka.com", "Gween", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472697959" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("ef84e4e1-3f54-42d9-bc72-8c0e39137006"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("45c15f36-ce71-47af-8f17-008fc832a595"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });
        }
    }
}
