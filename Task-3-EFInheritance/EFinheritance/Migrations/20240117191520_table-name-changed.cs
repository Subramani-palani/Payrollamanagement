using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EFinheritance.Migrations
{
    /// <inheritdoc />
    public partial class tablenamechanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserRecord",
                table: "UserRecord");

            migrationBuilder.RenameTable(
                name: "UserRecord",
                newName: "Userdata");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Userdata",
                table: "Userdata",
                column: "EmployeeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Userdata",
                table: "Userdata");

            migrationBuilder.RenameTable(
                name: "Userdata",
                newName: "UserRecord");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserRecord",
                table: "UserRecord",
                column: "EmployeeID");
        }
    }
}
