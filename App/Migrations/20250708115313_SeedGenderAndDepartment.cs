using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace App.Migrations
{
    /// <inheritdoc />
    public partial class SeedGenderAndDepartment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentCode", "DepartmentName" },
                values: new object[,]
                {
                    { "DT", "Digital Transformation" },
                    { "FIN", "Finance" },
                    { "HR", "Human Resources" }
                });

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "GenderId", "GenderName" },
                values: new object[,]
                {
                    { "F", "Female" },
                    { "M", "Male" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentCode",
                keyValue: "DT");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentCode",
                keyValue: "FIN");

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentCode",
                keyValue: "HR");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: "F");

            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "GenderId",
                keyValue: "M");
        }
    }
}
