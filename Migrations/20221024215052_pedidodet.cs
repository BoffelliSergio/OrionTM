using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrionTM_Web.Migrations
{
    public partial class pedidodet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TerminalId",
                table: "detalheListaEnvio",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_detalheListaEnvio_TerminalId",
                table: "detalheListaEnvio",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalheListaEnvio_Terminal_TerminalId",
                table: "detalheListaEnvio",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalheListaEnvio_Terminal_TerminalId",
                table: "detalheListaEnvio");

            migrationBuilder.DropIndex(
                name: "IX_detalheListaEnvio_TerminalId",
                table: "detalheListaEnvio");

            migrationBuilder.DropColumn(
                name: "TerminalId",
                table: "detalheListaEnvio");
        }
    }
}
