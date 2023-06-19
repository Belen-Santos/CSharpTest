using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelenSA.Migrations
{
    public partial class updatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Reason",
                table: "ReasonsForSigningUp",
                newName: "ReasonName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReasonName",
                table: "ReasonsForSigningUp",
                newName: "Reason");
        }
    }
}
