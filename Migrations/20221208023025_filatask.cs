using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrionTM_Web.Migrations
{
    public partial class filatask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_detalheListaEnvio_ListaEnvio_ListaEnvioId",
                table: "detalheListaEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_detalheListaEnvio_Terminal_TerminalId",
                table: "detalheListaEnvio");

            migrationBuilder.DropPrimaryKey(
                name: "PK_detalheListaEnvio",
                table: "detalheListaEnvio");

            migrationBuilder.RenameTable(
                name: "detalheListaEnvio",
                newName: "DetalheListaEnvio");

            migrationBuilder.RenameIndex(
                name: "IX_detalheListaEnvio_TerminalId",
                table: "DetalheListaEnvio",
                newName: "IX_DetalheListaEnvio_TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_detalheListaEnvio_ListaEnvioId",
                table: "DetalheListaEnvio",
                newName: "IX_DetalheListaEnvio_ListaEnvioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DetalheListaEnvio",
                table: "DetalheListaEnvio",
                column: "DetalheListaEnvioId");

            migrationBuilder.CreateTable(
                name: "FilaTasks",
                columns: table => new
                {
                    FilaTasksId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EquipmentId = table.Column<int>(type: "int", nullable: false),
                    DtAtualizaao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Task = table.Column<int>(type: "int", nullable: false),
                    TaskID = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilaTasks", x => x.FilaTasksId);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_DetalheListaEnvio_ListaEnvio_ListaEnvioId",
                table: "DetalheListaEnvio",
                column: "ListaEnvioId",
                principalTable: "ListaEnvio",
                principalColumn: "ListaEnvioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DetalheListaEnvio_Terminal_TerminalId",
                table: "DetalheListaEnvio",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DetalheListaEnvio_ListaEnvio_ListaEnvioId",
                table: "DetalheListaEnvio");

            migrationBuilder.DropForeignKey(
                name: "FK_DetalheListaEnvio_Terminal_TerminalId",
                table: "DetalheListaEnvio");

            migrationBuilder.DropTable(
                name: "FilaTasks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DetalheListaEnvio",
                table: "DetalheListaEnvio");

            migrationBuilder.RenameTable(
                name: "DetalheListaEnvio",
                newName: "detalheListaEnvio");

            migrationBuilder.RenameIndex(
                name: "IX_DetalheListaEnvio_TerminalId",
                table: "detalheListaEnvio",
                newName: "IX_detalheListaEnvio_TerminalId");

            migrationBuilder.RenameIndex(
                name: "IX_DetalheListaEnvio_ListaEnvioId",
                table: "detalheListaEnvio",
                newName: "IX_detalheListaEnvio_ListaEnvioId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_detalheListaEnvio",
                table: "detalheListaEnvio",
                column: "DetalheListaEnvioId");

            migrationBuilder.AddForeignKey(
                name: "FK_detalheListaEnvio_ListaEnvio_ListaEnvioId",
                table: "detalheListaEnvio",
                column: "ListaEnvioId",
                principalTable: "ListaEnvio",
                principalColumn: "ListaEnvioId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_detalheListaEnvio_Terminal_TerminalId",
                table: "detalheListaEnvio",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
