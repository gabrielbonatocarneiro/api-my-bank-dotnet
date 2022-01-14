using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_my_bank_dotnet.Migrations
{
  public partial class usuario : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
        .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
        name: "usuario",
        columns: table => new
        {
          usuario_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

          endereco_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          conta_bancaria_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          nome_completo = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          apelido = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          login = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          senha = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          rg = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          cpf = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          idade = table.Column<int>(type: "int", nullable: false),

          sexo = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          estado_civil = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          renda_mensal = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          data_nascimento = table.Column<DateTime>(type: "date", nullable: false),

          created_at = table.Column<DateTime>(type: "datetime", nullable: false),

          updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_usuario", x => x.usuario_id);

          table.ForeignKey(
            name: "FK_usuario_conta_bancaria_conta_bancaria_id",
            column: x => x.conta_bancaria_id,
            principalTable: "conta_bancaria",
            principalColumn: "conta_bancaria_id",
            onDelete: ReferentialAction.Cascade);

          table.ForeignKey(
            name: "FK_usuario_endereco_endereco_id",
            column: x => x.endereco_id,
            principalTable: "endereco",
            principalColumn: "endereco_id",
            onDelete: ReferentialAction.Cascade);
        })
      .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateIndex(
        name: "IX_usuario_conta_bancaria_id",
        table: "usuario",
        column: "conta_bancaria_id",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_usuario_cpf",
        table: "usuario",
        column: "cpf",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_usuario_email",
        table: "usuario",
        column: "email",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_usuario_endereco_id",
        table: "usuario",
        column: "endereco_id",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_usuario_login",
        table: "usuario",
        column: "login",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_usuario_rg",
        table: "usuario",
        column: "rg",
        unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "usuario");
    }
  }
}