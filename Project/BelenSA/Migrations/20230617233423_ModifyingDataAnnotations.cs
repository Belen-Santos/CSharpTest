using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelenSA.Migrations
{
    public partial class ModifyingDataAnnotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "HowTheyHeardAboutUs",
                table: "Subscriber",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "HowTheyHeardAboutUs",
                table: "Subscriber",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
