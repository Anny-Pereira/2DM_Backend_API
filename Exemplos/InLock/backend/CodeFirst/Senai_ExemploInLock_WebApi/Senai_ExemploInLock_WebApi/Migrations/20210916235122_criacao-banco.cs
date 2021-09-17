using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Senai_ExemploInLock_WebApi.Migrations
{
    public partial class criacaobanco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudios",
                columns: table => new
                {
                    idEstudio = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeEstudio = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudios", x => x.idEstudio);
                });

            migrationBuilder.CreateTable(
                name: "TiposUsuario",
                columns: table => new
                {
                    idTiposUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tituloTiposUsuario = table.Column<string>(type: "varchar(150)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposUsuario", x => x.idTiposUsuario);
                });

            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    idJogo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nomeJogo = table.Column<string>(type: "varchar(150)", nullable: false),
                    descricao = table.Column<string>(type: "TEXT", nullable: false),
                    dataLancamento = table.Column<DateTime>(type: "DATE", nullable: false),
                    valor = table.Column<decimal>(type: "DECIMAL (10,2)", nullable: false),
                    idEstudio = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.idJogo);
                    table.ForeignKey(
                        name: "FK_Jogos_Estudios_idEstudio",
                        column: x => x.idEstudio,
                        principalTable: "Estudios",
                        principalColumn: "idEstudio",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    idUsuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "varchar(150)", nullable: false),
                    senha = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: false),
                    idTiposUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.idUsuario);
                    table.ForeignKey(
                        name: "FK_Usuarios_TiposUsuario_idTiposUsuario",
                        column: x => x.idTiposUsuario,
                        principalTable: "TiposUsuario",
                        principalColumn: "idTiposUsuario",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Estudios",
                columns: new[] { "idEstudio", "nomeEstudio" },
                values: new object[,]
                {
                    { 1, "Blizzard" },
                    { 2, "RockStar Studios" },
                    { 3, "Square Enix" }
                });

            migrationBuilder.InsertData(
                table: "TiposUsuario",
                columns: new[] { "idTiposUsuario", "tituloTiposUsuario" },
                values: new object[,]
                {
                    { 1, "Administrador" },
                    { 4, "Cliente" }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "email", "idTiposUsuario", "senha" },
                values: new object[] { 1, "administrador@admin.com", 2, "admin" });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "idJogo", "dataLancamento", "descricao", "idEstudio", "nomeJogo", "valor" },
                values: new object[] { 1, new DateTime(2021, 5, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "É um jogo que contém banstante ação...", 1, "Diablo 3", 99.00m });

            migrationBuilder.InsertData(
                table: "Jogos",
                columns: new[] { "idJogo", "dataLancamento", "descricao", "idEstudio", "nomeJogo", "valor" },
                values: new object[] { 2, new DateTime(2018, 10, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "É um jogo eletrônico de ação e aventura...", 2, "Read Dead Redemption II", 120.00m });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "idUsuario", "email", "idTiposUsuario", "senha" },
                values: new object[] { 2, "cliente@cliente.com", 4, "cliente" });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_idEstudio",
                table: "Jogos",
                column: "idEstudio");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_idTiposUsuario",
                table: "Usuarios",
                column: "idTiposUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Estudios");

            migrationBuilder.DropTable(
                name: "TiposUsuario");
        }
    }
}
