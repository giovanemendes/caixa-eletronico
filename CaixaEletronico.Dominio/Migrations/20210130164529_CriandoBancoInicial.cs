using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaixaEletronico.Dominio.Migrations
{
    public partial class CriandoBancoInicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cartao",
                columns: table => new
                {
                    CartaoId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<int>(nullable: false),
                    Senha = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cartao", x => x.CartaoId);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ClienteId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: true),
                    Cpf = table.Column<string>(nullable: true),
                    DataNascimento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ClienteId);
                });

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    ContaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Numero = table.Column<string>(nullable: true),
                    Agencia = table.Column<string>(nullable: true),
                    Saldo = table.Column<decimal>(nullable: false),
                    Ativa = table.Column<bool>(nullable: false),
                    CartaoId = table.Column<int>(nullable: true),
                    ClienteId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.ContaId);
                    table.ForeignKey(
                        name: "FK_Conta_Cartao_CartaoId",
                        column: x => x.CartaoId,
                        principalTable: "Cartao",
                        principalColumn: "CartaoId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Conta_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "ClienteId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Conta_CartaoId",
                table: "Conta",
                column: "CartaoId");

            migrationBuilder.CreateIndex(
                name: "IX_Conta_ClienteId",
                table: "Conta",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropTable(
                name: "Cartao");

            migrationBuilder.DropTable(
                name: "Clientes");
        }
    }
}
