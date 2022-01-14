using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_my_bank_dotnet.Migrations
{
    public partial class conta_bancaria : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "conta_bancaria",
                columns: table => new
                {
                    conta_bancaria_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    num_agencia = table.Column<uint>(type: "int unsigned", nullable: false),
                    num_conta_corrente = table.Column<ulong>(type: "bigint unsigned", nullable: false),
                    created_at = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_conta_bancaria", x => x.conta_bancaria_id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_conta_bancaria_num_conta_corrente",
                table: "conta_bancaria",
                column: "num_conta_corrente",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "conta_bancaria");
        }
    }
}
