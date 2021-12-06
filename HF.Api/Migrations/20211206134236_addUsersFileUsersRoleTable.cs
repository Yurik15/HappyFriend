using Microsoft.EntityFrameworkCore.Migrations;

namespace HF.Api.Migrations
{
    public partial class addUsersFileUsersRoleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsersId",
                table: "UsersFile",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsersRole_UsersId",
                table: "UsersRole",
                column: "UsersId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersFile_UsersId",
                table: "UsersFile",
                column: "UsersId");

            migrationBuilder.AddForeignKey(
                name: "FK_UsersFile_Users_UsersId",
                table: "UsersFile",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsersRole_Users_UsersId",
                table: "UsersRole",
                column: "UsersId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsersFile_Users_UsersId",
                table: "UsersFile");

            migrationBuilder.DropForeignKey(
                name: "FK_UsersRole_Users_UsersId",
                table: "UsersRole");

            migrationBuilder.DropIndex(
                name: "IX_UsersRole_UsersId",
                table: "UsersRole");

            migrationBuilder.DropIndex(
                name: "IX_UsersFile_UsersId",
                table: "UsersFile");

            migrationBuilder.DropColumn(
                name: "UsersId",
                table: "UsersFile");
        }
    }
}
