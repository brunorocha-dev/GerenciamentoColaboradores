using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciadorColaboradores.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoTipoDeDadoColunaEntradaSaida : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HoraEntrada",
                table: "Gerenciador");

            migrationBuilder.DropColumn(
                name: "HoraSaida",
                table: "Gerenciador");

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistroEntrada",
                table: "Gerenciador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RegistroSaida",
                table: "Gerenciador",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistroEntrada",
                table: "Gerenciador");

            migrationBuilder.DropColumn(
                name: "RegistroSaida",
                table: "Gerenciador");

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
        }
    }
}
