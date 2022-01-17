using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace api_my_bank_dotnet.Migrations
{
  public partial class user : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.AlterDatabase()
        .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateTable(
        name: "user",
        columns: table => new
        {
          user_id = table.Column<ulong>(type: "bigint unsigned", nullable: false)
            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),

          address_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          bank_account_id = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          full_name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          surname = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          login = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          password = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          passport_number = table.Column<string>(type: "varchar(9)", maxLength: 9, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          age = table.Column<int>(type: "int", nullable: false),

          gender = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          civil_status = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
            .Annotation("MySql:CharSet", "utf8mb4"),

          monthly_income = table.Column<ulong>(type: "bigint unsigned", nullable: false),

          birth_date = table.Column<DateTime>(type: "date", nullable: false),

          created_at = table.Column<DateTime>(type: "datetime", nullable: false),

          updated_at = table.Column<DateTime>(type: "datetime", nullable: false)
        },
        constraints: table =>
        {
          table.PrimaryKey("PK_user", x => x.user_id);

          table.ForeignKey(
            name: "FK_user_bank_account_bank_account_id",
            column: x => x.bank_account_id,
            principalTable: "bank_account",
            principalColumn: "bank_account_id",
            onDelete: ReferentialAction.Cascade);

          table.ForeignKey(
            name: "FK_user_address_address_id",
            column: x => x.address_id,
            principalTable: "address",
            principalColumn: "address_id",
            onDelete: ReferentialAction.Cascade);
        })
      .Annotation("MySql:CharSet", "utf8mb4");

      migrationBuilder.CreateIndex(
        name: "IX_user_bank_account_id",
        table: "user",
        column: "bank_account_id",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_user_email",
        table: "user",
        column: "email",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_user_address_id",
        table: "user",
        column: "address_id",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_user_login",
        table: "user",
        column: "login",
        unique: true);

      migrationBuilder.CreateIndex(
        name: "IX_user_passport_number",
        table: "user",
        column: "passport_number",
        unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
        name: "user");
    }
  }
}