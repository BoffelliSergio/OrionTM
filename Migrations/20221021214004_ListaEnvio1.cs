using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrionTM_Web.Migrations
{
    public partial class ListaEnvio1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ListaEnvio",
                columns: table => new
                {
                    ListaEnvioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaEnvio", x => x.ListaEnvioId);
                });

            migrationBuilder.CreateTable(
                name: "detalheListaEnvio",
                columns: table => new
                {
                    DetalheListaEnvioId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ListaEnvioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalheListaEnvio", x => x.DetalheListaEnvioId);
                    table.ForeignKey(
                        name: "FK_detalheListaEnvio_ListaEnvio_ListaEnvioId",
                        column: x => x.ListaEnvioId,
                        principalTable: "ListaEnvio",
                        principalColumn: "ListaEnvioId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_detalheListaEnvio_ListaEnvioId",
                table: "detalheListaEnvio",
                column: "ListaEnvioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "detalheListaEnvio");

            migrationBuilder.DropTable(
                name: "ListaEnvio");
        }
    }
}
