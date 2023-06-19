using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BelenSA.Migrations
{
    public partial class updatingRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribersReasonsSignUp");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscriber",
                table: "Subscriber");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReasonSignUp",
                table: "ReasonSignUp");

            migrationBuilder.DropColumn(
                name: "ReasonSigningUp",
                table: "ReasonSignUp");

            migrationBuilder.RenameTable(
                name: "Subscriber",
                newName: "Subscribers");

            migrationBuilder.RenameTable(
                name: "ReasonSignUp",
                newName: "ReasonsForSigningUp");

            migrationBuilder.RenameColumn(
                name: "ReasonSignUpId",
                table: "ReasonsForSigningUp",
                newName: "ReasonId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subscribers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "HowTheyHeardAboutUs",
                table: "Subscribers",
                type: "nvarchar(MAX)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Reason",
                table: "ReasonsForSigningUp",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers",
                column: "SubscriberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReasonsForSigningUp",
                table: "ReasonsForSigningUp",
                column: "ReasonId");

            migrationBuilder.CreateTable(
                name: "SubscribersReasons",
                columns: table => new
                {
                    SubscriberReasonId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SubscriberId = table.Column<int>(type: "int", nullable: false),
                    ReasonSignUpId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscribersReasons", x => x.SubscriberReasonId);
                    table.ForeignKey(
                        name: "FK_SubscribersReasons_ReasonsForSigningUp_ReasonSignUpId",
                        column: x => x.ReasonSignUpId,
                        principalTable: "ReasonsForSigningUp",
                        principalColumn: "ReasonId");
                    table.ForeignKey(
                        name: "FK_SubscribersReasons_Subscribers_SubscriberId",
                        column: x => x.SubscriberId,
                        principalTable: "Subscribers",
                        principalColumn: "SubscriberId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubscribersReasons_ReasonSignUpId",
                table: "SubscribersReasons",
                column: "ReasonSignUpId");

            migrationBuilder.CreateIndex(
                name: "IX_SubscribersReasons_SubscriberId",
                table: "SubscribersReasons",
                column: "SubscriberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubscribersReasons");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Subscribers",
                table: "Subscribers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ReasonsForSigningUp",
                table: "ReasonsForSigningUp");

            migrationBuilder.DropColumn(
                name: "Reason",
                table: "ReasonsForSigningUp");

            migrationBuilder.RenameTable(
                name: "Subscribers",
                newName: "Subscriber");

            migrationBuilder.RenameTable(
                name: "ReasonsForSigningUp",
                newName: "ReasonSignUp");

            migrationBuilder.RenameColumn(
                name: "ReasonId",
                table: "ReasonSignUp",
                newName: "ReasonSignUpId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Subscriber",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "HowTheyHeardAboutUs",
                table: "Subscriber",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(MAX)");

            migrationBuilder.AddColumn<string>(
                name: "ReasonSigningUp",
                table: "ReasonSignUp",
                type: "nvarchar(MAX)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Subscriber",
                table: "Subscriber",
                column: "SubscriberId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReasonSignUp",
                table: "ReasonSignUp",
                column: "ReasonSignUpId");

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
    }
}
