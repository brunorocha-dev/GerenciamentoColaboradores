using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorColaboradores.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoDaEntradaSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraEntrada",
                table: "Gerenciador",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "HoraSaida",
                table: "Gerenciador",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "UltimaAtualizacao",
                table: "Gerenciador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraEntrada",
                table: "Gerenciador");

            migrationBuilder.DropColumn(
                name: "HoraSaida",
                table: "Gerenciador");

            migrationBuilder.DropColumn(
                name: "UltimaAtualizacao",
                table: "Gerenciador");

            migrationBuilder.CreateTable(
                name: "Pontos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColaboradorId = table.Column<int>(type: "int", nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "time", nullable: false),
                    HoraSaida = table.Column<TimeSpan>(type: "time", nullable: false),
                    dataUltimaAtualizacao = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pontos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pontos_Gerenciador_ColaboradorId",
                        column: x => x.ColaboradorId,
                        principalTable: "Gerenciador",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pontos_ColaboradorId",
                table: "Pontos",
                column: "ColaboradorId");
        }
    }
}
