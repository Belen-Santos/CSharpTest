using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelenSA.Migrations
{
    public partial class CreatingDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ReasonSignUp",
                columns: table => new
                {
                    ReasonSignUpId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReasonSigningUp = table.Column<string>(type: "nvarchar(MAX)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReasonSignUp", x => x.ReasonSignUpId);
                });

            migrationBuilder.CreateTable(
                name: "Subscriber",
                columns: table => new
                {
                    SubscriberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HowTheyHeardAboutUs = table.Column<string>(type: "nvarchar(MAX)", nullable: false),
                    SubscriptionDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriber", x => x.SubscriberId);
                });

            migrationBuilder.CreateTable(
                name: "SubscribersReasonsSignUp",
                columns: table => new
                {
                    ReasonSignUpId = table.Column<int>(type: "int", nullable: false),
                    SubscriberId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribersReasonsSignUp", x => new { x.ReasonSignUpId, x.SubscriberId });
                    table.ForeignKey(
                        name: "FK_SubscribersReasonsSignUp_ReasonSignUp_ReasonSignUpId",
                        column: x => x.ReasonSignUpId,
                        principalTable: "ReasonSignUp",
                        principalColumn: "ReasonSignUpId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SubscribersReasonsSignUp_Subscriber_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscriber",
                        principalColumn: "SubscriberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscribersReasonsSignUp_SubscriberId",
                table: "SubscribersReasonsSignUp",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribersReasonsSignUp");

            migrationBuilder.DropTable(
                name: "ReasonSignUp");

            migrationBuilder.DropTable(
                name: "Subscriber");
        }
    }
}
