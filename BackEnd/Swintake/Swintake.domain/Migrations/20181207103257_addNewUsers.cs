using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Swintake.domain.Migrations
{
    public partial class addNewUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "User_PasswordHashed",
                table: "Users",
                newName: "PasswordHashed");

            migrationBuilder.RenameColumn(
                name: "User_AppliedSalt",
                table: "Users",
                newName: "AppliedSalt");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "FirstName", "AppliedSalt", "PasswordHashed" },
                values: new object[] { new Guid("88878a2c-04d6-43b9-b22b-650ea27d39c6"), "reinout@switchfully.com", "Reinout", "rODZhnBsLGRP908sBZiXzg==", "WO8nNwTcrxigARQfBn4nYRh8X16ExDQJ8jNuECJT8fE=" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: new Guid("88878a2c-04d6-43b9-b22b-650ea27d39c6"));

            migrationBuilder.RenameColumn(
                name: "PasswordHashed",
                table: "Users",
                newName: "User_PasswordHashed");

            migrationBuilder.RenameColumn(
                name: "AppliedSalt",
                table: "Users",
                newName: "User_AppliedSalt");
        }
    }
}
