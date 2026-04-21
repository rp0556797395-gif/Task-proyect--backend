using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect.Data.Migrations
{
    /// <inheritdoc />
    public partial class Tasks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listtask_listclient_ClientsId",
                table: "listtask");

            migrationBuilder.DropIndex(
                name: "IX_listtask_ClientsId",
                table: "listtask");

            migrationBuilder.DropColumn(
                name: "ClientsId",
                table: "listtask");

            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "listtask",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_listtask_ClientId",
                table: "listtask",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_listtask_listclient_ClientId",
                table: "listtask",
                column: "ClientId",
                principalTable: "listclient",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_listtask_listclient_ClientId",
                table: "listtask");

            migrationBuilder.DropIndex(
                name: "IX_listtask_ClientId",
                table: "listtask");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "listtask");

            migrationBuilder.AddColumn<int>(
                name: "ClientsId",
                table: "listtask",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_listtask_ClientsId",
                table: "listtask",
                column: "ClientsId");

            migrationBuilder.AddForeignKey(
                name: "FK_listtask_listclient_ClientsId",
                table: "listtask",
                column: "ClientsId",
                principalTable: "listclient",
                principalColumn: "Id");
        }
    }
}
