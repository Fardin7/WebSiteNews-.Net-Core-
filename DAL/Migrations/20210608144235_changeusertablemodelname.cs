using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class changeusertablemodelname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetUsers_ApplicationUserId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_ApplicationUserId",
                table: "Permissions");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Permissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AspNetUsersId",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_AspNetUsersId",
                table: "Permissions",
                column: "AspNetUsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetUsers_AspNetUsersId",
                table: "Permissions",
                column: "AspNetUsersId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Permissions_AspNetUsers_AspNetUsersId",
                table: "Permissions");

            migrationBuilder.DropIndex(
                name: "IX_Permissions_AspNetUsersId",
                table: "Permissions");

            migrationBuilder.DropColumn(
                name: "AspNetUsersId",
                table: "Permissions");

            migrationBuilder.AlterColumn<string>(
                name: "ApplicationUserId",
                table: "Permissions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_ApplicationUserId",
                table: "Permissions",
                column: "ApplicationUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Permissions_AspNetUsers_ApplicationUserId",
                table: "Permissions",
                column: "ApplicationUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
