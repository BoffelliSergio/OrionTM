using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrionTM_Web.Migrations
{
    public partial class fila : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
            migrationBuilder.RenameColumn(
                name: "EquipmentId",
                table: "FilaTasks",
                newName: "TerminalId");

            migrationBuilder.RenameColumn(
                name: "DtAtualizaao",
                table: "FilaTasks",
                newName: "DtAtualizacao");

            migrationBuilder.CreateIndex(
                name: "IX_FilaTasks_TerminalId",
                table: "FilaTasks",
                column: "TerminalId");

            migrationBuilder.AddForeignKey(
                name: "FK_FilaTasks_Terminal_TerminalId",
                table: "FilaTasks",
                column: "TerminalId",
                principalTable: "Terminal",
                principalColumn: "TerminalId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FilaTasks_Terminal_TerminalId",
                table: "FilaTasks");

            migrationBuilder.DropIndex(
                name: "IX_FilaTasks_TerminalId",
                table: "FilaTasks");

            migrationBuilder.RenameColumn(
                name: "TerminalId",
                table: "FilaTasks",
                newName: "EquipmentId");

            migrationBuilder.RenameColumn(
                name: "DtAtualizacao",
                table: "FilaTasks",
                newName: "DtAtualizaao");
        }
         
    }
}
