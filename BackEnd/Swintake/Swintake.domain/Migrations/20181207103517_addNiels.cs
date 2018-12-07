using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class addNiels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88878a2c-04d6-43b9-b22b-650ea27d39c6"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("9b406cf0-614a-4cdd-b9ff-d4ca1afc72f3"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("cce969a1-3baf-4ef5-a6f9-5ff5dcdaa260"), "niels@switchfully.com", "Niels", "rODZhnBsLGRP908sBZiXzg==", "TeBgBijhTG1++pvIvcEOd0hvSGBE1Po1kh6TFlW097w=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("9b406cf0-614a-4cdd-b9ff-d4ca1afc72f3"));

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("cce969a1-3baf-4ef5-a6f9-5ff5dcdaa260"));

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("88878a2c-04d6-43b9-b22b-650ea27d39c6"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });
        }
    }
}
