using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Employee.Backend.Migrations
{
    /// <inheritdoc />
    public partial class secondDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Employees_Id",
                table: "Employees",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Employees_Id",
                table: "Employees");
        }
    }
}
