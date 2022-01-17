using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_my_bank_dotnet.Migrations
{
  public partial class bank_account : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
        .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
        name: "bank_account",
        columns: table => new
        {
          bank_account_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

          branch_number = table.Column<uint>(type: "int unsigned", nullable: false),

          account_number = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          created_at = table.Column<DateTime>(type: "datetime", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_bank_account", x => x.bank_account_id);
        })
      .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateIndex(
        name: "IX_bank_account_account_number",
        table: "bank_account",
        column: "account_number",
        unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "bank_account");
    }
  }
}