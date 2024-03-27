using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagementEF.Migrations
{
    /// <inheritdoc />
    public partial class AddedEmployeeStatuesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Employees");

            migrationBuilder.AddColumn<int>(
                name: "StatusID",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EmployeeStatuses",
                columns: table => new
                {
                    StatusID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeStatuses", x => x.StatusID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StatusID",
                table: "Employees",
                column: "StatusID");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_EmployeeStatuses_StatusID",
                table: "Employees",
                column: "StatusID",
                principalTable: "EmployeeStatuses",
                principalColumn: "StatusID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_EmployeeStatuses_StatusID",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeeStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StatusID",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StatusID",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
