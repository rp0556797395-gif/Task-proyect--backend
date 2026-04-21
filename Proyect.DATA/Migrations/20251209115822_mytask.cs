using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Proyect.Data.Migrations
{
    /// <inheritdoc />
    public partial class mytask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "listclient",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    mail = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listclient", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "listtask",
                columns: table => new
                {
                    Code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Category = table.Column<int>(type: "int", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    ClientsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_listtask", x => x.Code);
                    table.ForeignKey(
                        name: "FK_listtask_listclient_ClientsId",
                        column: x => x.ClientsId,
                        principalTable: "listclient",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_listtask_ClientsId",
                table: "listtask",
                column: "ClientsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "listtask");

            migrationBuilder.DropTable(
                name: "listclient");
        }
    }
}
