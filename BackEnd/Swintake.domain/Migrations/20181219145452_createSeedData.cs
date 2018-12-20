using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class createSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("956faf4a-2925-49c2-a68b-34bdd8bead72"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("7683a833-cbd1-47f2-9ee0-6eb6288bac26"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("2e5e828b-c8e5-4e13-b366-4f2562e38d00"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("7845252f-0010-4d38-99b4-e4a63038db1c"));

            migrationBuilder.InsertData(
                table: "Campaigns",
                columns: new[] { "Id", "ClassStartDate", "Client", "Comment", "Name", "StartDate", "Status" },
                values: new object[,]
                {
                    { new Guid("bc482f0a-08b6-4b98-9a56-a1f06da0cac1"), new DateTime(2019, 2, 19, 15, 54, 51, 487, DateTimeKind.Local), "mixed", "max 8 candidates", "dotnet class 2019", new DateTime(2019, 1, 19, 15, 54, 51, 489, DateTimeKind.Local), 1 },
                    { new Guid("9bf09829-b5ba-4ba1-8652-cb9d6399baaa"), new DateTime(2018, 12, 19, 15, 54, 51, 491, DateTimeKind.Local), "CM", "at cm location", "Java academy 2019", new DateTime(2018, 12, 19, 15, 54, 51, 491, DateTimeKind.Local), 1 },
                    { new Guid("4f37f0d4-b8b8-405f-aae9-d81b7607cfcb"), new DateTime(2019, 2, 7, 15, 54, 51, 491, DateTimeKind.Local), "open for all", "", "Short javascript bootcamp", new DateTime(2018, 12, 29, 15, 54, 51, 491, DateTimeKind.Local), 1 }
                });

            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "Comment", "Email", "FirstName", "GitHubUsername", "LastName", "LinkedIn", "PhoneNumber" },
                values: new object[,]
                {
                    { new Guid("2201a275-63cf-453f-9141-d20fb16dd8c3"), "", "gwen.jamroziak@cegeka.com", "Gwen", "gwenjamroziak", "Jamroziak", "gwenjamroziak", "0472020406" },
                    { new Guid("e2fd2bb3-f5a0-4619-8403-68ff741b2a6d"), "", "caroline.callens@cegeka.com", "Caroline", "carolinecallens", "Callens", "carolinecallens", "0472030507" },
                    { new Guid("687155ff-0029-4590-b641-6f5622b70cb1"), "", "siene.dekeyser@cegeka.com", "Siene", "sienedekeyser", "Dekeyser", "sienedekeyser", "0472040608" },
                    { new Guid("7832c2cf-ad0f-4873-bd7b-af3f60ba0179"), "", "luc.verhoeven@carglass.be", "Luc", "lucverhoeven", "Verhoeven", "lucverhoeven", "0472050403" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[,]
                {
                    { new Guid("977bd92b-0206-48f4-a72e-4a839297e9ad"), "reinout@switchfully.com", "Reinout", "NgBFEGiYlnKAVlAkBj6Qkg==", "p1irTnDYNZBcCOfoph9UZaEmX5h4kd/UqkofgCUMMrA=" },
                    { new Guid("a167f922-0c23-426e-96ee-aca43e4b95a2"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("4f37f0d4-b8b8-405f-aae9-d81b7607cfcb"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("9bf09829-b5ba-4ba1-8652-cb9d6399baaa"));

            migrationBuilder.DeleteData(
                table: "Campaigns",
                keyColumn: "Id",
                keyValue: new Guid("bc482f0a-08b6-4b98-9a56-a1f06da0cac1"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("2201a275-63cf-453f-9141-d20fb16dd8c3"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("687155ff-0029-4590-b641-6f5622b70cb1"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("7832c2cf-ad0f-4873-bd7b-af3f60ba0179"));

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: new Guid("e2fd2bb3-f5a0-4619-8403-68ff741b2a6d"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("977bd92b-0206-48f4-a72e-4a839297e9ad"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("a167f922-0c23-426e-96ee-aca43e4b95a2"));

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
        }
    }
}
